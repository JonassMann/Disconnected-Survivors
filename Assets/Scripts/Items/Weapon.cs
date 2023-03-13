using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponStats baseStats;
    protected WeaponStats stats;

    [SerializeField] private float attackSpeed;
    private float attackTimer;

    private void Awake()
    {
        stats = baseStats;
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

    public void SetStats(WeaponStats addStats)
    {
        stats = baseStats + addStats;
    }
}