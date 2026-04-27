using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAfterDistance : MonoBehaviour
{
    GrabInteractable interactable;
    float totalDistance;
    Vector3 positionLastFrame;

    [SerializeField] float distanceBeforeDrop;

    private void Awake()
    {
        interactable = GetComponent<GrabInteractable>();
        totalDistance = distanceBeforeDrop;
    }

    private void Update()
    {
        if (totalDistance < distanceBeforeDrop)
        {
            // add distance moved this frame
            totalDistance += (transform.position - positionLastFrame).magnitude;
            positionLastFrame = transform.position;            
        }
        else
        {
            if (GameManager.instance.grabInteractors[0].SelectedInteractable == interactable)
            {
                GameManager.instance.grabInteractors[0].ForceRelease();
                Instantiate(ControllerInteractionsManager.instance.dropItemFX, ControllerInteractionsManager.instance.leftHandAnchor.transform); // particle fx                
            }
            if (GameManager.instance.grabInteractors[1].SelectedInteractable == interactable)
            {
                GameManager.instance.grabInteractors[1].ForceRelease();
                Instantiate(ControllerInteractionsManager.instance.dropItemFX, ControllerInteractionsManager.instance.rightHandAnchor.transform); // particle fx
            }

            // play specs drop sound
            if(gameObject.GetComponent<AudioSource>())
                gameObject.GetComponent<AudioSource>().Play();  

            Activate();
        }
    }

    public void Activate()
    {
        totalDistance = 0;
    }
}
