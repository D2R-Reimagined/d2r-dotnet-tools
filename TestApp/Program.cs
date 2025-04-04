using D2RReimaginedTools.FileParsers;
using D2RReimaginedTools.JsonFileParsers;
using D2RReimaginedTools.Models;

var filePath = Path.Combine(AppContext.BaseDirectory, "Data/excel/armor.txt");
var armorEntries = await ArmorParser.GetEntries(filePath);
Console.WriteLine($"Found {armorEntries.Count} armor entries.");

var translation = new TranslationFileParser("Data/strings/item-names.json");
foreach (var armor in armorEntries)
{
    var translationEntry = await translation.GetTranslationByKeyAsync(armor.NameStr);
    Console.WriteLine($"Armor: {armor.Name} - EnUS Translation: {translationEntry.EnUS}");
}

var path = Path.Combine(AppContext.BaseDirectory, "Data/excel/charstats.txt");
var charStats = await CharStatsParser.GetEntries(path);
Console.WriteLine($"Loaded {charStats.Count} classes:");
foreach (var c in charStats)
{
    Console.WriteLine($"Class: {c.Class}, Strength: {c.Strength}, StartSkill: {c.StartSkill}, Items: {c.StartingItems.Count}");
}