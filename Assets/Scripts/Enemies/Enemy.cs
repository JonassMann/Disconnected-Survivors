using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private EnemyStats stats;

    public float health;
    public float touchDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = stats.maxHealth;
    }

    public bool DoMove(Transform player)
    {
        if (player == null) return false;

        Vector2 moveVel = player.position - transform.position;
        rb.velocity = moveVel.normalized * stats.speed;

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Test");

        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(touchDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0) return;

        Destroy(gameObject);
    }

}
