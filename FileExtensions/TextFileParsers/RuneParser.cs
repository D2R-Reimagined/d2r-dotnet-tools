using System.Collections.Generic;
using System.Linq;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class RunesParser : HeaderMappedTextFileParser<RuneWord, RunesParser>
{
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
