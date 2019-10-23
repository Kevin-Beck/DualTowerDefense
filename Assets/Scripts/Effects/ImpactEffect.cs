using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ImpactEffect : Effect
{
    abstract public void ApplyProjectileEffect(AnimatedEnemy e); // used to add stuff to the enemy upon hitting etc
    abstract public GameObject GetImpactParticles();
}
