using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class MedicineBottle : MonoBehaviour
{
    public UnityEvent OnBottleGrabbed;   // Fired when bottle actually grabbed

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered &&
            other.GetComponentInParent<GrabInteractor>() &&
            GameManager.instance.toConsumeMedicine)
        {
            hasTriggered = true;
            OnBottleGrabbed.Invoke();
        }
    }
}
