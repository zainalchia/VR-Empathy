using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeChopDetector : MonoBehaviour
{
    public ChickenChopManager chopManager;

    private void OnTriggerEnter(Collider other)
    {
        // check if knife hit chicken collider
        if (other.CompareTag("MeatPiece"))
        {
            //detach next chicken pieces and show red lines
            chopManager.OnKnifeHit();
        }
    }
}


