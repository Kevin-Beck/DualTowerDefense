using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sequence", menuName = "Enemy Wave/Enemy Sequence")]
public class EnemySequence : ScriptableObject
{
    [SerializeField] string description;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyCount;
    [SerializeField] float spawnPace;

    public GameObject GetEnemy()
    {
        return enemyPrefab;
    }
    public int GetEnemyCount()
    {
        return enemyCount;
    }
    public float GetSpawnPace()
    {
        return spawnPace;
    }
}
