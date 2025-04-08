using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class SuperUniquesParser
{
    public static async Task<IList<SuperUnique>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new SuperUnique
            {
                Superunique = columns[0],
                Name = columns[1],
                Class = columns[2],
                HcIdx = columns[3].ToNullableInt(),
                MonSound = columns[4],
                Mod1 = columns[5].ToNullableInt(),
                Mod2 = columns[6].ToNullableInt(),
                Mod3 = columns[7].ToNullableInt(),
                MinGrp = columns[8].ToNullableInt(),
                MaxGrp = columns[9].ToNullableInt(),
                AutoPos = columns[10].ToNullableInt(),
                Stacks = columns[11].ToNullableInt(),
                Replaceable = columns[12].ToNullableInt(),
                Utrans = columns[13].ToNullableInt(),
                UtransN = columns[14].ToNullableInt(),
                UtransH = columns[15].ToNullableInt(),
                TC = columns[16],
                TCDesecrated = columns[17],
                TCN = columns[18],
                TCN_Desecrated = columns[19],
                TCH = columns[20],
                TCH_Desecrated = columns[21]
            })
            .ToList();
    }
}
