using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOutlineWhenGrabbed : MonoBehaviour
{
    [SerializeField]
    GameObject OutlineObject;


    private void Update()
    {
        if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject))
        {
            OutlineObject.SetActive(true);
        }
        else
        {
            OutlineObject.SetActive(false);
        }
    }
}
