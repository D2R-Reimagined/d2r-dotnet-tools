using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class NpcParser
{
    public static async Task<IList<Npc>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Npc
            {
                NpcName = columns[0],
                BuyMultiplier = columns[1].ToNullableInt(),
                SellMultiplier = columns[2].ToNullableInt(),
                RepairMultiplier = columns[3].ToNullableInt(),

                QuestFlagA = columns[4].ToNullableInt(),
                QuestBuyMultiplierA = columns[5].ToNullableInt(),
                QuestSellMultiplierA = columns[6].ToNullableInt(),
                QuestRepairMultiplierA = columns[7].ToNullableInt(),

                QuestFlagB = columns[8].ToNullableInt(),
                QuestBuyMultiplierB = columns[9].ToNullableInt(),
                QuestSellMultiplierB = columns[10].ToNullableInt(),
                QuestRepairMultiplierB = columns[11].ToNullableInt(),

                QuestFlagC = columns[12].ToNullableInt(),
                QuestBuyMultiplierC = columns[13].ToNullableInt(),
                QuestSellMultiplierC = columns[14].ToNullableInt(),
                QuestRepairMultiplierC = columns[15].ToNullableInt(),

                MaxBuy = columns[16].ToNullableInt(),
                MaxBuyNightmare = columns[17].ToNullableInt(),
                MaxBuyHell = columns[18].ToNullableInt(),
            })
            .ToList();
    }
}
