using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Confusion Effect affects the towers, bullets and enemies that are hit by the bullets
/// <para>Upon hit, has a chance to cause the enemy to reverse direction.</para>
/// <seealso cref="Effect"/>
/// </summary>
[CreateAssetMenu(fileName = "New Confusion", menuName = "Effect/Impact/Confusion")]
public class Confusion : ImpactEffect
{
    [SerializeField] private string description = "Chance to reverse enemy.";
    [SerializeField] private EffectType myType = default;
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>
    [Header("Particle Data")]
    [SerializeField] private GameObject impactParticles = default;

    [Header("Confusion Bullet Data")]
    [SerializeField] private GameObject effectParticle = default;
    [SerializeField] private float timeConfused = 2;
    [SerializeField] private float confusionChance = 0.1f;
    

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
