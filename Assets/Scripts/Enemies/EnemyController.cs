using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<Enemy> enemies;
    private GameObject player;
    private EnemySpawner spawner;

    [SerializeField] private GameObject enemyObject;

    private void Start()
    {
        enemies= new List<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GetComponent<EnemySpawner>();
    }

    void Update()
    {
        spawner.DoSpawn(enemyObject, enemies);
    }

    private void FixedUpdate()
    {
        for (int i = enemies.Count-1; i >= 0; i--)
        {
            if (enemies[i] == null)
            {
                player.GetComponent<PlayerController>().AddExp(50);

                enemies.RemoveAt(i);
                continue;
            }

            enemies[i].DoMove(player.transform);
        }
    }
}
