using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private EnemyStats stats;

    public float health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = stats.maxHealth;
    }

    public void DoMove(Transform player)
    {
        if (player == null) return;

        Vector2 moveVel = player.position - transform.position;
        rb.velocity = moveVel.normalized * stats.speed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0) return;

        Destroy(gameObject);
    }

}
