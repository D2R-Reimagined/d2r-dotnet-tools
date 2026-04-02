using System.Collections.Generic;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class SkillsParser : HeaderMappedTextFileParser<Skills, SkillsParser>
{
    private static readonly IReadOnlyDictionary<string, string[]> Aliases = new Dictionary<string, string[]>
    {
        [nameof(Skills.Param1Desc)] = ["Param1 Description"],
        [nameof(Skills.Param2Desc)] = ["Param2 Description"],
        [nameof(Skills.Param3Desc)] = ["Param3 Description"],
        [nameof(Skills.Param4Desc)] = ["Param4 Description"],
        [nameof(Skills.Param5Desc)] = ["Param5 Description"],
        [nameof(Skills.Param6Desc)] = ["Param6 Description"],
        [nameof(Skills.Param7Desc)] = ["Param7 Description"],
        [nameof(Skills.Param8Desc)] = ["Param8 Description"],
        [nameof(Skills.Param9Desc)] = ["Param9 Description"],
        [nameof(Skills.Param10Desc)] = ["Param10 Description", "Param10 Description2"],
        [nameof(Skills.Param11Desc)] = ["Param11 Description"],
        [nameof(Skills.Param12Desc)] = ["Param12 Description"],
        [nameof(Skills.Param13Desc)] = ["Param13Description"],
        [nameof(Skills.Param14Desc)] = ["Param14Description"],
        [nameof(Skills.Param15Desc)] = ["Param15Description"],
        [nameof(Skills.Param16Desc)] = ["Param16Description"],
        [nameof(Skills.Param17Desc)] = ["Param17Description"],
        [nameof(Skills.Param18Desc)] = ["Param18Description"],
        [nameof(Skills.Param19Desc)] = ["Param19Description"],
        [nameof(Skills.Param20Desc)] = ["Param20Description"]
    };

    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases => Aliases;
}
