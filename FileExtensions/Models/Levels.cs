using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.Models;

public record Level
{
    public string?  Name { get; init; }
    public string?  StringName { get; init; }
    public int? Id { get; init; }
    public int? Pal { get; init; }
    public int? Act { get; init; }
    public string?  QuestFlag { get; init; }
    public string?  QuestFlagEx { get; init; }
    public int? Layer { get; init; }
    public int? SizeX { get; init; }
    public int? SizeY { get; init; }
    public int? SizeX_N { get; init; }
    public int? SizeY_N { get; init; }
    public int? SizeX_H { get; init; }
    public int? SizeY_H { get; init; }
    public int? OffsetX { get; init; }
    public int? OffsetY { get; init; }
    public int? Depend { get; init; }
    public int? Teleport { get; init; }
    public int? Rain { get; init; }
    public int? Mud { get; init; }
    public int? NoPer { get; init; }
    public int? LOSDraw { get; init; }
    public int? FloorFilter { get; init; }
    public int? BlankScreen { get; init; }
    public int? DrawEdges { get; init; }
    public string?  IsInside { get; init; }
    public int? DrlgType { get; init; }
    public int? LevelType { get; init; }
    public int? SubType { get; init; }
    public int? SubTheme { get; init; }
    public int? SubWaypoint { get; init; }
    public int? SubShrine { get; init; }
    public int? Vis0 { get; init; }
    public int? Vis1 { get; init; }
    public int? Vis2 { get; init; }
    public int? Vis3 { get; init; }
    public int? Vis4 { get; init; }
    public int? Vis5 { get; init; }
    public int? Vis6 { get; init; }
    public int? Vis7 { get; init; }
    public int? Warp0 { get; init; }
    public int? Warp1 { get; init; }
    public int? Warp2 { get; init; }
    public int? Warp3 { get; init; }
    public int? Warp4 { get; init; }
    public int? Warp5 { get; init; }
    public int? Warp6 { get; init; }
    public int? Warp7 { get; init; }
    public int? Intensity { get; init; }
    public int? Red { get; init; }
    public int? Green { get; init; }
    public int? Blue { get; init; }
    public int? Portal { get; init; }
    public int? Position { get; init; }
    public int? SaveMonsters { get; init; }
    public int? Quest { get; init; }
    public int? WarpDist { get; init; }
    public int? MonLvl { get; init; }
    public int? MonLvl_N { get; init; }
    public int? MonLvl_H { get; init; }
    public int? MonLvlEx { get; init; }
    public int? MonLvlEx_N { get; init; }
    public int? MonLvlEx_H { get; init; }
    public int? MonDen { get; init; }
    public int? MonDen_N { get; init; }
    public int? MonDen_H { get; init; }
    public int? MonUMin { get; init; }
    public int? MonUMax { get; init; }
    public int? MonUMin_N { get; init; }
    public int? MonUMax_N { get; init; }
    public int? MonUMin_H { get; init; }
    public int? MonUMax_H { get; init; }
    public int? MonWndr { get; init; }
    public int? MonSpcWalk { get; init; }
    public int? NumMon { get; init; }

    // Monsters and their variants — manually listing out all 25 slots for each difficulty
    public string?  Mon1 { get; init; }
    public string?  Mon2 { get; init; }
    public string?  Mon3 { get; init; }
    public string?  Mon4 { get; init; }
    public string?  Mon5 { get; init; }
    public string?  Mon6 { get; init; }
    public string?  Mon7 { get; init; }
    public string?  Mon8 { get; init; }
    public string?  Mon9 { get; init; }
    public string?  Mon10 { get; init; }
    public string?  Mon11 { get; init; }
    public string?  Mon12 { get; init; }
    public string?  Mon13 { get; init; }
    public string?  Mon14 { get; init; }
    public string?  Mon15 { get; init; }
    public string?  Mon16 { get; init; }
    public string?  Mon17 { get; init; }
    public string?  Mon18 { get; init; }
    public string?  Mon19 { get; init; }
    public string?  Mon20 { get; init; }
    public string?  Mon21 { get; init; }
    public string?  Mon22 { get; init; }
    public string?  Mon23 { get; init; }
    public string?  Mon24 { get; init; }
    public string?  Mon25 { get; init; }

    public string?  RangedSpawn { get; init; }

    public string?  NMon1 { get; init; }
    public string?  NMon2 { get; init; }
    public string?  NMon3 { get; init; }
    public string?  NMon4 { get; init; }
    public string?  NMon5 { get; init; }
    public string?  NMon6 { get; init; }
    public string?  NMon7 { get; init; }
    public string?  NMon8 { get; init; }
    public string?  NMon9 { get; init; }
    public string?  NMon10 { get; init; }
    public string?  NMon11 { get; init; }
    public string?  NMon12 { get; init; }
    public string?  NMon13 { get; init; }
    public string?  NMon14 { get; init; }
    public string?  NMon15 { get; init; }
    public string?  NMon16 { get; init; }
    public string?  NMon17 { get; init; }
    public string?  NMon18 { get; init; }
    public string?  NMon19 { get; init; }
    public string?  NMon20 { get; init; }
    public string?  NMon21 { get; init; }
    public string?  NMon22 { get; init; }
    public string?  NMon23 { get; init; }
    public string?  NMon24 { get; init; }
    public string?  NMon25 { get; init; }

    public string?  UMon1 { get; init; }
    public string?  UMon2 { get; init; }
    public string?  UMon3 { get; init; }
    public string?  UMon4 { get; init; }
    public string?  UMon5 { get; init; }
    public string?  UMon6 { get; init; }
    public string?  UMon7 { get; init; }
    public string?  UMon8 { get; init; }
    public string?  UMon9 { get; init; }
    public string?  UMon10 { get; init; }
    public string?  UMon11 { get; init; }
    public string?  UMon12 { get; init; }
    public string?  UMon13 { get; init; }
    public string?  UMon14 { get; init; }
    public string?  UMon15 { get; init; }
    public string?  UMon16 { get; init; }
    public string?  UMon17 { get; init; }
    public string?  UMon18 { get; init; }
    public string?  UMon19 { get; init; }
    public string?  UMon20 { get; init; }
    public string?  UMon21 { get; init; }
    public string?  UMon22 { get; init; }
    public string?  UMon23 { get; init; }
    public string?  UMon24 { get; init; }
    public string?  UMon25 { get; init; }

    public string?  CMon1 { get; init; }
    public string?  CMon2 { get; init; }
    public string?  CMon3 { get; init; }
    public string?  CMon4 { get; init; }

    public int? Cpct1 { get; init; }
    public int? Cpct2 { get; init; }
    public int? Cpct3 { get; init; }
    public int? Cpct4 { get; init; }

    public int? Camt1 { get; init; }
    public int? Camt2 { get; init; }
    public int? Camt3 { get; init; }
    public int? Camt4 { get; init; }

    public int?  Themes { get; init; }
    public string?  SoundEnv { get; init; }
    public int? Waypoint { get; init; }
    public string?  LevelName { get; init; }
    public string?  LevelWarp { get; init; }
    public string?  LevelEntry { get; init; }

    public int? ObjGrp0 { get; init; }
    public int? ObjGrp1 { get; init; }
    public int? ObjGrp2 { get; init; }
    public int? ObjGrp3 { get; init; }
    public int? ObjGrp4 { get; init; }
    public int? ObjGrp5 { get; init; }
    public int? ObjGrp6 { get; init; }
    public int? ObjGrp7 { get; init; }

    public int? ObjPrb0 { get; init; }
    public int? ObjPrb1 { get; init; }
    public int? ObjPrb2 { get; init; }
    public int? ObjPrb3 { get; init; }
    public int? ObjPrb4 { get; init; }
    public int? ObjPrb5 { get; init; }
    public int? ObjPrb6 { get; init; }
    public int? ObjPrb7 { get; init; }

    public string?  LevelGroup { get; init; }
}
