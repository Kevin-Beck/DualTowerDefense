using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    [SerializeField] List<Position> CurrentTowers = new List<Position>();
    [SerializeField] GameObject towerPlaceHolder;


    public List<Position> GetCurrentTowers()
    {
        return CurrentTowers;
    }

    public void PlaceRepresentation()
    {
        foreach (Position p in CurrentTowers)
        {
           GameObject go = Instantiate(towerPlaceHolder, new Vector3(p.X, .25f, p.Z) * 4, Quaternion.identity);
            go.transform.parent = transform;
        }
    }
    public void DeleteAllRepresentations()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
    public void TEMPaddrandomTowers()
    {
        DeleteAllRepresentations();
        CurrentTowers.Add(new Position(Random.Range(0, 19), Random.Range(0, 19)));
        PlaceRepresentation();
    }
}
