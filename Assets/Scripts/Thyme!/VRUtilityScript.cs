using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


class ThymeVRUtility
{
    public static bool IsHeld(Grabbable grabbable)
    {
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.SelectedInteractable == null) continue;
            if (grabInteractor.SelectedInteractable.gameObject == grabbable.gameObject) return true;
        }
        return false;
    }
}