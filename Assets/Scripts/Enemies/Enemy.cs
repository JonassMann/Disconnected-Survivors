using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected EnemyStats stats;

    public float health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = stats.maxHealth;
    }

    public virtual void DoMove(Transform player)
    {
        if (player == null) return;

        Vector2 moveVel = player.position - transform.position;
        rb.velocity = moveVel.normalized * stats.speed;
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

        Destroy(gameObject);
    }

}
