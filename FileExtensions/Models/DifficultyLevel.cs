namespace D2RReimaginedTools.Models;
public class DifficultyLevel
{
    public string Name { get; set; } = string.Empty;
    public int ResistPenalty { get; set; }
    public int ResistPenaltyNonExpansion { get; set; }
    public int DeathExpPenalty { get; set; }
    public int MonsterSkillBonus { get; set; }
    public int MonsterFreezeDivisor { get; set; }
    public int MonsterColdDivisor { get; set; }
    public int AiCurseDivisor { get; set; }
    public int LifeStealDivisor { get; set; }
    public int ManaStealDivisor { get; set; }
    public int UniqueDamageBonus { get; set; }
    public int ChampionDamageBonus { get; set; }
    public int PlayerDamagePercentVSPlayer { get; set; }
    public int PlayerDamagePercentVSMercenary { get; set; }
    public int PlayerDamagePercentVSPrimeEvil { get; set; }
    public int PlayerHitReactBufferVSPlayer { get; set; }
    public int PlayerHitReactBufferVSMonster { get; set; }
    public int MercenaryDamagePercentVSPlayer { get; set; }
    public int MercenaryDamagePercentVSMercenary { get; set; }
    public int MercenaryDamagePercentVSBoss { get; set; }
    public int MercenaryMaxStunLength { get; set; }
    public int PrimeEvilDamagePercentVSPlayer { get; set; }
    public int PrimeEvilDamagePercentVSMercenary { get; set; }
    public int PrimeEvilDamagePercentVSPet { get; set; }
    public int PetDamagePercentVSPlayer { get; set; }
    public int MonsterCEDamagePercent { get; set; }
    public int MonsterFireEnchantExplosionDamagePercent { get; set; }
    public int StaticFieldMin { get; set; }
    public int GambleRare { get; set; }
    public int GambleSet { get; set; }
    public int GambleUnique { get; set; }
    public int GambleUber { get; set; }
    public int GambleUltra { get; set; }
}
