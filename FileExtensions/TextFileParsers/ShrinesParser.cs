using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class ShrinesParser
{
    public static async Task<IList<Shrines>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Shrines
            {
                Name = columns[0],
                ShrineType = columns[1],
                Effect = columns[2],
                Code = columns[3].ToNullableInt(),
                Arg0 = columns[4].ToNullableInt(),
                Arg1 = columns[5].ToNullableInt(),
                DurationInFrames = columns[6].ToNullableInt(),
                ResetTimeInMinutes = columns[7].ToNullableInt(),
                Rarity = columns[8].ToNullableInt(),
                StringName = columns[9],
                StringPhrase = columns[10],
                EffectClass = columns[11].ToNullableInt(),
                LevelMin = columns[12].ToNullableInt()
            })
            .ToList();
    }
}
