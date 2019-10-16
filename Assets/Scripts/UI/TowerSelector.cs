using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelector : MonoBehaviour
{
    Toggle myToggle;
    public TowerData curTower;
    [SerializeField] public List<TowerAbility> abilitiesToAdd = new List<TowerAbility>();

    private void Awake()
    {
        myToggle = GetComponent<Toggle>();
    }

    public void UpdateStatus()
    {
        if (myToggle.isOn)
            AddAbility();
        else
            RemoveEffects();
    }

    private void AddAbility()
    {
        foreach (TowerAbility ta in abilitiesToAdd)
            curTower.myAbilities.Add(ta);
    }
    private void RemoveEffects()
    {
        foreach (TowerAbility ta in abilitiesToAdd)
            curTower.myAbilities.Remove(ta);
    }

    private void OnDisable()
    {
        RemoveEffects();
    }
}
