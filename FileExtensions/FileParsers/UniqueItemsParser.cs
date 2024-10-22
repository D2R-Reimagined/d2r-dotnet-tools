using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.FileParsers;

public class UniqueItemsParser
{
    public async Task<IList<UniqueItem>> GetUniqueItems(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line

        return lines.Select(line => line.Split('\t'))
            .Select(columns => new UniqueItem
            {
                Index = columns[0],
                ID = columns[1].ToInt(),
                Version = columns[2].ToInt(),
                Enabled = columns[3].ToBool(),
                FirstLadderSeason = columns[4].ToInt(),
                LastLadderSeason = columns[5].ToInt(),
                Rarity = columns[6].ToInt(),
                NoLimit = columns[7].ToBool(),
                Level = columns[8].ToInt(),
                LevelRequirement = columns[9].ToInt(),
                Code = columns[10],
                ItemName = columns[11],
                Carry1 = columns[12].ToBool(),
                CostMultiplier = columns[13].ToInt(),
                CostAdd = columns[14].ToInt(),
                ChrTransform = columns[15],
                InvTransform = columns[16],
                FlippyFile = columns[17],
                InvFile = columns[18],
                DropSound = columns[19],
                DropSfxFrame = columns[20].ToInt(),
                UseSound = columns[21],
                DiabloCloneWeight = columns[70].ToInt(),
                Eol = columns[71].ToInt()
            })
            .ToList();
    }
}