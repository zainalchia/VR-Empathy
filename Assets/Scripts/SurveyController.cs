using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SurveyController : MonoBehaviour
{
    private void AppendCSV()
    {
        try
        {
            string path = Application.persistentDataPath + "/saved_data.csv";

            // check if file exists
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Timestamp,Position\n");
                Debug.Log("yoohoo " + path);
            }

            // StreamWriter append set to true
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("test");
                Debug.Log(path);
            }

            Debug.Log("blegh2");
            /*
            string fileText = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(Application.persistentDataPath + filename));
            string[] fileTextSplit = fileText.Split(new string[] { "\n" }, System.StringSplitOptions.None);
            int tableSize = fileTextSplit.Length;

            for (int i = 0; i < tableSize; i++)
            {
                //narration[i] = fileTextSplit[i];
            } */
        }
        catch (Exception e)
        {
            Debug.Log("no file found at " + Application.persistentDataPath);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AppendCSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
