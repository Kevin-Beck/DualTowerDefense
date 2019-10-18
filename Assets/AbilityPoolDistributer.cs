using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPoolDistributer : MonoBehaviour
{
    [SerializeField] IntVariable PlayerGold = default;
    [SerializeField] IntReference RerollCost = default;
    [SerializeField] GameEvent GoldChange = default;

    [SerializeField] List<AbilityAdder> adders= new List<AbilityAdder>();
    [SerializeField] Button rerollButton = null;

    [SerializeField] TowerData abilityPoolBase = default;
    AbilityPool abilityPool = default;
    private void Awake()
    {
        abilityPool = new AbilityPool(abilityPoolBase);
        rerollButton.GetComponentInChildren<Text>().text = ""+RerollCost.Value;
    }
    public void DistributeAbilities()
    {
        foreach (AbilityAdder aa in adders)
        {
            if (aa.GetAbility() != null)
            {
                abilityPool.AddAbilityToPool(aa.GetAbility());
            }
        }
        foreach (AbilityAdder aa in adders)
        {
            aa.SetAbility(abilityPool.GetAbilityFromPool());
        }
    }
    public void ReRoll()
    {
        if(RerollCost.Value <= PlayerGold.Value)
        {
            PlayerGold.Value -= RerollCost.Value;
            GoldChange.Raise();
            foreach (AbilityAdder aa in adders)
            {
                if (aa.GetAbility() != null)
                {
                    abilityPool.AddAbilityToPool(aa.GetAbility());
                }
            }
            DistributeAbilities();
        }
    }

}
