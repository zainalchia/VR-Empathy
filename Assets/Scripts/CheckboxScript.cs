using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckboxScript : MonoBehaviour
{
    public bool isChecked = false;
    [HideInInspector]
    public bool isDisabled = false;

    [HideInInspector]
    public RawImage image;

    //Secret menu scenario
    [HideInInspector]
    public bool toBeShown = true;

    void onEnable()
    {
        
        // try
        // {
        //     if (MainMenuManager.scenariosAvailable[scenarioName] != isChecked)
        //     {
        //         ChangeColor();
        //     }
        // }
        // catch (KeyNotFoundException ex)
        // {
        //     // This block catches the specific error and keeps the app from crashing
        //     Debug.Log("Error: The requested item was not found in inventory.");
        // }

        //ChangeColor();
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
    }

    public void ChangeColor()
    {
        Debug.Log("Change Color");
        //Select / Deselect scenario
        if (!isChecked)
        {
            isChecked = true;
            image.color = new Color(0, 255, 0);
            toBeShown = true;
        }
        else
        {
            isChecked = false;
            image.color = new Color(255, 255, 255);
            toBeShown = false;
        }
    }

    public void ChangeColorDisabledEnabled()
    {
        //Select / Deselect scenario
        if (!isDisabled)
        {
            isDisabled = true;
            image.color = new Color(255, 0, 0);
        }
        else
        {
            isDisabled = false;
            image.color = new Color(255, 255, 255);
        }
    }
}
