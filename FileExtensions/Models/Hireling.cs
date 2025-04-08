namespace D2RReimaginedTools.Models;
public record Hirelings
{
    public string? Hireling { get; init; }
    public string? SubType { get; init; }
    public int? Version { get; init; }
    public int? Id { get; init; }
    public int? Class { get; init; }
    public int? Act { get; init; }
    public int? Difficulty { get; init; }
    public int? Level { get; init; }
    public int? Seller { get; init; }
    public string? NameFirst { get; init; }
    public string? NameLast { get; init; }
    public int? Gold { get; init; }
    public int? ExpPerLevel { get; init; }
    public int? HP { get; init; }
    public int? HPPerLevel { get; init; }
    public int? Defense { get; init; }
    public int? DefensePerLevel { get; init; }
    public int? Strength { get; init; }
    public int? StrengthPerLevel { get; init; }
    public int? Dexterity { get; init; }
    public int? DexterityPerLevel { get; init; }
    public int? AttackRating { get; init; }
    public int? AttackRatingPerLevel { get; init; }
    public int? DamageMinimum { get; init; }
    public int? DamageMaximum { get; init; }
    public int? DamagePerLevel { get; init; }
    public int? ResistFire { get; init; }
    public int? ResistFirePerLevel { get; init; }
    public int? ResistCold { get; init; }
    public int? ResistColdPerLevel { get; init; }
    public int? ResistLightning { get; init; }
    public int? ResistLightningPerLevel { get; init; }
    public int? ResistPoison { get; init; }
    public int? ResistPoisonPerLevel { get; init; }
    public string? HireDescription { get; init; }
    public int? DefaultChance { get; init; }

    // Skill blocks (up to 6)
    public string? Skill1 { get; init; }
    public int? Mode1 { get; init; }
    public int? Chance1 { get; init; }
    public int? ChancePerLevel1 { get; init; }
    public int? Level1 { get; init; }
    public int? LevelPerLevel1 { get; init; }

    public string? Skill2 { get; init; }
    public int? Mode2 { get; init; }
    public int? Chance2 { get; init; }
    public int? ChancePerLevel2 { get; init; }
    public int?  Level2 { get; init; }
    public int? LevelPerLevel2 { get; init; }

    public string? Skill3 { get; init; }
    public int? Mode3 { get; init; }
    public int? Chance3 { get; init; }
    public int? ChancePerLevel3 { get; init; }
    public int? Level3 { get; init; }
    public int? LevelPerLevel3 { get; init; }

    public string? Skill4 { get; init; }
    public int? Mode4 { get; init; }
    public int? Chance4 { get; init; }
    public int? ChancePerLevel4 { get; init; }
    public int? Level4 { get; init; }
    public int? LevelPerLevel4 { get; init; }

    public string? Skill5 { get; init; }
    public int? Mode5 { get; init; }
    public int? Chance5 { get; init; }
    public int? ChancePerLevel5 { get; init; }
    public int? Level5 { get; init; }
    public int? LevelPerLevel5 { get; init; }

    public string? Skill6 { get; init; }
    public int? Mode6 { get; init; }
    public int? Chance6 { get; init; }
    public int? ChancePerLevel6 { get; init; }
    public int? Level6 { get; init; }
    public int? LevelPerLevel6 { get; init; }

    public int? HiringMaxLevelDifference { get; init; }
    public int? ResurrectCostMultiplier { get; init; }
    public int? ResurrectCostDivisor { get; init; }
    public int? ResurrectCostMaximum { get; init; }
    public string? EquivalentCharacterClass { get; init; }
}
