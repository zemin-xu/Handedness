using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Circle circleScript;

    private void OnTriggerEnter(Collider collision)
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            if (collision.gameObject.tag == "Controller")
            {
                GetComponent<Renderer>().material.color = Color.green;
                circleScript = transform.parent.GetComponent<Circle>();
                circleScript.OnCubetouched();
                UpdateOffsetData();

                Destroy(GetComponent<Collider>());
            }
        }
    }

    private void UpdateOffsetData()
    {
        circleScript.RecordControllerData();
    }
}