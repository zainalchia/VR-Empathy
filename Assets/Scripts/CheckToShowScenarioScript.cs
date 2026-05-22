using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToShowScenarioScript : MonoBehaviour
{

    [SerializeField] private CheckboxScript checkBoxScript;

    // Start is called before the first frame update
    void Awake()
    {
        if (checkBoxScript.toBeShown) return;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
