using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class MonUModParser
{
    public static async Task<IList<MonUMod>> GetEntries(string path)
    {
        var lines = (await TextFileParserFileUtility.ReadAllLinesAsync(typeof(MonUModParser), path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new MonUMod
            {
                UniqueModId = columns[0],
                Id = columns[1].ToNullableInt(),
                Enabled = columns[2].ToNullableInt(),
                Version = columns[3].ToNullableInt(),
                Xfer = columns[4].ToNullableInt(),
                Champion = columns[5].ToNullableInt(),
                FPick = columns[6].ToNullableInt(),
                Exclude1 = columns[7],
                Exclude2 = columns[8],
                CPick = columns[9].ToNullableInt(),
                CPick_N = columns[10].ToNullableInt(),
                CPick_H = columns[11].ToNullableInt(),
                UPick = columns[12].ToNullableInt(),
                UPick_N = columns[13].ToNullableInt(),
                UPick_H = columns[14].ToNullableInt(),
                Constants = columns[15].ToNullableInt(),
                ConstantDesc = columns[16],
                Eol = columns[17].ToNullableInt()
            })
            .ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<MonUMod> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<MonUMod>(typeof(MonUModParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

