using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Stats", menuName = "Stats/Weapon Stats")]
public class WeaponStats : ScriptableObject
{
    public float damage;
    public float size;
    public float speed;
    public float duration;
    public float pCount;
    public float cooldown;

    public static WeaponStats operator +(WeaponStats a, WeaponStats b)
    {
        WeaponStats result = new WeaponStats();
        result.damage = a.damage + b.damage;
        result.size = a.size + b.size;
        result.speed = a.speed + b.speed;
        result.duration = a.duration + b.duration;
        result.pCount = a.pCount + b.pCount;
        result.cooldown = a.cooldown + b.cooldown;

        return result;
    }
}
