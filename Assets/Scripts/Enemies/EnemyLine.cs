using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyLine : Enemy
{
    public bool horizontal = true;

    public override void DoMove()
    {
        base.DoMove();

        Vector2 moveDir = player.transform.position - transform.position;
        if (horizontal)
            moveDir.y = 0;
        else
            moveDir.x = 0;

        rb.velocity = moveDir.normalized * stats.speed;
    }
}
