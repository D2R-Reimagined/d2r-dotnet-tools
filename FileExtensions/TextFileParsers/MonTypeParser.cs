using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class MonTypeParser
{
    public static async Task<IList<MonType>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new MonType
            {
                Type = columns[0],
                Equiv1 = columns[1],
                Equiv2 = columns[2],
                Equiv3 = columns[3],
                StrPlur = columns[4],
                Element = columns[5],
                Eol = columns[6].ToNullableInt()
            })
            .ToList();
    }
}
