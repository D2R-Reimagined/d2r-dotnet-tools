using D2RReimaginedTools.FileParsers;
using D2RReimaginedTools.TextFileParsers;

var itemTypePath = Path.Combine(AppContext.BaseDirectory, "Data/excel/ItemTypes.txt");
var itemTypes = await ItemTypeParser.GetEntries(itemTypePath);
Console.WriteLine($"Parsed {itemTypes.Count} item types.");
foreach (var type in itemTypes)
{
    Console.WriteLine($"ItemType: {type.ItemType}, Code: {type.Code}");
}
