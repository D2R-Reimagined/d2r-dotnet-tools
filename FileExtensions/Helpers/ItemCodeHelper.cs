using D2RReimaginedTools.Models;
using D2RReimaginedTools.TextFileParsers;

namespace D2RReimaginedTools.Helpers;

public class ItemCodeHelper
{
    private static HashSet<string>? _validItemCodes;

    public static async Task InitializeAsync(string excelDirectory)
    {
        // Expecting something like "global/excel/"
        var armorPath = Path.Combine(excelDirectory, "armor.txt");
        var weaponsPath = Path.Combine(excelDirectory, "weapons.txt");
        var miscPath = Path.Combine(excelDirectory, "misc.txt");

        var armorItems = File.Exists(armorPath) ? await ArmorParser.GetEntries(armorPath) : new List<Armor>();
        var weaponItems = File.Exists(weaponsPath) ? await WeaponParser.GetEntries(weaponsPath) : new List<Weapon>();
        var miscItems = File.Exists(miscPath) ? await MiscParser.GetEntries(miscPath) : new List<Misc>();

        _validItemCodes = new HashSet<string>(
            armorItems.Select(a => a.Code)
                .Concat(weaponItems.Select(w => w.Code))
                .Concat(miscItems.Select(m => m.Code))
                .Where(code => !string.IsNullOrWhiteSpace(code))
        );
    }

    public static bool IsValidItemCode(string? code)
    {
        if (string.IsNullOrWhiteSpace(code) || _validItemCodes is null)
            return false;

        return _validItemCodes.Contains(code.Trim());
    }
}