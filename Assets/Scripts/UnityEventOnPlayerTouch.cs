using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnPlayerTouch : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null)
        {
            unityEvent.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<GrabInteractor>() != null)
        {
            unityEvent.Invoke();
        }
    }
}
