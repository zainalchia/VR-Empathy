using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class OutlineDisappearOnTouch : MonoBehaviour
{
    [SerializeField] Outline outline;
    bool inTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null)
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null)
        {
            inTrigger = false;
        }
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && inTrigger)
        {
            outline.enabled = false;
        }
    }
}
