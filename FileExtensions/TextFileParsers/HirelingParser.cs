using System.Collections.Generic;
using System.Linq;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class HirelingParser : HeaderMappedTextFileParser<Hirelings, HirelingParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(Hirelings.ExpPerLevel)] = ["Exp/Lvl"],
        [nameof(Hirelings.HPPerLevel)] = ["HP/Lvl"],
        [nameof(Hirelings.DefensePerLevel)] = ["Def/Lvl"],
        [nameof(Hirelings.Strength)] = ["Str"],
        [nameof(Hirelings.StrengthPerLevel)] = ["Str/Lvl"],
        [nameof(Hirelings.Dexterity)] = ["Dex"],
        [nameof(Hirelings.DexterityPerLevel)] = ["Dex/Lvl"],
        [nameof(Hirelings.AttackRating)] = ["AR"],
        [nameof(Hirelings.AttackRatingPerLevel)] = ["AR/Lvl"],
        [nameof(Hirelings.DamageMinimum)] = ["Dmg-Min"],
        [nameof(Hirelings.DamageMaximum)] = ["Dmg-Max"],
        [nameof(Hirelings.DamagePerLevel)] = ["Dmg/Lvl"],
        [nameof(Hirelings.ResistFirePerLevel)] = ["ResistFire/Lvl"],
        [nameof(Hirelings.ResistColdPerLevel)] = ["ResistCold/Lvl"],
        [nameof(Hirelings.ResistLightningPerLevel)] = ["ResistLightning/Lvl"],
        [nameof(Hirelings.ResistPoisonPerLevel)] = ["ResistPoison/Lvl"],
        [nameof(Hirelings.HireDescription)] = ["HireDesc"],
        [nameof(Hirelings.ChancePerLevel1)] = ["ChancePerLvl1"],
        [nameof(Hirelings.LevelPerLevel1)] = ["LvlPerLvl1"],
        [nameof(Hirelings.ChancePerLevel2)] = ["ChancePerLvl2"],
        [nameof(Hirelings.LevelPerLevel2)] = ["LvlPerLvl2"],
        [nameof(Hirelings.ChancePerLevel3)] = ["ChancePerLvl3"],
        [nameof(Hirelings.LevelPerLevel3)] = ["LvlPerLvl3"],
        [nameof(Hirelings.ChancePerLevel4)] = ["ChancePerLvl4"],
        [nameof(Hirelings.LevelPerLevel4)] = ["LvlPerLvl4"],
        [nameof(Hirelings.ChancePerLevel5)] = ["ChancePerLvl5"],
        [nameof(Hirelings.LevelPerLevel5)] = ["LvlPerLvl5"],
        [nameof(Hirelings.ChancePerLevel6)] = ["ChancePerLvl6"],
        [nameof(Hirelings.LevelPerLevel6)] = ["LvlPerLvl6"],
        [nameof(Hirelings.ResurrectCostMaximum)] = ["resurrectcostmax"],
        [nameof(Hirelings.EquivalentCharacterClass)] = ["equivalentcharclass"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;

    public static List<Hirelings> Parse(string filePath)
    {
        return GetEntries(filePath).GetAwaiter().GetResult().ToList();
    }
}
