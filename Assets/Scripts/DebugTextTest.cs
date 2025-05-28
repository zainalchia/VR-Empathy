using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DebugTextTest : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI consoleText;
    public TextMeshProUGUI Text;

    [Header("Settings")]
    public int maxLines = 50;

    [Header("Tag Filters")]
    public string[] requiredTags = new string[] { }; 

    private Queue<string> logLines = new Queue<string>();

    [SerializeField] private GameObject[] gameObjectPosition;

    void Start()
    {
        if (consoleText == null)
            consoleText = GetComponent<TextMeshProUGUI>();

        Text.text = "Console";
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
        if (logLines.Count >= maxLines)
            logLines.Dequeue();

        logLines.Enqueue(logString);

        consoleText.text = string.Join("\n", logLines.ToArray());
    }

    //void HandleLog(string logString, string stackTrace, LogType type)
    //{
    //    // If requiredTags is not empty, filter by tag
    //    if (requiredTags.Length > 0 && !requiredTags.Any(tag => logString.Contains(tag)))
    //        return;

    //    // Format based on log type
    //    string formattedLog = logString;
    //    switch (type)
    //    {
    //        case LogType.Warning:
    //            formattedLog = $"<color=yellow>{logString}</color>";
    //            break;
    //        case LogType.Error:
    //        case LogType.Exception:
    //            formattedLog = $"<color=red>{logString}</color>";
    //            break;
    //            // LogType.Log stays default
    //    }

    //    logLines.Enqueue(formattedLog);

    //    if (logLines.Count > maxLines)
    //        logLines.Dequeue();

    //    consoleText.text = string.Join("\n", logLines);
    //}

    //public void ClearConsole()
    //{
    //    logLines.Clear();
    //    consoleText.text = "";
    //}

    void Update()
    {
        // Optional live tracking of positions
        // Uncomment to debug GameObject positions
        /*
        if (gameObjectPosition != null && gameObjectPosition.Length > 0)
        {
            string positions = "";
            for (int i = 0; i < gameObjectPosition.Length; i++)
            {
                positions += gameObjectPosition[i].transform.position.ToString();
                if (i < gameObjectPosition.Length - 1)
                    positions += ", ";
            }
            Debug.Log("[DebugPos] " + positions);
        }
        */
    }
}
