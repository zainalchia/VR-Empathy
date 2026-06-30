using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class Medicine : MonoBehaviour
{
    public UnityEvent OnDroppedMedication;

    bool canPickUp = false;
    bool hasTriggeredEvent = false;

    public void SetPickUp()
    {
        canPickUp = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggeredEvent && other.gameObject.GetComponentInParent<GrabInteractor>() && canPickUp)
        {
            GameManager.instance.flag = false;
            hasTriggeredEvent = true;
            OnDroppedMedication.Invoke();
        }
    }
}
