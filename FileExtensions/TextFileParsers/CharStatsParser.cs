using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class CharStatsParser : HeaderMappedTextFileParser<CharStats, CharStatsParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(CharStats.Strength)] = ["str"],
        [nameof(CharStats.Dexterity)] = ["dex"],
        [nameof(CharStats.Intelligence)] = ["int"],
        [nameof(CharStats.Vitality)] = ["vit"],
        [nameof(CharStats.BaseWeaponClass)] = ["baseWClass"],
        [nameof(CharStats.Item1Location)] = ["item1loc"],
        [nameof(CharStats.Item2Location)] = ["item2loc"],
        [nameof(CharStats.Item3Location)] = ["item3loc"],
        [nameof(CharStats.Item4Location)] = ["item4loc"],
        [nameof(CharStats.Item5Location)] = ["item5loc"],
        [nameof(CharStats.Item6Location)] = ["item6loc"],
        [nameof(CharStats.Item7Location)] = ["item7loc"],
        [nameof(CharStats.Item8Location)] = ["item8loc"],
        [nameof(CharStats.Item9Location)] = ["item9loc"],
        [nameof(CharStats.Item10Location)] = ["item10loc"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
