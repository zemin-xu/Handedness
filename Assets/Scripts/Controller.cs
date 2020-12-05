using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script is attached on Controller to move Controller object by using mouse
/// </summary>
public class Controller : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float sensitivity = 0.01f;

    private Vector3 prevPos;

    private void Update()
    {
        Vector3 currPos = Input.mousePosition;
        Vector3 offset = currPos - prevPos;

        if (offset != Vector3.zero)
        {
            transform.rotation = camera.transform.rotation;

            Vector3 dir = Vector3.ProjectOnPlane(offset, transform.forward).normalized;
            transform.position = transform.position + offset.magnitude * dir * sensitivity;
        }

        prevPos = currPos;
    }
}