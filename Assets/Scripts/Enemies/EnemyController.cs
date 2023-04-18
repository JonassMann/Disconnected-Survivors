using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float gameTimer;
    public float maxGameTime;
    public float goldPerSec;

    private List<Enemy> enemies;
    private GameObject player;
    private EnemySpawner spawner;

    private float spawnTimer;

    [SerializeField] private EnemyWave enemyWave;
    private int wavePos;

    private void Start()
    {
        enemies = new List<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GetComponent<EnemySpawner>();

        spawnTimer = 0;
        gameTimer = 0;
        wavePos = 0;
    }

    void Update()
    {
        gameTimer += Time.deltaTime;

        if (gameTimer > maxGameTime)
            EndRound();

        if (wavePos >= enemyWave.waveList.Count)
        {
            Debug.Log("Wave list end");
            return;
        }

        if (gameTimer >= enemyWave.waveList[wavePos].timeNext)
            wavePos++;

        spawnTimer += Time.deltaTime;
        if (spawnTimer < enemyWave.waveList[wavePos].interval) return;

        spawnTimer = 0;
        spawner.DoSpawn(enemyWave.waveList[wavePos].enemy, enemies);
    }

    private void FixedUpdate()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
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

    public void EndRound()
    {
        int goldGained = (int)(goldPerSec * gameTimer);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenu>().EndGame(goldGained);
        // Show game end screen
        // Add gold with simple formula to PlayerPrefs
    }
}
