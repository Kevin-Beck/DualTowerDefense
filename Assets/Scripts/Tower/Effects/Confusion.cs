using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Confusion Effect affects the towers, bullets and enemies that are hit by the bullets
/// <para>Upon hit, has a chance to cause the enemy to reverse direction.</para>
/// <seealso cref="Effect"/>
/// </summary>
[CreateAssetMenu(fileName = "Confusion", menuName = "TowerEffect/Confusion")]
public class Confusion : Effect
{
    /// <summary>
    /// Type of damage the bullet carries to the enemy.
    /// <seealso cref="DamageType"/>
    /// </summary>
    [SerializeField] private DamageType typeOfDamage = DamageType.MAGIC;
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>
    [Header("Particle Data")]
    [SerializeField] private GameObject muzzleParticles = default;
    [SerializeField] private GameObject projectileParticles = default;
    [SerializeField] private GameObject impactParticles = default;

    [Header("Confusion Bullet Data")]
    [SerializeField] private GameObject effectParticle = default;
    [SerializeField] private float timeConfused = 2;
    [SerializeField] private float confusionChance = 0.1f;

    public override void AlterProjectile(PolyProjectile b)
    {
    }

    public override void AlterTower(PolyTower ts)
    {
    }

    public override void ApplyProjectileEffect(Enemy e)
    {
        if (Random.Range(0f, 1f) < confusionChance)
        {
            e.ewalk.Reverse(timeConfused);
            GameObject go = Instantiate(effectParticle, e.gameObject.transform.position + e.GetParticleOffset(), e.gameObject.transform.rotation);
            go.transform.parent = e.gameObject.transform;
            Destroy(go, timeConfused);
        }
    }

    public override GameObject GetImpactParticles()
    {
        return impactParticles;
    }

    public override GameObject GetMuzzleParticles()
    {
        return muzzleParticles;
    }

    public override GameObject GetProjectileParticles()
    {
        return projectileParticles;
    }
}
