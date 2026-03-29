using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class GambleParser
{
    public static async Task<IList<Gamble>> GetEntries(string path)
    {
        var lines = (await TextFileParserFileUtility.ReadAllLinesAsync(typeof(GambleParser), path)).Skip(1); // Skip header row

        return lines
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Split('\t'))
            .Select(col => new Gamble
            {
                Name = col[0].Trim(),
                Code = col.Length > 1 && !string.IsNullOrWhiteSpace(col[1]) ? col[1].Trim() : null
            })
            .ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<Gamble> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<Gamble>(typeof(GambleParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

