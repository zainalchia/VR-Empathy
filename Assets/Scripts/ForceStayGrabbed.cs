using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Unity.VisualScripting;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (forceStay == false)
            {
                if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject))
                {

                    if (ControllerInteractionsManager.instance.ObjInWhichHand(gameObject) == 0)
                    {
                        leftHandGrabbing = true;
                    }
                    else if (ControllerInteractionsManager.instance.ObjInWhichHand(gameObject) == 1)
                    {
                        rightHandGrabbing = true;
                    }

                    forceStay = true;
                }
            }
        }

        if (forceStay && active)
        {
            if (leftHandGrabbing)
            {
                if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
                {
                    // force select left hand
                    GameManager.instance.grabInteractors[0].ForceSelect(gameObject.GetComponent<GrabInteractable>());
                }
            }

            if (rightHandGrabbing)
            {
                if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
                {
                    // force select right hand
                    GameManager.instance.grabInteractors[1].ForceSelect(gameObject.GetComponent<GrabInteractable>());
                }
            }
        }

        /*
        string debug = "";
        foreach (GameObject go in ControllerInteractionsManager.instance.GetItemsGrabbedInHand())
        {
            debug += go.name;
        }
        GameManager.instance.DebugLog(active.ToString() + ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject).ToString() + forceStay.ToString() + ControllerInteractionsManager.instance.ObjInWhichHand(gameObject) +  leftHandGrabbing.ToString() + rightHandGrabbing.ToString() + debug);
        */
    }
}
