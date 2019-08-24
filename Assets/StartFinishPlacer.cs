using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFinishPlacer : MonoBehaviour
{
    public PositionVariable start;
    public PositionVariable end;

    public IntReference sizeX;
    public IntReference sizeZ;

    public GameObject StartMarker;
    public GameObject EndMarker;

    public void RandomizeLocations()
    {
        start.SetValue(new Position(Random.Range(0, sizeX.Value), Random.Range(0, sizeZ)));
        end.SetValue(new Position(Random.Range(0, sizeX.Value), Random.Range(0, sizeZ)));
        UpdatePositions();
    }

    public void UpdatePositions()
    {
        StartMarker.transform.position = new Vector3(start.Value.X, .25f, start.Value.Z) * 4;
        EndMarker.transform.position = new Vector3(end.Value.X, .25f, end.Value.Z) * 4;
    }

}
