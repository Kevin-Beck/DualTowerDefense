using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityAdder : MonoBehaviour
{
    [SerializeField] TowerData InventoryObject = default;
    [SerializeField] IntVariable PlayerGold = default;
    [SerializeField] GameEvent GoldChange = default;

    TowerAbility myAbility = default;
    [SerializeField] GameEvent abilityPurchased = default;

    Button myButton;
    Sprite baseSprite;
    Text buttonText;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        buttonText = myButton.GetComponentInChildren<Text>();
        baseSprite = myButton.GetComponent<Image>().sprite;
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
                myButton.GetComponent<Image>().sprite = baseSprite;
                myAbility = null;
            }
        }
    }
    public void SetAbility(TowerAbility ta)
    {
        myAbility = ta;
        if(myAbility != null)
        {
            myButton.GetComponent<Image>().sprite = ta.GetIcon();
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
