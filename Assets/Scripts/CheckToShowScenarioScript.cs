using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToShowScenarioScript : MonoBehaviour
{

    [SerializeField] private CheckboxScript checkBoxScript;

    // Start is called before the first frame update
    void Awake()
    {
        checkEnabledScenarios();
    }

    private void OnEnable()
    {
        checkEnabledScenarios();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkEnabledScenarios() 
    {
        if (checkBoxScript.toBeShown) return;

        gameObject.SetActive(false);
    }
}
