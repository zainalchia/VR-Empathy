using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ThymeVRUtility
{
    public static bool IsHeld(GrabInteractable interactable)
    {
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.SelectedInteractable == null) continue;
            if (grabInteractor.SelectedInteractable.gameObject == interactable.gameObject) return true;
        }
        return false;
    }
}