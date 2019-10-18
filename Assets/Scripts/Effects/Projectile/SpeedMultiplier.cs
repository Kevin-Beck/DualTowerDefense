using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Impact damage deals the specified damage upon impact
/// <seealso cref="ProjectileEffect"/>
/// </summary>
[CreateAssetMenu(fileName = "New Bullet Speed", menuName = "Effect/Projectile/SpeedMultiplier")]
public class SpeedMultiplier : ProjectileEffect
{
    [SerializeField] private string description = "Alters speed bullet travels.";
    [SerializeField] private EffectType myType = default;
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>
    [Header("Particle Data")]
    [SerializeField] private GameObject muzzleParticles = default;
    [SerializeField] private GameObject projectileParticles = default;

    [Header("Speed Data")]
    [SerializeField] private float speedMultiplier = 2;

    public override void AlterProjectile(PolyProjectile pp)
    {
        pp.speed *= speedMultiplier;
    }

    public override GameObject GetMuzzleParticles()
    {
        return muzzleParticles;
    }

    public override GameObject GetProjectileParticles()
    {
        return projectileParticles;
    }
    public override string GetDescription()
    {
        return description;
    }

    public override EffectType GetEffectType()
    {
        return myType;
    }
}
