using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugTextTest : MonoBehaviour
{
    public static DebugTextTest Instance;
    [SerializeField] private TMP_Text debugText;
    public int maxLines = 50;
     private Queue<string> logLines = new Queue<string>();

    //[SerializeField] private GameObject[] gameObjectPosition;

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        AddToConsole(logString); // funnel all logs through here
    }

    public void AddToConsole(string log)
    {
        if (debugText == null)
        {
            Debug.LogWarning("DebugTextTest: debugText is not assigned!");
            return;
        }

        if (logLines.Count >= maxLines)
            logLines.Dequeue();

        logLines.Enqueue(log);
        debugText.text = string.Join("\n", logLines.ToArray());
    }


    // Start is called before the first frame update
    //void Start()
    //{
    //    debugText = GetComponent<TMP_Text>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (gameObjectPosition != null)
    //    {
    //        for (int i = 0; i < gameObjectPosition.Length; i++)
    //        {
    //            if (i == 0)
    //                debugText.text = gameObjectPosition[i].transform.position.ToString();
    //            else
    //                debugText.text += ", " + gameObjectPosition[i].transform.position.ToString();
    //        }            
    //    }
    //}
}
