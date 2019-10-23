using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PolyProjectile : MonoBehaviour
{
    //Prefabs added to the projectile by the towereffects
    private List<GameObject> impactParticlesPrefabs = new List<GameObject>();
    private List<GameObject> projectileParticlesPrefabs = new List<GameObject>();
    private List<GameObject> muzzleParticlesPrefabs = new List<GameObject>();

    //Current living particles on the object
    private List<GameObject> impactParticles = new List<GameObject>();
    private List<GameObject> projectileParticles = new List<GameObject>();
    private List<GameObject> muzzleParticles = new List<GameObject>();

    /// <summary>
    /// Rate at which the bullet travels towards its target.
    /// </summary>
    public float speed = 70f;
    /// <summary>
    /// Target transform the bullet moves towards each update.
    /// </summary>
    Transform target;
    Vector3 targetHeight;
    /// <summary>
    /// List of Effects given to this bullet from its tower.
    /// </summary>
    public List<Effect> myEffects = new List<Effect>();

    [Header("Adjust for collision distance")]
    public float colliderRadius = 1.25f;

    void Start()
    {
        // go through the effects, add each effect's projectiles to the projectile lists
        foreach (Effect e in myEffects)
        {
            if(e is ProjectileEffect)
            {
                ProjectileEffect pe = (ProjectileEffect)e;
                if (pe.GetMuzzleParticles())
                    muzzleParticlesPrefabs.Add(pe.GetMuzzleParticles());
                if (pe.GetProjectileParticles())
                    projectileParticlesPrefabs.Add(pe.GetProjectileParticles());
            }else if(e is ImpactEffect)
            {
                ImpactEffect ie = (ImpactEffect)e;
                if (ie.GetImpactParticles())
                    impactParticlesPrefabs.Add(ie.GetImpactParticles());
            }
        }

        // Then create the projectiles for the start
        foreach(GameObject ppp in projectileParticlesPrefabs)
        {
            GameObject particles = Instantiate(ppp, transform.position, transform.rotation);
            particles.transform.parent = transform;
            projectileParticles.Add(particles);
        }
        if (muzzleParticlesPrefabs.Count > 0)
        {
            foreach(GameObject mpp in muzzleParticlesPrefabs)
            {
                GameObject particles = Instantiate(mpp, transform.position, transform.rotation);
                muzzleParticles.Add(particles);
                DestroyMuzzleParticles(1.5f); // destroy the particles after making them
            }
        }
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position + targetHeight - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // detect if we're collided
        if ((target.position + targetHeight- transform.position).magnitude < colliderRadius)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }


    /// <summary>
    /// HitTarget instantiates the particle effect, calls ApplyEffect, then destroys the particle effect after 2 seconds
    /// then self destructs.
    /// </summary>
    void HitTarget()
    {
    // create impact particles
        foreach(GameObject particles in impactParticlesPrefabs)
        {
            impactParticles.Add(Instantiate(particles, transform.position, transform.rotation));
        }
        
        // Destroy projectile particles, 3f
        foreach (GameObject particles in projectileParticles)
            Destroy(particles, 3f);
        // Destroy impact particles, 3.5f;
        foreach (GameObject particles in impactParticles)
            Destroy(particles, 3.5f);
        Destroy(gameObject);
        ApplyEffect();
        Destroy(gameObject);
    }

    /// <summary>
    /// ApplyEffect gets the Enemy script from the target. Then loops through each effect in its list, calling
    /// the appropriate function to give the target script its effect.
    /// </summary>
    void ApplyEffect()
    {
        AnimatedEnemy nme = target.gameObject.GetComponent<AnimatedEnemy>();
        foreach (Effect e in myEffects)
        {
            if(e is ImpactEffect)
                ((ImpactEffect)e).ApplyProjectileEffect(nme);
        }
    }

    /// <summary>
    /// Seek is used to set the bullet's target transform.
    /// </summary>
    /// <param name="_target">The target transform the bullet pursues</param>
    public void Seek(Transform _target)
    {
        target = _target;
        targetHeight = target.gameObject.GetComponent<AnimatedEnemy>().GetHeight();
    }
    /// <summary>
    /// Destroys the muzzle particles created when this projectile was born after specified time
    /// </summary>
    /// <param name="time">Seconds until the muzzle effects are destroyed</param>
    private void DestroyMuzzleParticles(float time)
    {
        foreach(GameObject particles in muzzleParticles)
            Destroy(particles, time);
    }
}
