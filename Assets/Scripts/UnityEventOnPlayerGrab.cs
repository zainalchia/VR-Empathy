using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnPlayerGrab : MonoBehaviour
{
    private bool grabbed = false;
    public UnityEvent OnGrab;

    void Update()
    {
        if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject) && grabbed == false)
        {
            OnGrab?.Invoke();
            grabbed = true;
        }
    }
}
