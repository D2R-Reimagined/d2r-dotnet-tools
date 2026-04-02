using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class PropertiesParser : HeaderMappedTextFileParser<Property, PropertiesParser>
{
    protected override Property FinalizeEntry(Property entry, string[] columns, IReadOnlyDictionary<string, int> columnMap)
    {
        return entry with { PropertyFunctions = new List<PropertyFunction>() };
    }
}
