﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.Models;

public record Skills
{
    public string? Skill { get; init; }
    public string? Id { get; init; }
    public string? CharClass { get; init; }
    public string? SkillDesc { get; init; }
    public int? SrvStFunc { get; init; }
    public int? SrvDoFunc { get; init; }
    public int? SrvStopFunc { get; init; }
    public int? PrgStack { get; init; }
    public int? SrvPrgFunc1 { get; init; }
    public int? SrvPrgFunc2 { get; init; }
    public int? SrvPrgFunc3 { get; init; }
    public string? PrgCalc1 { get; init; }
    public string? PrgCalc2 { get; init; }
    public string? PrgCalc3 { get; init; }
    public int? PrgDam { get; init; }
    public string? SrvMissile { get; init; }
    public string? DecQuant { get; init; }
    public int? Lob { get; init; }
    public string? SrvMissileA { get; init; }
    public string? SrvMissileB { get; init; }
    public string? SrvMissileC { get; init; }
    public string? UseServerMissilesOnRemoteClients { get; init; }
    public string? SrvOverlay { get; init; }
    public int? AuraFilter { get; init; }
    public string? AuraState { get; init; }
    public string? AuraTargetState { get; init; }
    public string? AuraLenCalc { get; init; }
    public string? AuraRangeCalc { get; init; }
    public string? AuraStat1 { get; init; }
    public string? AuraStatCalc1 { get; init; }
    public string? AuraStat2 { get; init; }
    public string? AuraStatCalc2 { get; init; }
    public string? AuraStat3 { get; init; }
    public string? AuraStatCalc3 { get; init; }
    public string? AuraStat4 { get; init; }
    public string? AuraStatCalc4 { get; init; }
    public string? AuraStat5 { get; init; }
    public string? AuraStatCalc5 { get; init; }
    public string? AuraStat6 { get; init; }
    public string? AuraStatCalc6 { get; init; }
    public string? AuraEvent1 { get; init; }
    public string? AuraEventFunc1 { get; init; }
    public string? AuraEvent2 { get; init; }
    public string? AuraEventFunc2 { get; init; }
    public string? AuraEvent3 { get; init; }
    public string? AuraEventFunc3 { get; init; }
    public string? PassiveState { get; init; }
    public string? PassiveIType { get; init; }
    public string? PassiveReqWeaponCount { get; init; }
    public string? PassiveStat1 { get; init; }
    public string? PassiveCalc1 { get; init; }
    public string? PassiveStat2 { get; init; }
    public string? PassiveCalc2 { get; init; }
    public string? PassiveStat3 { get; init; }
    public string? PassiveCalc3 { get; init; }
    public string? PassiveStat4 { get; init; }
    public string? PassiveCalc4 { get; init; }
    public string? PassiveStat5 { get; init; }
    public string? PassiveCalc5 { get; init; }
    public string? PassiveStat6 { get; init; }
    public string? PassiveCalc6 { get; init; }
    public string? PassiveStat7 { get; init; }
    public string? PassiveCalc7 { get; init; }
    public string? PassiveStat8 { get; init; }
    public string? PassiveCalc8 { get; init; }
    public string? PassiveStat9 { get; init; }
    public string? PassiveCalc9 { get; init; }
    public string? PassiveStat10 { get; init; }
    public string? PassiveCalc10 { get; init; }
    public string? PassiveStat11 { get; init; }
    public string? PassiveCalc11 { get; init; }
    public string? PassiveStat12 { get; init; }
    public string? PassiveCalc12 { get; init; }
    public string? PassiveStat13 { get; init; }
    public string? PassiveCalc13 { get; init; }
    public string? PassiveStat14 { get; init; }
    public string? PassiveCalc14 { get; init; }
    public string? Summon { get; init; }
    public string? PetType { get; init; }
    public string? PetMax { get; init; }
    public string? SumMode { get; init; }
    public string? SumSkill1 { get; init; }
    public string? SumSk1Calc { get; init; }
    public string? SumSkill2 { get; init; }
    public string? SumSk2Calc { get; init; }
    public string? SumSkill3 { get; init; }
    public string? SumSk3Calc { get; init; }
    public string? SumSkill4 { get; init; }
    public string? SumSk4Calc { get; init; }
    public string? SumSkill5 { get; init; }
    public string? SumSk5Calc { get; init; }
    public string? SumUmod { get; init; }
    public string? SumOverlay { get; init; }
    public string? StSuccessOnly { get; init; }
    public string? StSound { get; init; }
    public string? StSoundClass { get; init; }
    public string? StSoundDelay { get; init; }
    public string? WeaponSnd { get; init; }
    public string? DoSound { get; init; }
    public string? DoSoundA { get; init; }
    public string? DoSoundB { get; init; }
    public string? TgtOverlay { get; init; }
    public string? TgtSound { get; init; }
    public string? PrgOverlay { get; init; }
    public string? PrgSound { get; init; }
    public string? CastOverlay { get; init; }
    public string? CltOverlayA { get; init; }
    public string? CltOverlayB { get; init; }
    public string? CltStFunc { get; init; }
    public string? CltDoFunc { get; init; }
    public string? CltStopFunc { get; init; }
    public string? CltPrgFunc1 { get; init; }
    public string? CltPrgFunc2 { get; init; }
    public string? CltPrgFunc3 { get; init; }
    public string? CltMissile { get; init; }
    public string? CltMissileA { get; init; }
    public string? CltMissileB { get; init; }
    public string? CltMissileC { get; init; }
    public string? CltMissileD { get; init; }
    public string? CltCalc1 { get; init; }
    public string? CltCalc1Desc { get; init; }
    public string? CltCalc2 { get; init; }
    public string? CltCalc2Desc { get; init; }
    public string? CltCalc3 { get; init; }
    public string? CltCalc3Desc { get; init; }
    public string? Warp { get; init; }
    public string? Immediate { get; init; }
    public string? Enhanceable { get; init; }
    public string? AttackRank { get; init; }
    public string? NoAmmo { get; init; }
    public string? Range { get; init; }
    public string? WeapSel { get; init; }
    public string? ITypeA1 { get; init; }
    public string? ITypeA2 { get; init; }
    public string? ITypeA3 { get; init; }
    public string? ETypeA1 { get; init; }
    public string? ETypeA2 { get; init; }
    public string? ITypeB1 { get; init; }
    public string? ITypeB2 { get; init; }
    public string? ITypeB3 { get; init; }
    public string? ETypeB1 { get; init; }
    public string? ETypeB2 { get; init; }
    public string? Anim { get; init; }
    public string? SeqTrans { get; init; }
    public string? MonAnim { get; init; }
    public string? SeqNum { get; init; }
    public string? SeqInput { get; init; }
    public string? Durability { get; init; }
    public string? UseAttackRate { get; init; }
    public string? LineOfSight { get; init; }
    public string? TargetableOnly { get; init; }
    public string? SearchEnemyXY { get; init; }
    public string? SearchEnemyNear { get; init; }
    public string? SearchOpenXY { get; init; }
    public string? SelectProc { get; init; }
    public string? TargetCorpse { get; init; }
    public string? TargetPet { get; init; }
    public string? TargetAlly { get; init; }
    public string? TargetItem { get; init; }
    public string? AttackNoMana { get; init; }
    public string? TgtPlaceCheck { get; init; }
    public string? KeepCursorStateOnKill { get; init; }
    public string? ContinueCastUnselected { get; init; }
    public string? ClearSelectedOnHold { get; init; }
    public string? ItemEffect { get; init; }
    public string? ItemCltEffect { get; init; }
    public string? ItemTgtDo { get; init; }
    public string? ItemTarget { get; init; }
    public string? ItemUseRestrict { get; init; }
    public string? ItemCheckStart { get; init; }
    public string? ItemCltCheckStart { get; init; }
    public string? ItemCastSound { get; init; }
    public string? ItemCastOverlay { get; init; }
    public string? SkPoints { get; init; }
    public string? ReqLevel { get; init; }
    public string? MaxLvl { get; init; }
    public string? ReqStr { get; init; }
    public string? ReqDex { get; init; }
    public string? ReqInt { get; init; }
    public string? ReqVit { get; init; }
    public string? ReqSkill1 { get; init; }
    public string? ReqSkill2 { get; init; }
    public string? ReqSkill3 { get; init; }
    public string? Restrict { get; init; }
    public string? State1 { get; init; }
    public string? State2 { get; init; }
    public string? State3 { get; init; }
    public string? LocalDelay { get; init; }
    public string? GlobalDelay { get; init; }
    public string? LeftSkill { get; init; }
    public string? RightSkill { get; init; }
    public string? Repeat { get; init; }
    public string? AlwaysHit { get; init; }
    public string? UseManaOnDo { get; init; }
    public string? StartMana { get; init; }
    public string? MinMana { get; init; }
    public string? ManaShift { get; init; }
    public string? Mana { get; init; }
    public string? LvlMana { get; init; }
    public bool? Interrupt { get; init; }
    public string? InTown { get; init; }
    public string? Aura { get; init; }
    public string? Periodic { get; init; }
    public string? PerDelay { get; init; }
    public string? Finishing { get; init; }
    public string? PrgChargesToCast { get; init; }
    public string? PrgChargesConsumed { get; init; }
    public string? Passive { get; init; }
    public string? Progressive { get; init; }
    public string? Scroll { get; init; }
    public string? Calc1 { get; init; }
    public string? Calc1Desc { get; init; }
    public string? Calc2 { get; init; }
    public string? Calc2Desc { get; init; }
    public string? Calc3 { get; init; }
    public string? Calc3Desc { get; init; }
    public string? Calc4 { get; init; }
    public string? Calc4Desc { get; init; }
    public string? Calc5 { get; init; }
    public string? Calc5Desc { get; init; }
    public string? Calc6 { get; init; }
    public string? Calc6Desc { get; init; }
    public string? Param1 { get; init; }
    public string? Param1Desc { get; init; }
    public string? Param2 { get; init; }
    public string? Param2Desc { get; init; }
    public string? Param3 { get; init; }
    public string? Param3Desc { get; init; }
    public string? Param4 { get; init; }
    public string? Param4Desc { get; init; }
    public string? Param5 { get; init; }
    public string? Param5Desc { get; init; }
    public string? Param6 { get; init; }
    public string? Param6Desc { get; init; }
    public string? Param7 { get; init; }
    public string? Param7Desc { get; init; }
    public string? Param8 { get; init; }
    public string? Param8Desc { get; init; }
    public string? Param9 { get; init; }
    public string? Param9Desc { get; init; }
    public string? Param10 { get; init; }
    public string? Param10Desc { get; init; }
    public string? Param11 { get; init; }
    public string? Param11Desc { get; init; }
    public string? Param12 { get; init; }
    public string? Param12Desc { get; init; }
    public bool? InGame { get; init; }
    public int? ToHit { get; init; }
    public int? LevToHit { get; init; }
    public string? ToHitCalc { get; init; }
    public string? ResultFlags { get; init; }
    public string? HitFlags { get; init; }
    public int? HitClass { get; init; }
    public int? Kick { get; init; }
    public int? HitShift { get; init; }
    public int? SrcDam { get; init; }
    public int? MinDam { get; init; }
    public int? MinLevDam1 { get; init; }
    public int? MinLevDam2 { get; init; }
    public int? MinLevDam3 { get; init; }
    public int? MinLevDam4 { get; init; }
    public int? MinLevDam5 { get; init; }
    public int? MaxDam { get; init; }
    public int? MaxLevDam1 { get; init; }
    public int? MaxLevDam2 { get; init; }
    public int? MaxLevDam3 { get; init; }
    public int? MaxLevDam4 { get; init; }
    public int? MaxLevDam5 { get; init; }
    public string? DmgSymPerCalc { get; init; }
    public string? EType { get; init; }
    public int? EMin { get; init; }
    public int? EMinLev1 { get; init; }
    public int? EMinLev2 { get; init; }
    public int? EMinLev3 { get; init; }
    public int? EMinLev4 { get; init; }
    public int? EMinLev5 { get; init; }
    public int? EMax { get; init; }
    public int? EMaxLev1 { get; init; }
    public int? EMaxLev2 { get; init; }
    public int? EMaxLev3 { get; init; }
    public int? EMaxLev4 { get; init; }
    public int? EMaxLev5 { get; init; }
    public string? EDmgSymPerCalc { get; init; }
    public int? ELen { get; init; }
    public int? ELevLen1 { get; init; }
    public int? ELevLen2 { get; init; }
    public int? ELevLen3 { get; init; }
    public string? ELenSymPerCalc { get; init; }
    public int? AIType { get; init; }
    public int? AIBonus { get; init; }
    public int? CostMult { get; init; }
    public int? CostAdd { get; init; }
}
