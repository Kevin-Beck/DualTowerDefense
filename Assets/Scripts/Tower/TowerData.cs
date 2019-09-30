using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : ScriptableObject
{
    public float Value;
    public List<Effect> myAbilities;

    public void SetValue(float value)
    {
        Value = value;
    }

    public void SetValue(FloatVariable value)
    {
        Value = value.Value;
    }

    public void ApplyChange(float amount)
    {
        Value += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        Value += amount.Value;
    }
}
