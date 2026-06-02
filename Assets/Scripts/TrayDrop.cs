using Oculus.Interaction;
using UnityEngine;

public class TrayDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Only react to the tray
        if (other.CompareTag("Tray"))
        {
            other.transform.SetParent(null);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;

            other.GetComponent<ForceStayGrabbed>().SetForceGrabActive(false);
            other.GetComponent<Grabbable>().enabled = false;

            GameManager.instance.grabInteractors[1].ForceRelease();
            GameManager.instance.grabInteractors[0].ForceRelease();

        }
    }
}
