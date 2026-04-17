using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class SetItemParser : HeaderMappedTextFileParser<SetItem, SetItemParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> _aliases = new Dictionary<string, string[]>
    {
        [nameof(SetItem.LevelRequirement)] = ["lvl req"],
        [nameof(SetItem.CostMultiplier)] = ["cost mult"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => _aliases;

    protected override SetItem FinalizeEntry(SetItem entry, string[] columns, IReadOnlyDictionary<string, int> columnMap)
    {
        entry.Properties = ExtractBaseMods(columns, columnMap);
        entry.AdditionalProperties = ExtractAdditionalMods(columns, columnMap);
        return entry;
    }

    private static List<SetItemMod> ExtractBaseMods(string[] columns, IReadOnlyDictionary<string, int> columnMap)
    {
        var mods = new List<SetItemMod>();
        for (int i = 1; i <= 9; i++)
        {
            if (!columnMap.TryGetValue($"prop{i}", out var codeIdx)) continue;
            var code = columns[codeIdx];
            if (string.IsNullOrEmpty(code)) continue;

            mods.Add(new SetItemMod
            {
                Code = code,
                Param = columnMap.TryGetValue($"par{i}", out var parIdx) ? columns[parIdx] : null,
                Min = columnMap.TryGetValue($"min{i}", out var minIdx) ? ParseNullableInt(columns[minIdx]) : null,
                Max = columnMap.TryGetValue($"max{i}", out var maxIdx) ? ParseNullableInt(columns[maxIdx]) : null
            });
        }
        return mods;
    }

    private static List<SetItemMod> ExtractAdditionalMods(string[] columns, IReadOnlyDictionary<string, int> columnMap)
    {
        var mods = new List<SetItemMod>();
        // aprop1a, apar1a, amin1a, amax1a, aprop1b, etc.
        for (int i = 1; i <= 5; i++)
        {
            foreach (var suffix in new[] { "a", "b" })
            {
                if (!columnMap.TryGetValue($"aprop{i}{suffix}", out var codeIdx)) continue;
                var code = columns[codeIdx];
                if (string.IsNullOrEmpty(code)) continue;

                mods.Add(new SetItemMod
                {
                    Code = code,
                    Param = columnMap.TryGetValue($"apar{i}{suffix}", out var parIdx) ? columns[parIdx] : null,
                    Min = columnMap.TryGetValue($"amin{i}{suffix}", out var minIdx) ? ParseNullableInt(columns[minIdx]) : null,
                    Max = columnMap.TryGetValue($"amax{i}{suffix}", out var maxIdx) ? ParseNullableInt(columns[maxIdx]) : null
                });
            }
        }
        return mods;
    }

    private static int? ParseNullableInt(string s)
    {
        return int.TryParse(s, out var result) ? result : null;
    }
}
