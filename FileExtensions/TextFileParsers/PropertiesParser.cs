using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class PropertiesParser
{
    public static async Task<IList<Property>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line

        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Property()
            {
                Code = columns[0],
                Enabled = columns[1].ToBool(),
                Tooltip = columns[2],

                Func1 = columns[3].ToNullableInt(),
                Stat1 = columns[4],
                Set1 = columns[5].ToNullableInt(),
                Val1 = columns[6].ToNullableInt(),

                Func2 = columns[7].ToNullableInt(),
                Stat2 = columns[8],
                Set2 = columns[9].ToNullableInt(),
                Val2 = columns[10].ToNullableInt(),

                Func3 = columns[11].ToNullableInt(),
                Stat3 = columns[12],
                Set3 = columns[13].ToNullableInt(),
                Val3 = columns[14].ToNullableInt(),

                Func4 = columns[15].ToNullableInt(),
                Stat4 = columns[16],
                Set4 = columns[17].ToNullableInt(),
                Val4 = columns[18].ToNullableInt(),

                Func5 = columns[19].ToNullableInt(),
                Stat5 = columns[20],
                Set5 = columns[21].ToNullableInt(),
                Val5 = columns[22].ToNullableInt(),

                Func6 = columns[23].ToNullableInt(),
                Stat6 = columns[24],
                Set6 = columns[25].ToNullableInt(),
                Val6 = columns[26].ToNullableInt(),

                Func7 = columns[27].ToNullableInt(),
                Stat7 = columns[28],
                Set7 = columns[29].ToNullableInt(),
                Val7 = columns[30].ToNullableInt(),

                Parameter = columns[31],
                Min = columns[32],
                Max = columns[33],
                Notes = columns[34],
                Eol = columns[35].ToInt(),

                PropertyFunctions = new List<PropertyFunction>() // Assuming this needs further parsing
            }).ToList();
    }
}