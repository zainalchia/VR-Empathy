using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cloth : MonoBehaviour
{
    [SerializeField] GameObject DroppedFood;
    [SerializeField] LayerMask player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ToClean")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "LeftHand")
            ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
        if (collision.gameObject.tag == "RightHand")
            ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
    }
}
