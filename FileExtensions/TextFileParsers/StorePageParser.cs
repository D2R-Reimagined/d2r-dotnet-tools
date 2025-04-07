using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;


public static class StorePageParser
{
    public static async Task<IList<StorePage>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new StorePage
            {
                StorePageName = columns[0],
                Code = columns[1]
            })
            .ToList();
    }
}
