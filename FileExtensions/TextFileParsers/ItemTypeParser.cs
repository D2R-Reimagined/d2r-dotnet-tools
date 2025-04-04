using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class ItemTypeParser
{
    public static async Task<IList<ItemTypeModel>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header

        return lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Split('\t'))
            .Select(columns => new ItemTypeModel
            {
                ItemType = columns[0],
                Code = columns[1],
                Equiv1 = columns[2],
                Equiv2 = columns[3],
                Repair = columns[4].ToInt(),
                Body = columns[5].ToInt(),
                BodyLoc1 = columns[6],
                BodyLoc2 = columns[7],
                Shoots = columns[8],
                Quiver = columns[9],
                Throwable = columns[10].ToBool(),
                Reload = columns[11].ToBool(),
                ReEquip = columns[12].ToBool(),
                AutoStack = columns[13].ToBool(),
                Magic = columns[14].ToBool(),
                Rare = columns[15].ToBool(),
                Normal = columns[16].ToBool(),
                Beltable = columns[17].ToBool(),
                MaxSockets1 = columns[18].ToInt(),
                MaxSocketsLevelThreshold1 = columns[19].ToInt(),
                MaxSockets2 = columns[20].ToInt(),
                MaxSocketsLevelThreshold2 = columns[21].ToInt(),
                MaxSockets3 = columns[22].ToInt(),
                TreasureClass = columns[23],
                Rarity = columns[24].ToInt(),
                StaffMods = columns[25],
                Class = columns[26],
                VarInvGfx = columns[27],
                InvGfx1 = columns[28],
                InvGfx2 = columns[29],
                InvGfx3 = columns[30],
                InvGfx4 = columns[31],
                InvGfx5 = columns[32],
                InvGfx6 = columns[33],
                StorePage = columns[34],
            }).ToList();
    }
}
