using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    // when training data, we need to add this label to do supervised learning
    public bool isRightHanded;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        // if file is not existed, create data file
        CSVManager.CreateData();

        Cursor.visible = false;
    }

    public static void GetData(string d0, string d1, string d2, string d3, string label)
    {
        string[] ret = new string[CSVManager.FEATURE_NUM + 1];

        ret[0] = d0;
        ret[1] = d1;
        ret[2] = d2;
        ret[3] = d3;

        ret[CSVManager.FEATURE_NUM] = label;
        CSVManager.Append(ret);

        Debug.Log("update data");
    }
}