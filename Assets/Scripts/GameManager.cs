using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject mouse;

    private void Awake()
    {
        instance = this;

        // reset data
        CSVManager.CreateData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CSVManager.Append(GetData());
            Debug.Log("Data updated");
        }
    }

    private string[] GetData()
    {
        string[] ret = new string[CSVManager.FEATURE_NUM + 1];
        ret[0] = mouse.transform.position.x.ToString();
        ret[1] = mouse.transform.position.y.ToString();
        ret[2] = mouse.transform.position.z.ToString();

        ret[CSVManager.FEATURE_NUM] = 0.ToString();
        return ret;
    }
}