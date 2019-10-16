using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Impact damage deals the specified damage upon impact
/// <seealso cref="Effect"/>
/// </summary>
[CreateAssetMenu(fileName = "New RangeMultiplier", menuName = "Effect/Tower/RangeMultiplier")]
public class RangeMultiplier : TowerEffect
{
    [SerializeField] private string description;
    [SerializeField] private EffectType myType;
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>

    [SerializeField] private GameObject towerParticles;

    [Header("Particle Data")]
    [SerializeField] private GameObject muzzleParticles = default;

    [Header("Range Data")]
    [SerializeField] private float rangeMultiplier = 3;

    public override void AlterTower(PolyTower ts)
    {
        ts.range *= rangeMultiplier;
    }

    public override string GetDescription()
    {
        throw new System.NotImplementedException();
    }

    public override EffectType GetEffectType()
    {
        throw new System.NotImplementedException();
    }

    public override GameObject GetTowerParticles()
    {
        return towerParticles;
    }
}