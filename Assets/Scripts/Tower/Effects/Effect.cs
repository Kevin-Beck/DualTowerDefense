using UnityEngine;

public abstract class Effect : ScriptableObject
{
    abstract public void AlterTower(PolyTower ts); // used to change the range of the tower etc
    abstract public void AlterProjectile(PolyProjectile b); // used to change the speed and behaviour of the projectile etc
    abstract public void ApplyProjectileEffect(Enemy e); // used to add stuff to the enemy upon hitting etc
        
    abstract public GameObject GetImpactParticles();
    abstract public GameObject GetProjectileParticles();
    abstract public GameObject GetMuzzleParticles();
}
public enum DamageType
{
    ICE,
    FIRE,
    POISON,
    MAGIC
}