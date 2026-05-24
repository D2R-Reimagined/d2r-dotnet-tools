using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
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
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        }) ?? [];
        return _translations;
    }

    public async Task<List<TranslatableString>> GetAllEntriesAsync()
    {
        return await LoadTranslationsAsync();
    }

    public async Task<TranslatableString> GetTranslationByKeyAsync(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new KeyNotFoundException($"{key} must be supplied");
        }

        var translations = await LoadTranslationsAsync();
        return translations.FirstOrDefault(t => t.Key == key) ?? throw new KeyNotFoundException($"Translation with key {key} not found.");
    }

    /// <summary>
    /// Finds the entry whose <c>Key</c> matches <paramref name="key"/> (case-insensitive) and replaces the value
    /// of the <paramref name="languageColumn"/> field (e.g. <c>enUS</c>) with <paramref name="newValue"/>.
    /// All other entries, fields, and the original property order are preserved on disk.
    /// </summary>
    /// <returns><c>true</c> if at least one entry matched and was updated; otherwise <c>false</c>.</returns>
    public async Task<bool> ReplaceLanguageValueAsync(string key, string languageColumn, string? newValue)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key must be supplied", nameof(key));
        }

        if (string.IsNullOrWhiteSpace(languageColumn))
        {
            throw new ArgumentException("Language column must be supplied", nameof(languageColumn));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"JSON file not found at {filePath}");
        }

        JsonNode? rootNode;
        await using (var readStream = File.OpenRead(filePath))
        {
            rootNode = await JsonNode.ParseAsync(
                readStream,
                new JsonNodeOptions { PropertyNameCaseInsensitive = true });
        }

        if (rootNode is not JsonArray entries)
        {
            throw new InvalidDataException($"{filePath} is not a JSON array and cannot be edited as a translation file.");
        }

        var resolvedValue = newValue ?? string.Empty;
        var matched = false;

        foreach (var entryNode in entries)
        {
            if (entryNode is not JsonObject entryObject)
            {
                continue;
            }

            var keyProperty = entryObject
                .FirstOrDefault(kvp => string.Equals(kvp.Key, "Key", StringComparison.OrdinalIgnoreCase));
            var keyValue = keyProperty.Value?.GetValue<string>();
            if (string.IsNullOrEmpty(keyValue) ||
                !string.Equals(keyValue, key, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var existingLanguageProperty = entryObject
                .FirstOrDefault(kvp => string.Equals(kvp.Key, languageColumn, StringComparison.OrdinalIgnoreCase));
            if (existingLanguageProperty.Key != null)
            {
                entryObject[existingLanguageProperty.Key] = JsonValue.Create(resolvedValue);
            }
            else
            {
                entryObject[languageColumn] = JsonValue.Create(resolvedValue);
            }

            matched = true;
        }

        if (!matched)
        {
            return false;
        }

        var serialized = rootNode.ToJsonString(new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
        await File.WriteAllTextAsync(filePath, serialized);

        // Invalidate any previously-cached typed view so subsequent reads see the update.
        _translations = null;
        return true;
    }

    /// <summary>
    /// Appends a new translation entry to the JSON array. The new entry's <c>id</c> is the
    /// last entry's <c>id</c> plus one (or 0 when the file is empty). <paramref name="key"/>
    /// must be unique. <paramref name="languageValues"/> must contain a non-empty
    /// <c>enUS</c> value; any of the other 12 supported language columns are optional and
    /// fall back to the <c>enUS</c> value when omitted or empty.
    /// </summary>
    /// <returns>The newly assigned <c>id</c> of the inserted entry.</returns>
    public async Task<int> AddRowAsync(string key, IReadOnlyDictionary<string, string?> languageValues)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key must be supplied", nameof(key));
        }

        if (languageValues == null)
        {
            throw new ArgumentNullException(nameof(languageValues));
        }

        var caseInsensitive = new Dictionary<string, string?>(languageValues, StringComparer.OrdinalIgnoreCase);
        if (!caseInsensitive.TryGetValue("enUS", out var enUs) || string.IsNullOrEmpty(enUs))
        {
            throw new ArgumentException("enUS value is required when adding a translation row.", nameof(languageValues));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"JSON file not found at {filePath}");
        }

        JsonNode? rootNode;
        await using (var readStream = File.OpenRead(filePath))
        {
            rootNode = await JsonNode.ParseAsync(
                readStream,
                new JsonNodeOptions { PropertyNameCaseInsensitive = true });
        }

        if (rootNode is not JsonArray entries)
        {
            throw new InvalidDataException($"{filePath} is not a JSON array and cannot be edited as a translation file.");
        }

        foreach (var entryNode in entries)
        {
            if (entryNode is not JsonObject entryObject)
            {
                continue;
            }

            var existingKey = entryObject
                .FirstOrDefault(kvp => string.Equals(kvp.Key, "Key", StringComparison.OrdinalIgnoreCase))
                .Value?.GetValue<string>();
            if (!string.IsNullOrEmpty(existingKey) &&
                string.Equals(existingKey, key, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException($"A translation entry with Key '{key}' already exists in {Path.GetFileName(filePath)}.");
            }
        }

        var nextId = 0;
        for (var i = entries.Count - 1; i >= 0; i--)
        {
            if (entries[i] is not JsonObject lastObject)
            {
                continue;
            }

            var idProperty = lastObject
                .FirstOrDefault(kvp => string.Equals(kvp.Key, "id", StringComparison.OrdinalIgnoreCase));
            if (idProperty.Value != null && idProperty.Value.AsValue().TryGetValue<int>(out var lastId))
            {
                nextId = lastId + 1;
                break;
            }
        }

        // The 13 D2R language columns ship in this canonical order; preserve it on disk.
        string[] languageColumns =
        [
            "enUS", "zhTW", "deDE", "esES", "frFR", "itIT",
            "koKR", "plPL", "esMX", "jaJP", "ptBR", "ruRU", "zhCN"
        ];

        var newEntry = new JsonObject
        {
            ["id"] = JsonValue.Create(nextId),
            ["Key"] = JsonValue.Create(key)
        };

        foreach (var column in languageColumns)
        {
            var value = caseInsensitive.TryGetValue(column, out var supplied) && !string.IsNullOrEmpty(supplied)
                ? supplied
                : enUs;
            newEntry[column] = JsonValue.Create(value);
        }

        entries.Add(newEntry);

        var serialized = rootNode.ToJsonString(new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
        await File.WriteAllTextAsync(filePath, serialized);

        _translations = null;
        return nextId;
    }
}
