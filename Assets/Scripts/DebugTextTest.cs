using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugTextTest : MonoBehaviour
{
    public static DebugTextTest Instance;
    [SerializeField] private TMP_Text debugText;
    public int maxLines = 50;
    private Queue<string> logLines = new Queue<string>();

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
        AddToConsole(logString);
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
}
