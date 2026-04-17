using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class CubeModifierTypeParser : HeaderMappedTextFileParser<CubeModifierType, CubeModifierTypeParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(CubeModifierType.CubeModifierTypeName)] = ["cube modifier type"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
