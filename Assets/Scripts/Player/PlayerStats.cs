using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class PlayerStats
{
    public float maxHealth = 100;
    public float regen = 0;
    public float armor = 0;
    public float moveSpeed = 5;
    public float expMult = 1;

    public static PlayerStats GetStats(PlayerStats stats)
    {
        PlayerStats result = new PlayerStats();

        return result;
    }
}