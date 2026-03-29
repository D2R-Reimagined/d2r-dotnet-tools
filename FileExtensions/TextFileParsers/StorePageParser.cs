using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;


public static class StorePageParser
{
    public static async Task<IList<StorePage>> GetEntries(string path)
    {
        var lines = (await TextFileParserFileUtility.ReadAllLinesAsync(typeof(StorePageParser), path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new StorePage
            {
                StorePageName = columns[0],
                Code = columns[1]
            })
            .ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<StorePage> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<StorePage>(typeof(StorePageParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

