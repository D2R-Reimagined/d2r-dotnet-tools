using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class AutoMagicParser
{
    public static async Task<IList<AutoMagic>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // skip header

        return lines
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Split('\t'))
            .Select(col => new AutoMagic
            {
                Name = col[0],
                Version = col[1].ToInt(),
                Spawnable = col[2].ToBool(),
                Rare = col[3].ToBool(),
                Level = col[4].ToInt(),
                MaxLevel = col[5].ToNullableInt(),
                LevelReq = col[6].ToNullableInt(),
                ClassSpecific = col[7],
                Class = col[8],
                ClassLevelReq = col[9].ToNullableInt(),
                Frequency = col[10].ToInt(),
                Group = col[11].ToInt(),

                Mod1Code = col[12],
                Mod1Param = col[13].ToNullableInt(),
                Mod1Min = col[14].ToNullableInt(),
                Mod1Max = col[15].ToNullableInt(),

                Mod2Code = col[16],
                Mod2Param = col[17].ToNullableInt(),
                Mod2Min = col[18].ToNullableInt(),
                Mod2Max = col[19].ToNullableInt(),

                Mod3Code = col[20],
                Mod3Param = col[21].ToNullableInt(),
                Mod3Min = col[22].ToNullableInt(),
                Mod3Max = col[23].ToNullableInt(),

                TransformColor = col[24],

                IType1 = col[25],
                IType2 = col[26],
                IType3 = col[27],
                IType4 = col[28],
                IType5 = col[29],
                IType6 = col[30],
                IType7 = col[31],

                EType1 = col[32],
                EType2 = col[33],
                EType3 = col[34],
                EType4 = col[35],
                EType5 = col[36],

                Multiply = col[37].ToNullableInt(),
                Add = col[38].ToNullableInt(),
            }).ToList();
    }
}
