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
        start.SetValue(new Position(Random.Range(0, sizeX.Value/3), Random.Range(0, sizeZ/3)));
        end.SetValue(new Position(Random.Range(sizeX.Value/3 * 2, sizeX.Value), Random.Range(sizeZ.Value/3 *2, sizeZ)));
        UpdatePositions();
    }

    public void UpdatePositions()
    {
        StartMarker.transform.position = new Vector3(start.Value.X * 4, 0f, start.Value.Z * 4);
        EndMarker.transform.position = new Vector3(end.Value.X * 4, 0f, end.Value.Z * 4);
    }

}
