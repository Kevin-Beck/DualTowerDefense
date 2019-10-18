using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TowerAbility", menuName = "Tower/Ability")]
public class TowerAbility : ScriptableObject
{
    [SerializeField] public List<Effect> abilityEffects;
    [SerializeField] private int level { get; set; }
    [SerializeField] private string description = "TowerAbility";
    [SerializeField] private Sprite myIcon;
    [SerializeField] private int cost = 10;

    public List<Effect> GetEffects()
    {
        return abilityEffects;
    }
    public string GetDescription()
    {
        return description;
    }
    public int GetCost()
    {
        return cost;
    }
    public Sprite GetIcon()
    {
        return myIcon;
    }
}
