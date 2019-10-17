using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPoolDistributer : MonoBehaviour
{
    [SerializeField] IntVariable PlayerGold;
    [SerializeField] IntReference RerollCost;
    [SerializeField] GameEvent GoldChange;

    [SerializeField] List<AbilityAdder> adders= new List<AbilityAdder>();
    [SerializeField] Button rerollButton;

    [SerializeField] TowerData abilityPoolBase;
    AbilityPool abilityPool;
    private void Awake()
    {
        abilityPool = new AbilityPool(abilityPoolBase);
        rerollButton.GetComponentInChildren<Text>().text = "Reroll\n" + RerollCost.Value;
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
