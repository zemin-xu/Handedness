using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Circle : MonoBehaviour
{
    public bool isCubeTouched { get; private set; } = false;
    public bool isDoorOpen { get; private set; } = false;

    // When user has tried the mission of touching all the cubes
    public Action onCircleTouched;

    private int numCubeActivated = 0;

    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private float radius = 1f;

    [SerializeField]
    private int numOfCube = 16;

    [SerializeField]
    private float cubeSize = 0.01f;

    private List<GameObject> cubes;

    [SerializeField]
    private Transform controller;

    private float prevControllerEulerX;
    private float prevControllerEulerY;

    private void Start()
    {
        cubes = new List<GameObject>();
        cubes.Clear();

        onCircleTouched += CircleTouched;

        for (int i = 0; i < numOfCube; i++)
        {
            float angle = i * Mathf.PI * 2f / numOfCube;
            Vector3 newPos = new Vector3(transform.position.x + Mathf.Cos(angle) * radius,
                transform.position.y + Mathf.Sin(angle) * radius,
                transform.position.z);

            GameObject go = GameObject.Instantiate(cube, transform);
            go.transform.position = newPos;
            go.transform.rotation = Quaternion.identity;
            go.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
            cubes.Add(cube);
        }
    }

    // when a cube is touched
    public void OnCubetouched()
    {
        if (!isDoorOpen)
        {
            isCubeTouched = true;
            numCubeActivated++;
        }
    }

    // when user has tried touching all the cubes
    private void CircleTouched()
    {
        isDoorOpen = true;
    }

    public void RecordControllerData()
    {
        float x = controller.eulerAngles.x;
        float y = controller.eulerAngles.y;

        float offsetX = x - prevControllerEulerX;
        float offsetY = y - prevControllerEulerY;

        // append data
        GameManager.GetData(
            0.ToString(),
            0.ToString(),
            offsetX.ToString(),
            offsetY.ToString(),
            numCubeActivated.ToString(),
            Convert.ToInt32(GameManager.Instance.isRightHanded).ToString());

        prevControllerEulerX = x;
        prevControllerEulerY = y;
    }
}