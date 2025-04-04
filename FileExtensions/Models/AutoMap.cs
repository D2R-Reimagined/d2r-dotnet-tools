namespace D2RReimaginedTools.Models;
public record LevelPresetPathing
{
    public string? LevelName { get; init; }
    public string? TileName { get; init; }
    public string? Style { get; init; }
    public int?   StartSequence { get; init; }
    public int?   EndSequence { get; init; }

    public string? Type1 { get; init; }
    public int? Cel1 { get; init; }

    public string? Type2 { get; init; }
    public int? Cel2 { get; init; }

    public string? Type3 { get; init; }
    public int? Cel3 { get; init; }

    public string? Type4 { get; init; }
    public int? Cel4 { get; init; }
}
