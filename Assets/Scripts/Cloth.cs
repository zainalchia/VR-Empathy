using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Cloth : MonoBehaviour
{
    [SerializeField] GameObject DroppedFood;
    public UnityEvent FinishCleaning;
    public UnityEvent WhileCleaning;

    private float cleanInterval = 2;
    private bool AbleToClean = true;
    private bool startTimer = false;
    private float timer = 0;
    private bool CustomerDialogue = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ToClean")
        {
            if (AbleToClean)
            {
                Destroy(collision.gameObject);
                AbleToClean = false;
                startTimer = true;
                if (CustomerDialogue)
                {
                    WhileCleaning.Invoke();
                    CustomerDialogue = false;
                }
            }
        }

        if (collision.gameObject.tag == "LeftHand")
        {
            ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
        }
        if (collision.gameObject.tag == "RightHand")
        {
            ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
        }
    }

    private void Update()
    {

        if (startTimer)
        {
            timer += 1 * Time.deltaTime;
            if (timer >= cleanInterval)
            {
                timer = 0;
                startTimer = false;
                AbleToClean = true;
            }
        }

        if (DroppedFood.transform.childCount == 0) 
        {
            FinishCleaning.Invoke(); 
        }
    }
}
