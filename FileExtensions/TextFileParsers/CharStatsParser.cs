using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class CharStatsParser
{
    public static async Task<IList<CharStats>> GetEntries(string path)
    {
        var lines = (await TextFileParserFileUtility.ReadAllLinesAsync(typeof(CharStatsParser), path)).Skip(1); // Skip header

        return lines.Select(line => line.Split('\t'))
            .Where(columns => columns.Length > 10)
            .Select(columns => new CharStats
            {
                Class = columns[0],
                Strength = columns[1].ToInt(),
                Dexterity = columns[2].ToInt(),
                Intelligence = columns[3].ToInt(),
                Vitality = columns[4].ToInt(),
                Stamina = columns[5].ToInt(),
                HpAdd = columns[6].ToInt(),
                ManaRegen = columns[7].ToInt(),
                ToHitFactor = columns[8].ToInt(),
                WalkVelocity = columns[9].ToInt(),
                RunVelocity = columns[10].ToInt(),
                RunDrain = columns[11].ToInt(),
                Comment = columns[12],
                LifePerLevel = columns[13].ToInt(),
                StaminaPerLevel = columns[14].ToInt(),
                ManaPerLevel = columns[15].ToInt(),
                LifePerVitality = columns[16].ToInt(),
                StaminaPerVitality = columns[17].ToInt(),
                ManaPerMagic = columns[18].ToInt(),
                StatPerLevel = columns[19].ToInt(),
                SkillsPerLevel = columns[20].ToInt(),
                LightRadius = columns[21].ToInt(),
                BlockFactor = columns[22].ToInt(),
                MinimumCastingDelay = columns[23].ToInt(),
                StartSkill = columns[24],
                Skill1 = columns[25],
                Skill2 = columns[26],
                Skill3 = columns[27],
                Skill4 = columns[28],
                Skill5 = columns[29],
                Skill6 = columns[30],
                Skill7 = columns[31],
                Skill8 = columns[32],
                Skill9 = columns[33],
                Skill10 = columns[34],
                StrAllSkills = columns[35],
                StrSkillTab1 = columns[36],
                StrSkillTab2 = columns[37],
                StrSkillTab3 = columns[38],
                StrClassOnly = columns[39],
                HealthPotionPercent = columns[40].ToInt(),
                ManaPotionPercent = columns[41].ToInt(),
                BaseWeaponClass = columns[42],
                Item1 = columns[43],
                Item1Location = columns[44],
                Item1Count = columns[45].ToInt(),
                Item1Quality = columns[46].ToInt(),
                Item2 = columns[47],
                Item2Location = columns[48],
                Item2Count = columns[49].ToInt(),
                Item2Quality = columns[50].ToInt(),
                Item3 = columns[51],
                Item3Location = columns[52],
                Item3Count = columns[53].ToInt(),
                Item3Quality = columns[54].ToInt(),
                Item4 = columns[55],
                Item4Location = columns[56],
                Item4Count = columns[57].ToInt(),
                Item4Quality = columns[58].ToInt(),
                Item5 = columns[59],
                Item5Location = columns[60],
                Item5Count = columns[61].ToInt(),
                Item5Quality = columns[62].ToInt(),
                Item6 = columns[63],
                Item6Location = columns[64],
                Item6Count = columns[65].ToInt(),
                Item6Quality = columns[66].ToInt(),
                Item7 = columns[67],
                Item7Location = columns[68],
                Item7Count = columns[69].ToInt(),
                Item7Quality = columns[70].ToInt(),
                Item8 = columns[71],
                Item8Location = columns[72],
                Item8Count = columns[73].ToInt(),
                Item8Quality = columns[74].ToInt(),
                Item9 = columns[75],
                Item9Location = columns[76],
                Item9Count = columns[77].ToInt(),
                Item9Quality = columns[78].ToInt(),
                Item10 = columns[79],
                Item10Location = columns[80],
                Item10Count = columns[81].ToInt(),
                Item10Quality = columns[82].ToInt(),
            }).ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<CharStats> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<CharStats>(typeof(CharStatsParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

