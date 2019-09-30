using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float curHealth;

    [Header("0 = Immune, 1 = Normal, 2 = Weak")]
    [SerializeField] float FireVulnerability;
    [SerializeField] float IceVulnerability;
    [SerializeField] float PoisonVulnerability;

    [Header("ParticleEffects")]
    [SerializeField] GameObject fireParticles;
    [SerializeField] GameObject iceParticles;
    [SerializeField] GameObject poisonParticles;

    private void Start()
    {
        curHealth = maxHealth;
    }
    public void TakeDamage(float dmg, DamageType type)
    {
        float result = 0;
        if(type == DamageType.FIRE)
        {
            Instantiate(fireParticles, transform);
            result += dmg * FireVulnerability;
        }
        if (type == DamageType.ICE)
        {
            Instantiate(iceParticles, transform);
            result += dmg * IceVulnerability;
        }
        if (type == DamageType.POISON)
        {
            Instantiate(poisonParticles, transform);
            result += dmg * PoisonVulnerability;
        }
        curHealth -= dmg;
        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator TakeDamageOverTime(int ticks, float damagePerTick, float timeBetweenTicks, DamageType type)
    {
        for (int i = 0; i < ticks; i++)
        {
            yield return new WaitForSeconds(timeBetweenTicks);
            TakeDamage(damagePerTick, type);
        }

    }
}
