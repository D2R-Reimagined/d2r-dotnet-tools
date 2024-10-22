namespace D2RReimaginedTools.Models;

public record Property
{
    public string? Code { get; init; }
    public bool Enabled { get; init; }
    public IList<PropertyFunction> PropertyFunctions { get; init; }
    public string? Tooltip { get; init; }
    public string? Parameter { get; init; }
    public string? Min { get; init; }
    public string? Max { get; init; }
    public string? Notes { get; init; }
    public int Eol { get; init; }
}