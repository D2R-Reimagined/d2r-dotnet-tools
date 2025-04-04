namespace D2RReimaginedTools.Models;

public record CharStats
{
    public string Class { get; set; } = string.Empty;
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Vitality { get; set; }
    public int Stamina { get; set; }
    public int HpAdd { get; set; }
    public int ManaRegen { get; set; }
    public int ToHitFactor { get; set; }
    public int WalkVelocity { get; set; }
    public int RunVelocity { get; set; }
    public int RunDrain { get; set; }

    public string Comment { get; set; }

    public int LifePerLevel { get; set; }
    public int StaminaPerLevel { get; set; }
    public int ManaPerLevel { get; set; }
    public int LifePerVitality { get; set; }
    public int StaminaPerVitality { get; set; }
    public int ManaPerMagic { get; set; }

    public int StatPerLevel { get; set; }
    public int SkillsPerLevel { get; set; }

    public int LightRadius { get; set; }
    public int BlockFactor { get; set; }
    public int MinimumCastingDelay { get; set; }

    public string? StartSkill { get; set; }
    public List<string?> StartingSkills { get; set; } = new();
    public List<string?> StrSkillTabs { get; set; } = new();

    public string? StrClassOnly { get; set; }
    public int HealthPotionPercent { get; set; }
    public int ManaPotionPercent { get; set; }

    public string? BaseWClass { get; set; }

    public List<CharItem?> StartingItems { get; set; } = new();
}

public record CharItem
{
    public string? Code { get; set; }
    public string? Location { get; set; }
    public int Count { get; set; }
    public int Quality { get; set; }
}
