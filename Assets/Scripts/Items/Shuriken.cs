using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Shuriken : Weapon
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float multiShotTime;

    protected override void DoAttack()
    {
        base.DoAttack();

        GameObject closestEnemy = PlayerTools.FindClosestEnemy(gameObject);
        if (closestEnemy == null) return;

        StartCoroutine(SpawnProjectiles((closestEnemy.transform.position - transform.position).normalized));
    }

    private IEnumerator SpawnProjectiles(Vector3 direction)
    {

        for (int i = 0; i < stats.pCount; i++)
        {
            GameObject tempProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            tempProjectile.GetComponent<ShurikenProjectile>().Spawn(direction, stats);

            yield return new WaitForSeconds(multiShotTime);
        }
    }
}
