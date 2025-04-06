namespace D2RReimaginedTools.Models;

public record LvlMaze
{
    public string? Name { get; init; }
    public int? Level { get; init; }
    public int? Rooms { get; init; }
    public int? RoomsN { get; init; }
    public int?  RoomsH { get; init; }
    public int? SizeX { get; init; }
    public int? SizeY { get; init; }
    public int? Merge { get; init; }
}
