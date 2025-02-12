namespace D2RReimaginedTools.Models;

public record Property
{
    public string? Code { get; init; }
    public bool Enabled { get; init; }
    public string? Tooltip { get; init; }

    public int? Func1 { get; init; }
    public string? Stat1 { get; init; }
    public int? Set1 { get; init; }
    public int? Val1 { get; init; }

    public int? Func2 { get; init; }
    public string? Stat2 { get; init; }
    public int? Set2 { get; init; }
    public int? Val2 { get; init; }

    public int? Func3 { get; init; }
    public string? Stat3 { get; init; }
    public int? Set3 { get; init; }
    public int? Val3 { get; init; }

    public int? Func4 { get; init; }
    public string? Stat4 { get; init; }
    public int? Set4 { get; init; }
    public int? Val4 { get; init; }

    public int? Func5 { get; init; }
    public string? Stat5 { get; init; }
    public int? Set5 { get; init; }
    public int? Val5 { get; init; }

    public int? Func6 { get; init; }
    public string? Stat6 { get; init; }
    public int? Set6 { get; init; }
    public int? Val6 { get; init; }

    public int? Func7 { get; init; }
    public string? Stat7 { get; init; }
    public int? Set7 { get; init; }
    public int? Val7 { get; init; }
    
    public string? Parameter { get; init; }
    public string? Min { get; init; }
    public string? Max { get; init; }
    public string? Notes { get; init; }
    public int Eol { get; init; }
    
    public IList<PropertyFunction>? PropertyFunctions { get; init; }
}