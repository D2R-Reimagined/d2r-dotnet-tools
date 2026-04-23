namespace D2RReimaginedTools.Models;

public record ActInfo
{
    public int? Act { get; init; }
    public string? Town { get; init; }
    public string? Start { get; init; }
    public int? MaxNpcItemLevel { get; init; }
    public string? ClassLevelRangeStart { get; init; }
    public string? ClassLevelRangeEnd { get; init; }
    public int? WanderingNpcStart { get; init; }
    public int? WanderingNpcRange { get; init; }
    public string? CommonActCof { get; init; }
    public string? Waypoint1 { get; init; }
    public string? Waypoint2 { get; init; }
    public string? Waypoint3 { get; init; }
    public string? Waypoint4 { get; init; }
    public string? Waypoint5 { get; init; }
    public string? Waypoint6 { get; init; }
    public string? Waypoint7 { get; init; }
    public string? Waypoint8 { get; init; }
    public string? Waypoint9 { get; init; }
    public int? WanderingMonsterPopulateChance { get; init; }
    public int? WanderingMonsterRegionTotal { get; init; }
    public int? WanderingPopulateRandomChance { get; init; }
}
