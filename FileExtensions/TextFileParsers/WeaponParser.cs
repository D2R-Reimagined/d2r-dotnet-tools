using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class WeaponParser : HeaderMappedTextFileParser<Weapon, WeaponParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(Equipment.OneOrTwoHanded)] = ["1or2handed"],
        [nameof(Equipment.TwoHanded)] = ["2handed"],
        [nameof(Equipment.TwoHandMinDam)] = ["2handmindam"],
        [nameof(Equipment.TwoHandMaxDam)] = ["2handmaxdam"],
        [nameof(Equipment.TwoHandedWClass)] = ["2handedwclass"],
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
