using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class ForceStayGrabbed : MonoBehaviour
{
    public bool active = false;
    public bool forceStay = false;
    private bool leftHandGrabbing = false;
    private bool rightHandGrabbing = false;

    public void SetForceGrabActive(bool trueOrFalse)
    {
        active = trueOrFalse;

        if (trueOrFalse == false)
        {
            ControllerInteractionsManager.instance.ActivateItemDrop();
            forceStay = false;
            leftHandGrabbing = false;
            rightHandGrabbing = false;
        }
    }

    void Update()
    {
        if (active)
        {
            if (forceStay == false)
            {
                if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject))
                {
                    if (ControllerInteractionsManager.instance.ObjInWhichHand(gameObject) == 0)
                        leftHandGrabbing = true;
                    else if (ControllerInteractionsManager.instance.ObjInWhichHand(gameObject) == 1)
                        rightHandGrabbing = true;

                    forceStay = true;
                }
            }
        }

        if (forceStay && active)
        {
            if (leftHandGrabbing)
            {
                if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
                    GameManager.instance.grabInteractors[0].ForceSelect(gameObject.GetComponent<GrabInteractable>());
            }

            if (rightHandGrabbing)
            {
                if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
                    GameManager.instance.grabInteractors[1].ForceSelect(gameObject.GetComponent<GrabInteractable>());
            }
        }
    }
}
