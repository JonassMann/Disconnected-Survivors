using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class LaserCannonProjectile : MonoBehaviour
{
    private bool isActive = true;
    private float damage;

    public void Spawn(WeaponStatBlock stats, bool flip)
    {
        damage = stats.damage;
        Vector3 tempScale = Vector3.one * stats.size;
        tempScale.x = 100;
        if (flip) tempScale.x *= -1;
        transform.parent.localScale = tempScale;
        Invoke(nameof(DestroyProjectile), stats.duration);
    }

    private void DestroyProjectile()
    {
        if (!isActive) return;

        isActive = false;
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
