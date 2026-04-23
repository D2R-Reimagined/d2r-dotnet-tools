namespace D2RReimaginedTools.Models;

public record Overlay
{
    public string? OverlayName { get; init; }
    public string? ID { get; init; }
    public string? Filename { get; init; }
    public int? Version { get; init; }
    public int? Frames { get; init; }
    public string? Character { get; init; }
    public int? PreDraw { get; init; }
    public int? OneOfN { get; init; }
    public int? Xoffset { get; init; }
    public int? Yoffset { get; init; }
    public int? Height1 { get; init; }
    public int? Height2 { get; init; }
    public int? Height3 { get; init; }
    public int? Height4 { get; init; }
    public int? AnimRate { get; init; }
    public int? LoopWaitTime { get; init; }
    public int? Trans { get; init; }
    public int? InitRadius { get; init; }
    public int? Radius { get; init; }
    public int? Red { get; init; }
    public int? Green { get; init; }
    public int? Blue { get; init; }
    public int? NumDirections { get; init; }
    public int? LocalBlood { get; init; }
    public string? WeaponStateFlags { get; init; }
    public string? WeaponStateGroup { get; init; }
    public string? StartSound { get; init; }
}
