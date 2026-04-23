using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class OverlayParser : HeaderMappedTextFileParser<Overlay, OverlayParser>
{
    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases { get; } =
        new Dictionary<string, string[]>
        {
            ["OverlayName"] = ["overlay"],
            ["OneOfN"] = ["1ofN"],
        };
}
