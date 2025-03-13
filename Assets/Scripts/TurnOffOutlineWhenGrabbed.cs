using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOutlineWhenGrabbed : MonoBehaviour
{
    [SerializeField] Outline outline;

    private void Start()
    {
        if (outline == null)
            outline = GetComponent<Outline>();
    }

    private void Update()
    {
        if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject))
        {
            outline.enabled = false;
            this.enabled = false;
        }
    }
}
