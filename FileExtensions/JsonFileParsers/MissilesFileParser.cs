using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace D2RReimaginedTools.JsonFileParsers;

/// <summary>
/// Parses and edits the D2R Reimagined <c>data/hd/missiles/missiles.json</c> file.
/// The file is a single JSON object whose top-level properties (excluding the
/// <c>dependencies</c> object) map a missile key to a string asset name.
/// All edits go through <see cref="JsonNode"/> so the original property order
/// and surrounding entries are preserved when the file is rewritten.
/// </summary>
public class MissilesFileParser(string filePath)
{
    private const string DependenciesPropertyName = "dependencies";

    private JsonObject? _root;

    private async Task<JsonObject> LoadRootAsync()
    {
        if (_root != null)
        {
            return _root;
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
                new JsonNodeOptions { PropertyNameCaseInsensitive = false });
        }

        if (rootNode is not JsonObject rootObject)
        {
            throw new InvalidDataException(
                $"{filePath} is not a JSON object and cannot be edited as a missiles file.");
        }

        _root = rootObject;
        return _root;
    }

    /// <summary>
    /// Returns the asset value mapped to <paramref name="key"/> or <c>null</c>
    /// when the key is not present (or maps to a non-string value such as the
    /// <c>dependencies</c> object).
    /// </summary>
    public async Task<string?> GetMissileValueByKeyAsync(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key must be supplied", nameof(key));
        }

        var root = await LoadRootAsync();
        var match = root
            .FirstOrDefault(kvp => string.Equals(kvp.Key, key, StringComparison.OrdinalIgnoreCase));

        return match.Value is JsonValue value && value.TryGetValue(out string? text)
            ? text
            : null;
    }

    /// <summary>
    /// Returns every missile key/value pair, skipping the reserved
    /// <c>dependencies</c> object and any non-string values.
    /// </summary>
    public async Task<IReadOnlyDictionary<string, string>> GetAllMissilesAsync()
    {
        var root = await LoadRootAsync();
        var entries = new Dictionary<string, string>(StringComparer.Ordinal);

        foreach (var kvp in root)
        {
            if (string.Equals(kvp.Key, DependenciesPropertyName, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (kvp.Value is JsonValue value && value.TryGetValue(out string? text))
            {
                entries[kvp.Key] = text ?? string.Empty;
            }
        }

        return entries;
    }

    /// <summary>
    /// Replaces the value associated with <paramref name="key"/> while preserving the
    /// original property order. The reserved <c>dependencies</c> property cannot be
    /// edited through this method.
    /// </summary>
    /// <returns><c>true</c> when an entry was replaced; <c>false</c> when no key matched.</returns>
    public async Task<bool> ReplaceMissileValueAsync(string key, string? newValue)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key must be supplied", nameof(key));
        }

        if (string.Equals(key, DependenciesPropertyName, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"The reserved '{DependenciesPropertyName}' property cannot be replaced through this API.");
        }

        var root = await LoadRootAsync();
        var match = root
            .FirstOrDefault(kvp => string.Equals(kvp.Key, key, StringComparison.OrdinalIgnoreCase));

        if (match.Key == null)
        {
            return false;
        }

        // Use the casing already on disk so the in-place replacement keeps the original key text.
        root[match.Key] = JsonValue.Create(newValue ?? string.Empty);

        await SaveAsync(root);
        return true;
    }

    /// <summary>
    /// Adds a new missile entry to the end of the file. When the key already exists, the
    /// existing entry is updated in place instead of appending a duplicate. The reserved
    /// <c>dependencies</c> key cannot be created through this method.
    /// </summary>
    /// <returns>
    /// <c>true</c> when a new row was appended; <c>false</c> when an existing entry was
    /// updated in place.
    /// </returns>
    public async Task<bool> AddMissileAsync(string key, string? value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key must be supplied", nameof(key));
        }

        if (string.Equals(key, DependenciesPropertyName, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"The reserved '{DependenciesPropertyName}' property cannot be added through this API.");
        }

        var root = await LoadRootAsync();
        var existing = root
            .FirstOrDefault(kvp => string.Equals(kvp.Key, key, StringComparison.OrdinalIgnoreCase));

        var resolvedValue = value ?? string.Empty;

        if (existing.Key != null)
        {
            root[existing.Key] = JsonValue.Create(resolvedValue);
            await SaveAsync(root);
            return false;
        }

        root[key] = JsonValue.Create(resolvedValue);
        await SaveAsync(root);
        return true;
    }

    private async Task SaveAsync(JsonObject root)
    {
        var serialized = root.ToJsonString(new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });

        await File.WriteAllTextAsync(filePath, serialized);

        // Force the next read to reload the freshly written file from disk.
        _root = null;
    }
}
