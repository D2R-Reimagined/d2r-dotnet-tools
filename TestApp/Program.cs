using D2RReimaginedTools.FileParsers;
using D2RReimaginedTools.JsonFileParsers;
using D2RReimaginedTools.Models;
using D2RReimaginedTools.TextFileParsers;



using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using D2RReimaginedTools.Models;

class Program
{
    static async Task Main()
    {
        string filePath = "Data/excel/gems.txt"; // Replace with the actual path to your file

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: The specified file does not exist.");
            return;
        }

        var gems = await GemParser.GetEntries(filePath);

        foreach (var gem in gems)
        {
            Console.WriteLine($"Name: {gem.Name}, Code: {gem.Code}, Transform: {gem.Transform}");
            Console.WriteLine($"Weapon Mod: {gem.WeaponMod1Code} ({gem.WeaponMod1Min}-{gem.WeaponMod1Max})");
            Console.WriteLine($"Helm Mod: {gem.HelmMod1Code} ({gem.HelmMod1Min}-{gem.HelmMod1Max})");
            Console.WriteLine($"Shield Mod: {gem.ShieldMod1Code} ({gem.ShieldMod1Min}-{gem.ShieldMod1Max})");
            Console.WriteLine("------------------------------------------------");
        }
    }
}

