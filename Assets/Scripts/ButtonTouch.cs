using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTouch : MonoBehaviour
{
    public UnityEvent ButtonTouched;

    private void OnTriggerEnter(Collider other)
    {
        ButtonTouched.Invoke();
        this.gameObject.SetActive(false);
    }
}
