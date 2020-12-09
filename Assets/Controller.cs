using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// make controller size small when doing action
/// </summary>
public class Controller : MonoBehaviour
{
    [SerializeField]
    private float sizeInAction = 0.1f;

    [SerializeField]
    private Circle circleScript;

    public bool hasPassedFirstMission = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (hasPassedFirstMission)
            {
                transform.localScale = new Vector3(sizeInAction, sizeInAction, sizeInAction);
            }
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            transform.localScale = Vector3.one;
            if (circleScript.isCubeTouched && !circleScript.isDoorOpen)
            {
                circleScript.onCircleTouched.Invoke();
            }
        }
    }
}