using D2RReimaginedTools.Helpers;
using D2RReimaginedTools.TextFileParsers;

var excelDirectory = Path.Combine(AppContext.BaseDirectory, "Data/excel");
var allProperties = await PropertiesParser.GetEntries(Path.Combine(excelDirectory, "properties.txt"));

foreach (var property in allProperties)
{
    var translatedKey = PropertiesHelper.GetPropertyTranslationKeyAsync(excelDirectory, property).Result;
    Console.WriteLine($"Property Translation Key: {translatedKey}");
}