using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioTester : MonoBehaviour
{
    [Header("Prompt Setup")]
    [SerializeField] public ScenarioPromptManager promptManager;

    [SerializeField] public ScenarioID selectedScenario;
    [SerializeField] public SceneID selectedScene;

    [SerializeField] public int promptIndex = 0;
    public int lastIndex = -1;

    public void Start()
    {
        if (promptManager == null)
        {
            Debug.LogError("ScenarioPromptManager reference is missing.");
            return;
        }

        promptManager.activeScenario = selectedScenario;
        promptManager.ShowPrompt(selectedScene, promptIndex);

    }

    void Update()
    {
        if (promptIndex != lastIndex)
        {
            lastIndex = promptIndex;
            TriggerPrompt(); // calls the method above
        }
    }

    // Optional public method if you want to trigger this from a UI button
    public void TriggerPrompt()
    {
        if (promptManager == null)
        {
            Debug.LogError("ScenarioPromptManager reference is missing.");
            return;
        }

        promptManager.activeScenario = selectedScenario;
        promptManager.ShowPrompt(selectedScene, promptIndex);
    }
}
