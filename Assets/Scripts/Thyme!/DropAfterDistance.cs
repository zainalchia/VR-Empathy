using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAfterDistance : MonoBehaviour
{
    GrabInteractable interactable;
    float totalDistance;
    Vector3 positionLastFrame;

    [SerializeField] float distanceBeforeDrop;

    private void Awake()
    {
        interactable = GetComponent<GrabInteractable>();
        totalDistance = distanceBeforeDrop;
    }

    private void Update()
    {
        if (totalDistance < distanceBeforeDrop)
        {
            // add distance moved this frame
            totalDistance += (transform.position - positionLastFrame).magnitude;
            positionLastFrame = transform.position;

            // reset
            if (totalDistance < distanceBeforeDrop) return;

            if (ControllerInteractionsManager.instance.leftGrabInteractor.SelectedInteractable == interactable)
                ControllerInteractionsManager.instance.leftGrabInteractor.ForceRelease();
            if (ControllerInteractionsManager.instance.rightGrabInteractor.SelectedInteractable == interactable)
                ControllerInteractionsManager.instance.rightGrabInteractor.ForceRelease();
        }
    }

    public void Activate()
    {
        totalDistance = 0;
    }
}
