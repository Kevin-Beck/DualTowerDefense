using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileEffect : Effect
{
    abstract public GameObject GetMuzzleParticles();
    abstract public GameObject GetProjectileParticles();
    abstract public void AlterProjectile(PolyProjectile b); // used to change the speed and behaviour of the projectile etc
}
