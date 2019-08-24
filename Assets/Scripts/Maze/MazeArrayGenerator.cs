using System.Collections.Generic;
using UnityEngine;

public class MazeArrayGenerator : MonoBehaviour
{
    [SerializeField] IntReference sizeZ;
    [SerializeField] IntReference sizeX;
    [SerializeField] PositionReference StartPosition;
    [SerializeField] PositionReference FinishPosition;
    private MazeNode[,] MazeArray;

    Stack<Position> mazeCreationStack;
    /// <summary>
    /// GetMaze takes in a list of blocked positions and returns a maze that move through the array
    /// </summary>
    /// <param name="BlockedPositions"></param>
    /// <returns></returns>
    public MazeNode[,] GetMaze(List<Position> BlockedPositions)
    {
        mazeCreationStack = new Stack<Position>();
        CreateMazeArray(BlockedPositions);
        if(!GenerateMaze(StartPosition))
            Debug.Log("Maze Failed to be created");
        return MazeArray;
    }

    /// <summary>
    /// CreateMazeArray reinitializes the maze to the size of the floatreferences
    /// </summary>
    private void CreateMazeArray(List<Position> blocked)
    {
        // create a new maze array with the updated size
        MazeArray = new MazeNode[sizeX.Value , sizeZ.Value];
        for (int i = 0; i < sizeX.Value; i++)
        {
            for(int j = 0; j < sizeZ.Value; j++)
            {
                MazeArray[i, j] = new MazeNode();
                MazeArray[i, j].InitializeNode(new Position(i,j));
            }
        }

        // Mark blocked positions as visited
        foreach(Position p in blocked)
        {
            MazeArray[p.X, p.Z].visited = true;
        }
        // MazeArray now contains an array of MazeNodes, with some of them checked off as being checked, these checked positions will not be included in the maze
    }

    /// <summary>
    /// GenerateMaze takes in the positions of blocked spots, and generates a maze from the remaining positions
    /// </summary>
    private bool GenerateMaze(Position pos)
    {
        MazeNode current = MazeArray[pos.X, pos.Z];
        // Mark this node as having been visited and add it to the stack
        mazeCreationStack.Push(pos);
        current.visited = true;
        // begin processing loop
        // check if we have looked in every direction
        if(current.currentDirection > 3)
        {
            // we have looked 0, 1, 2, 3 and we still do not have a direction to go.
            // we need to go back, if the stack is empty, we have made a maze
            // popping will remove the current position from the stack
            mazeCreationStack.Pop();
            // now if the stack is empty we have completed making a maze
            if(mazeCreationStack.Count == 0)
            {
                // maze completed
                return true;
            }
            else
            {
                // we still have more to pop from the stack, attempt to continue at previous point
                return GenerateMaze(mazeCreationStack.Pop());
            }
        }
        else
        {
            // we have not checked everydirection, so we reach into the node and go to its next direction            

            // find out what the next direction is
            while(current.currentDirection < 4)
            {
                Position moveDirection = new Position(0, 0);
                if (current.checkdirections[current.currentDirection] == 0)
                    moveDirection = new Position(0, 1);
                else if (current.checkdirections[current.currentDirection] == 1)
                    moveDirection = new Position(1, 0);
                else if (current.checkdirections[current.currentDirection] == 2)
                    moveDirection = new Position(-1, 0);
                else if (current.checkdirections[current.currentDirection] == 3)
                    moveDirection = new Position(0, -1);

                current.currentDirection++;
                Position nextPosition = current.myPos + moveDirection;

                if (ValidMove(nextPosition) && !MazeArray[nextPosition.X, nextPosition.Z].visited)
                {
                    // remove the walls before we hop to the new position
                    if(moveDirection.Z == 1)
                    {
                        current.RemoveNorthWall();
                        MazeArray[nextPosition.X, nextPosition.Z].RemoveSouthWall();
                    }else if(moveDirection.X == 1)
                    {
                        current.RemoveEastWall();
                        MazeArray[nextPosition.X, nextPosition.Z].RemoveWestWall();
                    }else if(moveDirection.Z == -1)
                    {
                        current.RemoveSouthWall();
                        MazeArray[nextPosition.X, nextPosition.Z].RemoveNorthWall();
                    }else if(moveDirection.X == -1)
                    {
                        current.RemoveWestWall();
                        MazeArray[nextPosition.X, nextPosition.Z].RemoveEastWall();
                    }
                    GenerateMaze(nextPosition);
                }
            }
            if (mazeCreationStack.Count == 0)
            {
                // maze completed
                return true;
            }
            else
            {
                // we still have more to pop from the stack, attempt to continue at previous point
                return GenerateMaze(mazeCreationStack.Pop());
            }
        }
    }
    /// <summary>
    /// ValidMove returns false if the position is outside of our 2d array size
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private bool ValidMove(Position pos)
    {
        return (pos.X >= 0 && pos.X < sizeX.Value && pos.Z >= 0 && pos.Z < sizeZ.Value);       
    }
}
