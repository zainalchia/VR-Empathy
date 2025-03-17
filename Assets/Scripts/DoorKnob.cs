using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Oculus.Interaction;

public class DoorKnob : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] GameObject DoorHandle;
    [SerializeField] bool canOpenDoor = false; // if true, player can open door anytime
    [SerializeField] AudioSource GateOpenSource;
    public UnityEvent OnDoorOpen;

    public enum DoorType
    {
        Door,
        Gate
    }

    public DoorType type;
    
    public void AllowDoorOpen() // call this if you want the door to be able to open after a scritped event
    {
        canOpenDoor = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(type == DoorType.Gate)
        {
            GetComponent<Collider>().enabled = false;
        }
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
                if(type == DoorType.Door) OnDoorOpen.Invoke();
                if(type == DoorType.Gate) StartCoroutine(DoorOpen());
                canOpenDoor = false;
            }
        }
    }

    IEnumerator DoorOpen()
    {
        transform.GetComponent<Outline>().enabled = false; // hides gate handle outline

        if (AlertTextController.instance) // hide alert text
        {
            if (AlertTextController.instance.gameObject.activeInHierarchy)
                AlertTextController.instance.SetInactive();
        }

        DoorHandle.GetComponent<Animator>().SetTrigger("HandleOpen");

        yield return new WaitForSeconds(0.7f);

        Door.GetComponent<Animator>().SetTrigger("OpenGate");
        GateOpenSource.Play();

        yield return new WaitForSeconds(0.7f);

        DoorHandle.GetComponent<Animator>().SetTrigger("HandleClose");

        yield return new WaitForSeconds(0.7f);

        OnDoorOpen.Invoke();
    }

}
