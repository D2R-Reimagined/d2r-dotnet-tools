using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class PetTypeParser
{
    public static async Task<IList<PetType>> GetEntries(string path)
    {
        var lines = (await TextFileParserFileUtility.ReadAllLinesAsync(typeof(PetTypeParser), path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new PetType
            {
                PetTypeId = columns[0],
                Group = columns[1],
                Pool = columns[2],
                BaseMax = columns[3].ToNullableInt(),
                Warp = columns[4].ToNullableInt(),
                Range = columns[5].ToNullableInt(),
                PartySend = columns[6].ToNullableInt(),
                Unsummon = columns[7].ToNullableInt(),
                AutoMap = columns[8].ToNullableInt(),
                Name = columns[9],
                DrawHP = columns[10].ToNullableInt(),
                IconType = columns[11].ToNullableInt(),
                BaseIcon = columns[12],
                MClass1 = columns[13],
                MIcon1 = columns[14],
                OverrideName1 = columns[15],
                MClass2 = columns[16],
                MIcon2 = columns[17],
                OverrideName2 = columns[18],
                MClass3 = columns[19],
                MIcon3 = columns[20],
                OverrideName3 = columns[21],
                MClass4 = columns[22],
                MIcon4 = columns[23],
                OverrideName4 = columns[24],
            })
            .ToList();
    }


    public static Task<FileInfo> SaveEntries(IList<PetType> entries, string? sourcePath = null, string? outputDirectory = null, CancellationToken cancellationToken = default)
    {
        return TextFileParserFileUtility.SaveEntriesAsync<PetType>(typeof(PetTypeParser), entries, sourcePath, outputDirectory, cancellationToken);
    }
}

