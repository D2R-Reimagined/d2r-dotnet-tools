using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class CubeMainParser : HeaderMappedTextFileParser<CubeMain, CubeMainParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(CubeMain.Operation)] = ["op"],
        [nameof(CubeMain.Level)] = ["lvl"],
        [nameof(CubeMain.LevelB)] = ["b lvl"],
        [nameof(CubeMain.PlvlB)] = ["b plvl"],
        [nameof(CubeMain.IlvlB)] = ["b ilvl"],
        [nameof(CubeMain.Mod1B)] = ["b mod 1"],
        [nameof(CubeMain.Mod1ChanceB)] = ["b mod 1 chance"],
        [nameof(CubeMain.Mod1ParamB)] = ["b mod 1 param"],
        [nameof(CubeMain.Mod1MinB)] = ["b mod 1 min"],
        [nameof(CubeMain.Mod1MaxB)] = ["b mod 1 max"],
        [nameof(CubeMain.Mod2B)] = ["b mod 2"],
        [nameof(CubeMain.Mod2ChanceB)] = ["b mod 2 chance"],
        [nameof(CubeMain.Mod2ParamB)] = ["b mod 2 param"],
        [nameof(CubeMain.Mod2MinB)] = ["b mod 2 min"],
        [nameof(CubeMain.Mod2MaxB)] = ["b mod 2 max"],
        [nameof(CubeMain.Mod3B)] = ["b mod 3"],
        [nameof(CubeMain.Mod3ChanceB)] = ["b mod 3 chance"],
        [nameof(CubeMain.Mod3ParamB)] = ["b mod 3 param"],
        [nameof(CubeMain.Mod3MinB)] = ["b mod 3 min"],
        [nameof(CubeMain.Mod3MaxB)] = ["b mod 3 max"],
        [nameof(CubeMain.Mod4B)] = ["b mod 4"],
        [nameof(CubeMain.Mod4ChanceB)] = ["b mod 4 chance"],
        [nameof(CubeMain.Mod4ParamB)] = ["b mod 4 param"],
        [nameof(CubeMain.Mod4MinB)] = ["b mod 4 min"],
        [nameof(CubeMain.Mod4MaxB)] = ["b mod 4 max"],
        [nameof(CubeMain.Mod5B)] = ["b mod 5"],
        [nameof(CubeMain.Mod5ChanceB)] = ["b mod 5 chance"],
        [nameof(CubeMain.Mod5ParamB)] = ["b mod 5 param"],
        [nameof(CubeMain.Mod5MinB)] = ["b mod 5 min"],
        [nameof(CubeMain.Mod5MaxB)] = ["b mod 5 max"],
        [nameof(CubeMain.LevelC)] = ["c lvl"],
        [nameof(CubeMain.PlvlC)] = ["c plvl"],
        [nameof(CubeMain.IlvlC)] = ["c ilvl"],
        [nameof(CubeMain.Mod1C)] = ["c mod 1"],
        [nameof(CubeMain.Mod1ChanceC)] = ["c mod 1 chance"],
        [nameof(CubeMain.Mod1ParamC)] = ["c mod 1 param"],
        [nameof(CubeMain.Mod1MinC)] = ["c mod 1 min"],
        [nameof(CubeMain.Mod1MaxC)] = ["c mod 1 max"],
        [nameof(CubeMain.Mod2C)] = ["c mod 2"],
        [nameof(CubeMain.Mod2ChanceC)] = ["c mod 2 chance"],
        [nameof(CubeMain.Mod2ParamC)] = ["c mod 2 param"],
        [nameof(CubeMain.Mod2MinC)] = ["c mod 2 min"],
        [nameof(CubeMain.Mod2MaxC)] = ["c mod 2 max"],
        [nameof(CubeMain.Mod3C)] = ["c mod 3"],
        [nameof(CubeMain.Mod3ChanceC)] = ["c mod 3 chance"],
        [nameof(CubeMain.Mod3ParamC)] = ["c mod 3 param"],
        [nameof(CubeMain.Mod3MinC)] = ["c mod 3 min"],
        [nameof(CubeMain.Mod3MaxC)] = ["c mod 3 max"],
        [nameof(CubeMain.Mod4C)] = ["c mod 4"],
        [nameof(CubeMain.Mod4ChanceC)] = ["c mod 4 chance"],
        [nameof(CubeMain.Mod4ParamC)] = ["c mod 4 param"],
        [nameof(CubeMain.Mod4MinC)] = ["c mod 4 min"],
        [nameof(CubeMain.Mod4MaxC)] = ["c mod 4 max"],
        [nameof(CubeMain.Mod5C)] = ["c mod 5"],
        [nameof(CubeMain.Mod5ChanceC)] = ["c mod 5 chance"],
        [nameof(CubeMain.Mod5ParamC)] = ["c mod 5 param"],
        [nameof(CubeMain.Mod5MinC)] = ["c mod 5 min"],
        [nameof(CubeMain.Mod5MaxC)] = ["c mod 5 max"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
