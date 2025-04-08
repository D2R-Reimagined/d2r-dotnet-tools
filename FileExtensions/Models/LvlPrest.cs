using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.Models;

public record LevelsPreset
{
    public string?  Name { get; init; }
    public int? Def { get; init; }
    public int? LevelId { get; init; }
    public int? Populate { get; init; }
    public int? Logicals { get; init; }
    public int? Outdoors { get; init; }
    public int? Animate { get; init; }
    public int? KillEdge { get; init; }
    public int? FillBlanks { get; init; }
    public int? SizeX { get; init; }
    public int? SizeY { get; init; }
    public int? AutoMap { get; init; }
    public int? Scan { get; init; }
    public int? Pops { get; init; }
    public int? PopPad { get; init; }
    public int? Files { get; init; }
    public string?  File1 { get; init; }
    public string?  File2 { get; init; }
    public string?  File3 { get; init; }
    public string?  File4 { get; init; }
    public string?  File5 { get; init; }
    public string?  File6 { get; init; }
    public int? Dt1Mask { get; init; }
}

