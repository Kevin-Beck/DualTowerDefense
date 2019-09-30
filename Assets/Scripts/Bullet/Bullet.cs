using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    public float speed = 70f;
    Transform target;
    public GameObject impactEffect;

    public List<Effect> myAbilities = new List<Effect>();

    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        
        ApplyEffect();

        Destroy(effectInstance, 2f);
        Destroy(gameObject);
    }

    void ApplyEffect()
    {
        Enemy e = target.gameObject.GetComponent<Enemy>();
        foreach (Effect ta in myAbilities)
        {
            ta.ApplyProjectileEffect(e);
        }
    }
}
