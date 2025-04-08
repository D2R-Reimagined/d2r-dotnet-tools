using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class MonEquipParser
{
    public static async Task<IList<MonEquip>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Split('\t'))
            .Select(columns => new MonEquip
            {
                Monster = columns[0],
                OnInit = columns[1].ToInt(),
                Level = columns[2].ToInt(),
                Item1 = columns[3],
                Location1 = columns[4],
                Modifier1 = columns[5].ToInt(),
                Item2 = columns[6],
                Location2 = columns[7],
                Modifier2 = columns[8].ToInt(),
                Item3 = columns[9],
                Location3 = columns[10],
                Modifier3 = columns[11].ToInt(),
            })
            .ToList();
    }
}
