﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.TextFileParsers;

using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class LevelParser
{
    public static async Task<IList<Level>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Level
            {
                Name = columns[0],
                StringName = columns[1],
                Id = columns[2].ToInt(),
                Pal = columns[3].ToInt(),
                Act = columns[4].ToInt(),
                QuestFlag = columns[5],
                QuestFlagEx = columns[6],
                Layer = columns[7].ToInt(),
                SizeX = columns[8].ToInt(),
                SizeY = columns[9].ToInt(),
                SizeX_N = columns[10].ToInt(),
                SizeY_N = columns[11].ToInt(),
                SizeX_H = columns[12].ToInt(),
                SizeY_H = columns[13].ToInt(),
                OffsetX = columns[14].ToInt(),
                OffsetY = columns[15].ToInt(),
                Depend = columns[16].ToInt(),
                Teleport = columns[17].ToInt(),
                Rain = columns[18].ToInt(),
                Mud = columns[19].ToInt(),
                NoPer = columns[20].ToInt(),
                LOSDraw = columns[21].ToInt(),
                FloorFilter = columns[22].ToInt(),
                BlankScreen = columns[23].ToInt(),
                DrawEdges = columns[24].ToInt(),
                IsInside = columns[25],
                DrlgType = columns[26].ToInt(),
                LevelType = columns[27].ToInt(),
                SubType = columns[28].ToInt(),
                SubTheme = columns[29].ToInt(),
                SubWaypoint = columns[30].ToInt(),
                SubShrine = columns[31].ToInt(),

                Vis0 = columns[32].ToInt(),
                Vis1 = columns[33].ToInt(),
                Vis2 = columns[34].ToInt(),
                Vis3 = columns[35].ToInt(),
                Vis4 = columns[36].ToInt(),
                Vis5 = columns[37].ToInt(),
                Vis6 = columns[38].ToInt(),
                Vis7 = columns[39].ToInt(),

                Warp0 = columns[40].ToInt(),
                Warp1 = columns[41].ToInt(),
                Warp2 = columns[42].ToInt(),
                Warp3 = columns[43].ToInt(),
                Warp4 = columns[44].ToInt(),
                Warp5 = columns[45].ToInt(),
                Warp6 = columns[46].ToInt(),
                Warp7 = columns[47].ToInt(),

                Intensity = columns[48].ToInt(),
                Red = columns[49].ToInt(),
                Green = columns[50].ToInt(),
                Blue = columns[51].ToInt(),
                Portal = columns[52].ToInt(),
                Position = columns[53].ToInt(),
                SaveMonsters = columns[54].ToInt(),
                Quest = columns[55].ToInt(),
                WarpDist = columns[56].ToInt(),

                MonLvl = columns[57].ToInt(),
                MonLvl_N = columns[58].ToInt(),
                MonLvl_H = columns[59].ToInt(),

                MonLvlEx = columns[60].ToInt(),
                MonLvlEx_N = columns[61].ToInt(),
                MonLvlEx_H = columns[62].ToInt(),

                MonDen = columns[63].ToInt(),
                MonDen_N = columns[64].ToInt(),
                MonDen_H = columns[65].ToInt(),

                MonUMin = columns[66].ToInt(),
                MonUMax = columns[67].ToInt(),
                MonUMin_N = columns[68].ToInt(),
                MonUMax_N = columns[69].ToInt(),
                MonUMin_H = columns[70].ToInt(),
                MonUMax_H = columns[71].ToInt(),

                MonWndr = columns[72].ToInt(),
                MonSpcWalk = columns[73].ToInt(),
                NumMon = columns[74].ToInt(),

                Mon1 = columns[75],
                Mon2 = columns[76],
                Mon3 = columns[77],
                Mon4 = columns[78],
                Mon5 = columns[79],
                Mon6 = columns[80],
                Mon7 = columns[81],
                Mon8 = columns[82],
                Mon9 = columns[83],
                Mon10 = columns[84],
                Mon11 = columns[85],
                Mon12 = columns[86],
                Mon13 = columns[87],
                Mon14 = columns[88],
                Mon15 = columns[89],
                Mon16 = columns[90],
                Mon17 = columns[91],
                Mon18 = columns[92],
                Mon19 = columns[93],
                Mon20 = columns[94],
                Mon21 = columns[95],
                Mon22 = columns[96],
                Mon23 = columns[97],
                Mon24 = columns[98],
                Mon25 = columns[99],

                RangedSpawn = columns[100],

                NMon1 = columns[101],
                NMon2 = columns[102],
                NMon3 = columns[103],
                NMon4 = columns[104],
                NMon5 = columns[105],
                NMon6 = columns[106],
                NMon7 = columns[107],
                NMon8 = columns[108],
                NMon9 = columns[109],
                NMon10 = columns[110],
                NMon11 = columns[111],
                NMon12 = columns[112],
                NMon13 = columns[113],
                NMon14 = columns[114],
                NMon15 = columns[115],
                NMon16 = columns[116],
                NMon17 = columns[117],
                NMon18 = columns[118],
                NMon19 = columns[119],
                NMon20 = columns[120],
                NMon21 = columns[121],
                NMon22 = columns[122],
                NMon23 = columns[123],
                NMon24 = columns[124],
                NMon25 = columns[125],

                UMon1 = columns[126],
                UMon2 = columns[127],
                UMon3 = columns[128],
                UMon4 = columns[129],
                UMon5 = columns[130],
                UMon6 = columns[131],
                UMon7 = columns[132],
                UMon8 = columns[133],
                UMon9 = columns[134],
                UMon10 = columns[135],
                UMon11 = columns[136],
                UMon12 = columns[137],
                UMon13 = columns[138],
                UMon14 = columns[139],
                UMon15 = columns[140],
                UMon16 = columns[141],
                UMon17 = columns[142],
                UMon18 = columns[143],
                UMon19 = columns[144],
                UMon20 = columns[145],
                UMon21 = columns[146],
                UMon22 = columns[147],
                UMon23 = columns[148],
                UMon24 = columns[149],
                UMon25 = columns[150],

                CMon1 = columns[151],
                CMon2 = columns[152],
                CMon3 = columns[153],
                CMon4 = columns[154],
                Cpct1 = columns[155].ToInt(),
                Cpct2 = columns[156].ToInt(),
                Cpct3 = columns[157].ToInt(),
                Cpct4 = columns[158].ToInt(),
                Camt1 = columns[159].ToInt(),
                Camt2 = columns[160].ToInt(),
                Camt3 = columns[161].ToInt(),
                Camt4 = columns[162].ToInt(),

                Themes = columns[163].ToInt(),
                Waypoint = columns[164].ToInt(),
                LevelName = columns[165]
            })
            .ToList();
    }
}