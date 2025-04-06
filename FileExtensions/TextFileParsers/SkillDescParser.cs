using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class SkillDescParser
{
    public static async Task<IList<SkillDesc>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new SkillDesc
            {
                SkillName = columns[0],
                SkillPage = columns[1].ToNullableInt(),
                SkillRow = columns[2].ToNullableInt(),
                SkillColumn = columns[3].ToNullableInt(),
                ListRow = columns[4].ToNullableInt(),
                IconCel = columns[5].ToNullableInt(),
                HireableIconCel = columns[6].ToNullableInt(),
                NameString = columns[7],
                ShortString = columns[8],
                LongString = columns[9],
                AlternateString = columns[10],
                DescriptionDamage = columns[11].ToNullableInt(),
                DamageCalculation1 = columns[12],
                DamageCalculation2 = columns[13],
                Param1Element = columns[14],
                Param1Min = columns[15],
                Param1Max = columns[16],
                Param2Element = columns[17],
                Param2Min = columns[18],
                Param2Max = columns[19],
                Param3Element = columns[20],
                Param3Min = columns[21],
                Param3Max = columns[22],
                DescriptionAttack = columns[23].ToNullableInt(),
                DescriptionMissile1 = columns[24],
                DescriptionMissile2 = columns[25],
                DescriptionMissile3 = columns[26],

                DescriptionLine1 = columns[27],
                DescriptionTextA1 = columns[28],
                DescriptionTextB1 = columns[29],
                DescriptionCalculationA1 = columns[30],
                DescriptionCalculationB1 = columns[31],

                DescriptionLine2 = columns[32],
                DescriptionTextA2 = columns[33],
                DescriptionTextB2 = columns[34],
                DescriptionCalculationA2 = columns[35],
                DescriptionCalculationB2 = columns[36],

                DescriptionLine3 = columns[37],
                DescriptionTextA3 = columns[38],
                DescriptionTextB3 = columns[39],
                DescriptionCalculationA3 = columns[40],
                DescriptionCalculationB3 = columns[41],

                DescriptionLine4 = columns[42],
                DescriptionTextA4 = columns[43],
                DescriptionTextB4 = columns[44],
                DescriptionCalculationA4 = columns[45],
                DescriptionCalculationB4 = columns[46],

                DescriptionLine5 = columns[47],
                DescriptionTextA5 = columns[48],
                DescriptionTextB5 = columns[49],
                DescriptionCalculationA5 = columns[50],
                DescriptionCalculationB5 = columns[51],

                DescriptionLine6 = columns[52],
                DescriptionTextA6 = columns[53],
                DescriptionTextB6 = columns[54],
                DescriptionCalculationA6 = columns[55],
                DescriptionCalculationB6 = columns[56],

                Dsc2Line1 = columns[57],
                Dsc2TextA1 = columns[58],
                Dsc2TextB1 = columns[59],
                Dsc2CalculationA1 = columns[60],
                Dsc2CalculationB1 = columns[61],

                Dsc2Line2 = columns[62],
                Dsc2TextA2 = columns[63],
                Dsc2TextB2 = columns[64],
                Dsc2CalculationA2 = columns[65],
                Dsc2CalculationB2 = columns[66],

                Dsc2Line3 = columns[67],
                Dsc2TextA3 = columns[68],
                Dsc2TextB3 = columns[69],
                Dsc2CalculationA3 = columns[70],
                Dsc2CalculationB3 = columns[71],

                Dsc2Line4 = columns[72],
                Dsc2TextA4 = columns[73],
                Dsc2TextB4 = columns[74],
                Dsc2CalculationA4 = columns[75],
                Dsc2CalculationB4 = columns[76],

                Dsc2Line5 = columns[77],
                Dsc2TextA5 = columns[78],
                Dsc2TextB5 = columns[79],
                Dsc2CalculationA5 = columns[80],
                Dsc2CalculationB5 = columns[81],

                Dsc3Line1 = columns[82],
                Dsc3TextA1 = columns[83],
                Dsc3TextB1 = columns[84],
                Dsc3CalculationA1 = columns[85],
                Dsc3CalculationB1 = columns[86],

                Dsc3Line2 = columns[87],
                Dsc3TextA2 = columns[88],
                Dsc3TextB2 = columns[89],
                Dsc3CalculationA2 = columns[90],
                Dsc3CalculationB2 = columns[91],

                Dsc3Line3 = columns[92],
                Dsc3TextA3 = columns[93],
                Dsc3TextB3 = columns[94],
                Dsc3CalculationA3 = columns[95],
                Dsc3CalculationB3 = columns[96],

                Dsc3Line4 = columns[97],
                Dsc3TextA4 = columns[98],
                Dsc3TextB4 = columns[99],
                Dsc3CalculationA4 = columns[100],
                Dsc3CalculationB4 = columns[101],

                Dsc3Line5 = columns[102],
                Dsc3TextA5 = columns[103],
                Dsc3TextB5 = columns[104],
                Dsc3CalculationA5 = columns[105],
                Dsc3CalculationB5 = columns[106],

                Dsc3Line6 = columns[107],
                Dsc3TextA6 = columns[108],
                Dsc3TextB6 = columns[109],
                Dsc3CalculationA6 = columns[110],
                Dsc3CalculationB6 = columns[111],

                Dsc3Line7 = columns[112],
                Dsc3TextA7 = columns[113],
                Dsc3TextB7 = columns[114],
                Dsc3CalculationA7 = columns[115],
                Dsc3CalculationB7 = columns[116],

                ItemProcText = columns[117],
                ItemProcDescriptionLineCount = columns[118].ToNullableInt(),
                EndOfLine = columns[119]
            })
            .ToList();
    }
}
