using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

/// <summary>Uses header mapping to preserve column independence for DropTreasureClass.</summary>
public sealed class DropTreasureClassParser : HeaderMappedTextFileParser<DropTreasureClass, DropTreasureClassParser>;

/// <summary>Uses header mapping to preserve column independence for DropNamedItem.</summary>
public sealed class DropNamedItemParser : HeaderMappedTextFileParser<DropNamedItem, DropNamedItemParser>;

/// <summary>Uses header mapping to preserve column independence for DropItemRatio.</summary>
public sealed class DropItemRatioParser : HeaderMappedTextFileParser<DropItemRatio, DropItemRatioParser>;

/// <summary>Uses header mapping to preserve column independence for DropLevel.</summary>
public sealed class DropLevelParser : HeaderMappedTextFileParser<DropLevel, DropLevelParser>;
