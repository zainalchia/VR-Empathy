using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Oculus.Interaction;

public class DoorKnob : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] bool canOpenDoor = false; // if true, player can open door anytime
    public UnityEvent OnDoorOpen;
    
    public void AllowDoorOpen() // call this if you want the door to be able to open after a scritped event
    {
        canOpenDoor = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        OnDoorOpen.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canOpenDoor)
        {
            if (other.gameObject.GetComponentInParent<GrabInteractor>() != null)
            {
                OnDoorOpen.Invoke();
                canOpenDoor = false;
            }
        }
    }
}
