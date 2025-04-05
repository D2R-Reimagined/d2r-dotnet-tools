using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.TextFileParsers;

using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;



public class InventoryParser
{
    public static async Task<IList<Inventory>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line

        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Inventory
            {
                Class = columns[0],
                InvLeft = columns[1].ToInt(),
                InvRight = columns[2].ToInt(),
                InvTop = columns[3].ToInt(),
                InvBottom = columns[4].ToInt(),
                GridX = columns[5].ToInt(),
                GridY = columns[6].ToInt(),
                GridLeft = columns[7].ToInt(),
                GridRight = columns[8].ToInt(),
                GridTop = columns[9].ToInt(),
                GridBottom = columns[10].ToInt(),
                GridBoxWidth = columns[11].ToInt(),
                GridBoxHeight = columns[12].ToInt(),

                RArmLeft = columns[13].ToInt(),
                RArmRight = columns[14].ToInt(),
                RArmTop = columns[15].ToInt(),
                RArmBottom = columns[16].ToInt(),
                RArmWidth = columns[17].ToInt(),
                RArmHeight = columns[18].ToInt(),

                TorsoLeft = columns[19].ToInt(),
                TorsoRight = columns[20].ToInt(),
                TorsoTop = columns[21].ToInt(),
                TorsoBottom = columns[22].ToInt(),
                TorsoWidth = columns[23].ToInt(),
                TorsoHeight = columns[24].ToInt(),

                LArmLeft = columns[25].ToInt(),
                LArmRight = columns[26].ToInt(),
                LArmTop = columns[27].ToInt(),
                LArmBottom = columns[28].ToInt(),
                LArmWidth = columns[29].ToInt(),
                LArmHeight = columns[30].ToInt(),

                HeadLeft = columns[31].ToInt(),
                HeadRight = columns[32].ToInt(),
                HeadTop = columns[33].ToInt(),
                HeadBottom = columns[34].ToInt(),
                HeadWidth = columns[35].ToInt(),
                HeadHeight = columns[36].ToInt(),

                NeckLeft = columns[37].ToInt(),
                NeckRight = columns[38].ToInt(),
                NeckTop = columns[39].ToInt(),
                NeckBottom = columns[40].ToInt(),
                NeckWidth = columns[41].ToInt(),
                NeckHeight = columns[42].ToInt(),

                RHandLeft = columns[43].ToInt(),
                RHandRight = columns[44].ToInt(),
                RHandTop = columns[45].ToInt(),
                RHandBottom = columns[46].ToInt(),
                RHandWidth = columns[47].ToInt(),
                RHandHeight = columns[48].ToInt(),

                LHandLeft = columns[49].ToInt(),
                LHandRight = columns[50].ToInt(),
                LHandTop = columns[51].ToInt(),
                LHandBottom = columns[52].ToInt(),
                LHandWidth = columns[53].ToInt(),
                LHandHeight = columns[54].ToInt(),

                BeltLeft = columns[55].ToInt(),
                BeltRight = columns[56].ToInt(),
                BeltTop = columns[57].ToInt(),
                BeltBottom = columns[58].ToInt(),
                BeltWidth = columns[59].ToInt(),
                BeltHeight = columns[60].ToInt(),

                FeetLeft = columns[61].ToInt(),
                FeetRight = columns[62].ToInt(),
                FeetTop = columns[63].ToInt(),
                FeetBottom = columns[64].ToInt(),
                FeetWidth = columns[65].ToInt(),
                FeetHeight = columns[66].ToInt(),

                GlovesLeft = columns[67].ToInt(),
                GlovesRight = columns[68].ToInt(),
                GlovesTop = columns[69].ToInt(),
                GlovesBottom = columns[70].ToInt(),
                GlovesWidth = columns[71].ToInt(),
                GlovesHeight = columns[72].ToInt(),
            }).ToList();
    }
}
