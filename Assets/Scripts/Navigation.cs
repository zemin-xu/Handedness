using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// help controller and camera navigate in environment
/// should be attached at the parent gameobject
/// when moving it will guide the player move forward or backward
/// when rotating it will only change the rotation of camera
/// </summary>
public class Navigation : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 10.0f;

    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private Camera camera;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidbody.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            camera.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * rotateSpeed * -1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            camera.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.velocity = camera.transform.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.velocity = camera.transform.forward * moveSpeed * -1;
        }
    }
}