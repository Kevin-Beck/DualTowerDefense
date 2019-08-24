using System;

[Serializable]
public class Position
{
    public int X;// { get; set; }
    public int Z;// { get; set; }
    public Position(int posx, int posz)
    {
        X = posx;
        Z = posz;
    }
    public static Position operator+ (Position p1, Position p2)
    {
        return new Position(p1.X + p2.X, p1.Z + p2.Z);
    }    
}
