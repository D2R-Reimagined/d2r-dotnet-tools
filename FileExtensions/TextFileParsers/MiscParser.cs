using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class MiscParser
{
    public static async Task<IList<Misc>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line

        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Misc
            {
                Name = columns[0],
                Version = columns[1].ToInt(),
                CompactSave = columns[2].ToInt(),
                Rarity = columns[3].ToInt(),
                Spawnable = columns[4].ToBool(),
                MinAC = columns[5].ToInt(),
                MaxAC = columns[6].ToInt(),
                Speed = columns[7].ToInt(),
                ReqStr = columns[8].ToInt(),
                ReqDex = columns[9].ToInt(),
                Block = columns[10].ToInt(),
                Durability = columns[11].ToInt(),
                NoDurability = columns[12].ToInt(),
                Level = columns[13].ToInt(),
                ShowLevel = columns[14].ToBool(),
                LevelReq = columns[15].ToInt(),
                Cost = columns[16].ToInt(),
                GambleCost = columns[17].ToInt(),
                Code = columns[18],
                NameStr = columns[19],
                MagicLvl = columns[20].ToInt(),
                AutoPrefix = columns[21].ToInt(),
                AlternateGfx = columns[22],
            }).ToList();
    }
}