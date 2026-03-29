using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class CubeMainParser
{
    public static async Task<IList<CubeMain>> GetEntries(string path)
    {
        var lines = await TextFileParserFileUtility.ReadAllLinesAsync(typeof(CubeMainParser), path);
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
                MinDiff = columns.GetValue(columnMap, "min diff").ToInt(),
                Version = columns.GetValue(columnMap, "version").ToInt(),
                Operation = columns.GetValue(columnMap, "op"),
                Param = columns.GetValue(columnMap, "param"),
                Value = columns.GetValue(columnMap, "value"),
                Class = columns.GetValue(columnMap, "class"),
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
                LevelB = columns.GetValue(columnMap, "b lvl").ToInt(),
                PlvlB = columns.GetValue(columnMap, "b plvl").ToInt(),
                IlvlB = columns.GetValue(columnMap, "b ilvl").ToInt(),

                Mod1B = columns.GetValue(columnMap, "b mod 1"),
                Mod1ChanceB = columns.GetValue(columnMap, "b mod 1 chance").ToInt(),
                Mod1ParamB = columns.GetValue(columnMap, "b mod 1 param"),
                Mod1MinB = columns.GetValue(columnMap, "b mod 1 min").ToInt(),
                Mod1MaxB = columns.GetValue(columnMap, "b mod 1 max").ToInt(),

                Mod2B = columns.GetValue(columnMap, "b mod 2"),
                Mod2ChanceB = columns.GetValue(columnMap, "b mod 2 chance").ToInt(),
                Mod2ParamB = columns.GetValue(columnMap, "b mod 2 param"),
                Mod2MinB = columns.GetValue(columnMap, "b mod 2 min").ToInt(),
                Mod2MaxB = columns.GetValue(columnMap, "b mod 2 max").ToInt(),

                Mod3B = columns.GetValue(columnMap, "b mod 3"),
                Mod3ChanceB = columns.GetValue(columnMap, "b mod 3 chance").ToInt(),
                Mod3ParamB = columns.GetValue(columnMap, "b mod 3 param"),
                Mod3MinB = columns.GetValue(columnMap, "b mod 3 min").ToInt(),
                Mod3MaxB = columns.GetValue(columnMap, "b mod 3 max").ToInt(),

                Mod4B = columns.GetValue(columnMap, "b mod 4"),
                Mod4ChanceB = columns.GetValue(columnMap, "b mod 4 chance").ToInt(),
                Mod4ParamB = columns.GetValue(columnMap, "b mod 4 param"),
                Mod4MinB = columns.GetValue(columnMap, "b mod 4 min").ToInt(),
                Mod4MaxB = columns.GetValue(columnMap, "b mod 4 max").ToInt(),

                Mod5B = columns.GetValue(columnMap, "b mod 5"),
                Mod5ChanceB = columns.GetValue(columnMap, "b mod 5 chance").ToInt(),
                Mod5ParamB = columns.GetValue(columnMap, "b mod 5 param"),
                Mod5MinB = columns.GetValue(columnMap, "b mod 5 min").ToInt(),
                Mod5MaxB = columns.GetValue(columnMap, "b mod 5 max").ToInt(),

                OutputC = columns.GetValue(columnMap, "output c"),
                LevelC = columns.GetValue(columnMap, "c lvl").ToInt(),
                PlvlC = columns.GetValue(columnMap, "c plvl").ToInt(),
                IlvlC = columns.GetValue(columnMap, "c ilvl").ToInt(),

                Mod1C = columns.GetValue(columnMap, "c mod 1"),
                Mod1ChanceC = columns.GetValue(columnMap, "c mod 1 chance").ToInt(),
                Mod1ParamC = columns.GetValue(columnMap, "c mod 1 param"),
                Mod1MinC = columns.GetValue(columnMap, "c mod 1 min").ToInt(),
                Mod1MaxC = columns.GetValue(columnMap, "c mod 1 max").ToInt(),

                Mod2C = columns.GetValue(columnMap, "c mod 2"),
                Mod2ChanceC = columns.GetValue(columnMap, "c mod 2 chance").ToInt(),
                Mod2ParamC = columns.GetValue(columnMap, "c mod 2 param"),
                Mod2MinC = columns.GetValue(columnMap, "c mod 2 min").ToInt(),
                Mod2MaxC = columns.GetValue(columnMap, "c mod 2 max").ToInt(),

                Mod3C = columns.GetValue(columnMap, "c mod 3"),
                Mod3ChanceC = columns.GetValue(columnMap, "c mod 3 chance").ToInt(),
                Mod3ParamC = columns.GetValue(columnMap, "c mod 3 param"),
                Mod3MinC = columns.GetValue(columnMap, "c mod 3 min").ToInt(),
                Mod3MaxC = columns.GetValue(columnMap, "c mod 3 max").ToInt(),

                Mod4C = columns.GetValue(columnMap, "c mod 4"),
                Mod4ChanceC = columns.GetValue(columnMap, "c mod 4 chance").ToInt(),
                Mod4ParamC = columns.GetValue(columnMap, "c mod 4 param"),
                Mod4MinC = columns.GetValue(columnMap, "c mod 4 min").ToInt(),
                Mod4MaxC = columns.GetValue(columnMap, "c mod 4 max").ToInt(),

                Mod5C = columns.GetValue(columnMap, "c mod 5"),
                Mod5ChanceC = columns.GetValue(columnMap, "c mod 5 chance").ToInt(),
                Mod5ParamC = columns.GetValue(columnMap, "c mod 5 param"),
                Mod5MinC = columns.GetValue(columnMap, "c mod 5 min").ToInt(),
                Mod5MaxC = columns.GetValue(columnMap, "c mod 5 max").ToInt(),
                Eol = columns.GetValue(columnMap, "*eol").ToInt()
            })
            .ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<CubeMain> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<CubeMain>(typeof(CubeMainParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

