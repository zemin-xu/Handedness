using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// to open the door when user has finish mission of touching cubes
/// </summary>
public class AutoDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject leftDoor;

    [SerializeField]
    private GameObject rightDoor;

    [SerializeField]
    private Circle circleScript;

    [SerializeField]
    private float moveValue = 2.0f;

    private void Start()
    {
        circleScript.onCircleTouched += OpenDoor;
    }

    private void OpenDoor()
    {
        StartCoroutine(CoroutineOpenDoor());
    }

    private IEnumerator CoroutineOpenDoor()
    {
        float delta = 0;
        while (delta < moveValue)
        {
            float x = Time.deltaTime;
            Vector3 left = new Vector3(leftDoor.transform.position.x + x, leftDoor.transform.position.y,
                leftDoor.transform.position.z);
            Vector3 right = new Vector3(rightDoor.transform.position.x - x, rightDoor.transform.position.y,
                rightDoor.transform.position.z);

            leftDoor.transform.position = left;
            rightDoor.transform.position = right;

            delta += x;

            yield return null;
        }
    }
}