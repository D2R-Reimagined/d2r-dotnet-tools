using System.IO;
using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

public static class HirelingParser
{
    public static List<Hirelings> Parse(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        return lines
            .Skip(1) // skip header
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line =>
            {
                var columns = line.Split('\t');

                return new Hirelings
                {
                    Hireling = columns[0],
                    SubType = columns[1],
                    Version = columns[2].ToNullableInt(),
                    Id = columns[3].ToNullableInt(),
                    Class = columns[4].ToNullableInt(),
                    Act = columns[5].ToNullableInt(),
                    Difficulty = columns[6].ToNullableInt(),
                    Level = columns[7].ToNullableInt(),
                    Seller = columns[8].ToNullableInt(),
                    NameFirst = columns[9],
                    NameLast = columns[10],
                    Gold = columns[11].ToNullableInt(),
                    ExpPerLevel = columns[12].ToNullableInt(),
                    HP = columns[13].ToNullableInt(),
                    HPPerLevel = columns[14].ToNullableInt(),
                    Defense = columns[15].ToNullableInt(),
                    DefensePerLevel = columns[16].ToNullableInt(),
                    Strength = columns[17].ToNullableInt(),
                    StrengthPerLevel = columns[18].ToNullableInt(),
                    Dexterity = columns[19].ToNullableInt(),
                    DexterityPerLevel = columns[20].ToNullableInt(),
                    AttackRating = columns[21].ToNullableInt(),
                    AttackRatingPerLevel = columns[22].ToNullableInt(),
                    DamageMinimum = columns[23].ToNullableInt(),
                    DamageMaximum = columns[24].ToNullableInt(),
                    DamagePerLevel = columns[25].ToNullableInt(),
                    ResistFire = columns[26].ToNullableInt(),
                    ResistFirePerLevel = columns[27].ToNullableInt(),
                    ResistCold = columns[28].ToNullableInt(),
                    ResistColdPerLevel = columns[29].ToNullableInt(),
                    ResistLightning = columns[30].ToNullableInt(),
                    ResistLightningPerLevel = columns[31].ToNullableInt(),
                    ResistPoison = columns[32].ToNullableInt(),
                    ResistPoisonPerLevel = columns[33].ToNullableInt(),
                    HireDescription = columns[34],
                    DefaultChance = columns[35].ToNullableInt(),
                    Skill1 = columns[36],
                    Mode1 = columns[37].ToNullableInt(),
                    Chance1 = columns[38].ToNullableInt(),
                    ChancePerLevel1 = columns[39].ToNullableInt(),
                    Level1 = columns[40].ToNullableInt(),
                    LevelPerLevel1 = columns[41].ToNullableInt(),
                    Skill2 = columns[42],
                    Mode2 = columns[43].ToNullableInt(),
                    Chance2 = columns[44].ToNullableInt(),
                    ChancePerLevel2 = columns[45].ToNullableInt(),
                    Level2 = columns[46].ToNullableInt(),
                    LevelPerLevel2 = columns[47].ToNullableInt(),
                    Skill3 = columns[48],
                    Mode3 = columns[49].ToNullableInt(),
                    Chance3 = columns[50].ToNullableInt(),
                    ChancePerLevel3 = columns[51].ToNullableInt(),
                    Level3 = columns[52].ToNullableInt(),
                    LevelPerLevel3 = columns[53].ToNullableInt(),
                    Skill4 = columns[54],
                    Mode4 = columns[55].ToNullableInt(),
                    Chance4 = columns[56].ToNullableInt(),
                    ChancePerLevel4 = columns[57].ToNullableInt(),
                    Level4 = columns[58].ToNullableInt(),
                    LevelPerLevel4 = columns[59].ToNullableInt(),
                    Skill5 = columns[60],
                    Mode5 = columns[61].ToNullableInt(),
                    Chance5 = columns[62].ToNullableInt(),
                    ChancePerLevel5 = columns[63].ToNullableInt(),
                    Level5 = columns[64].ToNullableInt(),
                    LevelPerLevel5 = columns[65].ToNullableInt(),
                    Skill6 = columns[66],
                    Mode6 = columns[67].ToNullableInt(),
                    Chance6 = columns[68].ToNullableInt(),
                    ChancePerLevel6 = columns[69].ToNullableInt(),
                    Level6 = columns[70].ToNullableInt(),
                    LevelPerLevel6 = columns[71].ToNullableInt(),
                    HiringMaxLevelDifference = columns[72].ToNullableInt(),
                    ResurrectCostMultiplier = columns[73].ToNullableInt(),
                    ResurrectCostDivisor = columns[74].ToNullableInt(),
                    ResurrectCostMaximum = columns[75].ToNullableInt(),
                    EquivalentCharacterClass = columns[76]
                };
            })
            .ToList();
    }
}
