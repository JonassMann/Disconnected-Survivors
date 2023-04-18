using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class LightningStrike : Weapon
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float multiShotTime;

    protected override void DoAttack()
    {
        base.DoAttack();

        GameObject enemy = PlayerTools.FindRandomEnemy();
        if (enemy == null) return;

        StartCoroutine(SpawnProjectiles(enemy.transform.position));
    }

    private IEnumerator SpawnProjectiles(Vector3 pos)
    {

        for (int i = 0; i < stats.pCount; i++)
        {
            GameObject tempProjectile = Instantiate(projectile, pos, Quaternion.identity);
            tempProjectile.GetComponent<LightningStrikeProjectile>().Spawn(pos, stats);

            yield return new WaitForSeconds(multiShotTime);
        }
    }
}
