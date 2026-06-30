using UnityEngine;
using UnityEngine.UI;

public class CheckboxScript : MonoBehaviour
{
    public bool isChecked = false;
    [HideInInspector]
    public bool isDisabled = false;

    [HideInInspector]
    public RawImage image;

    [HideInInspector]
    public bool toBeShown = true;

    void Start()
    {
        image = GetComponent<RawImage>();
    }

    public void ChangeColor()
    {
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
