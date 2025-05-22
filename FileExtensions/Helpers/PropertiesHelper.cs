using D2RReimaginedTools.Models;
using D2RReimaginedTools.TextFileParsers;

namespace D2RReimaginedTools.Helpers;

public class PropertiesHelper
{
    public static async Task<string> GetPropertyTranslationKeyAsync(string excelPath, Property property)
    {
        var itemStatEntries = await ItemStatCostParser.GetEntries(Path.Combine(excelPath, "itemstatcost.txt"));

        // List of all stat fields in the property
        var stats = new[] { property.Stat1, property.Stat2, property.Stat3, property.Stat4, property.Stat5, property.Stat6, property.Stat7 };

        foreach (var stat in stats)
        {
            if (!string.IsNullOrWhiteSpace(stat))
            {
                var itemStatEntry = itemStatEntries.FirstOrDefault(x => x.Stat == stat);
                if (itemStatEntry != null && !string.IsNullOrWhiteSpace(itemStatEntry.DescStrPos))
                {
                    return itemStatEntry.DescStrPos;
                }
            }
        }

        return $"NOT FOUND - {property.Code} - {property.Stat1}";
    }

}