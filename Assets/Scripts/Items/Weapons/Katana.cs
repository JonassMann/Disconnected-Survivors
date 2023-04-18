using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Katana : Weapon
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float multiShotTime;

    private bool attackRight = true;

    protected override void DoAttack()
    {
        base.DoAttack();

        GameObject closestEnemy = PlayerTools.FindClosestEnemy(gameObject);
        if (closestEnemy == null) return;

        StartCoroutine(SpawnProjectiles());
    }

    private IEnumerator SpawnProjectiles()
    {
        for (int i = 0; i < stats.pCount; i++)
        {
            GameObject tempProjectile = Instantiate(projectile, transform.position, Quaternion.identity, transform);
            tempProjectile.transform.GetChild(0).GetComponent<KatanaProjectile>().Spawn(stats, attackRight);

            attackRight = !attackRight;
            yield return new WaitForSeconds(multiShotTime);
        }
    }
}
