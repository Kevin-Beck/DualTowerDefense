using UnityEngine;

/// <summary>
/// BoolVariable is a Scriptable Object that holds a boolean. It is used when you wish to have a boolean that is
/// accessed and used by many different sources independent of each other.
/// <para>Many instances of BoolVariable can be created in the Unity Editor and given a name. Then
/// many other objects can reference this value using a BoolReference if they only need to read, or 
/// through the direct access of the BoolVariable scriptable Object.</para>
/// <para>Example: BoolVariable created in unity named MenuOpened set to false. The UI is given direct
/// access to this BoolVariable. When a menu is opened, this value is set to false. Another game element
/// will have a BoolReference to occassionally check if the value is set to true or false. This structure
/// saves from repeated accessors and coupling between elements that are only tangentially related.</para>
/// </summary>
[CreateAssetMenu(fileName = "BoolVariable", menuName = "Variables/BoolVariable")]
public class BoolVariable : ScriptableObject
{
#if UNITY_EDITOR
    /// <summary>
    /// Description of what this Boolean is used for, written by the Game Designer
    /// </summary>
    [Multiline]
    public string DeveloperDescription = "";
#endif
    /// <summary>
    /// Value of the boolean
    /// </summary>
    public bool Value;

    /// <summary>
    /// Sets the value of the boolean using a bool
    /// </summary>
    /// <param name="value"></param>
    public void SetValue(bool value)
    {
        Value = value;
    }

    /// <summary>
    /// Sets the value of the boolean
    /// </summary>
    /// <param name="value">Enables a BoolVariable to be passed to set value</param>
    public void SetValue(BoolVariable value)
    {
        Value = value.Value;
    }
}