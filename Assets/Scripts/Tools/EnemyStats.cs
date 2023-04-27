using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "Stats/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public float speed;
    public float maxHealth;
    public float touchDamage;
    public float exp;

    public static EnemyStats operator +(EnemyStats a, EnemyStats b)
    {
        EnemyStats result = new EnemyStats();
        result.speed = a.speed + b.speed;
        result.maxHealth = a.maxHealth + b.maxHealth;
        result.touchDamage = a.touchDamage + b.touchDamage;
        result.exp = a.exp + b.exp;

        return result;
    }
}
