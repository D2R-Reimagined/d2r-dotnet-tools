using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.TextFileParsers;

using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class LvlWarpParser
{
    public static async Task<IList<LvlWarp>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new LvlWarp
            {
                Name = columns[0],
                Id = columns[1].ToInt(),
                SelectX = columns[2].ToInt(),
                SelectY = columns[3].ToInt(),
                SelectDX = columns[4].ToInt(),
                SelectDY = columns[5].ToInt(),
                ExitWalkX = columns[6].ToInt(),
                ExitWalkY = columns[7].ToInt(),
                OffsetX = columns[8].ToInt(),
                OffsetY = columns[9].ToInt(),
                LitVersion = columns[10].ToInt(),
                Tiles = columns[11].ToInt(),
                NoInteract = columns[12].ToInt(),
                Direction = columns[13],
                UniqueId = columns[14].ToInt()
            })
            .ToList();
    }
}