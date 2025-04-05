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

public static class CubeMainParser
{
    public static async Task<IList<CubeMain>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new CubeMain
            {
                Description = columns[0],
                Enabled = columns[1].ToBool(),
                FirstLadderSeason = columns[2].ToInt(),
                LastLadderSeason = columns[3].ToInt(),
                MinDiff = columns[4].ToInt(),
                Version = columns[5].ToInt(),
                Operation = columns[6],
                Param = columns[7],
                Value = columns[8],
                Class = columns[9],
                NumInputs = columns[10].ToInt(),
                Input1 = columns[11],
                Input2 = columns[12],
                Input3 = columns[13],
                Input4 = columns[14],
                Input5 = columns[15],
                Input6 = columns[16],
                Input7 = columns[17],
                Output = columns[18],
                Level = columns[19].ToInt(),
                Plvl = columns[20].ToInt(),
                Ilvl = columns[21].ToInt(),
                Mod1 = columns[22],
                Mod1Chance = columns[23].ToInt(),
                Mod1Param = columns[24],
                Mod1Min = columns[25].ToInt(),
                Mod1Max = columns[26].ToInt(),
                Mod2 = columns[27],
                Mod2Chance = columns[28].ToInt(),
                Mod2Param = columns[29],
                Mod2Min = columns[30].ToInt(),
                Mod2Max = columns[31].ToInt(),
                Mod3 = columns[32],
                Mod3Chance = columns[33].ToInt(),
                Mod3Param = columns[34],
                Mod3Min = columns[35].ToInt(),
                Mod3Max = columns[36].ToInt(),
                Mod4 = columns[37],
                Mod4Chance = columns[38].ToInt(),
                Mod4Param = columns[39],
                Mod4Min = columns[40].ToInt(),
                Mod4Max = columns[41].ToInt(),
                Mod5 = columns[42],
                Mod5Chance = columns[43].ToInt(),
                Mod5Param = columns[44],
                Mod5Min = columns[45].ToInt(),
                Mod5Max = columns[46].ToInt(),

                OutputB = columns[47],
                LevelB = columns[48].ToInt(),
                PlvlB = columns[49].ToInt(),
                IlvlB = columns[50].ToInt(),
                Mod1B = columns[51],
                Mod1ChanceB = columns[52].ToInt(),
                Mod1ParamB = columns[53],
                Mod1MinB = columns[54].ToInt(),
                Mod1MaxB = columns[55].ToInt(),
                Mod2B = columns[56],
                Mod2ChanceB = columns[57].ToInt(),
                Mod2ParamB = columns[58],
                Mod2MinB = columns[59].ToInt(),
                Mod2MaxB = columns[60].ToInt(),
                Mod3B = columns[61],
                Mod3ChanceB = columns[62].ToInt(),
                Mod3ParamB = columns[63],
                Mod3MinB = columns[64].ToInt(),
                Mod3MaxB = columns[65].ToInt(),
                Mod4B = columns[66],
                Mod4ChanceB = columns[67].ToInt(),
                Mod4ParamB = columns[68],
                Mod4MinB = columns[69].ToInt(),
                Mod4MaxB = columns[70].ToInt(),
                Mod5B = columns[71],
                Mod5ChanceB = columns[72].ToInt(),
                Mod5ParamB = columns[73],
                Mod5MinB = columns[74].ToInt(),
                Mod5MaxB = columns[75].ToInt(),

                OutputC = columns[76],
                LevelC = columns[77].ToInt(),
                PlvlC = columns[78].ToInt(),
                IlvlC = columns[79].ToInt(),
                Mod1C = columns[80],
                Mod1ChanceC = columns[81].ToInt(),
                Mod1ParamC = columns[82],
                Mod1MinC = columns[83].ToInt(),
                Mod1MaxC = columns[84].ToInt(),
                Mod2C = columns[85],
                Mod2ChanceC = columns[86].ToInt(),
                Mod2ParamC = columns[87],
                Mod2MinC = columns[88].ToInt(),
                Mod2MaxC = columns[89].ToInt(),
                Mod3C = columns[90],
                Mod3ChanceC = columns[91].ToInt(),
                Mod3ParamC = columns[92],
                Mod3MinC = columns[93].ToInt(),
                Mod3MaxC = columns[94].ToInt(),
                Mod4C = columns[95],
                Mod4ChanceC = columns[96].ToInt(),
                Mod4ParamC = columns[97],
                Mod4MinC = columns[98].ToInt(),
                Mod4MaxC = columns[99].ToInt(),
                Mod5C = columns[100],
                Mod5ChanceC = columns[101].ToInt(),
                Mod5ParamC = columns[102],
                Mod5MinC = columns[103].ToInt(),
                Mod5MaxC = columns[104].ToInt()
            })
            .ToList();
    }
}