using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyLine : Enemy
{
    public override void DoMove()
    {
        base.DoMove();

        Vector2 moveVel = player.transform.position - transform.position;
        rb.velocity = moveVel.normalized * stats.speed;
    }
}
