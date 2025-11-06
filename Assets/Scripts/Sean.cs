using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sean : MonoBehaviour
{
    public UnityEvent OnGrab;

    private void OnTriggerEnter(Collider other)
    {
        OnGrab.Invoke();
    }
}
