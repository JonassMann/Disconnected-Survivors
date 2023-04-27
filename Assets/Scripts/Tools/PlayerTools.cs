using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerTools
{
    public static GameObject FindClosestEnemy(GameObject obj, string tag = "Enemy")
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject g in enemies)
        {
            if (g == obj) continue;

            float distance = Vector3.Distance(obj.transform.position, g.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = g;
            }
        }

        return closest;
    }

    public static GameObject FindFurthestEnemy(GameObject obj, string tag = "Enemy")
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        GameObject furthest = null;
        float furthestDistance = Mathf.Infinity;

        foreach (GameObject g in enemies)
        {
            if (g == obj) continue;

            float distance = Vector3.Distance(obj.transform.position, g.transform.position);
            if (distance > furthestDistance)
            {
                furthestDistance = distance;
                furthest = g;
            }
        }

        return furthest;
    }

    public static GameObject FindRandomEnemy(string tag = "Enemy")
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

        int rdm = Random.Range(0, enemies.Length);

        return enemies[rdm];
    }

    public static GameObject FindHighestHealth(string tag = "Enemy")
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        GameObject highHp = null;
        float highestHp = 0;

        foreach (GameObject g in enemies)
        {
            Enemy e = g.GetComponent<Enemy>();

            if (e.health > highestHp)
            {
                highestHp = e.health;
                highHp = g;
            }
        }

        return highHp;
    }

    public static float GetNextExp(int currentLevel)
    {
        return currentLevel * 100;
    }

    public static int SelectWeighted(List<int> weights)
    {
        int totalWeight = 0;
        foreach (int i in weights)
            totalWeight += i;

        int selectionValue = Random.Range(1, totalWeight+1);
        int incrementWeights = 0;

        for (int i = 0; i < weights.Count; i++)
        {
            incrementWeights += weights[i];
            if (selectionValue <= incrementWeights)
                return i;
        }

        return 0;
    }
}
