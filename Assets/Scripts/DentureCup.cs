using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;
using System.Linq;

public class DentureCup : MonoBehaviour
{
    public UnityEvent OnDenturePlaced;

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
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    other.gameObject.GetComponent<BoxCollider>().enabled = false;
                    other.gameObject.transform.position = this.gameObject.transform.position;
                    
                    OnDenturePlaced.Invoke();
                }
            }
            else if (other.gameObject.GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() == null)
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                other.gameObject.transform.position = this.gameObject.transform.position;

                OnDenturePlaced.Invoke();
            }
        }
    }
}
