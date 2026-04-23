namespace D2RReimaginedTools.Models;

public record ActInfo
{
    public int? Act { get; init; }
    public int? Town { get; init; }
    public int? Start { get; init; }
    public int? MaxNpcItemLevel { get; init; }
    public int? ClassLevelRangeStart { get; init; }
    public int? ClassLevelRangeEnd { get; init; }
    public int? WanderingNpcStart { get; init; }
    public int? WanderingNpcRange { get; init; }
    public string? CommonActCof { get; init; }
    public int? Waypoint1 { get; init; }
    public int? Waypoint2 { get; init; }
    public int? Waypoint3 { get; init; }
    public int? Waypoint4 { get; init; }
    public int? Waypoint5 { get; init; }
    public int? Waypoint6 { get; init; }
    public int? Waypoint7 { get; init; }
    public int? Waypoint8 { get; init; }
    public int? Waypoint9 { get; init; }
    public int? WanderingMonsterPopulateChance { get; init; }
    public int? WanderingMonsterRegionTotal { get; init; }
    public int? WanderingPopulateRandomChance { get; init; }
}
