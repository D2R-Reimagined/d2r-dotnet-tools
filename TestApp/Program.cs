using D2RReimaginedTools.Models;
using D2RReimaginedTools.TextFileParsers;

var defaultPath = Path.Combine(AppContext.BaseDirectory, "Data", "excel", "charstats.txt");

Console.WriteLine("CharStats TSV editor");
Console.WriteLine($"Default file: {defaultPath}");

var sourcePath =
    PromptForExistingPath("Enter the path to charstats.txt or press Enter to use the default: ", defaultPath);
var entries = (await CharStatsParser.GetEntries(sourcePath)).ToList();

if (entries.Count == 0)
{
    Console.WriteLine("No rows were loaded.");
    return;
}

Console.WriteLine();
Console.WriteLine("Available classes:");
for (var index = 0; index < entries.Count; index++)
{
    var entry = entries[index];
    Console.WriteLine(
        $"{index + 1}. {entry.Class} (StatPerLevel={entry.StatPerLevel}, SkillsPerLevel={entry.SkillsPerLevel})");
}

var selectedIndex = PromptForIndex(entries.Count, "Select a class by number: ") - 1;
var selectedEntry = entries[selectedIndex];

Console.WriteLine();
Console.WriteLine($"Editing {selectedEntry.Class}");
selectedEntry.StatPerLevel =
    PromptForOptionalInt($"StatPerLevel [{selectedEntry.StatPerLevel}]: ", selectedEntry.StatPerLevel);
selectedEntry.SkillsPerLevel =
    PromptForOptionalInt($"SkillsPerLevel [{selectedEntry.SkillsPerLevel}]: ", selectedEntry.SkillsPerLevel);

var outputPath = BuildUpdatedPath(sourcePath);
var tempOutputDirectory = Path.Combine(Path.GetTempPath(), "d2r-dotnet-tools", Guid.NewGuid().ToString("N"));
var generatedFile = await CharStatsParser.SaveEntries(entries, sourcePath, tempOutputDirectory);

Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
File.Copy(generatedFile.FullName, outputPath, overwrite: true);

Console.WriteLine();
Console.WriteLine($"Updated file written to: {outputPath}");

static string PromptForExistingPath(string prompt, string defaultPath)
{
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        var path = string.IsNullOrWhiteSpace(input) ? defaultPath : input.Trim();

        if (File.Exists(path))
        {
            return path;
        }

        Console.WriteLine($"File not found: {path}");
    }
}

static int PromptForIndex(int maxValue, string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out var value) && value >= 1 && value <= maxValue)
        {
            return value;
        }

        Console.WriteLine($"Enter a number between 1 and {maxValue}.");
    }
}

static int PromptForOptionalInt(string prompt, int currentValue)
{
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return currentValue;
        }

        if (int.TryParse(input.Trim(), out var value))
        {
            return value;
        }

        Console.WriteLine("Enter an integer or press Enter to keep the current value.");
    }
}

static string BuildUpdatedPath(string sourcePath)
{
    var directory = Path.GetDirectoryName(sourcePath) ?? AppContext.BaseDirectory;
    var fileName = Path.GetFileNameWithoutExtension(sourcePath);
    var extension = Path.GetExtension(sourcePath);

    return Path.Combine(directory, $"{fileName}-updated{extension}");
}