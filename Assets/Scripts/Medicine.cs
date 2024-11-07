using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Medicine : MonoBehaviour
{
    [SerializeField] GameObject otherMedicineBottle;
    public UnityEvent OnGrabbedMedicine;
    public UnityEvent OnDroppedMedication;

    bool pickUpFirstTime = false;
    bool droppedFirstTime = false;

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
            droppedFirstTime = true;

            // play drop animation here
            

            //OnDroppedMedication.Invoke();

            
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
        else if (!droppedFirstTime)
        {
            HasBeenDropped();
        }

    }
}
