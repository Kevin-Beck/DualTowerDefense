using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    Vector3 offset;
    public float speed = 50;
    public float rotSpeed = 50;
    private void Start()
    {
        offset = transform.position;
    }

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
        if (transform.position.y > 100)
            transform.position = new Vector3(transform.position.x, 100, transform.position.z);

    }
}
