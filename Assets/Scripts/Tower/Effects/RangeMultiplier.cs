using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Impact damage deals the specified damage upon impact
/// <seealso cref="Effect"/>
/// </summary>
[CreateAssetMenu(fileName = "RangeMultiplier", menuName = "TowerEffect/RangeMultiplier")]
public class RangeMultiplier : Effect
{
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>
    [Header("Particle Data")]
    [SerializeField] private GameObject muzzleParticles = default;
    [SerializeField] private GameObject projectileParticles = default;
    [SerializeField] private GameObject impactParticles = default;

    [Header("Range Data")]
    [SerializeField] private float rangeMultiplier = 3;

    public override void AlterProjectile(PolyProjectile b)
    {
    }

    public override void AlterTower(PolyTower ts)
    {
        ts.range *= rangeMultiplier;
    }

    public override void ApplyProjectileEffect(Enemy e)
    {
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