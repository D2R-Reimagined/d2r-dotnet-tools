using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class CubeModifierTypeParser
{
    public static async Task<IList<CubeModifierType>> GetEntries(string path)
    {
        var lines = (await TextFileParserFileUtility.ReadAllLinesAsync(typeof(CubeModifierTypeParser), path)).Skip(1); // Skip header

        return lines
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Split('\t'))
            .Select(col => new CubeModifierType
            {
                CubeModifierTypeName = col[0],
                Code = col.Length > 1 && !string.IsNullOrWhiteSpace(col[1]) ? col[1] : null
            })
            .ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<CubeModifierType> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<CubeModifierType>(typeof(CubeModifierTypeParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

