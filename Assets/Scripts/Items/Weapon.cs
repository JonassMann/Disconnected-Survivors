using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Sprite itemImg;
    public string itemName;

    [SerializeField] private WeaponStats baseStats;
    [SerializeField] private GameObject evolvedWeapon;
    protected WeaponStatBlock stats;
    public int level = 1;

    public int maxLevel;

    [SerializeField] private float attackSpeed;
    private float attackTimer;

    private void Awake()
    {
        stats = baseStats.stats[0];
    }

    private void Start()
    {
        attackTimer = attackSpeed * (100 - stats.cooldown) / 100;
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer > 0) return;
        attackTimer = attackSpeed * (100 - stats.cooldown) / 100;

        DoAttack();
    }

    protected virtual void DoAttack()
    {
        // Debug.Log("Attack: " + name);
    }

    public bool LevelUp()
    {
        level++;

        // If max level, try evolve

        SetStats();

        if (level >= maxLevel)
            return true;

        return false;
    }

    public void SetStats(WeaponStatBlock addStats = null)
    {
        if (level > maxLevel) return;

        if (addStats == null)
            stats = baseStats.stats[level-1];
        else
            stats = baseStats.stats[level-1] + addStats;
    }
}