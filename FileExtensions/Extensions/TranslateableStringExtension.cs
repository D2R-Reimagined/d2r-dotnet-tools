using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.Extensions;

public static class TranslatableStringExtensions
{
    public static string GetLocalized(this TranslatableString ts, string language)
    {
        return language switch
        {
            "EnUS" => ts.EnUS,
            "ZhTW" => ts.ZhTW,
            "DeDE" => ts.DeDE,
            "EsES" => ts.EsES,
            "FrFR" => ts.FrFR,
            "ItIT" => ts.ItIT,
            "KoKR" => ts.KoKR,
            "PlPL" => ts.PlPL,
            "EsMX" => ts.EsMX,
            "JaJP" => ts.JaJP,
            "PtBR" => ts.PtBR,
            "RuRU" => ts.RuRU,
            "ZhCN" => ts.ZhCN,
            _ => ts.EnUS // fallback
        };
    }
}