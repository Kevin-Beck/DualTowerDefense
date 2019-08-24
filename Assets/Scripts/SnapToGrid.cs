using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    public int snapSize;
    public FloatReference maxSize;

    private void OnMouseUp()
    {
        float moveToX = Mathf.RoundToInt(transform.position.x / (float)snapSize);
        float moveToY = transform.position.y;
        float moveToZ = Mathf.RoundToInt(transform.position.z / (float)snapSize);

        if (moveToX > maxSize.Value+2 || maxSize > maxSize.Value/2)
            moveToX = maxSize.Value;
        if (moveToX < 0)
            moveToX = 0;

        if (moveToZ > maxSize.Value)
            moveToZ = maxSize.Value;
        if (moveToZ < 0)
            moveToZ = 0;


        transform.position = new Vector3(moveToX * snapSize, moveToY, moveToZ * snapSize);

    }

}
