using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public ThingRuntimeSet tiles;

    public float speed = 10f;
    public float curSpeed;
    public float dist = 0.2f;
    private Transform target;
    private int wavepointIndex;
    private int direction = 1; // 1 = forward, -1 = backwards;


    List<Coroutine> walkSpeedResets = new List<Coroutine>();
    List<Coroutine> directionResets = new List<Coroutine>();

    private void Start()
    {
        wavepointIndex = tiles.Items.Count-1;
        target = tiles.Items[wavepointIndex].transform;
        curSpeed = speed;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * curSpeed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= dist)
        {
            GetNextWayPoint();
        }

        void GetNextWayPoint()
        {
            wavepointIndex += -1 * direction;
            if(wavepointIndex > tiles.Items.Count - 1)
            {
                wavepointIndex = tiles.Items.Count -1;
            }
            if (wavepointIndex < 0)
            {
                Destroy(gameObject);
                return;
            }

            target = tiles.Items[wavepointIndex].transform;
        }
    }
    public void Slow(float time, float intensity)
    {
        walkSpeedResets.Add(StartCoroutine(SlowMovement(time, intensity)));
    }
    public IEnumerator SlowMovement(float time, float intensity)
    {        
        curSpeed *= intensity;
        yield return new WaitForSeconds(time);
        ResetSpeed();
    }
    public void ResetSpeed()
    {
        curSpeed = speed;
        foreach (Coroutine c in walkSpeedResets)
            StopCoroutine(c);
    }


    public void Reverse(float time)
    {
        directionResets.Add(StartCoroutine(ReverseDirection(time)));
    }
    private IEnumerator ReverseDirection(float time)
    {
        direction = -1;
        wavepointIndex++;
        yield return new WaitForSeconds(3);
        ResetDirection();
    }
    public void ResetDirection()
    {
        direction = 1;
        foreach (Coroutine c in directionResets)
            StopCoroutine(c);
    }
}
