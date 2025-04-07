﻿using D2RReimaginedTools.Extensions;
using D2RReimaginedTools.Models;


namespace D2RReimaginedTools.TextFileParsers;


public static class MissilesParser
{
    public static async Task<IList<Missiles>> GetEntries(string path)
    {
        var lines = (await File.ReadAllLinesAsync(path)).Skip(1); // Skip header line
        return lines.Select(line => line.Split('\t'))
            .Select(columns => new Missiles
            {
                MissileName = columns[0],
                MissileId = columns[1].ToInt(),
                ClientDoFunction = columns[2].ToNullableInt(),
                ClientHitFunction = columns[3].ToNullableInt(),
                ServerDoFunction = columns[4].ToNullableInt(),
                ServerHitFunction = columns[5].ToNullableInt(),
                ServerDamageFunction = columns[6].ToNullableInt(),
                ServerCalculation1 = columns[7],
                ServerCalculation1Description = columns[8],
                Parameter1 = columns[9],
                Parameter1Description = columns[10],
                Parameter2 = columns[11],
                Parameter2Description = columns[12],
                Parameter3 = columns[13],
                Parameter3Description = columns[14],
                Parameter4 = columns[15],
                Parameter4Description = columns[16],
                Parameter5 = columns[17],
                Parameter5Description = columns[18],
                ClientCalculation1 = columns[19],
                ClientCalculation1Description = columns[20],
                ClientParameter1 = columns[21],
                ClientParameter1Description = columns[22],
                ClientParameter2 = columns[23],
                ClientParameter2Description = columns[24],
                ClientParameter3 = columns[25],
                ClientParameter3Description = columns[26],
                ClientParameter4 = columns[27],
                ClientParameter4Description = columns[28],
                ClientParameter5 = columns[29],
                ClientParameter5Description = columns[30],
                ServerHitCalculation1 = columns[31],
                ServerHitCalculation1Description = columns[32],
                ServerHitParameter1 = columns[33],
                ServerHitParameter1Description = columns[34],
                ServerHitParameter2 = columns[35],
                ServerHitParameter2Description = columns[36],
                ServerHitParameter3 = columns[37],
                ServerHitParameter3Description = columns[38],
                ClientHitCalculation1 = columns[39],
                ClientHitParameter1Description = columns[40],
                ClientHitParameter2Description = columns[41],
                ClientHitParameter3Description = columns[42],
                DamageCalculation1 = columns[43],
                DamageParameter1Description = columns[44],
                DamageParameter2Description = columns[45],
                Velocity = columns[46].ToNullableInt(),
                MaxVelocity = columns[47].ToNullableInt(),
                VelocityLevel = columns[48].ToNullableInt(),
                Acceleration = columns[49].ToNullableInt(),
                Range = columns[50].ToNullableInt(),
                LevelRange = columns[51].ToNullableInt(),
                Light = columns[52].ToNullableInt(),
                Flicker = columns[53].ToNullableInt(),
                Red = columns[54].ToNullableInt(),
                Green = columns[55].ToNullableInt(),
                Blue = columns[56].ToNullableInt(),
                InitialSteps = columns[57].ToNullableInt(),
                Activate = columns[58].ToNullableInt(),
                LoopAnimation = columns[59].ToNullableInt(),
                CelFile = columns[60],
                AnimationRate = columns[61].ToNullableInt(),
                AnimationLength = columns[62].ToNullableInt(),
                AnimationSpeed = columns[63].ToNullableInt(),
                RandomStart = columns[64].ToNullableInt(),
                SubLoop = columns[65].ToNullableInt(),
                SubStart = columns[66].ToNullableInt(),
                SubStop = columns[67].ToNullableInt(),
                CollisionType = columns[68].ToNullableInt(),
                CollisionKill = columns[69].ToNullableInt(),
                CollisionFriend = columns[70].ToNullableInt(),
                LastCollision = columns[71].ToNullableInt(),
                Collision = columns[72].ToNullableInt(),
                ClientCollision = columns[73].ToNullableInt(),
                ClientSend = columns[74].ToNullableInt(),
                NextHit = columns[75].ToNullableInt(),
                NextDelay = columns[76].ToNullableInt(),
                XOffset = columns[77].ToNullableInt(),
                YOffset = columns[78].ToNullableInt(),
                ZOffset = columns[79].ToNullableInt(),
                Size = columns[80].ToNullableInt(),
                SourceTown = columns[81].ToNullableInt(),
                ClientSourceTown = columns[82].ToNullableInt(),
                CanDestroy = columns[83].ToNullableInt(),
                ToHit = columns[84].ToNullableInt(),
                AlwaysExplode = columns[85].ToNullableInt(),
                Explosion = columns[86].ToNullableInt(),
                Town = columns[87].ToNullableInt(),
                NoUniqueModifier = columns[88].ToNullableInt(),
                NoMultiShot = columns[89].ToNullableInt(),
                Holy = columns[90].ToNullableInt(),
                CanSlow = columns[91].ToNullableInt(),
                ReturnFire = columns[92].ToNullableInt(),
                GetHit = columns[93].ToNullableInt(),
                SoftHit = columns[94].ToNullableInt(),
                KnockBack = columns[95].ToNullableInt(),
                Transform = columns[96].ToNullableInt(),
                Pierce = columns[97].ToNullableInt(),
                MissileSkill = columns[98].ToNullableInt(),
                Skill = columns[99],
                ResultFlags = columns[100].ToNullableInt(),
                HitFlags = columns[101].ToNullableInt(),
                HitShift = columns[102].ToNullableInt(),
                ApplyMastery = columns[103].ToNullableInt(),
                SourceDamage = columns[104].ToNullableInt(),
                HalfTwoHandedSource = columns[105].ToNullableInt(),
                SourceMissileDamage = columns[106].ToNullableInt(),
                MinimumDamage = columns[107].ToNullableInt(),
                MinimumLevelDamage1 = columns[108].ToNullableInt(),
                MinimumLevelDamage2 = columns[109].ToNullableInt(),
                MinimumLevelDamage3 = columns[110].ToNullableInt(),
                MinimumLevelDamage4 = columns[111].ToNullableInt(),
                MinimumLevelDamage5 = columns[112].ToNullableInt(),
                MaximumDamage = columns[113].ToNullableInt(),
                MaximumLevelDamage1 = columns[114].ToNullableInt(),
                MaximumLevelDamage2 = columns[115].ToNullableInt(),
                MaximumLevelDamage3 = columns[116].ToNullableInt(),
                MaximumLevelDamage4 = columns[117].ToNullableInt(),
                MaximumLevelDamage5 = columns[118].ToNullableInt(),
                DamageSymbolPerCalculation = columns[119].ToNullableInt(),
                ElementType = columns[120],
                ElementMinimum = columns[121].ToNullableInt(),
                MinimumElementLevel1 = columns[122].ToNullableInt(),
                MinimumElementLevel2 = columns[123].ToNullableInt(),
                MinimumElementLevel3 = columns[124].ToNullableInt(),
                MinimumElementLevel4 = columns[125].ToNullableInt(),
                MinimumElementLevel5 = columns[126].ToNullableInt(),
                ElementMaximum = columns[127].ToNullableInt(),
                MaximumElementLevel1 = columns[128].ToNullableInt(),
                MaximumElementLevel2 = columns[129].ToNullableInt(),
                MaximumElementLevel3 = columns[130].ToNullableInt(),
                MaximumElementLevel4 = columns[131].ToNullableInt(),
                MaximumElementLevel5 = columns[132].ToNullableInt(),
                ElementDamageSymbolPerCalculation = columns[133],
                ElementLength = columns[134].ToNullableInt(),
                ElementLevelLength1 = columns[135].ToNullableInt(),
                ElementLevelLength2 = columns[136].ToNullableInt(),
                ElementLevelLength3 = columns[137].ToNullableInt(),
                HitClass = columns[138].ToNullableInt(),
                NumberOfDirections = columns[139].ToNullableInt(),
                LocalBlood = columns[140].ToNullableInt(),
                DamageRate = columns[141].ToNullableInt(),
                TravelSound = columns[142],
                HitSound = columns[143],
                ProgressionSound = columns[144],
                ProgressionOverlay = columns[145],
                ExplosionMissile = columns[146],
                SubMissile1 = columns[147],
                SubMissile2 = columns[148],
                SubMissile3 = columns[149],
                HitSubMissile1 = columns[150],
                HitSubMissile2 = columns[151],
                HitSubMissile3 = columns[152],
                HitSubMissile4 = columns[153],
                ClientSubMissile1 = columns[154],
                ClientSubMissile2 = columns[155],
                ClientSubMissile3 = columns[156],
                ClientHitSubMissile1 = columns[157],
                ClientHitSubMissile2 = columns[158],
                ClientHitSubMissile3 = columns[159],
                ClientHitSubMissile4 = columns[160]
            })
            .ToList();
    }
}