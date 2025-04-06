namespace D2RReimaginedTools.TextFileParsers;

using D2RReimaginedTools.Models;
using D2RReimaginedTools.Extensions;

public static class TsvToSetItemExtensions
{
    public static SetItem ToSetItem(this string[] columns)
    {
        return new SetItem
        {
            Index = columns[0],
            Id = columns[1],
            Set = columns[2],
            Item = columns[3],
            ItemName = columns[4],
            Rarity = columns[5].ToNullableInt(),
            Level = columns[6].ToNullableInt(),
            LevelRequirement = columns[7].ToNullableInt(),
            CharacterTransform = columns[8],
            InventoryTransform = columns[9],
            InventoryFile = columns[10],
            FlippyFile = columns[11],
            DropSound = columns[12],
            DropSfxFrame = columns[13].ToNullableInt(),
            UseSound = columns[14],
            CostMultiplier = columns[15].ToNullableInt(),
            CostAdd = columns[16].ToNullableInt(),
            AddFunc = columns[17].ToNullableInt(),

            Properties = ExtractMods(columns, 18, 9),
            AdditionalProperties = ExtractMods(columns, 54, 10),

            DiabloCloneWeight = columns[94].ToNullableInt()
        };
    }

    private static List<SetItemMod> ExtractMods(string[] columns, int start, int count)
    {
        var mods = new List<SetItemMod>();
        for (int i = 0; i < count; i++)
        {
            int index = start + i * 4;
            mods.Add(new SetItemMod
            {
                Code = columns[index],
                Param = columns[index + 1],
                Min = columns[index + 2].ToNullableInt(),
                Max = columns[index + 3].ToNullableInt()
            });
        }
        return mods;
    }
}
