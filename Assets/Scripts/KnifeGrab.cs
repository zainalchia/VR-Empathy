using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class KnifeGrab : MonoBehaviour
{
    public ChickenChopManager chopManager;
    [SerializeField] private ForceStayGrabbed forceStayGrabbed;
    private Grabbable grabbable;
    [SerializeField] GameObject chopper;
    private bool hasGrabbed = false;

    private void Awake()
    {
        grabbable = GetComponent<Grabbable>();
    }

    private void Update()
    {
        // Detect if knife has just been grabbed
        if (!hasGrabbed && grabbable != null && grabbable.SelectingPointsCount > 0) //player hands is already holding knife
        {
            hasGrabbed = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // If the left hand touches the knife and it is NOT already grabbed
        if (other.CompareTag("LeftHand") && grabbable.SelectingPointsCount == 0)
        {
            chopper.GetComponent<Grabbable>().enabled = false;
            chopper.GetComponent<GrabInteractable>().enabled = false;
            grabbable.enabled = false;

 
        }

        // Right hand can always grab
        else if (other.CompareTag("RightHand"))
        {
            chopper.GetComponent<Grabbable>().enabled = true;
            chopper.GetComponent<GrabInteractable>().enabled = true;
            grabbable.enabled = true;
        }
    }

}
