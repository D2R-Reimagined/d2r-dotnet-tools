using System.Collections.Generic;
using System.Linq;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class SoundsParser : HeaderMappedTextFileParser<Sounds, SoundsParser>
{
    protected override Sounds FinalizeEntry(Sounds entry, string[] columns, IReadOnlyDictionary<string, int> columnMap)
    {
        var raw = new Dictionary<string, string>();

        foreach (var pair in columnMap)
        {
            if (IsNumericHeader(pair.Key) && pair.Value < columns.Length)
            {
                raw[pair.Key] = columns[pair.Value];
            }
        }

        return raw.Count > 0 ? entry with { RawNumericColumns = raw } : entry;
    }

    protected override string? GetValueForHeader(Sounds entry, string headerName)
    {
        var normalized = NormalizeColumnName(headerName);

        if (IsNumericHeader(normalized) && entry.RawNumericColumns.TryGetValue(normalized, out var raw))
        {
            return raw;
        }

        return base.GetValueForHeader(entry, headerName);
    }

    private static bool IsNumericHeader(string normalizedName)
    {
        return normalizedName.Length > 0 && normalizedName.All(char.IsDigit);
    }
}
