using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Sprite itemImg;
    public string itemName;

    [SerializeField] private WeaponStats baseStats;
    public string childWeapon = "";
    [SerializeField] private GameObject evolvedWeapon;
    protected WeaponStatBlock stats;
    public int level = 1;

    [SerializeField] private float attackSpeed;
    private float attackTimer;

    private void Awake()
    {
        if (evolvedWeapon != null)
            evolvedWeapon.GetComponent<Weapon>().childWeapon = itemName;
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

    public GameObject LevelUp(GameObject controller)
    {
        level++;

        if (level > baseStats.stats.Count)
        {
            if (evolvedWeapon == null) return controller;
        }

        // If max level, try evolve

        SetStats();

        if (level >= baseStats.stats.Count)
            if (evolvedWeapon != null) return evolvedWeapon;
            else return controller;

        return null;
    }

    public void SetStats(WeaponStatBlock addStats = null)
    {
        if (level > baseStats.stats.Count) return;

        if (addStats == null)
            stats = baseStats.stats[level - 1];
        else
            stats = baseStats.stats[level - 1] + addStats;
    }
}