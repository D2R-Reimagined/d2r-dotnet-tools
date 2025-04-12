using D2RReimaginedTools.Models;
using D2RReimaginedTools.TextFileParsers;

namespace D2RReimaginedTools.Helpers;

public class PropertiesHelper
{
    public static async Task<string> GetPropertyTranslationKeyAsync(string excelPath, Property property)
    {
        var hasMoreThanOneStat = !string.IsNullOrWhiteSpace(property.Stat2);
        var itemStatEntries = await ItemStatCostParser.GetEntries(Path.Combine(excelPath, "itemstatcost.txt"));

        if (!hasMoreThanOneStat)
        {
            var foundItemStatEntry = itemStatEntries.FirstOrDefault(x => x.Stat == property.Stat1);
            if (foundItemStatEntry != null)
            {
                return foundItemStatEntry.DescStrPos;
            }
        }
        else
        {
            //TODO handle stat groups
        }

        return $"NOT FOUND - {property.Code} - {property.Stat1}";
    }
}