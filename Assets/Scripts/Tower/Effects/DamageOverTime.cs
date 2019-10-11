using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Impact damage deals the specified damage upon impact
/// <seealso cref="Effect"/>
/// </summary>
[CreateAssetMenu(fileName = "DamageOverTime", menuName = "TowerEffect/DamageOverTime")]
public class DamageOverTime : Effect
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

    [Header("DamageOverTime Data")]
    [SerializeField] private int numberOfTicks = default;
    [SerializeField] private GameObject tickParticles = default;
    [SerializeField] private float tickDamage = default;
    [SerializeField] private float tickDelay = default;

    public override void AlterProjectile(PolyProjectile b)
    {
    }

    public override void AlterTower(PolyTower ts)
    {
    }

    public override void ApplyProjectileEffect(Enemy e)
    {
        e.ehealth.TakeDamageOverTime(numberOfTicks, tickDamage, typeOfDamage, tickDelay, tickParticles);
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