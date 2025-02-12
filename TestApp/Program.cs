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