using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace D2RReimaginedTools.TextFileParsers;

public abstract class HeaderMappedTextFileParser<TEntry, TParser>
    where TEntry : class
    where TParser : HeaderMappedTextFileParser<TEntry, TParser>, new()
{
    private static readonly TParser Parser = new();
    private static readonly PropertyInfo[] Properties = typeof(TEntry)
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(property => property.CanRead && property.CanWrite)
        .Where(property => property.GetIndexParameters().Length == 0)
        .ToArray();

    private static ParserFileContext? Context;
    private static Dictionary<string, PropertyInfo>? _cachedPropertyMap;

    // Per-entry original row data, keyed by entry instance reference.
    // Lets SaveEntriesCore preserve the original line (whitespace, formatting, unmapped
    // columns, blank-vs-zero, etc.) when a cell has not actually been changed by the caller.
    private static readonly ConditionalWeakTable<object, OriginalRow> OriginalRows = new();

    private sealed record OriginalRow(string RawLine, string[] Columns);

    public static Task<IList<TEntry>> GetEntries(string path, CancellationToken cancellationToken = default)
    {
        return Parser.GetEntriesCore(path, cancellationToken);
    }

    /// <summary>
    /// Resolves a TSV column header (or property name) to the underlying <see cref="TEntry"/> property.
    /// Lookup honors the parser's <see cref="PropertyColumnAliases"/> so that raw game column headers
    /// (e.g. <c>dsc2calca1</c>) resolve to their mapped property (e.g. <c>Dsc2CalculationA1</c>).
    /// Returns <c>null</c> when the column is unknown.
    /// </summary>
    public static PropertyInfo? ResolveProperty(string? columnOrPropertyName)
    {
        if (string.IsNullOrWhiteSpace(columnOrPropertyName))
        {
            return null;
        }

        var map = Parser.GetOrBuildPropertyMap();
        return map.TryGetValue(NormalizeColumnName(columnOrPropertyName), out var property) ? property : null;
    }

    public static Task<FileInfo> SaveEntries(IList<TEntry> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return Parser.SaveEntriesCore(entries, sourcePath, outputDirectory, cancellationToken);
    }

    public static Task<FileInfo> SaveEntriesPreservingUnchanged(IList<TEntry> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return Parser.SaveEntriesCore(entries, sourcePath, outputDirectory, cancellationToken);
    }

    protected virtual int HeaderRowIndex => 0;

    protected virtual int DataStartRowIndex => HeaderRowIndex + 1;

    protected virtual bool IgnoreBlankLines => true;

    protected virtual IReadOnlyDictionary<string, string[]> PropertyColumnAliases => EmptyAliases;

    protected virtual TEntry FinalizeEntry(TEntry entry, string[] columns, IReadOnlyDictionary<string, int> columnMap)
    {
        return entry;
    }

    protected virtual string? GetValueForHeader(TEntry entry, string headerName)
    {
        var propertyMap = GetOrBuildPropertyMap();
        var normalizedHeader = NormalizeColumnName(headerName);

        if (!propertyMap.TryGetValue(normalizedHeader, out var property))
        {
            return null;
        }

        return FormatValue(property.GetValue(entry));
    }

    protected virtual IEnumerable<string> GetColumnCandidates(string propertyName)
    {
        yield return NormalizeColumnName(propertyName);

        if (PropertyColumnAliases.TryGetValue(propertyName, out var aliases))
        {
            foreach (var alias in aliases)
            {
                yield return NormalizeColumnName(alias);
            }
        }
    }

    private async Task<IList<TEntry>> GetEntriesCore(string path, CancellationToken cancellationToken)
    {
        // Read the file as raw text once so we can detect the original newline style
        // and remember the exact raw line for each entry. This is the cheapest way to
        // preserve byte-for-byte fidelity for rows the caller never modifies.
        var rawText = await File.ReadAllTextAsync(path, cancellationToken);
        var newline = DetectNewline(rawText);
        var hasTrailingNewline = rawText.Length > 0 && (rawText[^1] == '\n' || rawText[^1] == '\r');
        var lines = SplitLinesPreserving(rawText);

        Context = new ParserFileContext(Path.GetFileName(path), lines, newline, hasTrailingNewline);

        if (lines.Length <= HeaderRowIndex)
        {
            return new List<TEntry>();
        }

        var header = lines[HeaderRowIndex].Split('\t');
        var columnMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < header.Length; i++)
        {
            columnMap.TryAdd(NormalizeColumnName(header[i]), i);
        }

        var result = new List<TEntry>(Math.Max(0, lines.Length - DataStartRowIndex));
        for (int rowIndex = DataStartRowIndex; rowIndex < lines.Length; rowIndex++)
        {
            var rawLine = lines[rowIndex];
            if (IgnoreBlankLines && string.IsNullOrWhiteSpace(rawLine))
            {
                continue;
            }

            var columns = rawLine.Split('\t');
            var entry = FinalizeEntry(MapEntry(columns, columnMap), columns, columnMap);

            // Attach a snapshot of the original row so SaveEntriesCore can patch only
            // the cells the caller actually changed. ConditionalWeakTable keys by
            // reference and does not prevent the entry from being collected.
            OriginalRows.AddOrUpdate(entry, new OriginalRow(rawLine, columns));

            result.Add(entry);
        }

        return result;
    }

    private async Task<FileInfo> SaveEntriesCore(IList<TEntry> entries, string? sourcePath, string? outputDirectory, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(sourcePath))
        {
            var rawText = await File.ReadAllTextAsync(sourcePath, cancellationToken);
            var detectedNewline = DetectNewline(rawText);
            var trailing = rawText.Length > 0 && (rawText[^1] == '\n' || rawText[^1] == '\r');
            var sourceLines = SplitLinesPreserving(rawText);
            Context = new ParserFileContext(Path.GetFileName(sourcePath), sourceLines, detectedNewline, trailing);
        }

        if (Context is null || Context.Lines.Length <= HeaderRowIndex)
        {
            throw new InvalidOperationException($"No TSV header is available for {typeof(TParser).Name}. Load entries first or provide a sourcePath when saving.");
        }

        var targetDirectory = string.IsNullOrWhiteSpace(outputDirectory) ? Path.GetTempPath() : outputDirectory;
        Directory.CreateDirectory(targetDirectory);

        var outputPath = Path.Combine(targetDirectory, Context.FileName ?? GetDefaultFileName());
        var header = Context.Lines[HeaderRowIndex].Split('\t');

        // Pre-resolve header -> property once per save so we don't re-walk the alias map
        // for every cell of every row. Null entries mean "unmapped column" and are left untouched.
        var headerProperties = new PropertyInfo?[header.Length];
        var propertyMap = GetOrBuildPropertyMap();
        for (int i = 0; i < header.Length; i++)
        {
            propertyMap.TryGetValue(NormalizeColumnName(header[i]), out var prop);
            headerProperties[i] = prop;
        }

        var lines = new List<string>(Math.Max(Context.Lines.Length, entries.Count + DataStartRowIndex));
        lines.AddRange(Context.Lines.Take(DataStartRowIndex));

        foreach (var entry in entries)
        {
            if (OriginalRows.TryGetValue(entry, out var original))
            {
                lines.Add(BuildPreservedRow(entry, header, headerProperties, original));
            }
            else
            {
                // Entry was constructed by the caller (not produced by GetEntries).
                // Fall back to the original full-serialization behavior for it.
                var values = new string[header.Length];
                for (int i = 0; i < header.Length; i++)
                {
                    var prop = headerProperties[i];
                    values[i] = prop is null ? string.Empty : FormatValue(prop.GetValue(entry));
                }
                lines.Add(string.Join('\t', values));
            }
        }

        var newline = Context.Newline;
        var builder = new StringBuilder();
        for (int i = 0; i < lines.Count; i++)
        {
            builder.Append(lines[i]);
            if (i < lines.Count - 1 || Context.HasTrailingNewline)
            {
                builder.Append(newline);
            }
        }

        await File.WriteAllTextAsync(outputPath, builder.ToString(), cancellationToken);
        return new FileInfo(outputPath);
    }

    private string BuildPreservedRow(TEntry entry, string[] header, PropertyInfo?[] headerProperties, OriginalRow original)
    {
        // Fast path: re-use the original column array. Only allocate a copy if a cell
        // actually needs to change. This makes the no-change case essentially free.
        string[]? mutated = null;
        var originalColumns = original.Columns;

        for (int i = 0; i < header.Length; i++)
        {
            var property = headerProperties[i];
            if (property is null)
            {
                continue; // unmapped column -> always preserve original cell
            }

            var newValue = FormatValue(property.GetValue(entry));
            var originalCell = i < originalColumns.Length ? originalColumns[i] : string.Empty;

            if (CellsEquivalent(originalCell, newValue, property.PropertyType))
            {
                continue;
            }

            if (mutated is null)
            {
                mutated = new string[Math.Max(originalColumns.Length, header.Length)];
                for (int j = 0; j < mutated.Length; j++)
                {
                    mutated[j] = j < originalColumns.Length ? originalColumns[j] : string.Empty;
                }
            }

            mutated[i] = newValue;
        }

        return mutated is null ? original.RawLine : string.Join('\t', mutated);
    }

    private static bool CellsEquivalent(string originalCell, string newValue, Type propertyType)
    {
        if (string.Equals(originalCell, newValue, StringComparison.Ordinal))
        {
            return true;
        }

        var targetType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

        // Strings are compared ordinally above; any difference is a real change.
        if (targetType == typeof(string))
        {
            return false;
        }

        // For typed columns we treat blank cells and the type's default value as equivalent
        // so that a row whose property was deserialized from "" -> 0 is not rewritten as "0",
        // and a bool cell that was "" is not rewritten as "0".
        if (targetType == typeof(bool))
        {
            return (string.IsNullOrWhiteSpace(originalCell) && newValue == "0")
                || (string.IsNullOrWhiteSpace(newValue) && originalCell == "0");
        }

        if (targetType.IsPrimitive || targetType == typeof(decimal))
        {
            // Compare numerically when both sides parse, so "05" and "5", "+5" and "5",
            // "1.0" and "1" do not appear as changes for numeric properties.
            if (TryParseInvariant(originalCell, targetType, out var originalNumber)
                && TryParseInvariant(newValue, targetType, out var newNumber))
            {
                return Equals(originalNumber, newNumber);
            }

            // Empty original cell vs the type's default value (e.g. "" vs "0") -> not a change.
            if (string.IsNullOrWhiteSpace(originalCell)
                && TryParseInvariant(newValue, targetType, out var parsedNew)
                && Equals(parsedNew, Activator.CreateInstance(targetType)))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(newValue)
                && TryParseInvariant(originalCell, targetType, out var parsedOriginal)
                && Equals(parsedOriginal, Activator.CreateInstance(targetType)))
            {
                return true;
            }
        }

        return false;
    }

    private static bool TryParseInvariant(string value, Type targetType, out object? result)
    {
        result = null;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        bool success;
        if (targetType == typeof(byte)) { success = byte.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(sbyte)) { success = sbyte.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(short)) { success = short.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(ushort)) { success = ushort.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(int)) { success = int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(uint)) { success = uint.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(long)) { success = long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(ulong)) { success = ulong.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(float)) { success = float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(double)) { success = double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        if (targetType == typeof(decimal)) { success = decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var v); result = v; return success; }
        return false;
    }

    private static string DetectNewline(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            var c = text[i];
            if (c == '\r')
            {
                return i + 1 < text.Length && text[i + 1] == '\n' ? "\r\n" : "\r";
            }
            if (c == '\n')
            {
                return "\n";
            }
        }
        return Environment.NewLine;
    }

    private static string[] SplitLinesPreserving(string text)
    {
        if (text.Length == 0)
        {
            return Array.Empty<string>();
        }

        var result = new List<string>();
        var start = 0;
        for (int i = 0; i < text.Length; i++)
        {
            var c = text[i];
            if (c == '\r' || c == '\n')
            {
                result.Add(text.Substring(start, i - start));
                if (c == '\r' && i + 1 < text.Length && text[i + 1] == '\n')
                {
                    i++;
                }
                start = i + 1;
            }
        }

        if (start < text.Length)
        {
            result.Add(text.Substring(start));
        }

        return result.ToArray();
    }

    private TEntry MapEntry(string[] columns, IReadOnlyDictionary<string, int> columnMap)
    {
        var entry = (TEntry)Activator.CreateInstance(typeof(TEntry), nonPublic: true)!;
        var propertyMap = GetOrBuildPropertyMap();

        foreach (var pair in propertyMap)
        {
            if (!columnMap.TryGetValue(pair.Key, out var index) || index >= columns.Length)
            {
                continue;
            }

            pair.Value.SetValue(entry, ConvertValue(pair.Value.PropertyType, columns[index]));
        }

        return entry;
    }

    private Dictionary<string, PropertyInfo> GetOrBuildPropertyMap()
    {
        if (_cachedPropertyMap is not null)
        {
            return _cachedPropertyMap;
        }

        var propertyMap = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);

        foreach (var property in Properties)
        {
            foreach (var candidate in GetColumnCandidates(property.Name))
            {
                propertyMap.TryAdd(candidate, property);
            }
        }

        _cachedPropertyMap = propertyMap;
        return propertyMap;
    }

    private static object? ConvertValue(Type propertyType, string value)
    {
        if (propertyType == typeof(string))
        {
            return value;
        }

        var targetType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
        var isNullable = Nullable.GetUnderlyingType(propertyType) is not null;

        if (targetType == typeof(bool))
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return isNullable ? null : false;
            }

            return value == "1" || value.Equals("true", StringComparison.OrdinalIgnoreCase);
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            return isNullable ? null : Activator.CreateInstance(targetType);
        }

        return targetType switch
        {
            _ when targetType == typeof(byte) => byte.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(sbyte) => sbyte.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(short) => short.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(ushort) => ushort.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(int) => int.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(uint) => uint.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(long) => long.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(ulong) => ulong.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(float) => float.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(double) => double.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ when targetType == typeof(decimal) => decimal.TryParse(value, CultureInfo.InvariantCulture, out var result) ? (object)result : (isNullable ? null : default),
            _ => value
        };
    }

    private static string FormatValue(object? value)
    {
        return value switch
        {
            null => string.Empty,
            bool boolean => boolean ? "1" : "0",
            IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
            _ => value.ToString() ?? string.Empty
        };
    }

    protected static string NormalizeColumnName(string name)
    {
        return new string(name
            .Trim()
            .Where(char.IsLetterOrDigit)
            .Select(char.ToLowerInvariant)
            .ToArray());
    }

    private static string GetDefaultFileName()
    {
        const string suffix = "Parser";
        var parserName = typeof(TParser).Name;
        var baseName = parserName.EndsWith(suffix, StringComparison.Ordinal)
            ? parserName[..^suffix.Length]
            : parserName;

        return $"{baseName.ToLowerInvariant()}.txt";
    }

    private static readonly IReadOnlyDictionary<string, string[]> EmptyAliases = new Dictionary<string, string[]>();

    private sealed record ParserFileContext(string? FileName, string[] Lines, string Newline, bool HasTrailingNewline);
}
