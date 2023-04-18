using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int spawnCap;
    [SerializeField] private float spawnOffset;
    private float camHeight;
    private float camWidth;

    public LayerMask wallMask;

    private void Start()
    {
        camHeight = Camera.main.orthographicSize * 2;
        camWidth = camHeight * Camera.main.aspect;
    }

    public void DoSpawn(GameObject enemy, List<Enemy> enemyList)
    {
        if (enemyList.Count >= spawnCap) return;

        GameObject tempEnemy = Instantiate(enemy, GetSpawnPos(), Quaternion.identity);

        enemyList.Add(tempEnemy.GetComponent<Enemy>());
    }

    private Vector3 GetSpawnPos()
    {
        Vector3 pos = new Vector3();

        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0:
                pos.x = Random.Range(-camWidth / 2, camWidth / 2);
                pos.y = camHeight / 2 + spawnOffset;
                break;

            case 1:
                pos.x = Random.Range(-camWidth / 2, camWidth / 2);
                pos.y = -camHeight / 2 - spawnOffset;
                break;

            case 2:
                pos.x = camWidth / 2 + spawnOffset;
                pos.y = Random.Range(-camHeight / 2, camHeight / 2);
                break;

            case 3:
                pos.x = -camWidth / 2 - spawnOffset;
                pos.y = Random.Range(-camHeight / 2, camHeight / 2);
                break;

            default:
                break;
        }

        pos.x += Camera.main.transform.position.x;
        pos.y += Camera.main.transform.position.y;

        return pos;
    }
}