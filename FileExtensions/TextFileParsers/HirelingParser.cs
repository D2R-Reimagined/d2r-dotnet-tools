using System.Collections.Generic;
using System.Linq;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class HirelingParser : HeaderMappedTextFileParser<Hirelings, HirelingParser>
{
    public static List<Hirelings> Parse(string filePath)
    {
        return GetEntries(filePath).GetAwaiter().GetResult().ToList();
    }
}
