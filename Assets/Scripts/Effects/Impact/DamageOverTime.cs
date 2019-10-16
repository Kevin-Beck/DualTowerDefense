using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Impact damage deals the specified damage upon impact
/// <seealso cref="Effect"/>
/// </summary>
[CreateAssetMenu(fileName = "New DamageOverTime", menuName = "Effect/Impact/DamageOverTime")]
public class DamageOverTime : ImpactEffect
{
    [SerializeField] private string description;
    [SerializeField] private EffectType myType;
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>
    [Header("Particle Data")]
    [SerializeField] private GameObject impactParticles = default;

    [Header("DamageOverTime Data")]
    [SerializeField] private int numberOfTicks = default;
    [SerializeField] private GameObject tickParticles = default;
    [SerializeField] private float tickDamage = default;
    [SerializeField] private float tickDelay = default;
    
    public override void ApplyProjectileEffect(Enemy e)
    {
        e.ehealth.TakeDamageOverTime(numberOfTicks, tickDamage, myType, tickDelay, tickParticles);
    }

    public override GameObject GetImpactParticles()
    {
        return impactParticles;
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