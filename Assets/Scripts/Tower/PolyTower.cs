using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyTower : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f;
    private float fireCountdown = 0f;
    public float fireRate = 1f;
    public float turnSpeed = 10f;

    [Header("UnitySetup")]
    public Transform partToRotate;
    private Transform target;
    public Transform firePoint;

    [Header("Effects")]
    [SerializeField] public List<Effect> myEffects = new List<Effect>();

    [Header("Other")]
    public GameObject bulletPrefab;
    public ThingRuntimeSet enemies;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    
    void Shoot()
    {
        // TODO make this real
        // Create the bullet
        GameObject go = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // disable it before it does anything, give it the list of effects,
        // then it will create its own list of prefabs from the effects
        // then reactivate it
        // The bullet itself will process the effects list and decide which particles go on the bullet
        // The tower will simply hand it the list it has of the effects that bullet is supposed to have
        go.SetActive(false);
        PolyProjectile bullet = go.GetComponent<PolyProjectile>();
        bullet.myAbilities = myEffects;
        go.transform.parent = target;
        go.SetActive(true);

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        Thing[] curEnemies = enemies.Items.ToArray();
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (Thing t in curEnemies)
        {
            GameObject go = t.gameObject;
            float distanceToEnemy = Vector3.SqrMagnitude(transform.position - go.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = go;
            }
        }

        if (closestEnemy != null && shortestDistance <= range * range)
            target = closestEnemy.transform;
        else
            target = null;
    }

}
