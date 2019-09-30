using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyWalk))]
[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    EnemyWalk ewalk;
    EnemyHealth ehealth;

    private void Start()
    {
        ewalk = GetComponent<EnemyWalk>();
        ehealth = GetComponent<EnemyHealth>();
    }

    public void Slow(float time, float intensity)
    {
        StartCoroutine(ewalk.Slow(time, intensity));
    }

    public void TakeDamage(float dmg, DamageType type)
    {
        ehealth.TakeDamage(dmg, type);
    }

    public void TakeDamageOverTime(int ticks, float damagePerTick, float timeBetweenTicks, DamageType type)
    {
        StartCoroutine(ehealth.TakeDamageOverTime(ticks, damagePerTick, timeBetweenTicks, type));
    }



    // Enemy walk will control movement, like stuns etc, and will be called internally so you will add a stun to a bullet, the bullet will hit the object and call EnemyWalk.Stun(val);
    // Enemy walk will then stun for the time passed.
    // Enemy walk will have a function called EnemyWalk.Slow(val, time) which will slow the object for the time
    // Enemy health will manage the dots etc

    // The bullet will have a function called apply damage, this will use the target object, get enemyhealth, then it will use whatever affects are set in the bullet. pure damage, and then dots etc through this enemy health script
    // The bullet will have a function called apply movement, this will use the target object, get enemywalk, then it will use the affects set on the bullet.

    // the bullet will have these settings set when the bullet is fired. The bullet will be created, the tower fire function will then set all the bullet effects, the effects will be stored on the tower when the tower is created.
    // runtime sets of the towers will be kept for each type of tower when it is instantiated, if the tower has frost effect, it will be saved as a frost tower

    // during the game some kinds of towers will be disabled, all frost towers are stopped this round etc.


}
