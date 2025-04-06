using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.Models;

public record Shrines
{
    public string? Name { get; init; }
    public string? ShrineType { get; init; }
    public string? Effect { get; init; }
    public int? Code { get; init; }
    public int? Arg0 { get; init; }
    public int? Arg1 { get; init; }
    public int? DurationInFrames { get; init; }
    public int? ResetTimeInMinutes { get; init; }
    public int? Rarity { get; init; }
    public string? StringName { get; init; }
    public string? StringPhrase { get; init; }
    public int? EffectClass { get; init; }
    public int? LevelMin { get; init; }
}
