using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEffect : Effect
{
    override public void AlterTower(TowerScript ts)
    {

    }
    override public void AlterProjectile(Bullet b)
    {

    }
    public override void ApplyProjectileEffect(Enemy hitEnemy)
    {
        hitEnemy.Slow(3, 0.5f);
        hitEnemy.TakeDamage(5, DamageType.ICE);
    }
}
