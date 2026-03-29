using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class SkillCalcParser
{
    public static async Task<IList<SkillCalc>> GetEntries(string path)
    {
        var lines = (await TextFileParserFileUtility.ReadAllLinesAsync(typeof(SkillCalcParser), path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new SkillCalc
            {
                Code = columns[0],
                Description = columns[1]
            })
            .ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<SkillCalc> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<SkillCalc>(typeof(SkillCalcParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

