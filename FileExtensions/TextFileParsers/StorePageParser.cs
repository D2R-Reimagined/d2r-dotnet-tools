using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class StorePageParser : HeaderMappedTextFileParser<StorePage, StorePageParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(StorePage.StorePageName)] = ["Store Page"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
