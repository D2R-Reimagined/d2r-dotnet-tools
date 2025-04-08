using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class MonUModParser
{
    public static async Task<IList<MonUMod>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new MonUMod
            {
                UniqueModId = columns[0],
                Enabled = columns[1].ToNullableInt(),
                Version = columns[2].ToNullableInt(),
                Xfer = columns[3].ToNullableInt(),
                Champion = columns[4].ToNullableInt(),
                FPick = columns[5].ToNullableInt(),
                Exclude1 = columns[6],
                Exclude2 = columns[7],
                CPick = columns[8].ToNullableInt(),
                CPick_N = columns[9].ToNullableInt(),
                CPick_H = columns[10].ToNullableInt(),
                UPick = columns[11].ToNullableInt(),
                UPick_N = columns[12].ToNullableInt(),
                UPick_H = columns[13].ToNullableInt(),
                Constants = columns[14].ToNullableInt(),
                ConstantDesc = columns[15]
            })
            .ToList();
    }
}
