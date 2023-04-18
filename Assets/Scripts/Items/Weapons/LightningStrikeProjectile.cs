using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class LightningStrikeProjectile : MonoBehaviour
{
    private bool isActive = true;
    private float damage;

    public void Spawn(Vector3 direction, WeaponStatBlock stats)
    {
        damage = stats.damage;
        transform.localScale = Vector3.one * stats.size;
        Invoke(nameof(DestroyProjectile), stats.duration);
    }

    private void DestroyProjectile()
    {
        if (!isActive) return;

        isActive = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
