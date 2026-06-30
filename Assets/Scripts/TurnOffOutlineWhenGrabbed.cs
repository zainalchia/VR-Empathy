using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnOffOutlineWhenGrabbed : MonoBehaviour
{
    [SerializeField] Outline outline;
    public UnityEvent OnGrabbed;

    private void Start()
    {
        if (outline == null)
            outline = GetComponent<Outline>();
    }

    private void Update()
    {
        if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject))
        {
            OnGrabbed?.Invoke();
            outline.enabled = false;
            this.enabled = false;
        }
    }
}
