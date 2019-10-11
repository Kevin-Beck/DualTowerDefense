using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = default;
    float curHealth;

    [Header("DMG Multiplier: 0 = Immune, 1 = Normal, 2 = Weak")]
    [SerializeField] float FireVulnerability = 1;
    [SerializeField] float IceVulnerability = 1;
    [SerializeField] float PoisonVulnerability = 1;
    [SerializeField] float MagicVulnerability = 1;    

     BarController barController;

    [SerializeField] Vector3 DamageTickPositionOffset = default;
    private void Awake()
    {
        barController = GetComponentInChildren<BarController>();
        if (barController == null)
            throw new MissingComponentException();
    }
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
            result += dmg * MagicVulnerability;
        }

        if(particles != null)
        {
            GameObject go = Instantiate(particles, transform.position + DamageTickPositionOffset, transform.rotation);
            go.transform.parent = gameObject.transform;
        }

        curHealth -= dmg;
        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
        barController.UpdateBarValue(curHealth, maxHealth);
    }
    public void TakeDamageOverTime(int ticks, float damagePerTick, DamageType typeOfDamage, float timeBetweenTicks, GameObject tickParticles)
    {
        StartCoroutine(DamageOverTime(ticks, damagePerTick, typeOfDamage, timeBetweenTicks, tickParticles));
    }
    private IEnumerator DamageOverTime(int ticks, float damagePerTick, DamageType typeOfDamage, float timeBetweenTicks, GameObject tickParticles)
    {
        for (int i = 0; i < ticks; i++)
        {
            yield return new WaitForSeconds(timeBetweenTicks);
            TakeDamage(damagePerTick, typeOfDamage, tickParticles);
        }

    }
}
