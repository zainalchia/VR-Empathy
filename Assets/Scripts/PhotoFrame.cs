using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class PhotoFrame : MonoBehaviour
{
    public UnityEvent OnFrameGrabbed;
    private bool hasGrabbed = false;

    private Grabbable grabbable;

    [SerializeField] GameObject grabPoint;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "LeftHand")
        {
            grabPoint.transform.localPosition = new Vector3(0.1133f, -0.127f, -0.0045f);
        }
        else if (collision.gameObject.tag == "RightHand")
        {
            grabPoint.transform.localPosition = new Vector3(-0.1122f, -0.127f, -0.0045f);


        }
    }

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
