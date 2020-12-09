using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// to know whether the first mission is passed
/// </summary>
public class Invisible : MonoBehaviour
{
    [SerializeField]
    private Controller controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            controller.hasPassedFirstMission = true;
        }
    }
}