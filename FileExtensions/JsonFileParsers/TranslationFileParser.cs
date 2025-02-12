using System.Text.Json;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.JsonFileParsers;

public class TranslationFileParser(string filePath)
{
    private List<TranslatableString>? _translations;
        
    private async Task<List<TranslatableString>> LoadTranslationsAsync()
    {
        if (_translations != null)
        {
            return _translations;
        }
        
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"JSON file not found at {filePath}");
        }

        var json = await File.ReadAllTextAsync(filePath);
        _translations = JsonSerializer.Deserialize<List<TranslatableString>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? [];
        return _translations;
    }
    
    public async Task<TranslatableString> GetTranslationByKeyAsync(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return new TranslatableString();
        }
        
        var translations = await LoadTranslationsAsync();
        return translations.FirstOrDefault(t => t.Key == key) ?? throw new KeyNotFoundException($"Translation with key {key} not found.");
    }
}