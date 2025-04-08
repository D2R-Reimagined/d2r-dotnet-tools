namespace D2RReimaginedTools.Models;

public record MonUMod
{
    public string? UniqueModId { get; init; }
    public int? Enabled { get; init; }
    public int? Version { get; init; }
    public int? Xfer { get; init; }
    public int? Champion { get; init; }
    public int? FPick { get; init; }
    public string? Exclude1 { get; init; }
    public string? Exclude2 { get; init; }
    public int? CPick { get; init; }
    public int? CPick_N { get; init; }
    public int? CPick_H { get; init; }
    public int? UPick { get; init; }
    public int? UPick_N { get; init; }
    public int? UPick_H { get; init; }
    public int? Constants { get; init; }
    public string? ConstantDesc { get; init; }
}
