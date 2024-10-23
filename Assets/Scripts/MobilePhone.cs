using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobilePhone : MonoBehaviour
{
    public UnityEvent OnAnswerPhone;


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
        if (GameManager.instance.canAnswerPhone)
        {
            if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(this.gameObject)) // check if holding phone
            {
                if (other.gameObject.GetComponentInParent<GrabInteractor>() != null) // check if collider that touch was a hand
                {
                    if (!this.gameObject.GetComponentInParent<GrabInteractable>().HasSelectingInteractor(other.gameObject.GetComponentInParent<GrabInteractor>())) // check if collider that touch was the hand that is not holding the phone
                    {
                        GameManager.instance.canAnswerPhone = false;
                        OnAnswerPhone.Invoke();
                    }
                }
            }
        }
    }
}
