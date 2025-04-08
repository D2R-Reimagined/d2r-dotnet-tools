namespace D2RReimaginedTools.Models;


public record TreasureClass
{
    public string? TreasureClassName { get; init; }
    public string? Group { get; init; }
    public int? Level { get; init; }
    public int? Picks { get; init; }
    public int? Unique { get; init; }
    public int? Set { get; init; }
    public int? Rare { get; init; }
    public int? Magic { get; init; }
    public int? NoDrop { get; init; }
    public string? Item1 { get; init; }
    public int? Prob1 { get; init; }
    public string? Item2 { get; init; }
    public int? Prob2 { get; init; }
    public string? Item3 { get; init; }
    public int? Prob3 { get; init; }
    public string? Item4 { get; init; }
    public int? Prob4 { get; init; }
    public string? Item5 { get; init; }
    public int? Prob5 { get; init; }
    public string? Item6 { get; init; }
    public int? Prob6 { get; init; }
    public string? Item7 { get; init; }
    public int? Prob7 { get; init; }
    public string? Item8 { get; init; }
    public int? Prob8 { get; init; }
    public string? Item9 { get; init; }
    public int? Prob9 { get; init; }
    public string? Item10 { get; init; }
    public int? Prob10 { get; init; }
    public int? ItemProbSum { get; init; }
    public int? ItemProbTotal { get; init; }
    public string? TreasureClassDropChance { get; init; }
    public int? FirstLadderSeason { get; init; }
    public int? LastLadderSeason { get; init; }
    public bool? NoAlwaysSpawn { get; init; }
}

