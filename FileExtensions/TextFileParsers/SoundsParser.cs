

using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;

namespace D2RReimaginedTools.TextFileParsers;

public static class SoundsParser
{
    public static async Task<IList<Sounds>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Sounds
            {
                Sound = columns[0],
                Index = columns[1].ToNullableInt(),
                Redirect = columns[2],
                Channel = columns[3],
                FileName = columns[4],
                IsLocal = columns[5].ToBool(),
                IsMusic = columns[6].ToBool(),
                IsAmbientScene = columns[7].ToBool(),
                IsAmbientEvent = columns[8].ToBool(),
                IsUI = columns[9].ToBool(),
                VolumeMin = columns[10].ToNullableInt(),
                VolumeMax = columns[11].ToNullableInt(),
                PitchMin = columns[12].ToNullableInt(),
                PitchMax = columns[13].ToNullableInt(),
                GroupSize = columns[14].ToNullableInt(),
                GroupWeight = columns[15].ToNullableInt(),
                Loop = columns[16].ToBool(),
                FadeIn = columns[17].ToNullableInt(),
                FadeOut = columns[18].ToNullableInt(),
                DeferInst = columns[19].ToBool(),
                StopInst = columns[20].ToBool(),
                Duration = columns[21].ToNullableInt(),
                Compound = columns[22],
                Falloff = columns[23].ToNullableInt(),
                LFEMix = columns[24].ToNullableInt(),
                _3dSpread = columns[25].ToNullableInt(),
                Priority = columns[26].ToNullableInt(),
                Stream = columns[27].ToBool(),
                Is2D = columns[28].ToBool(),
                Tracking = columns[29].ToBool(),
                Solo = columns[30].ToBool(),
                MusicVol = columns[31].ToBool(),
                Block1 = columns[32].ToNullableInt(),
                Block2 = columns[33].ToNullableInt(),
                Block3 = columns[34].ToNullableInt(),
                HDOptOut = columns[35].ToBool(),
                Delay = columns[36].ToNullableInt(),
                Unknown4737 = columns[37].ToNullableInt()
            })
            .ToList();
    }
}
