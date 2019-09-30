using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f;
    public float turnSpeed = 10f;
    public float fireRate = 10f;
    private float fireCountdown = 0f;

    [Header("UnitySetup")]
    public ThingRuntimeSet enemies;
    public Transform partToRotate;
    private Transform target;

    public GameObject bulletPrefab;
    public Transform firePoint;

    List<Effect> myTowerAbilities = new List<Effect>();

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
        // TEMP FOR TESTING
       // IceEffect ie = new IceEffect();        
        FireEffect fe = new FireEffect();
        myTowerAbilities.Add(fe);
      //  myTowerAbilities.Add(ie);
        // END TEMP
    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void Shoot()
    {
        GameObject go = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.myAbilities = myTowerAbilities;
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

        foreach(Thing t in curEnemies)
        {
            GameObject go = t.gameObject;
            float distanceToEnemy = Vector3.SqrMagnitude(transform.position - go.transform.position);
            if(distanceToEnemy < shortestDistance)
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
