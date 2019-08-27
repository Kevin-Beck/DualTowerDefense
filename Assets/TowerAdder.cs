using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAdder : MonoBehaviour
{
    public GameObject tower;

    public IntReference MazeX;
    public IntReference MazeZ;

    public ThingRuntimeSet towers;

    public void AddRandomTower()
    {
        GameObject go = Instantiate(tower, 4* new Vector3(Random.Range(0, MazeX), .5f, Random.Range(0, MazeZ)), Quaternion.identity);
        go.transform.parent = transform;
    }
    public void AddAHundo()
    {
        for (int i = 0; i < 100; i++)
            AddRandomTower();
    }
    public void DestroyAllTowers()
    {
        foreach(Thing t in towers.Items)
        {
            Destroy(t.gameObject);
        }
    }
}
