using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnCollision : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;
    [SerializeField] GameObject[] whitelist;

    private void OnTriggerEnter(Collider other)
    {
        // check whitelist, if there is one 
        if((whitelist != null) || (whitelist.Length != 0))
            if (!whitelist.Contains(other.gameObject)) return;

        unityEvent.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {   
        // check whitelist, if there is one 
        if ((whitelist != null) || (whitelist.Length != 0))
            if (!whitelist.Contains(collision.gameObject)) return;

        unityEvent.Invoke();
    }
}
