using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class PropertiesParser
{
    public static IList<Property> Entries { get; private set; } = new List<Property>();
    
    public static async Task<IList<Property>> GetEntries(string path)
    {
        if (Entries.Count > 0)
            return Entries;
        
        var lines = await File.ReadAllLinesAsync(path);
        if (lines.Length == 0) return new List<Property>();

        var header = lines[0].Split('\t');
        var columnMap = header
            .Select((name, index) => new { name, index })
            .ToDictionary(x => x.name.Trim(), x => x.index, StringComparer.OrdinalIgnoreCase);

        Entries = lines
            .Skip(1)
            .Select(line => line.Split('\t'))
            .Where(columns => columns.Length >= header.Length)
            .Select(columns => new Property
            {
                Code = columns.GetValue(columnMap, "code"),
                Enabled = columns.GetValue(columnMap, "*Enabled").ToBool(),
                Tooltip = columns.GetValue(columnMap, "*Tooltip"),

                Func1 = columns.GetValue(columnMap, "func1").ToNullableInt(),
                Stat1 = columns.GetValue(columnMap, "stat1"),
                Set1 = columns.GetValue(columnMap, "set1").ToNullableInt(),
                Val1 = columns.GetValue(columnMap, "val1"),

                Func2 = columns.GetValue(columnMap, "func2").ToNullableInt(),
                Stat2 = columns.GetValue(columnMap, "stat2"),
                Set2 = columns.GetValue(columnMap, "set2").ToNullableInt(),
                Val2 = columns.GetValue(columnMap, "val2"),

                Func3 = columns.GetValue(columnMap, "func3").ToNullableInt(),
                Stat3 = columns.GetValue(columnMap, "stat3"),
                Set3 = columns.GetValue(columnMap, "set3").ToNullableInt(),
                Val3 = columns.GetValue(columnMap, "val3"),

                Func4 = columns.GetValue(columnMap, "func4").ToNullableInt(),
                Stat4 = columns.GetValue(columnMap, "stat4"),
                Set4 = columns.GetValue(columnMap, "set4").ToNullableInt(),
                Val4 = columns.GetValue(columnMap, "val4"),

                Func5 = columns.GetValue(columnMap, "func5").ToNullableInt(),
                Stat5 = columns.GetValue(columnMap, "stat5"),
                Set5 = columns.GetValue(columnMap, "set5").ToNullableInt(),
                Val5 = columns.GetValue(columnMap, "val5"),

                Func6 = columns.GetValue(columnMap, "func6").ToNullableInt(),
                Stat6 = columns.GetValue(columnMap, "stat6"),
                Set6 = columns.GetValue(columnMap, "set6").ToNullableInt(),
                Val6 = columns.GetValue(columnMap, "val6"),

                Func7 = columns.GetValue(columnMap, "func7").ToNullableInt(),
                Stat7 = columns.GetValue(columnMap, "stat7"),
                Set7 = columns.GetValue(columnMap, "set7").ToNullableInt(),
                Val7 = columns.GetValue(columnMap, "val7"),

                Parameter = columns.GetValue(columnMap, "*Parameter"),
                Min = columns.GetValue(columnMap, "*Min"),
                Max = columns.GetValue(columnMap, "*Max"),
                Notes = columns.GetValue(columnMap, "*Notes"),
                Eol = columns.GetValue(columnMap, "*eol").ToInt(),

                PropertyFunctions = new List<PropertyFunction>()
            })
            .ToList();
        
        return Entries;
    }
}
