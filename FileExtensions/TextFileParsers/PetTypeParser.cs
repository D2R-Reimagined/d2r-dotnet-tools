using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class PetTypeParser : HeaderMappedTextFileParser<PetType, PetTypeParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(PetType.PetTypeId)] = ["pet type"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
