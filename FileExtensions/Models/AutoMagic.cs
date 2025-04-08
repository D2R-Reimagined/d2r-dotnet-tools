namespace D2RReimaginedTools.Models;
public record AutoMagic
{
    public string? Name { get; set; }
    public int Version { get; set; }
    public bool Spawnable { get; set; }
    public bool Rare { get; set; }
    public int Level { get; set; }
    public int? MaxLevel { get; set; }
    public int? LevelReq { get; set; }
    public string? ClassSpecific { get; set; }
    public string? Class { get; set; }
    public int? ClassLevelReq { get; set; }
    public int Frequency { get; set; }
    public int Group { get; set; }

    public string? Mod1Code { get; set; }
    public int? Mod1Param { get; set; }
    public int? Mod1Min { get; set; }
    public int? Mod1Max { get; set; }

    public string? Mod2Code { get; set; }
    public int? Mod2Param { get; set; }
    public int? Mod2Min { get; set; }
    public int? Mod2Max { get; set; }

    public string? Mod3Code { get; set; }
    public int? Mod3Param { get; set; }
    public int? Mod3Min { get; set; }
    public int? Mod3Max { get; set; }

    public string? TransformColor { get; set; }

    public string? IType1 { get; set; }
    public string? IType2 { get; set; }
    public string? IType3 { get; set; }
    public string? IType4 { get; set; }
    public string? IType5 { get; set; }
    public string? IType6 { get; set; }
    public string? IType7 { get; set; }

    public string? EType1 { get; set; }
    public string? EType2 { get; set; }
    public string? EType3 { get; set; }
    public string? EType4 { get; set; }
    public string? EType5 { get; set; }

    public int? Multiply { get; set; }
    public int? Add { get; set; }
}
