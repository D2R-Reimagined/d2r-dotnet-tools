using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class ItemStatCostParser
{
    public static async Task<IList<ItemStatCost>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1);

        return lines.Select(line => line.Split('\t'))
            .Select(columns => new ItemStatCost
            {
                Stat = columns[0],
                ID = columns[1],
                SendOther = columns[2],
                Signed = columns[3],
                SendBits = columns[4],
                SendParamBits = columns[5],
                UpdateAnimRate = columns[6],
                Saved = columns[7],
                CSvSigned = columns[8],
                CSvBits = columns[9],
                CSvParam = columns[10],
                FCallback = columns[11],
                FMin = columns[12],
                MinAccr = columns[13],
                Encode = columns[14],
                Add = columns[15],
                Multiply = columns[16],
                ValShift = columns[17],
                SaveBits_109 = columns[18],
                SaveAdd_109 = columns[19],
                SaveBits = columns[20],
                SaveAdd = columns[21],
                SaveParamBits = columns[22],
                KeepZero = columns[23],
                Op = columns[24],
                OpParam = columns[25],
                OpBase = columns[26],
                OpStat1 = columns[27],
                OpStat2 = columns[28],
                OpStat3 = columns[29],
                Direct = columns[30],
                MaxStat = columns[31],
                DamageRelated = columns[32],
                ItemEvent1 = columns[33],
                ItemEventFunc1 = columns[34],
                ItemEvent2 = columns[35],
                ItemEventFunc2 = columns[36],
                DescPriority = columns[37],
                DescFunc = columns[38],
                DescVal = columns[39],
                DescStrPos = columns[40],
                DescStrNeg = columns[41],
                DescStr2 = columns[42],
                Dgrp = columns[43],
                DgrpFunc = columns[44],
                DgrpVal = columns[45],
                DgrpStrPos = columns[46],
                DgrpStrNeg = columns[47],
                DgrpStr2 = columns[48],
                Stuff = columns[49],
                AdvDisplay = columns[50],
                Eol = columns[51]
            }).ToList();
    }
}
