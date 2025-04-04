using D2RReimaginedTools.FileParsers;
using D2RReimaginedTools.JsonFileParsers;
using D2RReimaginedTools.Models;
using D2RReimaginedTools.TextFileParsers;



var filePath = Path.Combine(AppContext.BaseDirectory, "Data/excel/armor.txt");
var (gems, runes) = GemRuneParser.Parse(filePath);
Console.WriteLine("📥 Parsing gems and runes from file...\n");

Console.WriteLine($"💎 Gems ({gems.Count}):");
foreach (var gem in gems)
{
    Console.WriteLine($"  - {gem.Name} (Version: {gem.Version})");
}

Console.WriteLine($"\n🪓 Runes ({runes.Count}):");
foreach (var rune in runes)
{
    Console.WriteLine($"  - {rune.Name}: {rune.Description}");
}