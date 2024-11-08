using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;
using System.Linq;

public class DentureCup : MonoBehaviour
{
    public UnityEvent OnDenturePlaced;

    void PositionDentureInCup(GameObject denture)
    {
        denture.GetComponent<Rigidbody>().isKinematic = true;
        denture.GetComponent<BoxCollider>().enabled = false;
        denture.transform.localScale = Vector3.one;
        denture.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1.3616f);

        OnDenturePlaced.Invoke();
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
        if (other.gameObject == GameManager.instance.dentures) // placed dentures into cup
        {
            if (other.gameObject.GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() != null)
            {
                if (!other.gameObject.GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>().HasSelectedInteractable)
                {
                    PositionDentureInCup(other.gameObject);
                }
            }
            else if (other.gameObject.GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() == null)
            {
                PositionDentureInCup(other.gameObject);
            }
        }
    }
}
