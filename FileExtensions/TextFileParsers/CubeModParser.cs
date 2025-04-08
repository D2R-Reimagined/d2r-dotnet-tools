using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class CubeModifierTypeParser
{
    public static async Task<IList<CubeModifierType>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header

        return lines
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Split('\t'))
            .Select(col => new CubeModifierType
            {
                CubeModifierTypeName = col[0],
                Code = col.Length > 1 && !string.IsNullOrWhiteSpace(col[1]) ? col[1] : null
            })
            .ToList();
    }
}
