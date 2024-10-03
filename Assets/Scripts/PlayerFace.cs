using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFace : MonoBehaviour
{
    public UnityEvent OnGlassesPutOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // putting on glasses
        if (GameManager.instance.toPutGlassesOn && ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(other.gameObject))
        {
            if (other.gameObject == GameManager.instance.glasses)
            {
                GameManager.instance.glasses.GetComponent<Rigidbody>().useGravity = false;
                GameManager.instance.glasses.SetActive(false);
                OnGlassesPutOn.Invoke();
                GameManager.instance.toPutGlassesOn = false;
            }                
        }

        // taking off glasses
        if (GameManager.instance.toTakeGlassesOff)
        {
            foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
            {
                if (other.gameObject.transform.parent.gameObject == grabInteractor.gameObject)
                {
                    if (!grabInteractor.HasSelectedInteractable) // make sure that controller is not holding onto anything else
                        ControllerInteractionsManager.instance.CanTakeOffGlasses(grabInteractor);
                }
            }
        }

        // medication minigame
        if (GameManager.instance.toEatMedication)
        {
            if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(other.gameObject)) // checks if it is held in hand
                MinigameManager.instance.EatMedication(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameManager.instance.toTakeGlassesOff) // check if hand is out of range to remove glasses
        {
            foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
            {
                if (other.gameObject.transform.parent.gameObject == grabInteractor.gameObject)
                {
                    ControllerInteractionsManager.instance.CannotTakeOffGlasses(grabInteractor);
                }
            }
        }
    }
}
