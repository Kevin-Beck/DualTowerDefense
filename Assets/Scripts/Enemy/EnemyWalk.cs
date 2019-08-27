using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public ThingRuntimeSet tiles;

    public float speed = 10f;
    private Transform target;
    private int wavepointIndex;

    private void Start()
    {
        wavepointIndex = tiles.Items.Count-1;
        target = tiles.Items[wavepointIndex].transform;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWayPoint();
        }

        void GetNextWayPoint()
        {
            wavepointIndex--;
            target = tiles.Items[wavepointIndex].transform;
        }
    }
}
