using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// help controller navigate in environment
/// it is to simulate the VR body rotation and movement
/// when moving it will guide the player move forward or backward
/// when rotating it will only change the rotation of this camera
/// </summary>
public class Navigation : MonoBehaviour
{
    private Transform parentTransform;

    [SerializeField]
    private float rotateSpeed = 10.0f;

    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private Camera camera;

    private Rigidbody rigidbody;

    private void Start()
    {
        parentTransform = transform.parent;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidbody.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            camera.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * rotateSpeed * -1);
            //ResetControllerPosition();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            camera.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * rotateSpeed);
            //ResetControllerPosition();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.velocity = transform.forward * moveSpeed;
            //playerTransform.Translate(transform.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //playerTransform.Translate(transform.forward * Time.deltaTime * moveSpeed * -1);
        }
    }

    private void ResetControllerPosition()
    {
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = camera.ScreenPointToRay(center);
        transform.position = transform.position;
        transform.position += ray.direction;
        //controllerTransform.Translate(ray.direction);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }
}