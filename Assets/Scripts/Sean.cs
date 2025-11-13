using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Sean : MonoBehaviour
{
    public UnityEvent OnGrab;
    bool PlayOnce = true;
    public bool StartSegment = false;

    private void OnTriggerEnter(Collider other)
    {
        if (StartSegment)
        {
            if (other.gameObject.tag == "LeftHand")
            {
                ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
            }
            if (other.gameObject.tag == "RightHand")
            {
                ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
            }
            if (PlayOnce && other.gameObject.tag.Contains("Hand"))
            {
                OnGrab.Invoke();
                PlayOnce = false;
            }
        }
    }
}
