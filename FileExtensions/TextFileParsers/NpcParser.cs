using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class NpcParser : HeaderMappedTextFileParser<Npc, NpcParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(Npc.NpcName)] = ["npc"],
        [nameof(Npc.BuyMultiplier)] = ["buy mult"],
        [nameof(Npc.SellMultiplier)] = ["sell mult"],
        [nameof(Npc.RepairMultiplier)] = ["rep mult"],
        [nameof(Npc.QuestBuyMultiplierA)] = ["questbuymult A"],
        [nameof(Npc.QuestSellMultiplierA)] = ["questsellmult A"],
        [nameof(Npc.QuestRepairMultiplierA)] = ["questrepmult A"],
        [nameof(Npc.QuestBuyMultiplierB)] = ["questbuymult B"],
        [nameof(Npc.QuestSellMultiplierB)] = ["questsellmult B"],
        [nameof(Npc.QuestRepairMultiplierB)] = ["questrepmult B"],
        [nameof(Npc.QuestBuyMultiplierC)] = ["questbuymult C"],
        [nameof(Npc.QuestSellMultiplierC)] = ["questsellmult C"],
        [nameof(Npc.QuestRepairMultiplierC)] = ["questrepmult C"],
        [nameof(Npc.MaxBuyNightmare)] = ["max buy (N)"],
        [nameof(Npc.MaxBuyHell)] = ["max buy (H)"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
