using D2RReimaginedTools.FileParsers;
using D2RReimaginedTools.JsonFileParsers;
using D2RReimaginedTools.Models;
using D2RReimaginedTools.TextFileParsers;


class Program
{
    static void Main(string[] args)
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "Data/excel/armor.txt");


        if (!File.Exists(filePath))
        {
            Console.WriteLine($"❌ File not found: {filePath}");
            return;
        }

        Console.WriteLine("📥 Parsing gems and runes from file...\n");

        var (gems, runes) = GemRuneParser.Parse(filePath);

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
    }
}