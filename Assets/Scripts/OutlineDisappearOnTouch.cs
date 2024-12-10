using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class OutlineDisappearOnTouch : MonoBehaviour
{
    [SerializeField] Outline outline;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null)
        {
            outline.enabled = false;
        }
    }
}
