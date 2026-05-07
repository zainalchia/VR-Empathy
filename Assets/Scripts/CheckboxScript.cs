using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckboxScript : MonoBehaviour
{
    bool isChecked = false;
    bool isDisabled = false;

    RawImage image;
    
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
            image.color = new Color(0, 225, 0);
        }
        else
        {
            isChecked = false;
            image.color = new Color(225, 225, 225);
        }
    }

    public void OtherScenarioButton()
    {
        //Select / Deselect scenario
        if (!isDisabled)
        {
            isDisabled = true;
            image.color = new Color(225, 0, 0);
        }
        else
        {
            isDisabled = false;
            image.color = new Color(225, 225, 225);
        }
    }
}
