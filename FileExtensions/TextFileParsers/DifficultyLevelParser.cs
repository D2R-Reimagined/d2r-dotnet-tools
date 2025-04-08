namespace D2RReimaginedTools.TextFileParsers;

using System.IO;
using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

public static class DifficultyLevelParser
{
    public static async Task<IList<DifficultyLevel>> GetEntries(string filePath)
    {
        var lines = (await File.ReadAllLinesAsync(filePath)).Skip(1); // skip header

        return lines.Select(line => line.Split('\t'))
            .Select(columns => new DifficultyLevel
            {
                Name = columns[0],
                ResistPenalty = columns[1].ToInt(),
                ResistPenaltyNonExpansion = columns[2].ToInt(),
                DeathExpPenalty = columns[3].ToInt(),
                MonsterSkillBonus = columns[4].ToInt(),
                MonsterFreezeDivisor = columns[5].ToInt(),
                MonsterColdDivisor = columns[6].ToInt(),
                AiCurseDivisor = columns[7].ToInt(),
                LifeStealDivisor = columns[8].ToInt(),
                ManaStealDivisor = columns[9].ToInt(),
                UniqueDamageBonus = columns[10].ToInt(),
                ChampionDamageBonus = columns[11].ToInt(),
                PlayerDamagePercentVSPlayer = columns[12].ToInt(),
                PlayerDamagePercentVSMercenary = columns[13].ToInt(),
                PlayerDamagePercentVSPrimeEvil = columns[14].ToInt(),
                PlayerHitReactBufferVSPlayer = columns[15].ToInt(),
                PlayerHitReactBufferVSMonster = columns[16].ToInt(),
                MercenaryDamagePercentVSPlayer = columns[17].ToInt(),
                MercenaryDamagePercentVSMercenary = columns[18].ToInt(),
                MercenaryDamagePercentVSBoss = columns[19].ToInt(),
                MercenaryMaxStunLength = columns[20].ToInt(),
                PrimeEvilDamagePercentVSPlayer = columns[21].ToInt(),
                PrimeEvilDamagePercentVSMercenary = columns[22].ToInt(),
                PrimeEvilDamagePercentVSPet = columns[23].ToInt(),
                PetDamagePercentVSPlayer = columns[24].ToInt(),
                MonsterCEDamagePercent = columns[25].ToInt(),
                MonsterFireEnchantExplosionDamagePercent = columns[26].ToInt(),
                StaticFieldMin = columns[27].ToInt(),
                GambleRare = columns[28].ToInt(),
                GambleSet = columns[29].ToInt(),
                GambleUnique = columns[30].ToInt(),
                GambleUber = columns[31].ToInt(),
                GambleUltra = columns[32].ToInt(),
            }).ToList();
    }
}
