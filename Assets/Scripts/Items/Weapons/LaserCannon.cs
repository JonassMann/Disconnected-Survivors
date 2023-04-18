using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class LaserCannon : Weapon
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float multiShotTime;

    protected override void DoAttack()
    {
        base.DoAttack();
        StartCoroutine(SpawnProjectiles());
    }

    private IEnumerator SpawnProjectiles()
    {
        GameObject tempProjectile1 = Instantiate(projectile, transform.position, Quaternion.identity, transform);
        GameObject tempProjectile2 = Instantiate(projectile, transform.position, Quaternion.identity, transform);
        tempProjectile1.transform.GetChild(0).GetComponent<LaserCannonProjectile>().Spawn(stats, true);
        tempProjectile2.transform.GetChild(0).GetComponent<LaserCannonProjectile>().Spawn(stats, false);
        yield return null;
    }
}
