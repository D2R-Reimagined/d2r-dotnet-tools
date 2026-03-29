using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;

namespace D2RReimaginedTools.TextFileParsers;

internal static class TextFileParserFileUtility
{
    private static readonly ConcurrentDictionary<Type, ParserFileContext> ParserContexts = new();

    public static string[] ReadAllLines(Type parserType, string path)
    {
        var lines = File.ReadAllLines(path);
        Register(parserType, path, lines);
        return lines;
    }

    public static async Task<string[]> ReadAllLinesAsync(Type parserType, string path, CancellationToken cancellationToken = default)
    {
        var lines = await File.ReadAllLinesAsync(path, cancellationToken);
        Register(parserType, path, lines);
        return lines;
    }

    public static async Task<FileInfo> SaveEntriesAsync<TEntry>(Type parserType, IList<TEntry> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        if (!string.IsNullOrWhiteSpace(sourcePath))
        {
            await ReadAllLinesAsync(parserType, sourcePath, cancellationToken);
        }

        if (!ParserContexts.TryGetValue(parserType, out var context) || context.Header.Length == 0)
        {
            throw new InvalidOperationException($"No TSV header is available for {parserType.Name}. Load entries first or provide a sourcePath when saving.");
        }

        var targetDirectory = string.IsNullOrWhiteSpace(outputDirectory) ? Path.GetTempPath() : outputDirectory;
        Directory.CreateDirectory(targetDirectory);

        var fileName = context.FileName ?? GetDefaultFileName(parserType);
        var outputPath = Path.Combine(targetDirectory, fileName);
        var properties = GetSerializableProperties(typeof(TEntry), context.Header.Length);

        if (properties.Length < context.Header.Length)
        {
            throw new InvalidOperationException($"{typeof(TEntry).Name} exposes {properties.Length} serializable properties, but {fileName} requires {context.Header.Length} columns.");
        }

        var lines = new string[entries.Count + 1];
        lines[0] = string.Join('\t', context.Header);

        for (var index = 0; index < entries.Count; index++)
        {
            var values = properties
                .Take(context.Header.Length)
                .Select(property => FormatValue(property.GetValue(entries[index])))
                .ToArray();

            lines[index + 1] = string.Join('\t', values);
        }

        await File.WriteAllLinesAsync(outputPath, lines, cancellationToken);
        return new FileInfo(outputPath);
    }

    private static void Register(Type parserType, string path, string[] lines)
    {
        var header = lines.Length == 0 ? [] : lines[0].Split('\t');
        ParserContexts[parserType] = new ParserFileContext(Path.GetFileName(path), header);
    }

    private static PropertyInfo[] GetSerializableProperties(Type type, int columnCount)
    {
        return GetPropertiesInDeclarationOrder(type)
            .Where(property => property.CanRead)
            .Where(property => property.GetIndexParameters().Length == 0)
            .Where(property => IsSupported(property.PropertyType))
            .Take(columnCount)
            .ToArray();
    }

    private static IEnumerable<PropertyInfo> GetPropertiesInDeclarationOrder(Type? type)
    {
        if (type is null || type == typeof(object))
        {
            yield break;
        }

        foreach (var property in GetPropertiesInDeclarationOrder(type.BaseType))
        {
            yield return property;
        }

        foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
        {
            yield return property;
        }
    }

    private static bool IsSupported(Type type)
    {
        var underlyingType = Nullable.GetUnderlyingType(type) ?? type;

        return underlyingType == typeof(string)
               || underlyingType == typeof(bool)
               || underlyingType == typeof(byte)
               || underlyingType == typeof(sbyte)
               || underlyingType == typeof(short)
               || underlyingType == typeof(ushort)
               || underlyingType == typeof(int)
               || underlyingType == typeof(uint)
               || underlyingType == typeof(long)
               || underlyingType == typeof(ulong)
               || underlyingType == typeof(float)
               || underlyingType == typeof(double)
               || underlyingType == typeof(decimal);
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

    private static string GetDefaultFileName(Type parserType)
    {
        const string suffix = "Parser";
        var parserName = parserType.Name;
        var baseName = parserName.EndsWith(suffix, StringComparison.Ordinal)
            ? parserName[..^suffix.Length]
            : parserName;

        return $"{baseName.ToLowerInvariant()}.txt";
    }

    private sealed record ParserFileContext(string? FileName, string[] Header);
}
