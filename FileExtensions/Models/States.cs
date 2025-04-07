﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RReimaginedTools.Models;


public record States
{
    public string? StateId { get; init; }
    public int? Id { get; init; }
    public string? Group { get; init; }
    public string? Remhit { get; init; }
    public string? Nosend { get; init; }
    public string? Transform { get; init; }
    public string? Aura { get; init; }
    public string? Curable { get; init; }
    public string? Curse { get; init; }
    public string? Active { get; init; }
    public string? Restrict { get; init; }
    public string? Disguise { get; init; }
    public string? AttBlue { get; init; }
    public string? DamBlue { get; init; }
    public string? ArmBlue { get; init; }
    public string? RfBlue { get; init; }
    public string? RlBlue { get; init; }
    public string? RcBlue { get; init; }
    public string? StambarBlue { get; init; }
    public string? RpBlue { get; init; }
    public string? AttRed { get; init; }
    public string? DamRed { get; init; }
    public string? ArmRed { get; init; }
    public string? RfRed { get; init; }
    public string? RlRed { get; init; }
    public string? RcRed { get; init; }
    public string? RpRed { get; init; }
    public string? Exp { get; init; }
    public string? PlrStayDeath { get; init; }
    public string? MonStayDeath { get; init; }
    public string? BossStayDeath { get; init; }
    public string? Hide { get; init; }
    public string? HideDead { get; init; }
    public string? Shatter { get; init; }
    public string? UDead { get; init; }
    public string? Life { get; init; }
    public string? Green { get; init; }
    public string? Pgsv { get; init; }
    public string? NoOverlays { get; init; }
    public string? NoClear { get; init; }
    public string? BossInv { get; init; }
    public string? MeleeOnly { get; init; }
    public string? NotOnDead { get; init; }
    public string? Overlay1 { get; init; }
    public string? Overlay2 { get; init; }
    public string? Overlay3 { get; init; }
    public string? Overlay4 { get; init; }
    public string? PgsvOverlay { get; init; }
    public string? CastOverlay { get; init; }
    public string? RemOverlay { get; init; }
    public string? Stat { get; init; }
    public string? SetFunc { get; init; }
    public string? RemFunc { get; init; }
    public string? Missile { get; init; }
    public string? Skill { get; init; }
    public string? ItemType { get; init; }
    public string? ItemTrans { get; init; }
    public string? ColorPri { get; init; }
    public string? ColorShift { get; init; }
    public int? LightR { get; init; }
    public int? LightG { get; init; }
    public int? LightB { get; init; }
    public string? OnSound { get; init; }
    public string? OffSound { get; init; }
    public string? GfxType { get; init; }
    public string? GfxClass { get; init; }
    public string? CltEvent { get; init; }
    public string? CltEventFunc { get; init; }
    public string? CltActiveFunc { get; init; }
    public string? SrvActiveFunc { get; init; }
    public string? CanStack { get; init; }
    public string? SunderFull { get; init; }
    public string? SunderResReduce { get; init; }
}
