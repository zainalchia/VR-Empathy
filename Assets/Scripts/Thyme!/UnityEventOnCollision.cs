using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnCollision : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;

    private void OnTriggerEnter(Collider other)
    {
        unityEvent.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        unityEvent.Invoke();
    }
}
