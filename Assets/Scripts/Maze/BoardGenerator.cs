using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject BoardNodePrefab;
    public GameObject PathTilePrefab;
    public GameEvent BoardCreated;
    public ThingRuntimeSet towers;
    public ThingRuntimeSet mazeNodes;
    public ThingRuntimeSet pathTiles;
    public float pathHeight;
    [SerializeField] FloatReference NodeScale;
    [SerializeField] float nodeHeight = 0;
    
    public void CreateBoard()
    {
        DeleteAllBoardNodesWithoutTowers();
        DeleteAllPathTiles();

        MazeArrayGenerator mag = GetComponent<MazeArrayGenerator>();
        List<Position> currentBlockedPositions = new List<Position>();
        // foreach tower, add it to the blocked list
        
        foreach(Thing t in towers.Items)
        {
            Position p = new Position(Mathf.RoundToInt(t.gameObject.transform.position.x / NodeScale), Mathf.RoundToInt(t.gameObject.transform.position.z / NodeScale));
            currentBlockedPositions.Add(p);
        }
        // foreach otherblocked position, block that position
        // in the future if we have other blocked sets we can eval them here before
        // generating the maze on the board.

        MazeNode[,] mazeData = mag.GetMaze(currentBlockedPositions);

        // Solve Maze
        MazeSolver myMazeSolver = GetComponent<MazeSolver>();
        Stack<Position> path = myMazeSolver.SolveMaze(mazeData);

        // Build Maze
        foreach (MazeNode mn in mazeData)
        {            
            GameObject go = Instantiate(BoardNodePrefab, transform);
            go.transform.position = new Vector3(mn.myPos.X * NodeScale.Value, nodeHeight, mn.myPos.Z * NodeScale.Value);
            BoardNode bn = go.GetComponent<BoardNode>();

            if (mn.walls[0] == false)
                Destroy(bn.NorthWall);
            if (mn.walls[1] == false)
                Destroy(bn.EastWall);
            if (mn.walls[2] == false)
                Destroy(bn.SouthWall);
            if (mn.walls[3] == false)
                Destroy(bn.WestWall);
        }

        // lay solved path
        while(path.Count > 0)
        {
            GameObject go = Instantiate(PathTilePrefab, transform);
            Position p = path.Pop();
            go.transform.position = new Vector3(p.X * NodeScale, pathHeight, p.Z * NodeScale);
        }
        
        BoardCreated.Raise();
    }

    public void DeleteAllBoardNodes()
    {
        while (mazeNodes.Items.Count > 0)
        {            
            Destroy(mazeNodes.Items[0].gameObject);
        }
    }
    public void DeleteAllBoardNodesWithoutTowers()
    {
        int pos = 0;
        while(mazeNodes.Items.Count > towers.Items.Count)
        {
            if (mazeNodes.Items[pos].gameObject.GetComponent<BoardNode>().myTurret == null)
                Destroy(mazeNodes.Items[pos].gameObject);
            else
                pos++;

            if (pos > mazeNodes.Items.Count)
                break;
        }
    }
    public void DeleteAllPathTiles()
    {
        while (pathTiles.Items.Count > 0)
            Destroy(pathTiles.Items[0].gameObject);
    }
}
