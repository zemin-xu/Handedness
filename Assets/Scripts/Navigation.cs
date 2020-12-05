using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// help controller navigate in environment
/// it is to simulate the VR body rotation and movement
/// this script will be attached onto camera
/// when moving it will guide the player move forward or backward
/// when rotating it will only change the rotation of this camera
/// </summary>
public class Navigation : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField]
    private float rotateSpeed = 10.0f;

    [SerializeField]
    private float moveSpeed = 1.0f;

    private void Start()
    {
        playerTransform = transform.parent;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * rotateSpeed * -1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            playerTransform.Translate(transform.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            playerTransform.Translate(transform.forward * Time.deltaTime * moveSpeed * -1);
        }
    }
}