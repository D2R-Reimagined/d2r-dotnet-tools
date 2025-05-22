using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class RunesParser
{
    private static IList<RuneWord> Entries { get; set; } = new List<RuneWord>();

    public static async Task<IList<RuneWord>> GetEntries(string path)
    {
        if (Entries != null && Entries.Count > 0)
            return Entries;

        var lines = await File.ReadAllLinesAsync(path);
        if (lines.Length < 2)
            return new List<RuneWord>();

        var header = lines[0].Split('\t');
        var columnMap = header
            .Select((name, index) => new { name = name.Trim(), index })
            .ToDictionary(x => x.name, x => x.index, StringComparer.OrdinalIgnoreCase);

        Entries = lines
            .Skip(1)
            .Select(line => line.Split('\t'))
            .Where(columns => columns.Length >= header.Length)
            .Select(columns => new RuneWord
            {
                Name = columns.GetValue(columnMap, "Name"),
                RuneName = columns.GetValue(columnMap, "*Rune Name"),
                Complete = columns.GetValue(columnMap, "complete").ToNullableInt(),
                FirstLadderSeason = columns.GetValue(columnMap, "firstLadderSeason").ToNullableInt(),
                LastLadderSeason = columns.GetValue(columnMap, "lastLadderSeason").ToNullableInt(),
                PatchRelease = columns.GetValue(columnMap, "*Patch Release"),

                ItemType1 = columns.GetValue(columnMap, "itype1"),
                ItemType2 = columns.GetValue(columnMap, "itype2"),
                ItemType3 = columns.GetValue(columnMap, "itype3"),
                ItemType4 = columns.GetValue(columnMap, "itype4"),
                ItemType5 = columns.GetValue(columnMap, "itype5"),
                ItemType6 = columns.GetValue(columnMap, "itype6"),

                ExcludeItemType1 = columns.GetValue(columnMap, "etype1"),
                ExcludeItemType2 = columns.GetValue(columnMap, "etype2"),
                ExcludeItemType3 = columns.GetValue(columnMap, "etype3"),

                RunesUsed = columns.GetValue(columnMap, "*RunesUsed"),
                Rune1 = columns.GetValue(columnMap, "Rune1"),
                Rune2 = columns.GetValue(columnMap, "Rune2"),
                Rune3 = columns.GetValue(columnMap, "Rune3"),
                Rune4 = columns.GetValue(columnMap, "Rune4"),
                Rune5 = columns.GetValue(columnMap, "Rune5"),
                Rune6 = columns.GetValue(columnMap, "Rune6"),

                Mods = Enumerable.Range(1, 7)
                    .Select(i => new RuneWordMod
                    {
                        Code = columns.GetValue(columnMap, $"T1Code{i}"),
                        Param = columns.GetValue(columnMap, $"T1Param{i}"),
                        Min = columns.GetValue(columnMap, $"T1Min{i}").ToNullableInt(),
                        Max = columns.GetValue(columnMap, $"T1Max{i}").ToNullableInt()
                    })
                    .ToList()
            })
            .ToList();

        return Entries;
    }
}