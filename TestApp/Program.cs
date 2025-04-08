using D2RReimaginedTools.TextFileParsers;

var filePath = Path.Combine(AppContext.BaseDirectory, "Data/excel/cubemain.txt");
var cubeMainEntries = await CubeMainParser.GetEntries(filePath);
Console.WriteLine($"Found {cubeMainEntries.Count} cube main entries.");

foreach (var recipe in cubeMainEntries)
{
    Console.WriteLine($"Recipe Output: {recipe.Output}");
}