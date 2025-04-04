using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.FileParsers;

public class CharStatsParser
{
    public static async Task<IList<CharStats>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header

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
            }).ToList();
    }
}
