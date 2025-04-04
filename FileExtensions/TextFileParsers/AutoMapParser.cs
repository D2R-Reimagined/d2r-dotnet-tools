using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class LevelPresetPathingParser
{
    public static async Task<IList<LevelPresetPathing>> GetEntries(string path)
    {
        var columns = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header

        return columns.Select(columns => columns.Split('\t'))
            .Where(columns => columns.Length > 10)
            .Select(columns => new LevelPresetPathing
            {
                LevelName = columns[0],
                TileName = columns[1],
                Style = columns[2],
                StartSequence = columns[3].ToInt(),
                EndSequence = columns[4].ToInt(),

                Type1 = columns[5],
                Cel1 = columns[6].ToInt(),

                Type2 = columns[7],
                Cel2 = columns[8].ToInt(),

                Type3 = columns[9],
                Cel3 = columns[10].ToInt(),

                Type4 = columns[11],
                Cel4 = columns[12].ToInt(),
            }).ToList();
    }
}