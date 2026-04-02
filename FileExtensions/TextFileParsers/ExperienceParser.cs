using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class ExperienceParser : HeaderMappedTextFileParser<Experience, ExperienceParser>
{
    protected override int DataStartRowIndex => 2;
}
