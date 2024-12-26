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

    [SerializeField]
    GameObject centerEyeAnchor;

    [SerializeField]
    float distanceRequired;

    bool beingLookedAt = false;
    float timer;
    bool eventHasBeenTrigerred = false;

    public void beingLookedAtTrigger(bool isbeinglooked)
    {
        beingLookedAt = isbeinglooked;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.toLookatPhotoFrame)
        {
            if(Vector3.Distance(centerEyeAnchor.transform.position, gameObject.transform.position) <= distanceRequired || centerEyeAnchor == null)
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
}
