using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Toothpaste : MonoBehaviour
{
    bool hasBeenUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // must set to isTrigger when grabbed as collision does not work when grabbed
        if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() != null && !hasBeenUsed)
        {
            if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>().HasSelectedInteractable)
                GetComponent<BoxCollider>().isTrigger = true;
            else
                GetComponent<BoxCollider>().isTrigger = false;
        }
        else
            GetComponent<BoxCollider>().isTrigger = false;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (hasBeenUsed) return;

    //    if (collision.gameObject.name == "Toothbrush")
    //    {
    //        GetComponent<AudioSource>().Play();
    //        hasBeenUsed = true;
    //        collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    //        collision.gameObject.GetComponent<IObjectInteractable>().SetInteractive(true);

    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenUsed) return;

        if (other.gameObject.name == "Toothbrush")
        {
            if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(other.gameObject))
            {
                GetComponent<AudioSource>().Play();
                hasBeenUsed = true;
                other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                other.gameObject.GetComponent<IObjectInteractable>().SetInteractive(true);
            }
        }
    }
}
