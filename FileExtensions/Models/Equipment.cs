namespace D2RReimaginedTools.Models;

public record Equipment
{
    public string Name { get; set; }
    public int? Version { get; set; }
    public int? CompactSave { get; set; }
    public int? Rarity { get; set; }
    public bool Spawnable { get; set; }
    public int? MinAC { get; set; }
    public int? MaxAC { get; set; }
    public int? Speed { get; set; }
    public int? ReqStr { get; set; }
    public int? ReqDex { get; set; }
    public int? Block { get; set; }
    public int? Durability { get; set; }
    public int? NoDurability { get; set; }
    public int? Level { get; set; }
    public bool? ShowLevel { get; set; }
    public int? LevelReq { get; set; }
    public int? Cost { get; set; }
    public int? GambleCost { get; set; }
    public string Code { get; set; }
    public string NameStr { get; set; }
    public int MagicLvl { get; set; }
    public int AutoPrefix { get; set; }
    public string? AlternateGfx { get; set; }
    public string? NormCode { get; set; }
    public string? UberCode { get; set; }
    public string? UltraCode { get; set; }
    public int? Component { get; set; }
    public int? InvWidth { get; set; }
    public int? InvHeight { get; set; }
    public bool? HasInv { get; set; }
    public int? GemSockets { get; set; }
    public int? GemApplyType { get; set; }
    public string? FlippyFile { get; set; }
    public string? InvFile { get; set; }
    public string? UniqueInvFile { get; set; }
    public string? SetInvFile { get; set; }
    public string? RArm { get; set; }
    public string? LArm { get; set; }
    public string? Torso { get; set; }
    public string? Legs { get; set; }
    public string? RSPad { get; set; }
    public string? LSPad { get; set; }
    public bool? Useable { get; set; }
    public bool? Stackable { get; set; }
    public int? MinStack { get; set; }
    public int? MaxStack { get; set; }
    public int? SpawnStack { get; set; }
    public int? Transmogrify { get; set; }
    public string? TMogType { get; set; }
    public int? TMogMin { get; set; }
    public int? TMogMax { get; set; }
    public string Type { get; set; }
    public string? Type2 { get; set; }
    public string? DropSound { get; set; }
    public int DropSfxFrame { get; set; }
    public string? UseSound { get; set; }
    public int? Unique { get; set; }
    public int? Transparent { get; set; }
    public int? TransTbl { get; set; }
    public int? Quivered { get; set; }
    public int? LightRadius { get; set; }
    public int? Belt { get; set; }
    public int? Quest { get; set; }
    public int? QuestDiffCheck { get; set; }
    public int? MissileType { get; set; }
    public int? DurWarning { get; set; }
    public int? QntWarning { get; set; }
    public int? MinDam { get; set; }
    public int? MaxDam { get; set; }
    public int? StrBonus { get; set; }
    public int? DexBonus { get; set; }
    public int? GemOffset { get; set; }
    public int? BitField1 { get; set; }
    public int? CharsiMin { get; set; }
    public int? CharsiMax { get; set; }
    public int? CharsiMagicMin { get; set; }
    public int? CharsiMagicMax { get; set; }
    public int? CharsiMagicLvl { get; set; }
    public int? GheedMin { get; set; }
    public int? GheedMax { get; set; }
    public int? GheedMagicMin { get; set; }
    public int? GheedMagicMax { get; set; }
    public int? GheedMagicLvl { get; set; }
    public int? AkaraMin { get; set; }
    public int? AkaraMax { get; set; }
    public int? AkaraMagicMin { get; set; }
    public int? AkaraMagicMax { get; set; }
    public int? AkaraMagicLvl { get; set; }
    public int? FaraMin { get; set; }
    public int? FaraMax { get; set; }
    public int? FaraMagicMin { get; set; }
    public int? FaraMagicMax { get; set; }
    public int? FaraMagicLvl { get; set; }
    public int? LysanderMin { get; set; }
    public int? LysanderMax { get; set; }
    public int? LysanderMagicMin { get; set; }
    public int? LysanderMagicMax { get; set; }
    public int? LysanderMagicLvl { get; set; }
    public int? DrognanMin { get; set; }
    public int? DrognanMax { get; set; }
    public int? DrognanMagicMin { get; set; }
    public int? DrognanMagicMax { get; set; }
    public int? DrognanMagicLvl { get; set; }
    public int? HratliMin { get; set; }
    public int? HratliMax { get; set; }
    public int? HratliMagicMin { get; set; }
    public int? HratliMagicMax { get; set; }
    public int? HratliMagicLvl { get; set; }
    public int? AlkorMin { get; set; }
    public int? AlkorMax { get; set; }
    public int? AlkorMagicMin { get; set; }
    public int? AlkorMagicMax { get; set; }
    public int? AlkorMagicLvl { get; set; }
    public int? OrmusMin { get; set; }
    public int? OrmusMax { get; set; }
    public int? OrmusMagicMin { get; set; }
    public int? OrmusMagicMax { get; set; }
    public int? OrmusMagicLvl { get; set; }
    public int? ElzixMin { get; set; }
    public int? ElzixMax { get; set; }
    public int? ElzixMagicMin { get; set; }
    public int? ElzixMagicMax { get; set; }
    public int? ElzixMagicLvl { get; set; }
    public int? AshearaMin { get; set; }
    public int? AshearaMax { get; set; }
    public int? AshearaMagicMin { get; set; }
    public int? AshearaMagicMax { get; set; }
    public int? AshearaMagicLvl { get; set; }
    public int? CainMin { get; set; }
    public int? CainMax { get; set; }
    public int? CainMagicMin { get; set; }
    public int? CainMagicMax { get; set; }
    public int? CainMagicLvl { get; set; }
    public int? HalbuMin { get; set; }
    public int? HalbuMax { get; set; }
    public int? HalbuMagicMin { get; set; }
    public int? HalbuMagicMax { get; set; }
    public int? HalbuMagicLvl { get; set; }
    public int? JamellaMin { get; set; }
    public int? JamellaMax { get; set; }
    public int? JamellaMagicMin { get; set; }
    public int? JamellaMagicMax { get; set; }
    public int? JamellaMagicLvl { get; set; }
    public int? LarzukMin { get; set; }
    public int? LarzukMax { get; set; }
    public int? LarzukMagicMin { get; set; }
    public int? LarzukMagicMax { get; set; }
    public int? LarzukMagicLvl { get; set; }
    public int? MalahMin { get; set; }
    public int? MalahMax { get; set; }
    public int? MalahMagicMin { get; set; }
    public int? MalahMagicMax { get; set; }
    public int? MalahMagicLvl { get; set; }
    public int? AnyaMin { get; set; }
    public int? AnyaMax { get; set; }
    public int? AnyaMagicMin { get; set; }
    public int? AnyaMagicMax { get; set; }
    public int? AnyaMagicLvl { get; set; }
    public string? Transform { get; set; }
    public string? InvTrans { get; set; }
    public int? SkipName { get; set; }
    public string? NightmareUpgrade { get; set; }
    public string? HellUpgrade { get; set; }
    public int? Nameable { get; set; }
    public int? PermStoreItem { get; set; }
    public int? OneOrTwoHanded { get; set; }
    public bool? TwoHanded { get; set; }
    public int? TwoHandMinDam { get; set; }
    public int? TwoHandMaxDam { get; set; }
    public int? MinMisDam { get; set; }
    public int? MaxMisDam { get; set; }
    public int? RangeAdder { get; set; }
    public string? HitClass { get; set; }
    public string? Comment { get; set; }
    public string? WClass { get; set; }
    public string? TwoHandedWClass { get; set; }
    

    public int? DiabloCloneWeight { get; set; }
}