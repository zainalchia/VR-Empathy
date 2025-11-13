using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class PlasterContainer : MonoBehaviour
{
    public UnityEvent OnContainerGrabbed; //event called when container is grabbed
    private bool hasGrabbed = false;
    private GrabInteractable grabInteractable;
    [SerializeField] private GameObject lidObject;

    private void Awake()
    {
        grabInteractable = GetComponent<GrabInteractable>(); //get grabInteractable
    }

    private void Start()
    {
        if (grabInteractable != null)
            grabInteractable.WhenSelectingInteractorViewAdded += OnGrabbed;
    }

    private void OnGrabbed(IInteractorView interactor)
    {
        // if container not yet grabbed and plaster use is allowed
        if (!hasGrabbed && GameManager.instance.toUsePlaster)
        {
            hasGrabbed = true;
            OnContainerGrabbed.Invoke(); //next event like open lid
        }
    }
}
