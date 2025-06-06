﻿using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class MonPropParser
{
    public static async Task<IList<MonProp>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new MonProp
            {
                Id = columns[0],
                Prop1 = columns[1],
                Chance1 = columns[2].ToNullableInt(),
                Par1 = columns[3],
                Min1 = columns[4].ToNullableInt(),
                Max1 = columns[5].ToNullableInt(),
                Prop2 = columns[6],
                Chance2 = columns[7].ToNullableInt(),
                Par2 = columns[8],
                Min2 = columns[9].ToNullableInt(),
                Max2 = columns[10].ToNullableInt(),
                Prop3 = columns[11],
                Chance3 = columns[12].ToNullableInt(),
                Par3 = columns[13],
                Min3 = columns[14].ToNullableInt(),
                Max3 = columns[15].ToNullableInt(),
                Prop4 = columns[16],
                Chance4 = columns[17].ToNullableInt(),
                Par4 = columns[18],
                Min4 = columns[19].ToNullableInt(),
                Max4 = columns[20].ToNullableInt(),
                Prop5 = columns[21],
                Chance5 = columns[22].ToNullableInt(),
                Par5 = columns[23],
                Min5 = columns[24].ToNullableInt(),
                Max5 = columns[25].ToNullableInt(),
                Prop6 = columns[26],
                Chance6 = columns[27].ToNullableInt(),
                Par6 = columns[28],
                Min6 = columns[29].ToNullableInt(),
                Max6 = columns[30].ToNullableInt(),

                Prop1N = columns[31],
                Chance1N = columns[32].ToNullableInt(),
                Par1N = columns[33],
                Min1N = columns[34].ToNullableInt(),
                Max1N = columns[35].ToNullableInt(),
                Prop2N = columns[36],
                Chance2N = columns[37].ToNullableInt(),
                Par2N = columns[38],
                Min2N = columns[39].ToNullableInt(),
                Max2N = columns[40].ToNullableInt(),
                Prop3N = columns[41],
                Chance3N = columns[42].ToNullableInt(),
                Par3N = columns[43],
                Min3N = columns[44].ToNullableInt(),
                Max3N = columns[45].ToNullableInt(),
                Prop4N = columns[46],
                Chance4N = columns[47].ToNullableInt(),
                Par4N = columns[48],
                Min4N = columns[49].ToNullableInt(),
                Max4N = columns[50].ToNullableInt(),
                Prop5N = columns[51],
                Chance5N = columns[52].ToNullableInt(),
                Par5N = columns[53],
                Min5N = columns[54].ToNullableInt(),
                Max5N = columns[55].ToNullableInt(),
                Prop6N = columns[56],
                Chance6N = columns[57].ToNullableInt(),
                Par6N = columns[58],
                Min6N = columns[59].ToNullableInt(),
                Max6N = columns[60].ToNullableInt(),

                Prop1H = columns[61],
                Chance1H = columns[62].ToNullableInt(),
                Par1H = columns[63],
                Min1H = columns[64].ToNullableInt(),
                Max1H = columns[65].ToNullableInt(),
                Prop2H = columns[66],
                Chance2H = columns[67].ToNullableInt(),
                Par2H = columns[68],
                Min2H = columns[69].ToNullableInt(),
                Max2H = columns[70].ToNullableInt(),
                Prop3H = columns[71],
                Chance3H = columns[72].ToNullableInt(),
                Par3H = columns[73],
                Min3H = columns[74].ToNullableInt(),
                Max3H = columns[75].ToNullableInt(),
                Prop4H = columns[76],
                Chance4H = columns[77].ToNullableInt(),
                Par4H = columns[78],
                Min4H = columns[79].ToNullableInt(),
                Max4H = columns[80].ToNullableInt(),
                Prop5H = columns[81],
                Chance5H = columns[82].ToNullableInt(),
                Par5H = columns[83],
                Min5H = columns[84].ToNullableInt(),
                Max5H = columns[85].ToNullableInt(),
                Prop6H = columns[86],
                Chance6H = columns[87].ToNullableInt(),
                Par6H = columns[88],
                Min6H = columns[89].ToNullableInt(),
                Max6H = columns[90].ToNullableInt(),
            })
            .ToList();
    }
}

