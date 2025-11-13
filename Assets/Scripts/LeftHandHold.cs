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
        // left hand moved away from chicken
        if (other.CompareTag("LeftHand"))
        {
            inContact = false;
            isHolding = false;
            chopManager.ChickenHold(false); //tell chicken is not held

            //hide all cut lines 
            if (chopManager != null)
            {
                foreach (var line in chopManager.cutLines)
                    line.SetActive(false);
            }
        }
    }

    void Update()
    {
        // check if left controller trigger is pressed
        bool triggerPressed = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.2f;

        // if touching chicken + holding trigger, start holding
        if (inContact && triggerPressed)
        {
            if (!isHolding)
            {
                isHolding = true;
                chopManager.ChickenHold(true);

                // show the correct current guideline based on progress
                if (chopManager != null)
                {
                    int current = chopManager.GetCurrentPieceIndex();
                    for (int i = 0; i < chopManager.cutLines.Count; i++)
                    {
                        // show the current one, hide others
                        chopManager.cutLines[i].SetActive(i == current);
                    }
                }

            }
        }

        // if trigger released or hand moved, stop holding
        else 
        {
            if (isHolding || !inContact)
            {
                isHolding = false;
                chopManager.ChickenHold(false);

                // hide all guide lines
                if (chopManager != null)
                {
                    foreach (var line in chopManager.cutLines)
                        line.SetActive(false);
                }
            }
        }
    }
}
