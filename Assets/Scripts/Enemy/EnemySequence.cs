using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sequence", menuName = "Enemy Wave/Enemy Sequence")]
public class EnemySequence : ScriptableObject
{
    [SerializeField] string description = "Sequence of enemies.";
    [SerializeField] GameObject enemyPrefab = default;
    [SerializeField] int enemyCount = 1;
    [SerializeField] float spawnPace = 2;

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
    public string GetDescription()
    {
        return description;
    }
}
