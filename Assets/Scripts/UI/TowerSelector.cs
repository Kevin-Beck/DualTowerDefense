using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelector : MonoBehaviour
{
    Toggle myToggle;
    public TowerData curTower;
    [SerializeField] public List<Effect> effectsToAdd = new List<Effect>();

    private void Awake()
    {
        myToggle = GetComponent<Toggle>();
    }

    public void UpdateStatus()
    {
        if (myToggle.isOn)
            AddEffects();
        else
            RemoveEffects();
    }

    private void AddEffects()
    {
        foreach (Effect e in effectsToAdd)
            curTower.myAbilities.Add(e);
    }
    private void RemoveEffects()
    {
        foreach (Effect e in effectsToAdd)
            curTower.myAbilities.Remove(e);
    }

    private void OnDisable()
    {
        RemoveEffects();
    }
}
