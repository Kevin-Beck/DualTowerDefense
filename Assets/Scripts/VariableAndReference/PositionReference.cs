using System;

[Serializable]
public class PositionReference
{
    public bool UseConstant = false;
    public Position ConstantValue;
    public PositionVariable Variable;

    public PositionReference()
    { }

    public PositionReference(Position value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public Position Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator Position(PositionReference reference)
    {
        return reference.Value;
    }
}
