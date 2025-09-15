using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class MedicineBottle : MonoBehaviour
{
    public UnityEvent OnBottleGrabbed;
    private bool hasGrabbed = false;

    private Grabbable grabbable;
    [SerializeField] private GameObject capObject; 

    private void Awake()
    {
        grabbable = GetComponent<Grabbable>();
    }

    private void Update()
    {
        if (!hasGrabbed &&
            GameManager.instance.toConsumeMedicine &&
            grabbable != null &&
            grabbable.SelectingPointsCount > 0) 
        {
            hasGrabbed = true;
            OnBottleGrabbed.Invoke(); 
        }
    }
}
