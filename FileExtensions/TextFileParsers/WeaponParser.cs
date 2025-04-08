using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class WeaponParser
{
    public static async Task<IList<Weapon>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1);

        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Weapon
            {
                Name = columns[0],
                Type = columns[1],
                Type2 = columns[2],
                Code = columns[3],
                AlternateGfx = columns[4],
                NameStr = columns[5],
                Version = columns[6].ToNullableInt(),
                CompactSave = columns[7].ToNullableInt(),
                Rarity = columns[8].ToNullableInt(),
                Spawnable = columns[9].ToBool(),
                Transmogrify = columns[10].ToNullableInt(),
                TMogType = columns[11],
                TMogMin = columns[12].ToNullableInt(),
                TMogMax = columns[13].ToNullableInt(),
                MinDam = columns[14].ToNullableInt(),
                MaxDam = columns[15].ToNullableInt(),
                OneOrTwoHanded = columns[16].ToNullableInt(), // Add to Weapon model if needed
                TwoHanded = columns[17].ToBool(),
                TwoHandMinDam = columns[18].ToNullableInt(),
                TwoHandMaxDam = columns[19].ToNullableInt(),
                MinMisDam = columns[20].ToNullableInt(),
                MaxMisDam = columns[21].ToNullableInt(),
                RangeAdder = columns[22].ToNullableInt(),
                Speed = columns[23].ToNullableInt(),
                StrBonus = columns[24].ToNullableInt(),
                DexBonus = columns[25].ToNullableInt(),
                ReqStr = columns[26].ToNullableInt(),
                ReqDex = columns[27].ToNullableInt(),
                Durability = columns[28].ToNullableInt(),
                NoDurability = columns[29].ToNullableInt(),
                Level = columns[30].ToNullableInt(),
                ShowLevel = columns[31].ToBool(),
                LevelReq = columns[32].ToNullableInt(),
                Cost = columns[33].ToNullableInt(),
                GambleCost = columns[34].ToNullableInt(),
                MagicLvl = columns[35].ToInt(),
                AutoPrefix = columns[36].ToInt(),
                NormCode = columns[37],
                UberCode = columns[38],
                UltraCode = columns[39],
                WClass = columns[40],
                TwoHandedWClass = columns[41],
                Component = columns[42].ToNullableInt(),
                HitClass = columns[43],
                InvWidth = columns[44].ToNullableInt(),
                InvHeight = columns[45].ToNullableInt(),
                Stackable = columns[46].ToBool(),
                MinStack = columns[47].ToNullableInt(),
                MaxStack = columns[48].ToNullableInt(),
                SpawnStack = columns[49].ToNullableInt(),
                FlippyFile = columns[50],
                InvFile = columns[51],
                UniqueInvFile = columns[52],
                SetInvFile = columns[53],
                HasInv = columns[54].ToBool(),
                GemSockets = columns[55].ToNullableInt(),
                GemApplyType = columns[56].ToNullableInt(),
                // Skipping *comment (57), not used in model
                Useable = columns[58].ToBool(),
                DropSound = columns[59],
                DropSfxFrame = columns[60].ToInt(),
                UseSound = columns[61],
                Unique = columns[62].ToNullableInt(),
                Transparent = columns[63].ToNullableInt(),
                TransTbl = columns[64].ToNullableInt(),
                Quivered = columns[65].ToNullableInt(),
                LightRadius = columns[66].ToNullableInt(),
                Belt = columns[67].ToNullableInt(),
                Quest = columns[68].ToNullableInt(),
                QuestDiffCheck = columns[69].ToNullableInt(),
                MissileType = columns[70].ToNullableInt(),
                DurWarning = columns[71].ToNullableInt(),
                QntWarning = columns[72].ToNullableInt(),
                GemOffset = columns[73].ToNullableInt(),
                BitField1 = columns[74].ToNullableInt(),

                // Add vendor fields 75+ like:
                CharsiMin = columns[75].ToNullableInt(),
                CharsiMax = columns[76].ToNullableInt(),
                CharsiMagicMin = columns[77].ToNullableInt(),
                CharsiMagicMax = columns[78].ToNullableInt(),
                CharsiMagicLvl = columns[79].ToNullableInt(),
                GheedMin = columns[80].ToNullableInt(),
                GheedMax = columns[81].ToNullableInt(),
                GheedMagicMin = columns[82].ToNullableInt(),
                GheedMagicMax = columns[83].ToNullableInt(),
                GheedMagicLvl = columns[84].ToNullableInt(),
                // etc... you can fill in the rest as needed

                Transform = columns[160],
                InvTrans = columns[161],
                SkipName = columns[162].ToNullableInt(),
                NightmareUpgrade = columns[163],
                HellUpgrade = columns[164],
                Nameable = columns[165].ToNullableInt(),
                PermStoreItem = columns[166].ToNullableInt(),
                DiabloCloneWeight = columns[167].ToNullableInt(),
            }).ToList();
    }
}
