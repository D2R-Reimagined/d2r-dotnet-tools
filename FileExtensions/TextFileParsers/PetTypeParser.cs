using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class PetTypeParser
{
    public static async Task<IList<PetType>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new PetType
            {
                PetTypeId = columns[0],
                Group = columns[1],
                BaseMax = columns[2].ToNullableInt(),
                Warp = columns[3].ToNullableInt(),
                Range = columns[4].ToNullableInt(),
                PartySend = columns[5].ToNullableInt(),
                Unsummon = columns[6].ToNullableInt(),
                AutoMap = columns[7].ToNullableInt(),
                Name = columns[8],
                DrawHP = columns[9].ToNullableInt(),
                IconType = columns[10].ToNullableInt(),
                BaseIcon = columns[11],
                MClass1 = columns[12],
                MIcon1 = columns[13],
                MClass2 = columns[14],
                MIcon2 = columns[15],
                MClass3 = columns[16],
                MIcon3 = columns[17],
                MClass4 = columns[18],
                MIcon4 = columns[19],
            })
            .ToList();
    }
}
