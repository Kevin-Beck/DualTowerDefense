using UnityEngine;
using System.Collections.Generic;

public class MazeNode
{
    public bool visited = false;
    public int[] checkdirections = new int[4] { 0, 1, 2, 3 };
    public int currentDirection = 0;
    public bool[] walls = new bool[4] { true, true, true, true };
    public Position myPos;
    public Position previous;
    // north = 0
    // east = 1
    // south = 2
    // west = 3
    public void InitializeNode(Position p)
    {
        myPos = p;
        currentDirection = 0;
        ShufflePositions();
        ResetWalls();
    }

    public void RemoveNorthWall()
    {
        walls[0] = false;
    }
    public void RemoveEastWall()
    {
        walls[1] = false;
    }
    public void RemoveSouthWall()
    {
        walls[2] = false;
    }
    public void RemoveWestWall()
    {
        walls[3] = false;
    }

    public void ShufflePositions()
    {
        List<int> directionList = new List<int>(checkdirections);

        for (int i = 0; i < directionList.Count-1; i++)
        {            
            int rnd = Random.Range(i,directionList.Count);
            int temp = checkdirections[i];
            checkdirections[i] = checkdirections[rnd];
            checkdirections[rnd] = temp;
        }
    }

    public void ResetWalls()
    {
        walls = new bool[4] { true, true, true, true };
    }
}
