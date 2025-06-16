using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum ScenarioID
{
    PastNegative,
    PastPositive,
    PresentBad,
    PresentGood
}

public enum SceneID
{
    Bathroom,
    Stall,
    Family,
    LivingRoom,
    VoidDeck,
    Bedroom
}

public class ScenarioPromptManager : MonoBehaviour
{
    [System.Serializable]
    public class PromptEntry
    {
        public ScenarioID Scenario;
        public SceneID Scene;
        public string PromptText;
    }

    public ScenarioID activeScenario;
    [SerializeField] public TextAsset csvFile;
    [SerializeField] private AlertTextController alertTextController;

    private Dictionary<string, List<PromptEntry>> promptMap = new();

    private void Awake()
    {
        LoadPrompts();
    }

    private void LoadPrompts()
    {
        if (csvFile == null)
        {
            Debug.LogError("CSV file not assigned to ScenarioPromptManager.");
            return;
        }

        //skip the headers in the CSV file
        string[] lines = csvFile.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(',');
            if (parts.Length < 3) continue;

            if (!System.Enum.TryParse(parts[0].Trim(), true, out ScenarioID scenario)) continue;
            if (!System.Enum.TryParse(parts[1].Trim(), true, out SceneID scene)) continue;

            PromptEntry entry = new PromptEntry
            {
                Scenario = scenario,
                Scene = scene,
                PromptText = parts[2].Trim()
            };

            string key = GetKey(scenario, scene);
            if (!promptMap.ContainsKey(key))
                promptMap[key] = new List<PromptEntry>();

            promptMap[key].Add(entry);
        }
    }

    private string GetKey(ScenarioID scenario, SceneID scene)
    {
        return $"{scenario}_{scene}";
    }

    public void ShowPrompt(ScenarioID scenario, SceneID scene, int index = 0)
    {
        string key = GetKey(scenario, scene);
        if (!promptMap.ContainsKey(key))
        {
            Debug.LogWarning($"No prompts found for: {scenario}, {scene}");
            return;
        }

        var list = promptMap[key];
        if (index < 0 || index >= list.Count)
        {
            Debug.LogWarning($"Prompt index out of range for: {scenario}, {scene}");
            return;
        }

        if (AlertTextController.instance == null && alertTextController != null)
        {
            alertTextController.gameObject.SetActive(true); // Activate manually
            AlertTextController.instance = alertTextController;
        }

        if (AlertTextController.instance != null)
        {
            AlertTextController.instance.ShowAlert(list[index].PromptText);
        }
        else
        {
            Debug.LogError("AlertTextController.instance is null! Make sure it's assigned in the inspector.");
        }
    }

    public void ShowPrompt(SceneID scene, int index = 0)
    {
        ShowPrompt(activeScenario, scene, index);
    }


    // Optional helper to return all prompts for logic-based sequencing
    public List<string> GetAllPrompts(ScenarioID scenario, SceneID scene)
    {
        string key = GetKey(scenario, scene);
        if (!promptMap.ContainsKey(key)) return new List<string>();

        List<string> prompts = new();
        foreach (var entry in promptMap[key])
            prompts.Add(entry.PromptText);

        return prompts;
    }
}
