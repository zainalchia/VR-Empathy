using Oculus.Interaction;
using UnityEngine;

public class PhotoFrame_Negative : MonoBehaviour
{
    private Grabbable grabbable;
    [SerializeField] private GameObject grabPoint;

    private void Awake()
    {
        grabbable = GetComponent<Grabbable>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("LeftHand"))
        {
            grabPoint.transform.localPosition = new Vector3(0.1133f, -0.127f, -0.0045f);
        }
        else if (collision.CompareTag("RightHand"))
        {
            grabPoint.transform.localPosition = new Vector3(-0.1122f, -0.127f, -0.0045f);
        }
    }
}
