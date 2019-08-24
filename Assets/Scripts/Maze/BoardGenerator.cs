using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject BoardNodePrefab;
    public GameEvent BoardCreated;
    [SerializeField] FloatReference NodeScale;
    [SerializeField] float NodeYvalue = 0;

    public void CreateBoard()
    {
        DeleteAllBoardNodes();
        MazeArrayGenerator mag = GetComponent<MazeArrayGenerator>();
        Towers towers = GetComponent<Towers>();
        MazeNode[,] mazeData = mag.GetMaze(towers.GetCurrentTowers());
        foreach(MazeNode mn in mazeData)
        {            
            GameObject go = Instantiate(BoardNodePrefab, transform);
            go.transform.position = new Vector3(mn.myPos.X * NodeScale.Value, NodeYvalue, mn.myPos.Z * NodeScale.Value);
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

        BoardCreated.Raise();
    }

    public void DeleteAllBoardNodes()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}
