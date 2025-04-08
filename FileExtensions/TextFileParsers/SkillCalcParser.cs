using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class SkillCalcParser
{
    public static async Task<IList<SkillCalc>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new SkillCalc
            {
                Code = columns[0],
                Description = columns[1]
            })
            .ToList();
    }
}
