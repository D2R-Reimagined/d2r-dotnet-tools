namespace D2RReimaginedTools.Models;

public record ItemType
    {
        public string ItemTypeName { get; init; }
        public string Code { get; init; }
        public string Equiv1 { get; init; }
        public string Equiv2 { get; init; }
        public bool Repair { get; init; }
        public bool Body { get; init; }
        public string BodyLoc1 { get; init; }
        public string BodyLoc2 { get; init; }
        public string Shoots { get; init; }
        public string Quiver { get; init; }
        public bool Throwable { get; init; }
        public bool Reload { get; init; }
        public bool ReEquip { get; init; }
        public bool AutoStack { get; init; }
        public bool Magic { get; init; }
        public bool Rare { get; init; }
        public bool Normal { get; init; }
        public bool Beltable { get; init; }
        public int MaxSockets1 { get; init; }
        public int MaxSocketsLevelThreshold1 { get; init; }
        public int MaxSockets2 { get; init; }
        public int MaxSocketsLevelThreshold2 { get; init; }
        public int MaxSockets3 { get; init; }
        public string TreasureClass { get; init; }
        public int Rarity { get; init; }
        public bool StaffMods { get; init; }
        public string Class { get; init; }
        public string VarInvGfx { get; init; }
        public string InvGfx1 { get; init; }
        public string InvGfx2 { get; init; }
        public string InvGfx3 { get; init; }
        public string InvGfx4 { get; init; }
        public string InvGfx5 { get; init; }
        public string InvGfx6 { get; init; }
        public string StorePage { get; init; }
}
