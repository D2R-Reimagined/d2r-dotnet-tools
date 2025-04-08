namespace D2RReimaginedTools.Models;

public class SetItem
{
    public string? Index { get; set; }
    public string? Id { get; set; }
    public string? Set { get; set; }
    public string? Item { get; set; }
    public string? ItemName { get; set; }
    public int? Rarity { get; set; }
    public int? Level { get; set; }
    public int? LevelRequirement { get; set; }
    public string? CharacterTransform { get; set; }
    public string? InventoryTransform { get; set; }
    public string? InventoryFile { get; set; }
    public string? FlippyFile { get; set; }
    public string? DropSound { get; set; }
    public int? DropSfxFrame { get; set; }
    public string? UseSound { get; set; }
    public int? CostMultiplier { get; set; }
    public int? CostAdd { get; set; }
    public int? AddFunc { get; set; }

    public List<SetItemMod> Properties { get; set; } = new();
    public List<SetItemMod> AdditionalProperties { get; set; } = new();

    public int? DiabloCloneWeight { get; set; }
}
