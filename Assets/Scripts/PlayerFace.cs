using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFace : MonoBehaviour
{
    // script is on GameObject "Face", in middleEyeAnchor
    public UnityEvent OnGlassesPutOn;
    //public UnityEvent OnDenturesPutOn;

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
        #region Glasses
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

        // checks if hand is in range to take off glasses
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
        #endregion

        #region Dentures
        //// putting on dentures
        //if (GameManager.instance.toPutDenturesOn && ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(other.gameObject))
        //{
        //    if (other.gameObject == GameManager.instance.dentures)
        //    {
        //        GameManager.instance.dentures.GetComponent<Rigidbody>().useGravity = false;
        //        GameManager.instance.dentures.SetActive(false);
        //        OnDenturesPutOn.Invoke();
        //        GameManager.instance.toPutDenturesOn = false;
        //    }
        //}

        // checks if hand is in range to take off dentures
        if (GameManager.instance.toTakeDenturesOff)
        {
            foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
            {
                if (other.gameObject.transform.parent.gameObject == grabInteractor.gameObject)
                {
                    if (!grabInteractor.HasSelectedInteractable) // make sure that controller is not holding onto anything else
                        ControllerInteractionsManager.instance.CanTakeOffDentures(grabInteractor);
                }
            }
        }
        #endregion



        if (other.gameObject.GetComponent<IObjectInteractable>() != null) // mug, toothbrush etc.
        {
            if (other.gameObject.GetComponent<IObjectInteractable>().ShouldInteractWithFace())
            {
                other.gameObject.GetComponent<IObjectInteractable>().OnInteract();
            }
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

        if (GameManager.instance.toTakeDenturesOff) // check if hand is out of range to remove dentures
        {
            foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
            {
                if (other.gameObject.transform.parent.gameObject == grabInteractor.gameObject)
                {
                    ControllerInteractionsManager.instance.CannotTakeOffDentures(grabInteractor);
                }
            }
        }
    }
}
