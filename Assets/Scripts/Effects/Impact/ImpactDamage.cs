using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Impact damage deals the specified damage upon impact
/// <seealso cref="Effect"/>
/// </summary>
[CreateAssetMenu(fileName = "New Impact Damage", menuName = "Effect/Impact/ImpactDamage")]
public class ImpactDamage : ImpactEffect
{
    [SerializeField] private string description = "Damages enemy on impact.";
    [SerializeField] private EffectType myType = default;
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>
    [Header("Impact Data")]
    [SerializeField] private GameObject impactParticles = default;
    [SerializeField] private float damage = default;
    
    
    public override void ApplyProjectileEffect(AnimatedEnemy e)
    {
        e.ehealth.TakeDamage(damage, myType, null);
    }

    public override string GetDescription()
    {
        return description;
    }

    public override EffectType GetEffectType()
    {
        return myType;
    }
    public override GameObject GetImpactParticles()
    {
        return impactParticles;
    }
}