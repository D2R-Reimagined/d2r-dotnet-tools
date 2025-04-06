namespace D2RReimaginedTools.Models;


public record MagicSuffix
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public int? Version { get; init; }
    public bool? Spawnable { get; init; }
    public bool? Rare { get; init; }
    public int? Level { get; init; }
    public int? MaxLevel { get; init; }
    public int? LevelReq { get; init; }
    public bool? ClassSpecific { get; init; }
    public string? Class { get; init; }
    public int? ClassLevelReq { get; init; }
    public int? Frequency { get; init; }
    public int? Group { get; init; }
    public string? Mod1Code { get; init; }
    public string? Mod1Param { get; init; }
    public int? Mod1Min { get; init; }
    public int? Mod1Max { get; init; }
    public string? Mod2Code { get; init; }
    public string? Mod2Param { get; init; }
    public int? Mod2Min { get; init; }
    public int? Mod2Max { get; init; }
    public string? Mod3Code { get; init; }
    public string? Mod3Param { get; init; }
    public int? Mod3Min { get; init; }
    public int? Mod3Max { get; init; }
    public string? TransformColor { get; init; }
    public string? IType1 { get; init; }
    public string? IType2 { get; init; }
    public string? IType3 { get; init; }
    public string? IType4 { get; init; }
    public string? IType5 { get; init; }
    public string? IType6 { get; init; }
    public string? IType7 { get; init; }
    public string? EType1 { get; init; }
    public string? EType2 { get; init; }
    public string? EType3 { get; init; }
    public string? EType4 { get; init; }
    public string? EType5 { get; init; }
    public int? Multiply { get; init; }
    public int? Add { get; init; }
}

