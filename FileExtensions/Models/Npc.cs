namespace D2RReimaginedTools.Models;

public record Npc
{
    public string? NpcName { get; set; }
    public int? BuyMultiplier { get; set; }
    public int? SellMultiplier { get; set; }
    public int? RepairMultiplier { get; set; }

    public int? QuestFlagA { get; set; }
    public int? QuestBuyMultiplierA { get; set; }
    public int? QuestSellMultiplierA { get; set; }
    public int? QuestRepairMultiplierA { get; set; }

    public int? QuestFlagB { get; set; }
    public int? QuestBuyMultiplierB { get; set; }
    public int? QuestSellMultiplierB { get; set; }
    public int? QuestRepairMultiplierB { get; set; }

    public int? QuestFlagC { get; set; }
    public int? QuestBuyMultiplierC { get; set; }
    public int? QuestSellMultiplierC { get; set; }
    public int? QuestRepairMultiplierC { get; set; }

    public int? MaxBuy { get; set; }
    public int? MaxBuyNightmare { get; set; }
    public int? MaxBuyHell { get; set; }
}
