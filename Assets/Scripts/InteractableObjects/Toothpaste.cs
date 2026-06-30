using Oculus.Interaction;
using System.Linq;
using UnityEngine;

public class Toothpaste : MonoBehaviour
{
    bool hasBeenUsed = false;

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
