using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class ExperienceParser : HeaderMappedTextFileParser<Experience, ExperienceParser>
{
    // Row 1 of experience.txt is the "MaxLvl" secondary-header row whose numeric columns
    // define the per-class level cap. We keep it as a real entry (Level = "MaxLvl") so plugin
    // authors can target it by the Level column just like any other row.
    protected override int DataStartRowIndex => 1;
}
