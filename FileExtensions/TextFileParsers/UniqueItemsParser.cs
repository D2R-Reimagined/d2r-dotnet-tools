using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class UniqueItemsParser : HeaderMappedTextFileParser<UniqueItem, UniqueItemsParser>
{
    protected override UniqueItem FinalizeEntry(UniqueItem entry, string[] columns, IReadOnlyDictionary<string, int> columnMap)
    {
        return entry with
        {
            Properties = new List<ItemProperty>
            {
                CreateItemProperty(entry, 1),
                CreateItemProperty(entry, 2),
                CreateItemProperty(entry, 3),
                CreateItemProperty(entry, 4),
                CreateItemProperty(entry, 5),
                CreateItemProperty(entry, 6),
                CreateItemProperty(entry, 7),
                CreateItemProperty(entry, 8),
                CreateItemProperty(entry, 9),
                CreateItemProperty(entry, 10),
                CreateItemProperty(entry, 11),
                CreateItemProperty(entry, 12)
            }
        };
    }

    private static ItemProperty CreateItemProperty(UniqueItem entry, int index)
    {
        return new ItemProperty
        {
            Property = GetString(entry, $"Prop{index}"),
            Parameter = GetString(entry, $"Par{index}"),
            Min = GetInt(entry, $"Min{index}"),
            Max = GetInt(entry, $"Max{index}")
        };
    }

    private static string? GetString(UniqueItem entry, string propertyName)
    {
        return typeof(UniqueItem).GetProperty(propertyName)?.GetValue(entry) as string;
    }

    private static int GetInt(UniqueItem entry, string propertyName)
    {
        return (int?)typeof(UniqueItem).GetProperty(propertyName)?.GetValue(entry) ?? 0;
    }
}
