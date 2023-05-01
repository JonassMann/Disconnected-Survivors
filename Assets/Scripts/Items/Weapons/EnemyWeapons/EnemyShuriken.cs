using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyShuriken : Weapon
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float multiShotTime;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void DoAttack()
    {
        base.DoAttack();

        StartCoroutine(SpawnProjectiles((player.transform.position - transform.position).normalized));
    }

    private IEnumerator SpawnProjectiles(Vector3 direction)
    {

        for (int i = 0; i < stats.pCount; i++)
        {
            GameObject tempProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            tempProjectile.GetComponent<EnemyShuriken_Projectile>().Spawn(direction, stats);

            yield return new WaitForSeconds(multiShotTime);
        }
    }
}
