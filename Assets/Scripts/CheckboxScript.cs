using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckboxScript : MonoBehaviour
{
    [SerializeField] bool isChecked = false;
    bool isDisabled = false;

    RawImage image;

    //Secret menu scenario
    public bool toBeShown = true;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
    }

    public void ChangeColor()
    {
        //Select / Deselect scenario
        if (!isChecked)
        {
            isChecked = true;
            image.color = new Color(0, 255, 0);
            toBeShown = false;
        }
        else
        {
            isChecked = false;
            image.color = new Color(255, 255, 255);
            toBeShown = true;
        }
    }

    public void OtherScenarioButton()
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
