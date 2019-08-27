using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public PositionReference start;
    public float timeBetweenWaves = 5f; // reference a float called time til next wave instead
    public float countdown = 2f; // initial delay, also should reference a float ref

    private int waveIndex = 0;

    public void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {

        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SpawnEnemy()
    {
        GameObject go = Instantiate(enemyPrefab, new Vector3(start.Value.X * 4, 5, start.Value.Z * 4), Quaternion.identity);
        go.transform.parent = transform;
    }
}
