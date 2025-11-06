using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FoodTray : MonoBehaviour
{
    public UnityEvent OnGrab;
    //public TMP_Text DebugText;
    public bool AbleToGrab = true;

    private void OnTriggerStay(Collider other)
    {
        if (AbleToGrab)
        {
            if (other.gameObject.tag.Contains("Hand"))
                OnGrab.Invoke();
            if (other.gameObject.tag == "LeftHand")
                ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
            else if (other.gameObject.tag == "RightHand")
                ControllerInteractionsManager.instance.rightGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
        }
    }
}
