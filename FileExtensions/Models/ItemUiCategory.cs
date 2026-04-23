namespace D2RReimaginedTools.Models;

public record ItemUiCategory
{
    public string? Name { get; init; }
    public int? IsEquipment { get; init; }
    public string? ParentCategory { get; init; }
    public string? QualityFilter { get; init; }
    public int? NumColumns { get; init; }
}
