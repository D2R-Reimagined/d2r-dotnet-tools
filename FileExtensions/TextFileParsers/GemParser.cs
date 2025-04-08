using System.IO;
using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

public static class GemParser
{
    public static async Task<IList<Gem>> GetEntries(string filePath)

    {
        var lines = (await File.ReadAllLinesAsync(filePath)).Skip(1); // Skip header line
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Gem
            {
            Name = columns[0],
            Letter = columns[1],
            Transform = columns[2],
            Code = columns[3],

            WeaponMod1Code = columns[4],
            WeaponMod1Param = columns[5],
            WeaponMod1Min = columns[6],
            WeaponMod1Max = columns[7],
            WeaponMod2Code = columns[8],
            WeaponMod2Param = columns[9],
            WeaponMod2Min = columns[10],
            WeaponMod2Max = columns[11],
            WeaponMod3Code = columns[12],
            WeaponMod3Param = columns[13],
            WeaponMod3Min = columns[14],
            WeaponMod3Max = columns[15],

            HelmMod1Code = columns[16],
            HelmMod1Param = columns[17],
            HelmMod1Min = columns[18],
            HelmMod1Max = columns[19],
            HelmMod2Code = columns[20],
            HelmMod2Param = columns[21],
            HelmMod2Min = columns[22],
            HelmMod2Max = columns[23],
            HelmMod3Code = columns[24],
            HelmMod3Param = columns[25],
            HelmMod3Min = columns[26],
            HelmMod3Max = columns[27],

            ShieldMod1Code = columns[28],
            ShieldMod1Param = columns[29],
            ShieldMod1Min = columns[30],
            ShieldMod1Max = columns[31],
            ShieldMod2Code = columns[32],
            ShieldMod2Param = columns[33],
            ShieldMod2Min = columns[34],
            ShieldMod2Max = columns[35],
            ShieldMod3Code = columns[36],
            ShieldMod3Param = columns[37],
            ShieldMod3Min = columns[38],
            ShieldMod3Max = columns[39],
        }).ToList();
    }
}
