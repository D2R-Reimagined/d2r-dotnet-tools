namespace D2RReimaginedTools.Models;

public record MonEquip
{
    public string? Monster { get; init; }
    public int? OnInit { get; init; }
    public int? Level { get; init; }
    public string? Item1 { get; init; }
    public string? Location1 { get; init; }
    public int? Modifier1 { get; init; }
    public string? Item2 { get; init; }
    public string? Location2 { get; init; }
    public int? Modifier2 { get; init; }
    public string? Item3 { get; init; }
    public string? Location3 { get; init; }
    public int? Modifier3 { get; init; }
}
