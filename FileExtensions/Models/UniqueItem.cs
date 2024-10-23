namespace D2RReimaginedTools.Models;

public record UniqueItem
{
    public string? Index { get; init; }
    public int ID { get; init; }
    public int Version { get; init; }
    public bool Enabled { get; init; }
    public int FirstLadderSeason { get; init; }
    public int LastLadderSeason { get; init; }
    public int Rarity { get; init; }
    public bool NoLimit { get; init; }
    public int Level { get; init; }
    public int LevelRequirement { get; init; }
    public string? Code { get; init; }
    public string? ItemName { get; init; }
    public bool Carry1 { get; init; }
    public int CostMultiplier { get; init; }
    public int CostAdd { get; init; }
    public string? ChrTransform { get; init; }
    public string? InvTransform { get; init; }
    public string? FlippyFile { get; init; }
    public string? InvFile { get; init; }
    public string? DropSound { get; init; }
    public int DropSfxFrame { get; init; }
    public string? UseSound { get; init; }
    public int DiabloCloneWeight { get; init; }
    public IList<ItemProperty>? Properties { get; init; }
    public int Eol { get; init; }
}