using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class ExperienceParser
{
    public static async Task<IList<Experience>> GetEntries(string path)
    {
        var lines = (await TextFileParserFileUtility.ReadAllLinesAsync(typeof(ExperienceParser), path)).Skip(2); // skip header + MaxLvl row

        return lines
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Split('\t'))
            .Select(col => new Experience
            {
                Level = int.Parse(col[0]),
                Amazon = uint.Parse(col[1]),
                Sorceress = uint.Parse(col[2]),
                Necromancer = uint.Parse(col[3]),
                Paladin = uint.Parse(col[4]),
                Barbarian = uint.Parse(col[5]),
                Druid = uint.Parse(col[6]),
                Assassin = uint.Parse(col[7]),
                Warlock = uint.Parse(col[8]),
                ExpRatio = int.Parse(col[9])
            })
            .ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<Experience> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<Experience>(typeof(ExperienceParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

