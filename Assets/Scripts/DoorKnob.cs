using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Oculus.Interaction;

public class DoorKnob : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] bool canOpenDoor = false;
    public UnityEvent OnDoorOpen;
    
    public void AllowDoorOpen()
    {
        canOpenDoor = true;
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
        if (canOpenDoor)
        {
            if (other.gameObject.transform.parent.gameObject.GetComponent<GrabInteractor>() != null)
            {
                OnDoorOpen.Invoke();
                canOpenDoor = false;
            }
        }
    }
}
