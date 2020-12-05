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

            // use dot to know if rotation around Y is greater than 180 degree
            float dot = Vector3.Dot(Vector3.forward, transform.forward);
            if (dot > 0)
            {
                transform.position = transform.position + offset.magnitude * dir * sensitivity;
            }
            else
            {
                transform.position = transform.position + offset.magnitude * dir * sensitivity * -1;
            }
        }

        prevPos = currPos;
    }
}