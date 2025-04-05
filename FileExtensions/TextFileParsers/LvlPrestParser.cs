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

public static class LvlPrestParser
{
    public static async Task<IList<LevelsPreset>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new LevelsPreset
            {
                Name = columns[0],
                Def = columns[1].ToInt(),
                LevelId = columns[2].ToInt(),
                Populate = columns[3].ToInt(),
                Logicals = columns[4].ToInt(),
                Outdoors = columns[5].ToInt(),
                Animate = columns[6].ToInt(),
                KillEdge = columns[7].ToInt(),
                FillBlanks = columns[8].ToInt(),
                SizeX = columns[9].ToInt(),
                SizeY = columns[10].ToInt(),
                AutoMap = columns[11].ToInt(),
                Scan = columns[12].ToInt(),
                Pops = columns[13].ToInt(),
                PopPad = columns[14].ToInt(),
                Files = columns[15].ToInt(),
                File1 = columns[16],
                File2 = columns[17],
                File3 = columns[18],
                File4 = columns[19],
                File5 = columns[20],
                File6 = columns[21],
                Dt1Mask = columns[22].ToInt()
            })
            .ToList();
    }
}