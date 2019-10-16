using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [Header("Path Directional Data")]
    public ThingRuntimeSet tiles;
    private Transform target;
    private int wavepointIndex;
    private int direction = 1; // 1 = forward, -1 = backwards;


    [Header("Walking Variables")]
    public float speed = 10f;
    public float curSpeed;
    public float dist = 0.2f;

    [Header("Warping Variables")]
    public bool warper = false;
    private bool timeToWarp = true;
    public int warpStepMin = 3;
    public int warpStepMax = 3;
    private int warpStep = 3;
    public float warpTime = 2;
    public GameObject warpParticles;


    [Header("Coroutine Storage")]
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
        if (warper && timeToWarp)
        {
            speed = 1;
            if(timeToWarp)
                StartCoroutine(Warp());
        }
        else
        {
            Vector3 dir = target.position - transform.position;

            transform.Translate(dir.normalized * curSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= dist)
            {
                GetNextWayPoint();
            }
        }
    }

    void GetNextWayPoint()
    {
        wavepointIndex += -1 * direction;
        if (wavepointIndex > tiles.Items.Count - 1)
        {
            wavepointIndex = tiles.Items.Count - 1;
        }
        if (wavepointIndex < 0)
        {
            Destroy(gameObject);
            return;
        }

        target = tiles.Items[wavepointIndex].transform;
    }

    public void Slow(float time, float intensity)
    {
        walkSpeedResets.Add(StartCoroutine(SlowMovement(time, intensity)));
    }
    private IEnumerator SlowMovement(float time, float intensity)
    {        
        curSpeed *= intensity;
        yield return new WaitForSeconds(time);
        ResetSpeed();
    }


    private IEnumerator WarpParticles(float time)
    {
        yield return new WaitForSeconds(time*.9f);
        Destroy(Instantiate(warpParticles, transform.position, transform.rotation), 1);
        if(wavepointIndex - warpStep > 0 && wavepointIndex - warpStep < tiles.Items.Count - 1)
            Destroy(Instantiate(warpParticles, tiles.Items[wavepointIndex-warpStep].transform.position, tiles.Items[wavepointIndex - warpStep].transform.rotation), 1);
    }
    private IEnumerator Warp()
    {
        timeToWarp = false;
        warpStep = Random.Range(warpStepMin, warpStepMax);
        StartCoroutine(WarpParticles(warpTime / (curSpeed / speed)));
        yield return new WaitForSeconds(warpTime / (curSpeed/speed));
        for (int i = 0; i < warpStep; i++)
            GetNextWayPoint();
        PolyProjectile[] curProj = GetComponentsInChildren<PolyProjectile>();
        foreach (PolyProjectile pp in curProj)
            Destroy(pp.gameObject);
        transform.position = target.position;
        timeToWarp = true;
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
    public int GetWavePointIndex()
    {
        return wavepointIndex;
    }
    public void SetWavePointIndex(int index)
    {
        wavepointIndex = index;
    }
}
