using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageOverTime", menuName = "TowerEffect/Damage Over Time")]
public class DamageOverTime : Effect
{
    [SerializeField] private DamageType typeOfDamage = DamageType.FIRE;
    [SerializeField] private GameObject particles;
    [SerializeField] private float impactDamage;

    [Header("Damage Over Time")]
    [SerializeField] private float damagePerTick;
    [SerializeField] private int ticks;
    [SerializeField] private int secondsBetweenTicks;


    override public void AlterTower(TowerScript ts)
    {

    }
    override public void AlterProjectile(Bullet b)
    {

    }
    public override void ApplyProjectileEffect(Enemy hitEnemy)
    {
        hitEnemy.TakeImpactDamage(this);
        hitEnemy.TakeDamageOverTime(ticks, damagePerTick, secondsBetweenTicks, this);
    }

    public override DamageType GetDamageType() => typeOfDamage;
    public override GameObject GetParticles() => particles;
    public override float GetImpactDamage() => impactDamage;
}
