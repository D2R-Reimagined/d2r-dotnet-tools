using D2RReimaginedTools.FileParsers;
using D2RReimaginedTools.JsonFileParsers;
using D2RReimaginedTools.Models;

var path = Path.Combine(AppContext.BaseDirectory, "Data/excel/charstats.txt");
var charStats = await CharStatsParser.GetEntries(path);
Console.WriteLine($"Loaded {charStats.Count} classes:");
foreach (var c in charStats)
{
    Console.WriteLine($"Class: {c.Class}, Strength: {c.Strength}, StartSkill: {c.StartSkill}");
}