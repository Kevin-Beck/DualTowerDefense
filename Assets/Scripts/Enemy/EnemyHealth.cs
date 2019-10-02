using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float curHealth;

    [Header("0 = Immune, 1 = Normal, 2 = Weak")]
    [SerializeField] float FireVulnerability = 1;
    [SerializeField] float IceVulnerability = 1;
    [SerializeField] float PoisonVulnerability = 1;
    [SerializeField] float MagicVulnerability = 1;

    [Header("HealthBar")]
    [SerializeField] BarController barController;

    private void Start()
    {
        curHealth = maxHealth;
    }
    public void TakeDamage(float dmg, DamageType type, GameObject particles)
    {
        float result = 0;

        if(type == DamageType.FIRE)
        {
            result += dmg * FireVulnerability;
        }
        if (type == DamageType.ICE)
        {
            result += dmg * IceVulnerability;
        }
        if (type == DamageType.POISON)
        {
            result += dmg * PoisonVulnerability;
        }
        if (type == DamageType.MAGIC)
        {
            result += dmg * PoisonVulnerability;
        }

        Instantiate(particles, transform);

        curHealth -= dmg;
        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
        barController.UpdateBarValue();
    }
    public IEnumerator TakeDamageOverTime(int ticks, float damagePerTick, float timeBetweenTicks, Effect effect)
    {
        for (int i = 0; i < ticks; i++)
        {
            yield return new WaitForSeconds(timeBetweenTicks);
            TakeDamage(damagePerTick, effect.GetDamageType(), effect.GetParticles());
        }

    }
}
