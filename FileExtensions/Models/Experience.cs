namespace D2RReimaginedTools.Models;

public record Experience
{
    public int Level { get; set; }

    public uint Amazon { get; set; }
    public uint Sorceress { get; set; }
    public uint Necromancer { get; set; }
    public uint Paladin { get; set; }
    public uint Barbarian { get; set; }
    public uint Druid { get; set; }
    public uint Assassin { get; set; }

    public int ExpRatio { get; set; }
}
