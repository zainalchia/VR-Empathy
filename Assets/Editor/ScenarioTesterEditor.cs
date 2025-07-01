using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScenarioTester))]
public class ScenarioTesterEditor : Editor
{
    private SerializedProperty promptManagerProp;
    private SerializedProperty selectedScenarioProp;
    private SerializedProperty selectedSceneProp;
    private SerializedProperty promptIndexProp;

    private void OnEnable()
    {
        promptManagerProp = serializedObject.FindProperty("promptManager");
        selectedScenarioProp = serializedObject.FindProperty("selectedScenario");
        selectedSceneProp = serializedObject.FindProperty("selectedScene");
        promptIndexProp = serializedObject.FindProperty("promptIndex");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(promptManagerProp);
        EditorGUILayout.PropertyField(selectedScenarioProp);

        ScenarioID scenario = (ScenarioID)selectedScenarioProp.enumValueIndex;

        string[] sceneOptions = GetFilteredSceneOptions(scenario);
        int selectedIndex = Mathf.Max(0, selectedSceneProp.enumValueIndex);

        selectedIndex = EditorGUILayout.Popup("Selected Scene", selectedIndex, sceneOptions);

        // Set back the selected scene enum index based on filtered option
        SceneID actualScene = (SceneID)System.Enum.Parse(typeof(SceneID), sceneOptions[selectedIndex]);
        selectedSceneProp.enumValueIndex = (int)actualScene;

        EditorGUILayout.PropertyField(promptIndexProp);

        if (GUILayout.Button("Trigger Prompt"))
        {
            ((ScenarioTester)target).TriggerPrompt();
        }

        serializedObject.ApplyModifiedProperties();

        Debug.Log($"Scene options: {string.Join(", ", sceneOptions)}");
        Debug.Log($"Attempting to parse: {sceneOptions[selectedIndex]}");

    }

    private string[] GetFilteredSceneOptions(ScenarioID scenario)
    {
        switch (scenario)
        {
            case ScenarioID.PastNegative:
            case ScenarioID.PastPositive:
                return new[] { "Bathroom", "Stall", "FamilyDinner" };

            case ScenarioID.PresentBad:
            case ScenarioID.PresentGood:
                return new[] { "Bathroom", "LivingRoom", "VoidDeck" };

            default:
                return System.Enum.GetNames(typeof(SceneID));
        }
    }
}
