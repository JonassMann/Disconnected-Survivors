using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float gameTimer;
    public float maxGameTime;
    public float goldPerSec;

    private List<Enemy> enemies;
    private EnemySpawner spawner;

    private float spawnTimer;

    [SerializeField] private EnemyWave enemyWave;
    private int wavePos;

    private int killCount;
    private float goldCount;

    public TMP_Text killCountText;
    public TMP_Text goldCountText;

    private void Start()
    {
        enemies = new List<Enemy>();
        spawner = GetComponent<EnemySpawner>();

        spawnTimer = 0;
        gameTimer = 0;
        wavePos = 0;
    }

    void Update()
    {
        gameTimer += Time.deltaTime;
        goldCount += goldPerSec * Time.deltaTime;
        goldCountText.text = $"{(int)goldCount}";

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
                killCountText.text = $"{++killCount}";
                enemies.RemoveAt(i);
                continue;
            }

            enemies[i].DoMove();
        }
    }

    public void EndRound()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenu>().EndGame((int)goldCount);
        // Show game end screen
        // Add gold with simple formula to PlayerPrefs
    }
}
