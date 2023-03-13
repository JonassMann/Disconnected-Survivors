using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerTools
{
    public static GameObject FindClosestWithTag(GameObject obj, string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject g in objects)
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
}
