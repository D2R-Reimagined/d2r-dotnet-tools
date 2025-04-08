using D2RReimaginedTools.FileParsers;
using D2RReimaginedTools.JsonFileParsers;
using D2RReimaginedTools.Models;
using D2RReimaginedTools.TextFileParsers;



using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using D2RReimaginedTools.Models;

var difficultyLevels = await DifficultyLevelParser.GetEntries("Data/excel/difficultylevels.txt");

//Console.WriteLine($"Parsed {difficultyLevels.Count} difficulty entries.");
//Console.WriteLine(string.Join(Environment.NewLine, difficultyLevels.Select(d => d.Name)));

foreach (var difficulty in difficultyLevels)
{
    Console.WriteLine($"--- {difficulty.Name} ---");
    Console.WriteLine($"Resist Penalty: {difficulty.ResistPenalty}");
    Console.WriteLine($"Death Exp Penalty: {difficulty.DeathExpPenalty}");
    Console.WriteLine($"Monster Skill Bonus: {difficulty.MonsterSkillBonus}");
    Console.WriteLine($"Player vs Player Damage %: {difficulty.PlayerDamagePercentVSPlayer}");
    Console.WriteLine($"Merc vs Boss Damage %: {difficulty.MercenaryDamagePercentVSBoss}");
    Console.WriteLine($"Static Field Min: {difficulty.StaticFieldMin}");
    Console.WriteLine($"Gamble Unique Chance: {difficulty.GambleUnique}");
    Console.WriteLine();
}