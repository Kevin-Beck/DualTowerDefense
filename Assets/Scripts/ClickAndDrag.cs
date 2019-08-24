using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private bool selected;
    Vector3 lastFramePosition;
    bool firstFrame = true;
    private Camera cam;
    [SerializeField] bool xpos = false;
    [SerializeField] bool xneg = false;
    [SerializeField] bool ypos = false;
    [SerializeField] bool yneg = false;
    [SerializeField] bool zpos = false;
    [SerializeField] bool zneg = false;

    void Start()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 150.0f))
        {
            if (hit.collider.gameObject == gameObject)
            {
                selected = true;
            }
            else
                selected = false;
        }
    }
    private void OnMouseUp()
    {
        selected = false;
        firstFrame = true;
    }
    private void OnMouseDrag()
    {
        if (selected)
        {
            if (firstFrame)
            {
                lastFramePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
                firstFrame = false;
            }
            else
            {
                Vector2 mousePos = new Vector2();
                Vector3 curFramePosition;
                mousePos.x = Input.mousePosition.x;
                mousePos.y = Input.mousePosition.y;
                curFramePosition = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

                Vector3 screenDifferenceVector = curFramePosition - lastFramePosition;

                Vector3 moveVector = new Vector3();
                if (xpos)
                    moveVector += Vector3.Project(screenDifferenceVector, new Vector3(1, 0, 0));
                if (xneg)
                    moveVector += Vector3.Project(screenDifferenceVector, new Vector3(-1, 0, 0));
                if (ypos)
                    moveVector += Vector3.Project(screenDifferenceVector, new Vector3(0, 1, 0));
                if (yneg)
                    moveVector += Vector3.Project(screenDifferenceVector, new Vector3(0, -1, 0));
                if (zpos)
                    moveVector += Vector3.Project(screenDifferenceVector, new Vector3(0, 0, 1));
                if (zneg)
                    moveVector += Vector3.Project(screenDifferenceVector, new Vector3(0, 0, -1));

                MoveMe(moveVector * 100);
                lastFramePosition = curFramePosition;
            }
        }
    }

    private void MoveMe(Vector3 pos)
    {
        transform.position += pos;
    }
    
}
