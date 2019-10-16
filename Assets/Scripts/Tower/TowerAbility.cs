using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TowerAbility", menuName = "Tower/Ability")]
public class TowerAbility : ScriptableObject
{
    [SerializeField] public List<Effect> abilityEffects;
    [SerializeField] private int level { get; set; }
    [SerializeField] private string description { get; set; }

    public List<Effect> GetEffects()
    {
        return abilityEffects;
    }
}
