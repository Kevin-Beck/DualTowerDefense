using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public abstract string GetDescription();
    public abstract EffectType GetEffectType();
}
public enum EffectType
{
    NONE,
    ICE,
    FIRE,
    POISON,
    MAGIC,
    EARTH,
    SHADOW,
    AIR,
    PHYSICAL
}