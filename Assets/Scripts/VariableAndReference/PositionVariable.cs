using UnityEngine;

[CreateAssetMenu(fileName = "PositionVariable", menuName = "Variables/PositionVariable")]
public class PositionVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public Position Value;

    public void SetValue(Position value)
    {
        Value = value;
    }

    public void SetValue(PositionVariable value)
    {
        Value = value.Value;
    }
}