namespace D2RReimaginedTools.Models;

public record LevelGroup
{
    public string? LevelGroupId { get; init; }
    public string? ParentLevelGroupId { get; init; }
    public int? CompleteThreshold { get; init; }
    public string? Effect { get; init; }
    public string? Name { get; init; }
    public string? NameString { get; init; }
}
