using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;
using System.Linq;

public class DentureCup : MonoBehaviour
{
    public UnityEvent OnDenturePlaced;
    [SerializeField] GameObject secondDenture; // need one denture to be already in cup as force stay and force dropping of denture breaks position of denture for some reason

    void PositionDentureInCup(GameObject denture) // fits the dentures into the cup, making the dentures not grabbable afterwards
    {
        denture.GetComponent<Grabbable>().enabled = false;
        denture.GetComponent<Rigidbody>().isKinematic = true;
        denture.GetComponent<BoxCollider>().enabled = false;
        denture.SetActive(false);
        secondDenture.SetActive(true);
        OnDenturePlaced.Invoke(); // continues the flow of events in scenario manager
    }

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
        if (other.gameObject == GameManager.instance.dentures) // place dentures into cup if not holding anymore
        {
            PositionDentureInCup(GameManager.instance.dentures);

            //if (other.gameObject.GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() != null)
            //{
            //    if (!other.gameObject.GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>().HasSelectedInteractable)
            //    {
            //        PositionDentureInCup(other.gameObject);
            //    }
            //}
            //else if (other.gameObject.GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() == null)
            //{
            //    PositionDentureInCup(other.gameObject);
            //}
        }
    }
}
