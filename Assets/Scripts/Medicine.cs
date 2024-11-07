using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Medicine : MonoBehaviour
{
    [SerializeField] GameObject otherMedicineBottle;
    [SerializeField] GameObject placeMedicineSpot;
    public UnityEvent OnGrabbedMedicine;
    public UnityEvent OnDroppedMedication;

    bool pickUpFirstTime = false;
    bool dropped = true;
    bool hasTriggeredEvent = false;

    void HasBeenPickUp()
    {
        if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(this.gameObject))
        {
            pickUpFirstTime = true;

            // change color here
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.green;
            this.gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = Color.green;
            otherMedicineBottle.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            otherMedicineBottle.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = Color.yellow;

            OnGrabbedMedicine.Invoke();
        }
    }

    void HasBeenDropped()
    {
        if (!ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(this.gameObject))
        {
            dropped = true;
        }
        else
        {
            dropped = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pickUpFirstTime)
        {
            HasBeenPickUp();
        }
        else if (!hasTriggeredEvent)
        {
            HasBeenDropped();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (pickUpFirstTime && dropped && !hasTriggeredEvent && other.gameObject == placeMedicineSpot)
        {
            hasTriggeredEvent = true;
            OnDroppedMedication.Invoke();
        }
    }
}
