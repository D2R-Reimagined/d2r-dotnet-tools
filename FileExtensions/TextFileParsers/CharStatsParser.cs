using D2RReimaginedTools.Models;
using D2RReimaginedTools.Extensions;

namespace D2RReimaginedTools.FileParsers;

public static class CharStatsParser
{
    public static async Task<IList<CharStats>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1);
        return lines
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Split('\t'))
            .Where(c => c.Length > 10)
            .Select(c =>
            {
                var stats = new CharStats
                {
                    Class = c[0],
                    Strength = c[1].ToInt(),
                    Dexterity = c[2].ToInt(),
                    Intelligence = c[3].ToInt(),
                    Vitality = c[4].ToInt(),
                    Stamina = c[5].ToInt(),
                    HpAdd = c[6].ToInt(),
                    ManaRegen = c[7].ToInt(),
                    ToHitFactor = c[8].ToInt(),
                    WalkVelocity = c[9].ToInt(),
                    RunVelocity = c[10].ToInt(),
                    RunDrain = c[11].ToInt(),
                    Comment = c[12],

                    LifePerLevel = c[13].ToInt(),
                    StaminaPerLevel = c[14].ToInt(),
                    ManaPerLevel = c[15].ToInt(),
                    LifePerVitality = c[16].ToInt(),
                    StaminaPerVitality = c[17].ToInt(),
                    ManaPerMagic = c[18].ToInt(),

                    StatPerLevel = c[19].ToInt(),
                    SkillsPerLevel = c[20].ToInt(),
                    LightRadius = c[21].ToInt(),
                    BlockFactor = c[22].ToInt(),
                    MinimumCastingDelay = c[23].ToInt(),

                    StartSkill = c[24],
                    StartingSkills = c.Skip(25).Take(10).ToList(),
                    StrSkillTabs = c.Skip(35).Take(3).ToList(),
                    StrClassOnly = c[38],
                    HealthPotionPercent = c[39].ToInt(),
                    ManaPotionPercent = c[40].ToInt(),
                    BaseWClass = c[41]
                };

                // Parse 10 item slots, 4 values each
                for (int i = 0; i < 10; i++)
                {
                    var index = 42 + i * 4;
                    if (index + 3 >= c.Length) break;

                    var item = new CharItem
                    {
                        Code = c[index],
                        Location = c[index + 1],
                        Count = c[index + 2].ToInt(),
                        Quality = c[index + 3].ToInt()
                    };
                    stats.StartingItems.Add(item);
                }

                return stats;
            })
            .ToList();
    }
}
