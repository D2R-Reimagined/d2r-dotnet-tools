namespace D2RReimaginedTools.Models;


public record RuneWord
{
    public string? Name { get; init; }
    public string? RuneName { get; init; }
    public int? Complete { get; init; }
    public int? DisallowCraftingInLadder { get; init; }
    public int? DisallowCraftingInNonLadder { get; init; }
    public int? FirstLadderSeason { get; init; }
    public int? LastLadderSeason { get; init; }
    public string? PatchRelease { get; init; }

    public string? ItemType1 { get; init; }
    public string? ItemType2 { get; init; }
    public string? ItemType3 { get; init; }
    public string? ItemType4 { get; init; }
    public string? ItemType5 { get; init; }
    public string? ItemType6 { get; init; }

    public string? ExcludeItemType1 { get; init; }
    public string? ExcludeItemType2 { get; init; }
    public string? ExcludeItemType3 { get; init; }

    public string? RunesUsed { get; init; }
    public string? Rune1 { get; init; }
    public string? Rune2 { get; init; }
    public string? Rune3 { get; init; }
    public string? Rune4 { get; init; }
    public string? Rune5 { get; init; }
    public string? Rune6 { get; init; }
    public string? T1Code1 { get; init; }
    public string? T1Param1 { get; init; }
    public int? T1Min1 { get; init; }
    public int? T1Max1 { get; init; }
    public string? T1Code2 { get; init; }
    public string? T1Param2 { get; init; }
    public int? T1Min2 { get; init; }
    public int? T1Max2 { get; init; }
    public string? T1Code3 { get; init; }
    public string? T1Param3 { get; init; }
    public int? T1Min3 { get; init; }
    public int? T1Max3 { get; init; }
    public string? T1Code4 { get; init; }
    public string? T1Param4 { get; init; }
    public int? T1Min4 { get; init; }
    public int? T1Max4 { get; init; }
    public string? T1Code5 { get; init; }
    public string? T1Param5 { get; init; }
    public int? T1Min5 { get; init; }
    public int? T1Max5 { get; init; }
    public string? T1Code6 { get; init; }
    public string? T1Param6 { get; init; }
    public int? T1Min6 { get; init; }
    public int? T1Max6 { get; init; }
    public string? T1Code7 { get; init; }
    public string? T1Param7 { get; init; }
    public int? T1Min7 { get; init; }
    public int? T1Max7 { get; init; }
    public int? Eol { get; init; }

    public List<RuneWordMod>? Mods { get; init; }
}

public record RuneWordMod
{
    public string? Code { get; init; }
    public string? Param { get; init; }
    public int? Min { get; init; }
    public int? Max { get; init; }
}
