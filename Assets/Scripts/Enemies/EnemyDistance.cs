using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyDistance : Enemy
{
    public float closeDistance;
    public float farDistance;
    public float backMultiplier = 1;

    private bool towards = true;

    public override void DoMove()
    {
        base.DoMove();
        if (player == null) return;

        Vector2 moveVel = player.transform.position - transform.position;

        if (towards && Vector2.Distance(transform.position, player.transform.position) < closeDistance)
            towards = false;
        else if (!towards && Vector2.Distance(transform.position, player.transform.position) > farDistance)
            towards = true;

        if(towards)
            rb.velocity = moveVel.normalized * stats.speed;
        else
            rb.velocity = moveVel.normalized * stats.speed * backMultiplier * -1;
    }
}
