using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class MiscParser
{
    public static async Task<IList<Misc>> GetEntries(string path)
    {
        var lines = await File.ReadAllLinesAsync(path);
        if (lines.Length == 0) return new List<Misc>();

        var header = lines[0].Split('\t');
        var columnMap = header
            .Select((name, index) => new { name, index })
            .ToDictionary(x => x.name.Trim(), x => x.index, StringComparer.OrdinalIgnoreCase);

        return lines
            .Skip(1)
            .Select(line => line.Split('\t'))
            .Where(columns => columns.Length >= header.Length) // optional safety check
            .Select(columns => new Misc
            {
                Name = columns.GetValue(columnMap, "name"),
                Version = columns.GetValue(columnMap, "version").ToInt(),
                CompactSave = columns.GetValue(columnMap, "compactsave").ToInt(),
                Rarity = columns.GetValue(columnMap, "rarity").ToInt(),
                Spawnable = columns.GetValue(columnMap, "spawnable").ToBool(),
                MinAC = columns.GetValue(columnMap, "minac").ToInt(),
                MaxAC = columns.GetValue(columnMap, "maxac").ToInt(),
                Speed = columns.GetValue(columnMap, "speed").ToInt(),
                ReqStr = columns.GetValue(columnMap, "reqstr").ToInt(),
                ReqDex = columns.GetValue(columnMap, "reqdex").ToInt(),
                Block = columns.GetValue(columnMap, "block").ToInt(),
                Durability = columns.GetValue(columnMap, "durability").ToInt(),
                NoDurability = columns.GetValue(columnMap, "nodurability").ToInt(),
                Level = columns.GetValue(columnMap, "level").ToInt(),
                ShowLevel = columns.GetValue(columnMap, "showlevel").ToBool(),
                LevelReq = columns.GetValue(columnMap, "levelreq").ToInt(),
                Cost = columns.GetValue(columnMap, "cost").ToInt(),
                GambleCost = columns.GetValue(columnMap, "gamble cost").ToInt(),
                Code = columns.GetValue(columnMap, "code"),
                AlternateGfx = columns.GetValue(columnMap, "alternategfx"),
                NameStr = columns.GetValue(columnMap, "namestr"),
                MagicLvl = columns.GetValue(columnMap, "magiclvl").ToInt(),
                AutoPrefix = columns.GetValue(columnMap, "auto prefix").ToInt(),
            })
            .ToList();
    }
}
