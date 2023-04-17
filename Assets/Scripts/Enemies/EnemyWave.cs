using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Wave", menuName = "Stats/Enemy Wave")]
public class EnemyWave : ScriptableObject
{
    [ShowInInspector]
    public List<WaveObject> waveList;

    [Serializable]
    public struct WaveObject
    {
        public GameObject enemy;
        public float interval;
        public float timeNext;
    }
}
