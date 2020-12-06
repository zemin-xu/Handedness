using UnityEngine;
using System.IO;

public static class CSVManager
{
    public const int FEATURE_NUM = 4;
    private static string dataDirectoryName = "Data";
    private static string dataFileName = "UserData.csv";
    private static string seperator = ",";

    private static string[] headers = new string[FEATURE_NUM + 1]
    {
        "controller_movement_offset_x",
        "controller_movement_offset_y",
        "left_button_click",
        "right_button_click",
        "is_right_handedness"
    };

    public static void Append(string[] strings)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string res = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (res != "")
                {
                    res += seperator;
                }
                res += strings[i];
            }
            sw.WriteLine(res);
        }
    }

    public static void CreateData()
    {
        VerifyDirectory();
        if (!VerifyFile())
        {
            using (StreamWriter sw = File.CreateText(GetFilePath()))
            {
                string res = "";
                for (int i = 0; i < headers.Length; i++)
                {
                    if (res != "")
                    {
                        res += seperator;
                    }
                    res += headers[i];
                }
                sw.WriteLine(res);
            }
        }
    }

    private static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    private static bool VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            return false;
        }
        return true;
    }

    private static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + dataDirectoryName;
    }

    private static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + dataFileName;
    }
}