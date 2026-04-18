using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class ItemTypeParser : HeaderMappedTextFileParser<ItemType, ItemTypeParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> _aliases = new Dictionary<string, string[]>
    {
        [nameof(ItemType.ItemTypeName)] = ["ItemType"],
        [nameof(ItemType.MaxSocketsLevelThreshold1)] = ["MaxSocketsLevelThreshold1"], // In case normalization differs
        [nameof(ItemType.MaxSocketsLevelThreshold2)] = ["MaxSocketsLevelThreshold2"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => _aliases;
}
