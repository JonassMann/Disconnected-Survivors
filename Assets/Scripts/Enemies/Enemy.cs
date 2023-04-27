using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected EnemyStats stats;

    public float health;

    protected GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = stats.maxHealth;
    }

    public void DoInit(GameObject playerObject)
    {
        player = playerObject;
    }

    public virtual void DoMove()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > 20)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(stats.touchDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0) return;

        player.GetComponent<PlayerController>().AddExp(stats.exp);
        Destroy(gameObject);
    }

}
