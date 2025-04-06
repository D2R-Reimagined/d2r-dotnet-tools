using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;


public static class MonPresetParser
{
    public static async Task<IList<MonPreset>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
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
}