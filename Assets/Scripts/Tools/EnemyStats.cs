using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "Stats/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public float speed;
    public float maxHealth;

    public static EnemyStats operator +(EnemyStats a, EnemyStats b)
    {
        EnemyStats result = new EnemyStats();
        result.speed = a.speed + b.speed;
        result.maxHealth = a.maxHealth + b.maxHealth;

        return result;
    }
}