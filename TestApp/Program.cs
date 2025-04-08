using D2RReimaginedTools.Helpers;

var excelDirectory = "Data/excel";
await ItemCodeHelper.InitializeAsync(excelDirectory);

Console.WriteLine($"Is valid item code: {ItemCodeHelper.IsValidItemCode("cap")}");