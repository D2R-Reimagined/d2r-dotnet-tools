namespace D2RReimaginedTools.Models;

public record ItemTypeModel
{
    public string? ItemType { get; set; }
    public string? Code { get; set; }
    public string? Equiv1 { get; set; }
    public string? Equiv2 { get; set; }
    public int? Repair { get; set; }
    public int? Body { get; set; }
    public string? BodyLoc1 { get; set; }
    public string? BodyLoc2 { get; set; }
    public string? Shoots { get; set; }
    public string? Quiver { get; set; }
    public bool? Throwable { get; set; }
    public bool? Reload { get; set; }
    public bool? ReEquip { get; set; }
    public bool? AutoStack { get; set; }
    public bool? Magic { get; set; }
    public bool? Rare { get; set; }
    public bool? Normal { get; set; }
    public bool? Beltable { get; set; }
    public int? MaxSockets1 { get; set; }
    public int? MaxSocketsLevelThreshold1 { get; set; }
    public int? MaxSockets2 { get; set; }
    public int? MaxSocketsLevelThreshold2 { get; set; }
    public int? MaxSockets3 { get; set; }
    public string? TreasureClass { get; set; }
    public int? Rarity { get; set; }
    public string? StaffMods { get; set; }
    public string? Class { get; set; }
    public string? VarInvGfx { get; set; }
    public string? InvGfx1 { get; set; }
    public string? InvGfx2 { get; set; }
    public string? InvGfx3 { get; set; }
    public string? InvGfx4 { get; set; }
    public string? InvGfx5 { get; set; }
    public string? InvGfx6 { get; set; }
    public string? StorePage { get; set; }
}
