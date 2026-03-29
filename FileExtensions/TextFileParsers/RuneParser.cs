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

        var lines = await TextFileParserFileUtility.ReadAllLinesAsync(typeof(RunesParser), path);
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
                DisallowCraftingInLadder = columns.GetValue(columnMap, "disallowCraftingInLadder").ToNullableInt(),
                DisallowCraftingInNonLadder = columns.GetValue(columnMap, "disallowCraftingInNonLadder").ToNullableInt(),
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
                T1Code1 = columns.GetValue(columnMap, "T1Code1"),
                T1Param1 = columns.GetValue(columnMap, "T1Param1"),
                T1Min1 = columns.GetValue(columnMap, "T1Min1").ToNullableInt(),
                T1Max1 = columns.GetValue(columnMap, "T1Max1").ToNullableInt(),
                T1Code2 = columns.GetValue(columnMap, "T1Code2"),
                T1Param2 = columns.GetValue(columnMap, "T1Param2"),
                T1Min2 = columns.GetValue(columnMap, "T1Min2").ToNullableInt(),
                T1Max2 = columns.GetValue(columnMap, "T1Max2").ToNullableInt(),
                T1Code3 = columns.GetValue(columnMap, "T1Code3"),
                T1Param3 = columns.GetValue(columnMap, "T1Param3"),
                T1Min3 = columns.GetValue(columnMap, "T1Min3").ToNullableInt(),
                T1Max3 = columns.GetValue(columnMap, "T1Max3").ToNullableInt(),
                T1Code4 = columns.GetValue(columnMap, "T1Code4"),
                T1Param4 = columns.GetValue(columnMap, "T1Param4"),
                T1Min4 = columns.GetValue(columnMap, "T1Min4").ToNullableInt(),
                T1Max4 = columns.GetValue(columnMap, "T1Max4").ToNullableInt(),
                T1Code5 = columns.GetValue(columnMap, "T1Code5"),
                T1Param5 = columns.GetValue(columnMap, "T1Param5"),
                T1Min5 = columns.GetValue(columnMap, "T1Min5").ToNullableInt(),
                T1Max5 = columns.GetValue(columnMap, "T1Max5").ToNullableInt(),
                T1Code6 = columns.GetValue(columnMap, "T1Code6"),
                T1Param6 = columns.GetValue(columnMap, "T1Param6"),
                T1Min6 = columns.GetValue(columnMap, "T1Min6").ToNullableInt(),
                T1Max6 = columns.GetValue(columnMap, "T1Max6").ToNullableInt(),
                T1Code7 = columns.GetValue(columnMap, "T1Code7"),
                T1Param7 = columns.GetValue(columnMap, "T1Param7"),
                T1Min7 = columns.GetValue(columnMap, "T1Min7").ToNullableInt(),
                T1Max7 = columns.GetValue(columnMap, "T1Max7").ToNullableInt(),
                Eol = columns.GetValue(columnMap, "*eol").ToNullableInt(),

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


    public static Task<FileInfo> SaveEntries(IList<RuneWord> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<RuneWord>(typeof(RunesParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

