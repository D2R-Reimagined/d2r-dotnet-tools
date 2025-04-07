namespace D2RReimaginedTools.Models;


public record Sounds
{
    public string? Sound { get; init; }
    public int? Index { get; init; }
    public string? Redirect { get; init; }
    public string? Channel { get; init; }
    public string? FileName { get; init; }
    public bool? IsLocal { get; init; }
    public bool? IsMusic { get; init; }
    public bool? IsAmbientScene { get; init; }
    public bool? IsAmbientEvent { get; init; }
    public bool? IsUI { get; init; }
    public int? VolumeMin { get; init; }
    public int? VolumeMax { get; init; }
    public int? PitchMin { get; init; }
    public int? PitchMax { get; init; }
    public int? GroupSize { get; init; }
    public int? GroupWeight { get; init; }
    public bool? Loop { get; init; }
    public int? FadeIn { get; init; }
    public int? FadeOut { get; init; }
    public bool? DeferInst { get; init; }
    public bool? StopInst { get; init; }
    public int? Duration { get; init; }
    public string? Compound { get; init; }
    public int? Falloff { get; init; }
    public int? LFEMix { get; init; }
    public int? _3dSpread { get; init; }
    public int? Priority { get; init; }
    public bool? Stream { get; init; }
    public bool? Is2D { get; init; }
    public bool? Tracking { get; init; }
    public bool? Solo { get; init; }
    public bool? MusicVol { get; init; }
    public int? Block1 { get; init; }
    public int? Block2 { get; init; }
    public int? Block3 { get; init; }
    public bool? HDOptOut { get; init; }
    public int? Delay { get; init; }
    public string? Unknown4737 { get; init; }
}
