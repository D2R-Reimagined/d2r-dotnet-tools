using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class StatesParser
{
    public static async Task<IList<States>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new States
            {
                StateId = columns[0],
                Id = columns[1].ToNullableInt(),
                Group = columns[2],
                Remhit = columns[3],
                Nosend = columns[4],
                Transform = columns[5],
                Aura = columns[6],
                Curable = columns[7],
                Curse = columns[8],
                Active = columns[9],
                Restrict = columns[10],
                Disguise = columns[11],
                AttBlue = columns[12],
                DamBlue = columns[13],
                ArmBlue = columns[14],
                RfBlue = columns[15],
                RlBlue = columns[16],
                RcBlue = columns[17],
                StambarBlue = columns[18],
                RpBlue = columns[19],
                AttRed = columns[20],
                DamRed = columns[21],
                ArmRed = columns[22],
                RfRed = columns[23],
                RlRed = columns[24],
                RcRed = columns[25],
                RpRed = columns[26],
                Exp = columns[27],
                PlrStayDeath = columns[28],
                MonStayDeath = columns[29],
                BossStayDeath = columns[30],
                Hide = columns[31],
                HideDead = columns[32],
                Shatter = columns[33],
                UDead = columns[34],
                Life = columns[35],
                Green = columns[36],
                Pgsv = columns[37],
                NoOverlays = columns[38],
                NoClear = columns[39],
                BossInv = columns[40],
                MeleeOnly = columns[41],
                NotOnDead = columns[42],
                Overlay1 = columns[43],
                Overlay2 = columns[44],
                Overlay3 = columns[45],
                Overlay4 = columns[46],
                PgsvOverlay = columns[47],
                CastOverlay = columns[48],
                RemOverlay = columns[49],
                Stat = columns[50],
                SetFunc = columns[51],
                RemFunc = columns[52],
                Missile = columns[53],
                Skill = columns[54],
                ItemType = columns[55],
                ItemTrans = columns[56],
                ColorPri = columns[57],
                ColorShift = columns[58],
                LightR = columns[59].ToNullableInt(),
                LightG = columns[60].ToNullableInt(),
                LightB = columns[61].ToNullableInt(),
                OnSound = columns[62],
                OffSound = columns[63],
                GfxType = columns[64],
                GfxClass = columns[65],
                CltEvent = columns[66],
                CltEventFunc = columns[67],
                CltActiveFunc = columns[68],
                SrvActiveFunc = columns[69],
                CanStack = columns[70],
                SunderFull = columns[71],
                SunderResReduce = columns[72]
            })
            .ToList();
    }
}
