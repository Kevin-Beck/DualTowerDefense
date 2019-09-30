using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : Effect
{
    override public void AlterTower(TowerScript ts)
    {

    }
    override public void AlterProjectile(Bullet b)
    {

    }
    public override void ApplyProjectileEffect(Enemy hitEnemy)
    {
        hitEnemy.TakeDamageOverTime(3, 2, 1, DamageType.FIRE);
    }
}
