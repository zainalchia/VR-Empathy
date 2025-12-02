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
        // Detect left hand touching chicken
        if (other.CompareTag("LeftHand"))
        {
            inContact = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Left hand moved away
        if (other.CompareTag("LeftHand"))
        {
            inContact = false;
            isHolding = false;

            if (chopManager != null)
                chopManager.ChickenHold(false);
        }
    }

    void Update()
    {
        // Track left controller trigger
        bool triggerPressed = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.2f;

        // If touching chicken and pressing trigger → holding
        if (inContact && triggerPressed)
        {
            if (!isHolding)
            {
                isHolding = true;
                chopManager.ChickenHold(true);
            }
        }
        else
        {
            // Trigger released or hand moved
            if (isHolding || !inContact)
            {
                isHolding = false;

                if (chopManager != null)
                    chopManager.ChickenHold(false);
            }
        }
    }
}
