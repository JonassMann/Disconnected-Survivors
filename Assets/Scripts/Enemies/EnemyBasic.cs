using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyBasic : Enemy
{
    public override void DoMove(Transform player)
    {
        base.DoMove(player);

        if (player == null) return;

        Vector2 moveVel = player.position - transform.position;
        rb.velocity = moveVel.normalized * stats.speed;
    }
}
