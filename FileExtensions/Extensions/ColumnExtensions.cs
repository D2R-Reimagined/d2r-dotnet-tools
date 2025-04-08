namespace D2RReimaginedTools.Extensions;

public static class ColumnExtensions
{
    public static string GetValue(this string[] columns, Dictionary<string, int> columnMap, string columnName)
    {
        return columnMap.TryGetValue(columnName, out var index) && index < columns.Length
            ? columns[index]
            : string.Empty;
    }
}
