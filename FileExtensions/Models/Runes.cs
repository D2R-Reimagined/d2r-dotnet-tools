namespace D2RReimaginedTools.Models;


public record RuneWord
{
    public string? Name { get; init; }
    public string? RuneName { get; init; }
    public int? Complete { get; init; }
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

    public List<RuneWordMod>? Mods { get; init; }
}

public record RuneWordMod
{
    public string? Code { get; init; }
    public string? Param { get; init; }
    public int? Min { get; init; }
    public int? Max { get; init; }
}
