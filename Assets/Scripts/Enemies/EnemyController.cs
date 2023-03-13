using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<EnemyMovement> enemies;
    private GameObject player;
    private EnemySpawner spawner;

    [SerializeField] private GameObject enemyObject;

    private void Start()
    {
        enemies= new List<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GetComponent<EnemySpawner>();
    }

    void Update()
    {
        spawner.DoSpawn(enemyObject, enemies);
    }

    private void FixedUpdate()
    {
        foreach (EnemyMovement em in enemies)
            em.DoMove(player.transform);
    }
}
