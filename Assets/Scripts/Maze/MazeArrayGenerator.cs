using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Creates an array of mazeNodes which can be processed and shown on screen.
/// </summary>
public class MazeArrayGenerator : MonoBehaviour
{
    [SerializeField] IntReference sizeZ = default;
    [SerializeField] IntReference sizeX = default;
    [SerializeField] PositionReference StartPosition = default;
    private MazeNode[,] MazeArray;
    Stack<MazeNode> mazeCreationStack;

    /// <summary>
    /// Takes in a list of Position Objects and returns a maze that move through the array
    /// Returns a two dimensional array of MazeNode Objects that represent a maze
    /// </summary>
    /// <param name="BlockedPositions"></param>
    /// <returns></returns>
    public MazeNode[,] GetMaze(List<Position> BlockedPositions)
    {        
        mazeCreationStack = new Stack<MazeNode>();        
        CreateMazeArray(BlockedPositions);        
        GenerateMaze(StartPosition);       
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
        

        foreach (Position p in blocked)
        {
            MazeArray[p.X, p.Z] = null;
        }

        // MazeArray now contains an array of MazeNodes, with some of them checked off as being checked, these checked positions will not be included in the maze
    }

    /// <summary>
    /// GenerateMaze takes in a start position, and generates a valid maze from the remaining positions
    /// </summary>
    private void GenerateMaze(Position createStart)
    {
        MazeNode current = MazeArray[createStart.X, createStart.Z];
        // Mark this node as having been visited and add it to the stack
        current.visited = true;
        // begin processing loop
        // check if we have looked in every direction
        bool finished = false;
        while (!finished)
        {
         
            if (current.currentDirection > 3)
            {
                // we have looked 0, 1, 2, 3 and we still do not have a direction to go.
                // we need to go back, if the stack is empty, we have made a maze
                // popping will remove the current position from the stack
                current = mazeCreationStack.Pop();
                // now if the stack is empty we have completed making a maze
                
            }
            else
            {
                // we have not checked everydirection, so we reach into the node and go to its next direction  
                
                bool foundValidPosition = false;
                while (current.currentDirection < 4 && !foundValidPosition)
                {
                    Position moveDirection = new Position(0, 0);
                    // process the next position in the current node
                    if (current.checkdirections[current.currentDirection] == 0)
                        moveDirection.Z = 1;
                    else if (current.checkdirections[current.currentDirection] == 1)
                        moveDirection.X = 1;
                    else if (current.checkdirections[current.currentDirection] == 2)
                        moveDirection.Z = -1;
                    else if (current.checkdirections[current.currentDirection] == 3)
                        moveDirection.X = -1; 

                    // that position is equal to the current position plus the move
                    Position nextPosition = new Position(current.myPos.X + moveDirection.X, current.myPos.Z + moveDirection.Z);
                    current.currentDirection++; // increment the counter for which diretion we should look at
                    // if this next position is a valid move, and it has not yet been processed, we will cut down the walls and go to that position
                    if (ValidMove(nextPosition) && MazeArray[nextPosition.X, nextPosition.Z] != null && !MazeArray[nextPosition.X, nextPosition.Z].visited)
                    {                        
                        // remove the walls before we hop to the new position
                        if (moveDirection.Z == 1)
                        {
                            current.RemoveNorthWall();
                            MazeArray[nextPosition.X, nextPosition.Z].RemoveSouthWall();
                        }
                        else if (moveDirection.X == 1)
                        {
                            current.RemoveEastWall();
                            MazeArray[nextPosition.X, nextPosition.Z].RemoveWestWall();
                        }
                        else if (moveDirection.Z == -1)
                        {
                            current.RemoveSouthWall();
                            MazeArray[nextPosition.X, nextPosition.Z].RemoveNorthWall();
                        }
                        else if (moveDirection.X == -1)
                        {
                            current.RemoveWestWall();
                            MazeArray[nextPosition.X, nextPosition.Z].RemoveEastWall();
                        }
                        foundValidPosition = true;

                        mazeCreationStack.Push(current);
                        current = MazeArray[nextPosition.X, nextPosition.Z];

                        mazeCreationStack.Push(current);
                        current.visited = true;
                    }                   
                }
            }

            if (mazeCreationStack.Count == 0 && current.currentDirection > 3)
            {
                // maze completed

                finished = true;
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
