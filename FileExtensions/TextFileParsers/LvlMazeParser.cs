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

public static class LvlMazeParser
{
    public static async Task<IList<LvlMaze>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new LvlMaze
            {
                Name = columns[0],
                Level = columns[1].ToInt(),
                Rooms = columns[2].ToInt(),
                RoomsN = columns[3].ToInt(),
                RoomsH = columns[4].ToInt(),
                SizeX = columns[5].ToInt(),
                SizeY = columns[6].ToInt(),
                Merge = columns[7].ToInt()
            })
            .ToList();
    }
}