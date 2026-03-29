using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;


public static class MonPresetParser
{
    public static async Task<IList<MonPreset>> GetEntries(string path)
    {
        var lines = (await TextFileParserFileUtility.ReadAllLinesAsync(typeof(MonPresetParser), path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Where(columns => columns.Length >= 3)
            .Select(columns => new MonPreset
            {
                Act = columns[0].ToInt(),
                Place = columns[1],
                Ds1Id = columns[2].ToInt()
            })
            .ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<MonPreset> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<MonPreset>(typeof(MonPresetParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

