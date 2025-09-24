using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class PhotoFrame : MonoBehaviour
{
    public UnityEvent OnFrameGrabbed;
    private bool hasGrabbed = false;

    private Grabbable grabbable;

    private void Awake()
    {
        grabbable = GetComponent<Grabbable>();
    }

    private void Update()
    {
        //check if grabbing photo is active 
        if (!hasGrabbed &&
            GameManager.instance.toLookAtObjective && grabbable != null &&
            grabbable.SelectingPointsCount > 0) //player currently grabbing
        {
            hasGrabbed = true;
            OnFrameGrabbed.Invoke(); //trigger next event
        }
    }
}
