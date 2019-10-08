using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Impact damage deals the specified damage upon impact
/// <seealso cref="Effect"/>
/// </summary>
[CreateAssetMenu(fileName = "ImpactDamage", menuName = "TowerEffect/ImpactDamage")]
public class ImpactDamage : Effect
{
    /// <summary>
    /// Type of damage the bullet carries to the enemy.
    /// <seealso cref="DamageType"/>
    /// </summary>
    [SerializeField] private DamageType typeOfDamage = DamageType.FIRE;
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>
    [Header("Particle Data")]
    [SerializeField] private GameObject muzzleParticles = default;
    [SerializeField] private GameObject projectileParticles = default;
    [SerializeField] private GameObject impactParticles = default;

    [Header("Impact Bullet Data")]
    [SerializeField] private GameObject effectParticle = default;
    [SerializeField] private float damage = default;

    public override void AlterProjectile(PolyProjectile b)
    {
    }

    public override void AlterTower(PolyTower ts)
    {
    }

    public override void ApplyProjectileEffect(Enemy e)
    {
        e.ehealth.TakeDamage(damage, typeOfDamage, null);
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