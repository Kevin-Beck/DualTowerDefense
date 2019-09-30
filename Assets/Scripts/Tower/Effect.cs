using UnityEngine;

public abstract class Effect
{
    abstract public void AlterTower(TowerScript ts); // used to change the range of the tower etc
    abstract public void AlterProjectile(Bullet b); // used to change the speed and behaviour of the projectile
    abstract public void ApplyProjectileEffect(Enemy e); // used to change the effect when the projectile hits the enemy
}

public enum DamageType
{
    ICE,
    FIRE,
    POISON
}