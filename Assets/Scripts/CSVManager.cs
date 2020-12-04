using UnityEngine;
using System.IO;

public static class CSVManager
{
    public const int FEATURE_NUM = 3;
    private static string dataDirectoryName = "Data";
    private static string dataFileName = "UserData.csv";
    private static string seperator = ",";

    private static string[] headers = new string[FEATURE_NUM + 1]
    {
        "position_x",
        "position_y",
        "position_z",
        "left_handedness"
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

    private static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    private static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            return;
        }
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