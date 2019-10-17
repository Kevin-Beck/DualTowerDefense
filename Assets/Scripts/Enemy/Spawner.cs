using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameEvent WaveCompleted;
    [SerializeField] public List<Wave> Waves = new List<Wave>();
    public PositionReference start;

    private int waveIndex = 0;

    public ThingRuntimeSet currentEnemies;    

    public void DestroyAllEnemies()
    {
        foreach (Thing enemy in currentEnemies.Items.ToArray())
            Destroy(enemy.gameObject);
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

    IEnumerator SpawnWave()
    {
        for(int i = 0; i < Waves[waveIndex].sequences.Count; i++)
        {
            EnemySequence es = Waves[waveIndex].sequences[i];

            for (int k = 0; k < es.GetEnemyCount(); k++)
            {
                SpawnEnemy(es.GetEnemy());
                yield return new WaitForSeconds(Waves[waveIndex].sequences[i].GetSpawnPace());
            }
        }
        waveIndex++;
        WaveCompleted.Raise();
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject go = Instantiate(enemyPrefab, new Vector3(start.Value.X * 4, 3, start.Value.Z * 4), Quaternion.identity);
        go.transform.parent = transform;
    }
}
