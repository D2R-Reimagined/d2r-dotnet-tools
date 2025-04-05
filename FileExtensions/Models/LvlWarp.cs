using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.Models;

public record LvlWarp
{
    public string? Name { get; init; }
    public int? Id { get; init; }
    public int? SelectX { get; init; }
    public int? SelectY { get; init; }
    public int? SelectDX { get; init; }
    public int? SelectDY { get; init; }
    public int? ExitWalkX { get; init; }
    public int? ExitWalkY { get; init; }
    public int? OffsetX { get; init; }
    public int? OffsetY { get; init; }
    public int? LitVersion { get; init; }
    public int? Tiles { get; init; }
    public int? NoInteract { get; init; }
    public string? Direction { get; init; }
    public int? UniqueId { get; init; }
}
