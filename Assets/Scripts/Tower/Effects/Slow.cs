using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slow", menuName = "TowerEffect/Slow")]
public class Slow : Effect
{
    [SerializeField] private DamageType typeOfDamage = DamageType.ICE;
    [SerializeField] private GameObject particles;
    [SerializeField] private float impactDamage;

    [Header("Ice Slow Effects")]
    [SerializeField] private float slowTime;
    [SerializeField] private float slowMultiplier;

    override public void AlterTower(TowerScript ts)
    {

    }
    override public void AlterProjectile(Bullet b)
    {

    }
    public override void ApplyProjectileEffect(Enemy hitEnemy)
    {
        hitEnemy.TakeImpactDamage(this);
        hitEnemy.Slow(slowTime, slowMultiplier);
    }

    public override DamageType GetDamageType() => typeOfDamage;
    public override GameObject GetParticles() => particles;
    public override float GetImpactDamage() => impactDamage;
}
