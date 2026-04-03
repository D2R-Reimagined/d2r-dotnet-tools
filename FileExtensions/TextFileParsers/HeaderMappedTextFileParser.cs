using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

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

    public static Task<IList<TEntry>> GetEntries(string path, CancellationToken cancellationToken = default)
    {
        return Parser.GetEntriesCore(path, cancellationToken);
    }

    public static Task<FileInfo> SaveEntries(IList<TEntry> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
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
        var lines = await File.ReadAllLinesAsync(path, cancellationToken);
        Context = new ParserFileContext(Path.GetFileName(path), lines);

        if (lines.Length <= HeaderRowIndex)
        {
            return new List<TEntry>();
        }

        var header = lines[HeaderRowIndex].Split('\t');
        var columnMap = header
            .Select((name, index) => new { name, index })
            .ToDictionary(x => NormalizeColumnName(x.name), x => x.index, StringComparer.OrdinalIgnoreCase);

        return lines
            .Skip(DataStartRowIndex)
            .Where(line => !IgnoreBlankLines || !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Split('\t'))
            .Select(columns => FinalizeEntry(MapEntry(columns, columnMap), columns, columnMap))
            .ToList();
    }

    private async Task<FileInfo> SaveEntriesCore(IList<TEntry> entries, string? sourcePath, string? outputDirectory, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(sourcePath))
        {
            var sourceLines = await File.ReadAllLinesAsync(sourcePath, cancellationToken);
            Context = new ParserFileContext(Path.GetFileName(sourcePath), sourceLines);
        }

        if (Context is null || Context.Lines.Length <= HeaderRowIndex)
        {
            throw new InvalidOperationException($"No TSV header is available for {typeof(TParser).Name}. Load entries first or provide a sourcePath when saving.");
        }

        var targetDirectory = string.IsNullOrWhiteSpace(outputDirectory) ? Path.GetTempPath() : outputDirectory;
        Directory.CreateDirectory(targetDirectory);

        var outputPath = Path.Combine(targetDirectory, Context.FileName ?? GetDefaultFileName());
        var header = Context.Lines[HeaderRowIndex].Split('\t');

        var lines = new List<string>(Math.Max(Context.Lines.Length, entries.Count + DataStartRowIndex));
        lines.AddRange(Context.Lines.Take(DataStartRowIndex));

        foreach (var entry in entries)
        {
            var values = header
                .Select(column => GetValueForHeader(entry, column) ?? string.Empty)
                .ToArray();

            lines.Add(string.Join('\t', values));
        }

        await File.WriteAllLinesAsync(outputPath, lines, cancellationToken);
        return new FileInfo(outputPath);
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

        if (targetType == typeof(bool))
        {
            if (string.IsNullOrWhiteSpace(value) && Nullable.GetUnderlyingType(propertyType) is not null)
            {
                return null;
            }

            return value == "1" || value.Equals("true", StringComparison.OrdinalIgnoreCase);
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            return Nullable.GetUnderlyingType(propertyType) is not null
                ? null
                : Activator.CreateInstance(targetType);
        }

        return targetType switch
        {
            _ when targetType == typeof(byte) => byte.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(sbyte) => sbyte.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(short) => short.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(ushort) => ushort.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(int) => int.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(uint) => uint.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(long) => long.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(ulong) => ulong.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(float) => float.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(double) => double.Parse(value, CultureInfo.InvariantCulture),
            _ when targetType == typeof(decimal) => decimal.Parse(value, CultureInfo.InvariantCulture),
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

    private sealed record ParserFileContext(string? FileName, string[] Lines);
}
