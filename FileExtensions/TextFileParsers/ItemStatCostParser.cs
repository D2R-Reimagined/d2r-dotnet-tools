using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class ItemStatCostParser : HeaderMappedTextFileParser<ItemStatCost, ItemStatCostParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(ItemStatCost.SaveBits_109)] = ["1.09-Save Bits"],
        [nameof(ItemStatCost.SaveAdd_109)] = ["1.09-Save Add"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
