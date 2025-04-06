using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;


public static class TsvToRuneWordExtensions
{
    public static RuneWord ToRuneWord(this string[] columns)
    {
        return new RuneWord
        {
            Name = columns[0],
            RuneName = columns[1],
            Complete = columns[2].ToNullableInt(),
            FirstLadderSeason = columns[3].ToNullableInt(),
            LastLadderSeason = columns[4].ToNullableInt(),
            PatchRelease = columns[5],

            ItemType1 = columns[6],
            ItemType2 = columns[7],
            ItemType3 = columns[8],
            ItemType4 = columns[9],
            ItemType5 = columns[10],
            ItemType6 = columns[11],

            ExcludeItemType1 = columns[12],
            ExcludeItemType2 = columns[13],
            ExcludeItemType3 = columns[14],

            RunesUsed = columns[15],
            Rune1 = columns[16],
            Rune2 = columns[17],
            Rune3 = columns[18],
            Rune4 = columns[19],
            Rune5 = columns[20],
            Rune6 = columns[21],

            Mods = new List<RuneWordMod>
            {
                ParseMod(columns, 22),
                ParseMod(columns, 26),
                ParseMod(columns, 30),
                ParseMod(columns, 34),
                ParseMod(columns, 38),
                ParseMod(columns, 42),
                ParseMod(columns, 46),
            }
        };
    }

    private static RuneWordMod ParseMod(string[] columns, int startIndex)
    {
        return new RuneWordMod
        {
            Code = columns[startIndex],
            Param = columns[startIndex + 1],
            Min = columns[startIndex + 2].ToNullableInt(),
            Max = columns[startIndex + 3].ToNullableInt()
        };
    }
}
