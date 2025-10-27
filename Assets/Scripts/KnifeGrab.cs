using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class KnifeGrab : MonoBehaviour
{
    public ChickenChopManager chopManager;  

    private Grabbable grabbable;
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
}
