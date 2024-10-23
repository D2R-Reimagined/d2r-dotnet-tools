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
                Properties = new List<ItemProperty>
                {
                    new() { Property = columns[22], Parameter = columns[23], Min = columns[24].ToInt(), Max = columns[25].ToInt() },
                    new() { Property = columns[26], Parameter = columns[27], Min = columns[28].ToInt(), Max = columns[29].ToInt() },
                    new() { Property = columns[30], Parameter = columns[31], Min = columns[32].ToInt(), Max = columns[33].ToInt() },
                    new() { Property = columns[34], Parameter = columns[35], Min = columns[36].ToInt(), Max = columns[37].ToInt() },
                    new() { Property = columns[38], Parameter = columns[39], Min = columns[40].ToInt(), Max = columns[41].ToInt() },
                    new() { Property = columns[42], Parameter = columns[43], Min = columns[44].ToInt(), Max = columns[45].ToInt() },
                    new() { Property = columns[46], Parameter = columns[47], Min = columns[48].ToInt(), Max = columns[49].ToInt() },
                    new() { Property = columns[50], Parameter = columns[51], Min = columns[52].ToInt(), Max = columns[53].ToInt() },
                    new() { Property = columns[54], Parameter = columns[55], Min = columns[56].ToInt(), Max = columns[57].ToInt() },
                    new() { Property = columns[58], Parameter = columns[59], Min = columns[60].ToInt(), Max = columns[61].ToInt() },
                    new() { Property = columns[62], Parameter = columns[63], Min = columns[64].ToInt(), Max = columns[65].ToInt() },
                    new() { Property = columns[66], Parameter = columns[67], Min = columns[68].ToInt(), Max = columns[69].ToInt() }
                },
                Eol = columns[71].ToInt()
            })
            .ToList();
    }
}