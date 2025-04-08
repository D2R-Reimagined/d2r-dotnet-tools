namespace D2RReimaginedTools.Models;
public record PetType
{
    public string? PetTypeId { get; init; }
    public string? Group { get; init; }
    public int? BaseMax { get; init; }
    public int? Warp { get; init; }
    public int? Range { get; init; }
    public int? PartySend { get; init; }
    public int? Unsummon { get; init; }
    public int? AutoMap { get; init; }
    public string Name { get; init; }
    public int? DrawHP { get; init; }
    public int? IconType { get; init; }
    public string? BaseIcon { get; init; }
    public string? MClass1 { get; init; }
    public string? MIcon1 { get; init; }
    public string? MClass2 { get; init; }
    public string? MIcon2 { get; init; }
    public string? MClass3 { get; init; }
    public string? MIcon3 { get; init; }
    public string? MClass4 { get; init; }
    public string? MIcon4 { get; init; }
}
