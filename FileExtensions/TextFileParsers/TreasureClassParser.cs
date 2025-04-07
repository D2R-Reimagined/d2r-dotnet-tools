using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class TreasureClassParser
{
    public static async Task<IList<TreasureClass>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1);
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new TreasureClass
            {
                TreasureClassName = columns[0],
                Group = columns[1],
                Level = columns[2].ToNullableInt(),
                Picks = columns[3].ToNullableInt(),
                Unique = columns[4].ToNullableInt(),
                Set = columns[5].ToNullableInt(),
                Rare = columns[6].ToNullableInt(),
                Magic = columns[7].ToNullableInt(),
                NoDrop = columns[8].ToNullableInt(),
                Item1 = columns[9],
                Prob1 = columns[10].ToNullableInt(),
                Item2 = columns[11],
                Prob2 = columns[12].ToNullableInt(),
                Item3 = columns[13],
                Prob3 = columns[14].ToNullableInt(),
                Item4 = columns[15],
                Prob4 = columns[16].ToNullableInt(),
                Item5 = columns[17],
                Prob5 = columns[18].ToNullableInt(),
                Item6 = columns[19],
                Prob6 = columns[20].ToNullableInt(),
                Item7 = columns[21],
                Prob7 = columns[22].ToNullableInt(),
                Item8 = columns[23],
                Prob8 = columns[24].ToNullableInt(),
                Item9 = columns[25],
                Prob9 = columns[26].ToNullableInt(),
                Item10 = columns[27],
                Prob10 = columns[28].ToNullableInt(),
                ItemProbSum = columns[29].ToNullableInt(),
                ItemProbTotal = columns[30].ToNullableInt(),
                TreasureClassDropChance = columns[31],
                FirstLadderSeason = columns[32].ToNullableInt(),
                LastLadderSeason = columns[33].ToNullableInt(),
                NoAlwaysSpawn = columns[34].ToBool()
            }).ToList();
    }
}

