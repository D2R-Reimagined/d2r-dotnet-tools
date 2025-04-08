using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class CubeMainParser
{
    public static async Task<IList<CubeMain>> GetEntries(string path)
    {
        var lines = await File.ReadAllLinesAsync(path);
        if (lines.Length == 0) return new List<CubeMain>();

        var header = lines[0].Split('\t');
        var columnMap = header
            .Select((name, index) => new { name, index })
            .ToDictionary(x => x.name.Trim(), x => x.index, StringComparer.OrdinalIgnoreCase);

        return lines
            .Skip(1)
            .Select(line => line.Split('\t'))
            .Where(columns => columns.Length == header.Length) // optional: skip malformed lines
            .Select(columns => new CubeMain
            {
                Description = columns.GetValue(columnMap, "description"),
                Enabled = columns.GetValue(columnMap, "enabled").ToBool(),
                FirstLadderSeason = columns.GetValue(columnMap, "firstladderseason").ToInt(),
                LastLadderSeason = columns.GetValue(columnMap, "lastladderseason").ToInt(),
                MinDiff = columns.GetValue(columnMap, "mindiff").ToInt(),
                Version = columns.GetValue(columnMap, "version").ToInt(),
                Operation = columns.GetValue(columnMap, "operation"),
                Param = columns.GetValue(columnMap, "param"),
                Value = columns.GetValue(columnMap, "value"),
                NumInputs = columns.GetValue(columnMap, "numinputs").ToInt(),
                Input1 = columns.GetValue(columnMap, "input 1"),
                Input2 = columns.GetValue(columnMap, "input 2"),
                Input3 = columns.GetValue(columnMap, "input 3"),
                Input4 = columns.GetValue(columnMap, "input 4"),
                Input5 = columns.GetValue(columnMap, "input 5"),
                Input6 = columns.GetValue(columnMap, "input 6"),
                Input7 = columns.GetValue(columnMap, "input 7"),
                Output = columns.GetValue(columnMap, "output"),
                Level = columns.GetValue(columnMap, "lvl").ToInt(),
                Plvl = columns.GetValue(columnMap, "plvl").ToInt(),
                Ilvl = columns.GetValue(columnMap, "ilvl").ToInt(),

                Mod1 = columns.GetValue(columnMap, "mod 1"),
                Mod1Chance = columns.GetValue(columnMap, "mod 1 chance").ToInt(),
                Mod1Param = columns.GetValue(columnMap, "mod 1 param"),
                Mod1Min = columns.GetValue(columnMap, "mod 1 min").ToInt(),
                Mod1Max = columns.GetValue(columnMap, "mod 1 max").ToInt(),

                Mod2 = columns.GetValue(columnMap, "mod 2"),
                Mod2Chance = columns.GetValue(columnMap, "mod 2 chance").ToInt(),
                Mod2Param = columns.GetValue(columnMap, "mod 2 param"),
                Mod2Min = columns.GetValue(columnMap, "mod 2 min").ToInt(),
                Mod2Max = columns.GetValue(columnMap, "mod 2 max").ToInt(),

                Mod3 = columns.GetValue(columnMap, "mod 3"),
                Mod3Chance = columns.GetValue(columnMap, "mod 3 chance").ToInt(),
                Mod3Param = columns.GetValue(columnMap, "mod 3 param"),
                Mod3Min = columns.GetValue(columnMap, "mod 3 min").ToInt(),
                Mod3Max = columns.GetValue(columnMap, "mod 3 max").ToInt(),

                Mod4 = columns.GetValue(columnMap, "mod 4"),
                Mod4Chance = columns.GetValue(columnMap, "mod 4 chance").ToInt(),
                Mod4Param = columns.GetValue(columnMap, "mod 4 param"),
                Mod4Min = columns.GetValue(columnMap, "mod 4 min").ToInt(),
                Mod4Max = columns.GetValue(columnMap, "mod 4 max").ToInt(),

                Mod5 = columns.GetValue(columnMap, "mod 5"),
                Mod5Chance = columns.GetValue(columnMap, "mod 5 chance").ToInt(),
                Mod5Param = columns.GetValue(columnMap, "mod 5 param"),
                Mod5Min = columns.GetValue(columnMap, "mod 5 min").ToInt(),
                Mod5Max = columns.GetValue(columnMap, "mod 5 max").ToInt(),

                OutputB = columns.GetValue(columnMap, "output b"),
                LevelB = columns.GetValue(columnMap, "lvl b").ToInt(),
                PlvlB = columns.GetValue(columnMap, "plvl b").ToInt(),
                IlvlB = columns.GetValue(columnMap, "ilvl b").ToInt(),

                Mod1B = columns.GetValue(columnMap, "mod 1 b"),
                Mod1ChanceB = columns.GetValue(columnMap, "mod 1 chance b").ToInt(),
                Mod1ParamB = columns.GetValue(columnMap, "mod 1 param b"),
                Mod1MinB = columns.GetValue(columnMap, "mod 1 min b").ToInt(),
                Mod1MaxB = columns.GetValue(columnMap, "mod 1 max b").ToInt(),

                Mod2B = columns.GetValue(columnMap, "mod 2 b"),
                Mod2ChanceB = columns.GetValue(columnMap, "mod 2 chance b").ToInt(),
                Mod2ParamB = columns.GetValue(columnMap, "mod 2 param b"),
                Mod2MinB = columns.GetValue(columnMap, "mod 2 min b").ToInt(),
                Mod2MaxB = columns.GetValue(columnMap, "mod 2 max b").ToInt(),

                Mod3B = columns.GetValue(columnMap, "mod 3 b"),
                Mod3ChanceB = columns.GetValue(columnMap, "mod 3 chance b").ToInt(),
                Mod3ParamB = columns.GetValue(columnMap, "mod 3 param b"),
                Mod3MinB = columns.GetValue(columnMap, "mod 3 min b").ToInt(),
                Mod3MaxB = columns.GetValue(columnMap, "mod 3 max b").ToInt(),

                Mod4B = columns.GetValue(columnMap, "mod 4 b"),
                Mod4ChanceB = columns.GetValue(columnMap, "mod 4 chance b").ToInt(),
                Mod4ParamB = columns.GetValue(columnMap, "mod 4 param b"),
                Mod4MinB = columns.GetValue(columnMap, "mod 4 min b").ToInt(),
                Mod4MaxB = columns.GetValue(columnMap, "mod 4 max b").ToInt(),

                Mod5B = columns.GetValue(columnMap, "mod 5 b"),
                Mod5ChanceB = columns.GetValue(columnMap, "mod 5 chance b").ToInt(),
                Mod5ParamB = columns.GetValue(columnMap, "mod 5 param b"),
                Mod5MinB = columns.GetValue(columnMap, "mod 5 min b").ToInt(),
                Mod5MaxB = columns.GetValue(columnMap, "mod 5 max b").ToInt(),

                OutputC = columns.GetValue(columnMap, "output c"),
                LevelC = columns.GetValue(columnMap, "lvl c").ToInt(),
                PlvlC = columns.GetValue(columnMap, "plvl c").ToInt(),
                IlvlC = columns.GetValue(columnMap, "ilvl c").ToInt(),

                Mod1C = columns.GetValue(columnMap, "mod 1 c"),
                Mod1ChanceC = columns.GetValue(columnMap, "mod 1 chance c").ToInt(),
                Mod1ParamC = columns.GetValue(columnMap, "mod 1 param c"),
                Mod1MinC = columns.GetValue(columnMap, "mod 1 min c").ToInt(),
                Mod1MaxC = columns.GetValue(columnMap, "mod 1 max c").ToInt(),

                Mod2C = columns.GetValue(columnMap, "mod 2 c"),
                Mod2ChanceC = columns.GetValue(columnMap, "mod 2 chance c").ToInt(),
                Mod2ParamC = columns.GetValue(columnMap, "mod 2 param c"),
                Mod2MinC = columns.GetValue(columnMap, "mod 2 min c").ToInt(),
                Mod2MaxC = columns.GetValue(columnMap, "mod 2 max c").ToInt(),

                Mod3C = columns.GetValue(columnMap, "mod 3 c"),
                Mod3ChanceC = columns.GetValue(columnMap, "mod 3 chance c").ToInt(),
                Mod3ParamC = columns.GetValue(columnMap, "mod 3 param c"),
                Mod3MinC = columns.GetValue(columnMap, "mod 3 min c").ToInt(),
                Mod3MaxC = columns.GetValue(columnMap, "mod 3 max c").ToInt(),

                Mod4C = columns.GetValue(columnMap, "mod 4 c"),
                Mod4ChanceC = columns.GetValue(columnMap, "mod 4 chance c").ToInt(),
                Mod4ParamC = columns.GetValue(columnMap, "mod 4 param c"),
                Mod4MinC = columns.GetValue(columnMap, "mod 4 min c").ToInt(),
                Mod4MaxC = columns.GetValue(columnMap, "mod 4 max c").ToInt(),

                Mod5C = columns.GetValue(columnMap, "mod 5 c"),
                Mod5ChanceC = columns.GetValue(columnMap, "mod 5 chance c").ToInt(),
                Mod5ParamC = columns.GetValue(columnMap, "mod 5 param c"),
                Mod5MinC = columns.GetValue(columnMap, "mod 5 min c").ToInt(),
                Mod5MaxC = columns.GetValue(columnMap, "mod 5 max c").ToInt()
            })
            .ToList();
    }
}