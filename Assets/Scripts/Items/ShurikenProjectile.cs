using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class ShurikenProjectile : MonoBehaviour
{
    private bool isActive = true;
    private float damage;

    public void Spawn(Vector3 direction, WeaponStats stats)
    {
        damage = stats.damage;
        transform.localScale = Vector3.one * stats.size;
        GetComponent<Rigidbody2D>().velocity = direction * stats.speed;
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
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
