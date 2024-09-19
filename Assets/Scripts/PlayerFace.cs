using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFace : MonoBehaviour
{
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
        if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(other.gameObject)) // checks if it is held in hand
            MinigameManager.instance.EatMedication(other.gameObject);
    }
}
