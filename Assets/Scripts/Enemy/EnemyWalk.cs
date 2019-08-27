using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public ThingRuntimeSet tiles;

    public float speed = 10f;
    public float dist = 0.2f;
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

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= dist)
        {
            GetNextWayPoint();
        }

        void GetNextWayPoint()
        {
            wavepointIndex--;
            if (wavepointIndex < 0)
            {
                Destroy(gameObject);
                return;
            }

            target = tiles.Items[wavepointIndex].transform;
        }
    }
}
