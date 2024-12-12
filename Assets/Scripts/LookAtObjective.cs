using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookAtObjective : MonoBehaviour
{
    [SerializeField]
    float timeToLook;

    [SerializeField]
    UnityEvent lookedAtComplete;

    bool beingLookedAt = false;
    float timer;
    bool eventHasBeenTrigerred = false;
    bool held = false;

    public void beingLookedAtTrigger(bool isbeinglooked)
    {
        beingLookedAt = isbeinglooked;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.toLookatPhotoFrame)
        {
            if (held)
            {
                if (beingLookedAt)
                {
                    if (timer < timeToLook)
                    {
                        timer += Time.deltaTime;
                    }
                    else
                    {
                        if (!eventHasBeenTrigerred)
                        {
                            lookedAtComplete.Invoke();
                            eventHasBeenTrigerred = true;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(this.gameObject.transform.parent.gameObject))// check if holding phone
        {
            held = true;
        } 

    }
}
