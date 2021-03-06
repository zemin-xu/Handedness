﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Handle : MonoBehaviour
{
    [SerializeField]
    private GameObject doorControlled;

    [SerializeField]
    private Movement movement;

    [SerializeField]
    private bool isRightHandle;

    [SerializeField]
    private GameObject indication;

    private float force = 0.3f;

    private Vector3 prevMousePos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            indication.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            indication.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                Vector3 delta = Time.deltaTime * movement.offset.magnitude * force * Vector3.forward;

                // append data
                GameManager.GetData(
                    movement.offset.x.ToString(),
                    movement.offset.y.ToString(),
                    0.ToString(),
                    0.ToString(),
                    0.ToString(),
                    Convert.ToInt32(GameManager.Instance.isRightHanded).ToString());

                if (isRightHandle)
                {
                    delta *= -1;
                }
                transform.position = transform.position + delta;
                doorControlled.transform.position = doorControlled.transform.position + delta;
            }
        }
    }
}