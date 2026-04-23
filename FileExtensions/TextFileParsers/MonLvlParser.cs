using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public class MonLvlParser : HeaderMappedTextFileParser<MonLvl, MonLvlParser>
{
    protected override IReadOnlyDictionary<string, string[]> PropertyColumnAliases { get; } =
        new Dictionary<string, string[]>
        {
            ["ACN"] = ["AC(N)"],
            ["ACH"] = ["AC(H)"],
            ["LAC"] = ["L-AC"],
            ["LACN"] = ["L-AC(N)"],
            ["LACH"] = ["L-AC(H)"],
            ["THN"] = ["TH(N)"],
            ["THH"] = ["TH(H)"],
            ["LTH"] = ["L-TH"],
            ["LTHN"] = ["L-TH(N)"],
            ["LTHH"] = ["L-TH(H)"],
            ["HPN"] = ["HP(N)"],
            ["HPH"] = ["HP(H)"],
            ["LHP"] = ["L-HP"],
            ["LHPN"] = ["L-HP(N)"],
            ["LHPH"] = ["L-HP(H)"],
            ["DMN"] = ["DM(N)"],
            ["DMH"] = ["DM(H)"],
            ["LDM"] = ["L-DM"],
            ["LDMN"] = ["L-DM(N)"],
            ["LDMH"] = ["L-DM(H)"],
            ["XPN"] = ["XP(N)"],
            ["XPH"] = ["XP(H)"],
            ["LXP"] = ["L-XP"],
            ["LXPN"] = ["L-XP(N)"],
            ["LXPH"] = ["L-XP(H)"],
        };
}
