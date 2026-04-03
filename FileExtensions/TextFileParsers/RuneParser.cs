using System.Collections.Generic;
using System.Linq;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class RunesParser : HeaderMappedTextFileParser<RuneWord, RunesParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> _aliases = new Dictionary<string, string[]>
    {
        [nameof(RuneWord.ItemType1)] = ["itype1"],
        [nameof(RuneWord.ItemType2)] = ["itype2"],
        [nameof(RuneWord.ItemType3)] = ["itype3"],
        [nameof(RuneWord.ItemType4)] = ["itype4"],
        [nameof(RuneWord.ItemType5)] = ["itype5"],
        [nameof(RuneWord.ItemType6)] = ["itype6"],
        [nameof(RuneWord.ExcludeItemType1)] = ["etype1"],
        [nameof(RuneWord.ExcludeItemType2)] = ["etype2"],
        [nameof(RuneWord.ExcludeItemType3)] = ["etype3"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => _aliases;

    protected override RuneWord FinalizeEntry(RuneWord entry, string[] columns, IReadOnlyDictionary<string, int> columnMap)
    {
        return entry with
        {
            Mods = Enumerable.Range(1, 7)
                .Select(i => new RuneWordMod
                {
                    Code = GetValue(entry, $"T1Code{i}"),
                    Param = GetValue(entry, $"T1Param{i}"),
                    Min = GetNullableIntValue(entry, $"T1Min{i}"),
                    Max = GetNullableIntValue(entry, $"T1Max{i}")
                })
                .ToList()
        };
    }

    private static string? GetValue(RuneWord entry, string propertyName)
    {
        return typeof(RuneWord).GetProperty(propertyName)?.GetValue(entry) as string;
    }

    private static int? GetNullableIntValue(RuneWord entry, string propertyName)
    {
        return typeof(RuneWord).GetProperty(propertyName)?.GetValue(entry) as int?;
    }
}
