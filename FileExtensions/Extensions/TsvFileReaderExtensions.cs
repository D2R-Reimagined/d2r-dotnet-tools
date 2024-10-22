namespace D2RReimaginedTools.Extensions;

public static class TsvFileReaderExtensions
{
    public static int ToInt(this string value)
    {
        return string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
    }

    public static bool ToBool(this string value)
    {
        return value == "1";
    }
}