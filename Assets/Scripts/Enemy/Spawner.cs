using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public PositionReference start;

    public void SpawnEnemy()
    {
        GameObject go = Instantiate(enemyPrefab, new Vector3(start.Value.X * 4, 5, start.Value.Z * 4), Quaternion.identity);
        go.transform.parent = transform;
    }
}
