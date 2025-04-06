using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;


namespace D2RReimaginedTools.TextFileParsers;


public static class MagicSuffixParser
{
    public static async Task<IList<MagicSuffix>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new MagicSuffix
            {
                Name = columns[0],
                Description = columns[1],
                Version = columns[2].ToInt(),
                Spawnable = columns[3].ToBool(),
                Rare = columns[4].ToBool(),
                Level = columns[5].ToInt(),
                MaxLevel = columns[6].ToInt(),
                LevelReq = columns[7].ToInt(),
                ClassSpecific = columns[8].ToBool(),
                Class = columns[9],
                ClassLevelReq = columns[10].ToInt(),
                Frequency = columns[11].ToInt(),
                Group = columns[12].ToInt(),
                Mod1Code = columns[13],
                Mod1Param = columns[14],
                Mod1Min = columns[15].ToInt(),
                Mod1Max = columns[16].ToInt(),
                Mod2Code = columns[17],
                Mod2Param = columns[18],
                Mod2Min = columns[19].ToInt(),
                Mod2Max = columns[20].ToInt(),
                Mod3Code = columns[21],
                Mod3Param = columns[22],
                Mod3Min = columns[23].ToInt(),
                Mod3Max = columns[24].ToInt(),
                TransformColor = columns[25],
                IType1 = columns[26],
                IType2 = columns[27],
                IType3 = columns[28],
                IType4 = columns[29],
                IType5 = columns[30],
                IType6 = columns[31],
                IType7 = columns[32],
                EType1 = columns[33],
                EType2 = columns[34],
                EType3 = columns[35],
                EType4 = columns[36],
                EType5 = columns[37],
                Multiply = columns[38].ToInt(),
                Add = columns[39].ToInt()
            })
            .ToList();
    }
}
