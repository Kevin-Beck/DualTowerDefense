using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Confusion", menuName = "TowerEffect/Confusion")]
public class Confusion : Effect
{
    [SerializeField] private DamageType typeOfDamage = DamageType.MAGIC;
    [SerializeField] private GameObject particles;
    [SerializeField] private float impactDamage;

    [Header("Damage Over Time")]
    [SerializeField] private float timeConfused = 2;


    override public void AlterTower(TowerScript ts)
    {

    }
    override public void AlterProjectile(Bullet b)
    {

    }
    public override void ApplyProjectileEffect(Enemy hitEnemy)
    {
        hitEnemy.TakeImpactDamage(this);
        hitEnemy.ReverseDirection(timeConfused);
    }

    public override DamageType GetDamageType() => typeOfDamage;
    public override GameObject GetParticles() => particles;
    public override float GetImpactDamage() => impactDamage;
}
