using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.Models;

public record Inventory
{
    public string? Class { get; init; }
    public int? InvLeft { get; init; }
    public int? InvRight { get; init; }
    public int? InvTop { get; init; }
    public int? InvBottom { get; init; }
    public int? GridX { get; init; }
    public int? GridY { get; init; }
    public int? GridLeft { get; init; }
    public int? GridRight { get; init; }
    public int? GridTop { get; init; }
    public int? GridBottom { get; init; }
    public int? GridBoxWidth { get; init; }
    public int? GridBoxHeight { get; init; }

    public int? RArmLeft { get; init; }
    public int? RArmRight { get; init; }
    public int? RArmTop { get; init; }
    public int? RArmBottom { get; init; }
    public int? RArmWidth { get; init; }
    public int? RArmHeight { get; init; }

    public int? TorsoLeft { get; init; }
    public int? TorsoRight { get; init; }
    public int? TorsoTop { get; init; }
    public int? TorsoBottom { get; init; }
    public int? TorsoWidth { get; init; }
    public int? TorsoHeight { get; init; }

    public int? LArmLeft { get; init; }
    public int? LArmRight { get; init; }
    public int? LArmTop { get; init; }
    public int? LArmBottom { get; init; }
    public int? LArmWidth { get; init; }
    public int? LArmHeight { get; init; }

    public int? HeadLeft { get; init; }
    public int? HeadRight { get; init; }
    public int? HeadTop { get; init; }
    public int? HeadBottom { get; init; }
    public int? HeadWidth { get; init; }
    public int? HeadHeight { get; init; }

    public int? NeckLeft { get; init; }
    public int? NeckRight { get; init; }
    public int? NeckTop { get; init; }
    public int? NeckBottom { get; init; }
    public int? NeckWidth { get; init; }
    public int? NeckHeight { get; init; }

    public int? RHandLeft { get; init; }
    public int? RHandRight { get; init; }
    public int? RHandTop { get; init; }
    public int? RHandBottom { get; init; }
    public int? RHandWidth { get; init; }
    public int? RHandHeight { get; init; }

    public int? LHandLeft { get; init; }
    public int? LHandRight { get; init; }
    public int? LHandTop { get; init; }
    public int? LHandBottom { get; init; }
    public int? LHandWidth { get; init; }
    public int? LHandHeight { get; init; }

    public int? BeltLeft { get; init; }
    public int? BeltRight { get; init; }
    public int? BeltTop { get; init; }
    public int? BeltBottom { get; init; }
    public int? BeltWidth { get; init; }
    public int? BeltHeight { get; init; }

    public int? FeetLeft { get; init; }
    public int? FeetRight { get; init; }
    public int? FeetTop { get; init; }
    public int? FeetBottom { get; init; }
    public int? FeetWidth { get; init; }
    public int? FeetHeight { get; init; }

    public int? GlovesLeft { get; init; }
    public int? GlovesRight { get; init; }
    public int? GlovesTop { get; init; }
    public int? GlovesBottom { get; init; }
    public int? GlovesWidth { get; init; }
    public int? GlovesHeight { get; init; }
}
