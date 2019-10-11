using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <para>***TODO: This is not rigorous and could be greatly improved***</para>
/// CameraMover is the basic controller for the main camera during runtime.
/// </summary>
public class CameraMover : MonoBehaviour
{
    public float maxheight = 100;
    /// <summary>
    /// The offset from the target position that the camera should sit.
    /// <para>if offset is Vector3.Zero, the camera sits directly on the origin.</para>
    /// </summary>
    Vector3 offset;
    /// <summary>
    /// Speed the camera moves forward/backwards/left/right
    /// </summary>
    public float speed = 50;
    /// <summary>
    /// Speed the camera rotates about the y axis
    /// </summary>
    public float rotSpeed = 50;
    /// <summary>
    /// Sets the offset to the current camera position from the origin, this allows the game designer to move the camera
    /// and that change is reflected here without altering any values by hand
    /// <para>This introduces issues depending on where the camera focus should be.</para>
    /// </summary>
    private void Start()
    {
        offset = transform.position;
    }

    /// <summary>
    /// Check for key presses, if anything is detected, a move vector is created and altered based on which keys are
    /// currently pressed.
    /// <para>Input.GetAxis("Mouse ScrollWheel") is used to get scrollwheel action for zooming in and out.</para>
    /// </summary>
    private void Update()
    {
        if (Input.anyKey)
        {
            Vector3 move = new Vector3();
            if (Input.GetKey(KeyCode.W))
            {
                move += transform.forward;
                move.Set(move.x, 0, move.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                move += -1* transform.forward;
                move.Set(move.x, 0, move.z);
            }
            if (Input.GetKey(KeyCode.D))
            {
                move += transform.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                move += -1 * transform.right;
            }
            transform.position += move * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.E))
                transform.RotateAround(transform.position -offset, Vector3.up, -1 * rotSpeed * Time.deltaTime);
            else if (Input.GetKey(KeyCode.Q))
                transform.RotateAround(transform.position-offset, Vector3.up, rotSpeed * Time.deltaTime);            
        }
        transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * speed;

        if(transform.position.y < 10)
            transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        if (transform.position.y > maxheight)
            transform.position = new Vector3(transform.position.x, maxheight, transform.position.z);

    }
}
