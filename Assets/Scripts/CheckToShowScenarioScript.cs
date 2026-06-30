using UnityEngine;

public class CheckToShowScenarioScript : MonoBehaviour
{
    [SerializeField] private CheckboxScript checkBoxScript;

    void Awake()
    {
        checkEnabledScenarios();
    }

    private void OnEnable()
    {
        checkEnabledScenarios();
    }

    void checkEnabledScenarios()
    {
        if (checkBoxScript.toBeShown) return;
        gameObject.SetActive(false);
    }
}
