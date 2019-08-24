using UnityEngine;

[CreateAssetMenu(fileName = "VectorVariable", menuName = "Variables/VectorVariable")]
public class VectorVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public Vector3 Value;

    public void SetValue(Vector3 value)
    {
        Value = value;
    }

    public void SetValue(VectorVariable value)
    {
        Value = value.Value;
    }

    public void ApplyChange(Vector3 amount)
    {
        Value += amount;
    }

    public void ApplyChange(VectorVariable amount)
    {
        Value += amount.Value;
    }
}
