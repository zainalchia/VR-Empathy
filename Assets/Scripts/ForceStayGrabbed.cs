using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class ForceStayGrabbed : MonoBehaviour
{
    public bool active = false;

    public void SetActive(bool trueOrFalse)
    {
        active = trueOrFalse;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                // force select left hand
                ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(this.gameObject.GetComponent<GrabInteractable>());
            }

            if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                // force select right hand
                ControllerInteractionsManager.instance.rightGrabInteractor.ForceSelect(this.gameObject.GetComponent<GrabInteractable>());
            }
        }
    }
}
