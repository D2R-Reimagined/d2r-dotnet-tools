using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.TextFileParsers;


using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using D2RReimaginedTools.Models;

public static class GemRuneParser
{
    public static (List<Gem> Gems, List<Rune> Runes) Parse(string filePath)
    {
        var gems = new List<Gem>();
        var runes = new List<Rune>();

        var lines = File.ReadAllLines(filePath);
        string currentSection = null;

        var gemPattern = new Regex(@"^(\S+)\s+\(([\d\.]+)\)");
        var runePattern = new Regex(@"^([A-Za-z0-9\+\-]+)\s+\-\s+(.+)$");

        foreach (var line in lines)
        {
            var trimmed = line.Trim();

            if (trimmed.Equals("*** LOCAL GEMS ***", StringComparison.OrdinalIgnoreCase))
            {
                currentSection = "GEMS";
                continue;
            }

            if (trimmed.Equals("*** RUNES ***", StringComparison.OrdinalIgnoreCase))
            {
                currentSection = "RUNES";
                continue;
            }

            if (string.IsNullOrWhiteSpace(trimmed))
                continue;

            if (currentSection == "GEMS")
            {
                var match = gemPattern.Match(trimmed);
                if (match.Success)
                {
                    gems.Add(new Gem
                    {
                        Name = match.Groups[1].Value,
                        Version = match.Groups[2].Value
                    });
                }
            }
            else if (currentSection == "RUNES")
            {
                var match = runePattern.Match(trimmed);
                if (match.Success)
                {
                    runes.Add(new Rune
                    {
                        Name = match.Groups[1].Value,
                        Description = match.Groups[2].Value
                    });
                }
            }
        }

        return (gems, runes);
    }
}
