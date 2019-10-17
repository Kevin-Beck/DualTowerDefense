using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityAdder : MonoBehaviour
{
    [SerializeField] TowerData InventoryObject;
    [SerializeField] IntVariable PlayerGold;
    [SerializeField] GameEvent GoldChange;

    TowerAbility myAbility;
    [SerializeField] GameEvent abilityPurchased;

    Button myButton;
    Text buttonText;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        buttonText = myButton.GetComponentInChildren<Text>();
    }

    public void AddAbilityToInventory()
    {
        if(myAbility != null)
        {
            if(PlayerGold.Value >= myAbility.GetCost())
            {
                InventoryObject.myAbilities.Add(myAbility);
                myButton.enabled = false;
                buttonText.text = "";
                PlayerGold.Value -= myAbility.GetCost();
                GoldChange.Raise();
                abilityPurchased.Raise();

                myAbility = null;
            }
        }
    }
    public void SetAbility(TowerAbility ta)
    {
        myAbility = ta;
        if(myAbility != null)
        {
            myButton.enabled = true;
            buttonText.text = myAbility.GetDescription() + "\n" + myAbility.GetCost();
        }else
        {
            buttonText.text = "";
            myButton.enabled = false;
        }

    }
    public TowerAbility GetAbility()
    {
        return myAbility;
    }
}
