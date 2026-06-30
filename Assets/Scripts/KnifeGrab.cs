using UnityEngine;
using Oculus.Interaction;

public class KnifeGrab : MonoBehaviour
{
    public ChickenChopManager chopManager;
    [SerializeField] private ForceStayGrabbed forceStayGrabbed;
    private Grabbable grabbable;
    [SerializeField] GameObject chopper;

    private void Awake()
    {
        grabbable = GetComponent<Grabbable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand") && grabbable.SelectingPointsCount == 0)
        {
            chopper.GetComponent<Grabbable>().enabled = false;
            chopper.GetComponent<GrabInteractable>().enabled = false;
            grabbable.enabled = false;
        }
        else if (other.CompareTag("RightHand"))
        {
            chopper.GetComponent<Grabbable>().enabled = true;
            chopper.GetComponent<GrabInteractable>().enabled = true;
            grabbable.enabled = true;
        }
    }
}
