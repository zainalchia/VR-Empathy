using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandHold : MonoBehaviour
{
    public ChickenChopManager chopManager;
    private bool inContact = false;        
    private bool isHolding = false;       

    void OnTriggerEnter(Collider other)
    {
        // detect left hand touching chicken
        if (other.CompareTag("LeftHand"))
        {
            inContact = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // left hand moved away
        if (other.CompareTag("LeftHand"))
        {
            inContact = false;
            isHolding = false;
            chopManager.ChickenHold(false); //tell chicken is not held
        }
    }

    void Update()
    {
        // check if left controller trigger is pressed
        bool triggerPressed = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.5f;

        // if touching chicken + holding trigger, start holding
        if (inContact && triggerPressed && !isHolding)
        {
            isHolding = true;
            chopManager.ChickenHold(true);
        }

        // if trigger released or hand moved, stop holding
        else if ((!inContact || !triggerPressed) && isHolding)
        {
            isHolding = false;
            chopManager.ChickenHold(false);
        }
    }
}
