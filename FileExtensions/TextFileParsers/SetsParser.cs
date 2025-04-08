using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class SetsParser
{
    public static async Task<IList<Sets>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Sets
            {
                Index = columns[0],
                Name = columns[1],
                Version = columns[2].ToNullableInt(),

                PCode2a = columns[3],
                PParam2a = columns[4],
                PMin2a = columns[5].ToNullableInt(),
                PMax2a = columns[6].ToNullableInt(),

                PCode2b = columns[7],
                PParam2b = columns[8],
                PMin2b = columns[9].ToNullableInt(),
                PMax2b = columns[10].ToNullableInt(),

                PCode3a = columns[11],
                PParam3a = columns[12],
                PMin3a = columns[13].ToNullableInt(),
                PMax3a = columns[14].ToNullableInt(),

                PCode3b = columns[15],
                PParam3b = columns[16],
                PMin3b = columns[17].ToNullableInt(),
                PMax3b = columns[18].ToNullableInt(),

                PCode4a = columns[19],
                PParam4a = columns[20],
                PMin4a = columns[21].ToNullableInt(),
                PMax4a = columns[22].ToNullableInt(),

                PCode4b = columns[23],
                PParam4b = columns[24],
                PMin4b = columns[25].ToNullableInt(),
                PMax4b = columns[26].ToNullableInt(),

                PCode5a = columns[27],
                PParam5a = columns[28],
                PMin5a = columns[29].ToNullableInt(),
                PMax5a = columns[30].ToNullableInt(),

                PCode5b = columns[31],
                PParam5b = columns[32],
                PMin5b = columns[33].ToNullableInt(),
                PMax5b = columns[34].ToNullableInt(),

                FCode1 = columns[35],
                FParam1 = columns[36],
                FMin1 = columns[37].ToNullableInt(),
                FMax1 = columns[38].ToNullableInt(),

                FCode2 = columns[39],
                FParam2 = columns[40],
                FMin2 = columns[41].ToNullableInt(),
                FMax2 = columns[42].ToNullableInt(),

                FCode3 = columns[43],
                FParam3 = columns[44],
                FMin3 = columns[45].ToNullableInt(),
                FMax3 = columns[46].ToNullableInt(),

                FCode4 = columns[47],
                FParam4 = columns[48],
                FMin4 = columns[49].ToNullableInt(),
                FMax4 = columns[50].ToNullableInt(),

                FCode5 = columns[51],
                FParam5 = columns[52],
                FMin5 = columns[53].ToNullableInt(),
                FMax5 = columns[54].ToNullableInt(),

                FCode6 = columns[55],
                FParam6 = columns[56],
                FMin6 = columns[57].ToNullableInt(),
                FMax6 = columns[58].ToNullableInt(),

                FCode7 = columns[59],
                FParam7 = columns[60],
                FMin7 = columns[61].ToNullableInt(),
                FMax7 = columns[62].ToNullableInt(),

                FCode8 = columns[63],
                FParam8 = columns[64],
                FMin8 = columns[65].ToNullableInt(),
                FMax8 = columns[66].ToNullableInt(),
            })
            .ToList();
    }
}
