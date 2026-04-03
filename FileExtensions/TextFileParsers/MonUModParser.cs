using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class MonUModParser : HeaderMappedTextFileParser<MonUMod, MonUModParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(MonUMod.UniqueModId)] = ["uniquemod"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
