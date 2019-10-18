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
    [SerializeField] private string description = "Alters the range of the tower.";
    [SerializeField] private EffectType myType = default;
    /// <summary>
    /// ParticleEffect tied to the effect.
    /// </summary>

    [Header("Tower Particle Effect")]
    [SerializeField] private GameObject towerParticles = default;

    [Header("Range Data")]
    [SerializeField] private float rangeMultiplier = 3;

    public override void AlterTower(PolyTower ts)
    {
        ts.range *= rangeMultiplier;
    }

    public override string GetDescription()
    {
        return description;
    }

    public override EffectType GetEffectType()
    {
        return myType;
    }

    public override GameObject GetTowerParticles()
    {
        return towerParticles;
    }
}