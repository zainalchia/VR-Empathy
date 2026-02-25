using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnPlayerGrab : MonoBehaviour
{
    private bool grabbed = false;
    public UnityEvent OnGrab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject) && grabbed == false)
        {
            OnGrab?.Invoke();
            grabbed = true;
        }
    }
}
