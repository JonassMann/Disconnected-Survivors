using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Weapon Stats", menuName = "Stats/Weapon Stats")]
public class WeaponStats : ScriptableObject
{
    public List<WeaponStatBlock> stats;
}

[Serializable]
public class WeaponStatBlock
{
    public float damage = 1;
    public float size = 1;
    public float speed = 1;
    public float duration = 3;
    public float pCount = 1;
    public float cooldown = 1;
    public float pierce = 0;

    public static WeaponStatBlock operator +(WeaponStatBlock a, WeaponStatBlock b)
    {
        WeaponStatBlock result = new WeaponStatBlock();
        result.damage = a.damage + b.damage;
        result.size = a.size + b.size;
        result.speed = a.speed + b.speed;
        result.duration = a.duration + b.duration;
        result.pCount = a.pCount + b.pCount;
        result.cooldown = a.cooldown + b.cooldown;
        result.pierce = a.pierce + b.pierce;

        return result;
    }
}