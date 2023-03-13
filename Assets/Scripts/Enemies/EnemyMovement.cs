using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DoMove(Transform player)
    {
        if (player == null) return;

        Vector2 moveVel = player.position - transform.position;
        rb.velocity = moveVel.normalized * moveSpeed;
    }
}
