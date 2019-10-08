using System;

/// <summary>
/// Bool Reference is a boolean value that is a read only source of data. There is an option to use a constant value
/// or to use the value stored in the variable.
/// <para>Bool Reference should be used when an entity needs to reference the value but not alter it.</para>
/// </summary>
[Serializable]
public class BoolReference
{
    /// <summary>
    /// References if the boolean should reflect a constant state, or the value saved on the variable.
    /// </summary>
    public bool UseConstant = false;
    /// <summary>
    /// The constant value if used.
    /// </summary>
    public bool ConstantValue;
    /// <summary>
    /// This is the reference to the BoolVariable, for the purpose of reading the value.
    /// </summary>
    public BoolVariable Variable;

    /// <summary>
    /// Default Constructor.
    /// </summary>
    public BoolReference()
    { }

    /// <summary>
    /// Returns the referenced value
    /// </summary>
    public bool Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    /// <summary>
    /// Enabled the direct comparison of BoolReference objects
    /// </summary>
    /// <param name="reference">Compared BoolReference</param>
    public static implicit operator bool(BoolReference reference)
    {
        return reference.Value;
    }
}