using D2RReimaginedTools.Helpers;
using D2RReimaginedTools.JsonFileParsers;
using D2RReimaginedTools.TextFileParsers;

var excelDirectory = Path.Combine(AppContext.BaseDirectory, "Data/excel");
var allProperties = await PropertiesParser.GetEntries(Path.Combine(excelDirectory, "properties.txt"));
var parser = new TranslationFileParser("Data/strings/item-modifiers.json");

foreach (var property in allProperties)
{
    var translatedKey = PropertiesHelper.GetPropertyTranslationKeyAsync(excelDirectory, property).Result;
    if (translatedKey.Contains("NOT FOUND"))
    {
        Console.WriteLine($"Property Code: {property.Code}");
        continue;
    }
    
    Console.WriteLine($"Property Translation Key: {translatedKey} \nTranslated Value: {(await parser.GetTranslationByKeyAsync(translatedKey)).EnUS}");
}