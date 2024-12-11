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

    public void beingLookedAtTrigger(bool isbeinglooked)
    {
        beingLookedAt = isbeinglooked;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.toLookatPhotoFrame)
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
                        gameObject.SetActive(false);
                        eventHasBeenTrigerred = true;
                    }
                }
            }
        }
    }
}
