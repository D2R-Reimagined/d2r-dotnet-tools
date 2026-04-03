using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class MonEquipParser : HeaderMappedTextFileParser<MonEquip, MonEquipParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(MonEquip.Location1)] = ["loc1"],
        [nameof(MonEquip.Modifier1)] = ["mod1"],
        [nameof(MonEquip.Location2)] = ["loc2"],
        [nameof(MonEquip.Modifier2)] = ["mod2"],
        [nameof(MonEquip.Location3)] = ["loc3"],
        [nameof(MonEquip.Modifier3)] = ["mod3"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
