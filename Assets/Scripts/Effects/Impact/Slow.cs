using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Confusion Effect affects the towers, bullets and enemies that are hit by the bullets
/// <para>Upon hit, has a chance to cause the enemy to reverse direction.</para>
/// <seealso cref="Effect"/>
/// </summary>
[CreateAssetMenu(fileName = "Slow", menuName = "Effect/Impact/Slow")]
public class Slow : ImpactEffect
{
    [SerializeField] private string description = "Chance to slow enmy on hit";
    [SerializeField] private EffectType myType = default;
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>
    [Header("Particle Data")]
    [SerializeField] private GameObject impactParticles = default;

    [Header("Slow Bullet Data")]
    [SerializeField] private GameObject effectParticle = default;
    [SerializeField] private float timeSlowed = 3;
    [SerializeField] private float slowChance = 0.2f;
    [SerializeField] private float slowIntensity = 0.25f;
    
    public override void ApplyProjectileEffect(Enemy e)
    {
        if (Random.Range(0f, 1f) < slowChance)
        {
            e.ewalk.Slow(timeSlowed, slowIntensity);
            GameObject go = Instantiate(effectParticle, e.gameObject.transform.position + e.GetParticleOffset(), e.gameObject.transform.rotation);
            go.transform.parent = e.gameObject.transform;
            Destroy(go, timeSlowed);
        }
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
