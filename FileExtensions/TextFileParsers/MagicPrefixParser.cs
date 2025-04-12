using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class MagicPrefixParser
{
    public static async Task<IList<MagicPrefix>> GetEntries(string path)
    {
        var lines = await File.ReadAllLinesAsync(path);
        if (lines.Length == 0) return new List<MagicPrefix>();

        var header = lines[0].Split('\t');
        var columnMap = header
            .Select((name, index) => new { name, index })
            .ToDictionary(x => x.name.Trim(), x => x.index, StringComparer.OrdinalIgnoreCase);

        return lines
            .Skip(1)
            .Select(line => line.Split('\t'))
            .Where(columns => columns.Length >= header.Length)
            .Select(columns => new MagicPrefix
            {
                Name = columns.GetValue(columnMap, "name"),
                Description = columns.GetValue(columnMap, "* Description"),
                Version = columns.GetValue(columnMap, "version").ToInt(),
                Spawnable = columns.GetValue(columnMap, "spawnable").ToBool(),
                Rare = columns.GetValue(columnMap, "rare").ToBool(),
                Level = columns.GetValue(columnMap, "level").ToInt(),
                MaxLevel = columns.GetValue(columnMap, "maxlevel").ToInt(),
                LevelReq = columns.GetValue(columnMap, "levelreq").ToInt(),
                ClassSpecific = columns.GetValue(columnMap, "classspecific").ToBool(),
                Class = columns.GetValue(columnMap, "class"),
                ClassLevelReq = columns.GetValue(columnMap, "classlevelreq").ToInt(),
                Frequency = columns.GetValue(columnMap, "frequency").ToInt(),
                Group = columns.GetValue(columnMap, "group").ToInt(),
                Mod1Code = columns.GetValue(columnMap, "mod1code"),
                Mod1Param = columns.GetValue(columnMap, "mod1param"),
                Mod1Min = columns.GetValue(columnMap, "mod1min").ToInt(),
                Mod1Max = columns.GetValue(columnMap, "mod1max").ToInt(),
                Mod2Code = columns.GetValue(columnMap, "mod2code"),
                Mod2Param = columns.GetValue(columnMap, "mod2param"),
                Mod2Min = columns.GetValue(columnMap, "mod2min").ToInt(),
                Mod2Max = columns.GetValue(columnMap, "mod2max").ToInt(),
                Mod3Code = columns.GetValue(columnMap, "mod3code"),
                Mod3Param = columns.GetValue(columnMap, "mod3param"),
                Mod3Min = columns.GetValue(columnMap, "mod3min").ToInt(),
                Mod3Max = columns.GetValue(columnMap, "mod3max").ToInt(),
                TransformColor = columns.GetValue(columnMap, "transformcolor"),
                IType1 = columns.GetValue(columnMap, "itype1"),
                IType2 = columns.GetValue(columnMap, "itype2"),
                IType3 = columns.GetValue(columnMap, "itype3"),
                IType4 = columns.GetValue(columnMap, "itype4"),
                IType5 = columns.GetValue(columnMap, "itype5"),
                IType6 = columns.GetValue(columnMap, "itype6"),
                IType7 = columns.GetValue(columnMap, "itype7"),
                EType1 = columns.GetValue(columnMap, "etype1"),
                EType2 = columns.GetValue(columnMap, "etype2"),
                EType3 = columns.GetValue(columnMap, "etype3"),
                EType4 = columns.GetValue(columnMap, "etype4"),
                EType5 = columns.GetValue(columnMap, "etype5"),
                Multiply = columns.GetValue(columnMap, "multiply").ToInt(),
                Add = columns.GetValue(columnMap, "add").ToInt()
            })
            .ToList();
    }
}
