namespace D2RReimaginedTools.Models;

/// <summary>Drop-calculation columns from the game's tab-separated tables.</summary>
public sealed class DropTreasureClass
{
    public string? TreasureClass { get; set; }
    public string? Group { get; set; }
    public string? ConditionCalc { get; set; }
    public string? QuestFlag { get; set; }
    public string? QuestFlagEx { get; set; }
    public string? Item1 { get; set; }
    public string? Item2 { get; set; }
    public string? Item3 { get; set; }
    public string? Item4 { get; set; }
    public string? Item5 { get; set; }
    public string? Item6 { get; set; }
    public string? Item7 { get; set; }
    public string? Item8 { get; set; }
    public string? Item9 { get; set; }
    public string? Item10 { get; set; }
    public int Level { get; set; }
    public int Picks { get; set; }
    public int Unique { get; set; }
    public int Set { get; set; }
    public int Rare { get; set; }
    public int Magic { get; set; }
    public int NoDrop { get; set; }
    public int Prob1 { get; set; }
    public int Prob2 { get; set; }
    public int Prob3 { get; set; }
    public int Prob4 { get; set; }
    public int Prob5 { get; set; }
    public int Prob6 { get; set; }
    public int Prob7 { get; set; }
    public int Prob8 { get; set; }
    public int Prob9 { get; set; }
    public int Prob10 { get; set; }
}

/// <summary>Drop-calculation columns from the game's tab-separated tables.</summary>
public sealed class DropNamedItem
{
    public string? Index { get; set; }
    public string? Code { get; set; }
    public string? Item { get; set; }
    public string? DropConditionCalc { get; set; }
    public int Lvl { get; set; }
    public int Rarity { get; set; }
    public bool Disabled { get; set; }
    public bool Spawnable { get; set; }
}

/// <summary>Drop-calculation columns from the game's tab-separated tables.</summary>
public sealed class DropItemRatio
{
    public int Version { get; set; }
    public int Uber { get; set; }
    public int ClassSpecific { get; set; }
    public int Unique { get; set; }
    public int UniqueDivisor { get; set; }
    public int UniqueMin { get; set; }
    public int Set { get; set; }
    public int SetDivisor { get; set; }
    public int SetMin { get; set; }
}

/// <summary>Drop-calculation columns from the game's tab-separated tables.</summary>
public sealed class DropLevel
{
    public string? LevelName { get; set; }
    public string? Mon1 { get; set; }
    public string? Mon2 { get; set; }
    public string? Mon3 { get; set; }
    public string? Mon4 { get; set; }
    public string? Mon5 { get; set; }
    public string? Mon6 { get; set; }
    public string? Mon7 { get; set; }
    public string? Mon8 { get; set; }
    public string? Mon9 { get; set; }
    public string? Mon10 { get; set; }
    public string? Mon11 { get; set; }
    public string? Mon12 { get; set; }
    public string? Mon13 { get; set; }
    public string? Mon14 { get; set; }
    public string? Mon15 { get; set; }
    public string? Mon16 { get; set; }
    public string? Mon17 { get; set; }
    public string? Mon18 { get; set; }
    public string? Mon19 { get; set; }
    public string? Mon20 { get; set; }
    public string? Mon21 { get; set; }
    public string? Mon22 { get; set; }
    public string? Mon23 { get; set; }
    public string? Mon24 { get; set; }
    public string? Mon25 { get; set; }
    public string? Nmon1 { get; set; }
    public string? Nmon2 { get; set; }
    public string? Nmon3 { get; set; }
    public string? Nmon4 { get; set; }
    public string? Nmon5 { get; set; }
    public string? Nmon6 { get; set; }
    public string? Nmon7 { get; set; }
    public string? Nmon8 { get; set; }
    public string? Nmon9 { get; set; }
    public string? Nmon10 { get; set; }
    public string? Nmon11 { get; set; }
    public string? Nmon12 { get; set; }
    public string? Nmon13 { get; set; }
    public string? Nmon14 { get; set; }
    public string? Nmon15 { get; set; }
    public string? Nmon16 { get; set; }
    public string? Nmon17 { get; set; }
    public string? Nmon18 { get; set; }
    public string? Nmon19 { get; set; }
    public string? Nmon20 { get; set; }
    public string? Nmon21 { get; set; }
    public string? Nmon22 { get; set; }
    public string? Nmon23 { get; set; }
    public string? Nmon24 { get; set; }
    public string? Nmon25 { get; set; }
    public string? Umon1 { get; set; }
    public string? Umon2 { get; set; }
    public string? Umon3 { get; set; }
    public string? Umon4 { get; set; }
    public string? Umon5 { get; set; }
    public string? Umon6 { get; set; }
    public string? Umon7 { get; set; }
    public string? Umon8 { get; set; }
    public string? Umon9 { get; set; }
    public string? Umon10 { get; set; }
    public string? Umon11 { get; set; }
    public string? Umon12 { get; set; }
    public string? Umon13 { get; set; }
    public string? Umon14 { get; set; }
    public string? Umon15 { get; set; }
    public string? Umon16 { get; set; }
    public string? Umon17 { get; set; }
    public string? Umon18 { get; set; }
    public string? Umon19 { get; set; }
    public string? Umon20 { get; set; }
    public string? Umon21 { get; set; }
    public string? Umon22 { get; set; }
    public string? Umon23 { get; set; }
    public string? Umon24 { get; set; }
    public string? Umon25 { get; set; }
    public int Id { get; set; }
    public int MonLvlEx { get; set; }
    public int MonLvlExN { get; set; }
    public int MonLvlExH { get; set; }
}
