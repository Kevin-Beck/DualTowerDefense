using System.Collections.Generic;
using UnityEngine;

public class MazeSolver : MonoBehaviour
{
    private MazeNode[,] myMaze;
    Stack<Position> Path;
    public bool[,] visited;
    public PositionReference StartRef;
    public PositionReference FinishRef;
    private int curX;
    private int curZ;
    private int fails = 0;

    public IntReference MazeX;
    public IntReference MazeZ;

    public GameEvent MazeSolved;
    public GameEvent MazeSolveFailed;    

    public Stack<Position> SolveMaze(MazeNode[,] Maze)
    {
        myMaze = Maze;
        Path = new Stack<Position>();

        curX = StartRef.Value.X;
        curZ = StartRef.Value.Z;

        visited = new bool[MazeX.Value, MazeZ.Value];
        for (int i = 0; i < MazeX.Value; i++)
        {
            for (int j = 0; j < MazeZ.Value; j++)
            {
                visited[i, j] = false;
            }
        }

        while (SolveStep()) ;       

        return Path;
    }
    public bool SolveStep()
    {
        if (curX == FinishRef.Value.X && curZ == FinishRef.Value.Z)
        {
            Path.Push(new Position(curX, curZ));
            MazeSolved.Raise();
            return false;
        }
        else
        {
            // Save the current path we are on
            Path.Push(new Position(curX, curZ));
            // Mark our current spot as explored
            visited[curX, curZ] = true;

            // if we cannot move to a valid location false is returned and we need to move back a spot.
            if (!MoveToValidPosition())
            {
                Path.Pop();
                Position backStep = new Position(curX, curZ);
                if (Path.Count != 0)
                {
                    backStep = Path.Pop();
                }
                else if (Path.Count == 0)
                {
                    fails++;
                }
                else
                    fails = 0;

                if (fails > 4)
                {
                    MazeSolveFailed.Raise();
                    return false;
                }
                curX = backStep.X;
                curZ = backStep.Z;

            }
            return true;
        }
        
    }

    private bool MoveToValidPosition()
    {
        // Check North
        if (curZ + 1 >= MazeZ.Value || myMaze[curX, curZ].walls[0] || visited[curX, curZ+1])
        {
            // if we hit a wall north, or north is off the charts, or north has been visited -- move on we cant move there
        }
        else
        {
            curZ += 1;
            return true;
        }
        
        // Check East
        if (curX+1 >= MazeX.Value || myMaze[curX, curZ].walls[1] || visited[curX+1, curZ])
        {
        }
        else
        {
            curX += 1;
            return true;
        }

        // Check South
        if (curZ - 1 < 0 || myMaze[curX, curZ].walls[2] || visited[curX, curZ-1])
        {
            // if we hit a wall north, or north is off the charts, or north has been visited -- move on
        }
        else
        {
            curZ -= 1;
            return true;
        }

        // Check West
        if (curX-1 < 0 || myMaze[curX, curZ].walls[3] || visited[curX-1, curZ])
        {
            // if we hit a wall north, or north is off the charts, or north has been visited -- move on
        }
        else
        {
            curX -= 1;
            return true;
        }
        return false;
    }
}
