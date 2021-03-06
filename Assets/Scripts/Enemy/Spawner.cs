﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameEvent WaveCompleted;
    [SerializeField] public List<Wave> Waves = new List<Wave>();
    public PositionReference start;

    private int waveIndex = 0;

    public ThingRuntimeSet currentEnemies;
    [SerializeField] GameEvent EnemySpawned;

    public void DestroyAllEnemies()
    {
        foreach (Thing enemy in currentEnemies.Items.ToArray())
            Destroy(enemy.gameObject);
    }
    public Wave GetNextWaveData()
    {
        if (waveIndex >= Waves.Count)
            return null;
        return Waves[waveIndex];
    }
    public void SpawnNextWave()
    {
        if (waveIndex >= Waves.Count)
        {
            Debug.Log("Level Completed");
            return;
        }
        else
        {
            StartCoroutine(SpawnWave());            
        }
    }
    public void CheckForWaveCompletion()
    {
        if(currentEnemies.Items.Count == 0) // TODO need this to only detect last enemy
        {
            WaveCompleted.Raise();
        }
    }
    IEnumerator SpawnWave()
    {
        for(int i = 0; i < Waves[waveIndex].sequences.Count; i++)
        {
            EnemySequence es = Waves[waveIndex].sequences[i];

            for (int k = 0; k < es.GetEnemyCount(); k++)
            {
                SpawnEnemy(es.GetEnemy());
                EnemySpawned.Raise();
                yield return new WaitForSeconds(Waves[waveIndex].sequences[i].GetSpawnPace());
            }
        }
        waveIndex++;
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject go = Instantiate(enemyPrefab, new Vector3(start.Value.X * 4, 2, start.Value.Z * 4), Quaternion.identity);
        go.transform.parent = transform;
    }
}
