using UnityEngine;

public class TissueBoxSpawner : MonoBehaviour
{
    [Header("Tissue")]
    public GameObject tissueObject; // already placed in scene
    public Transform leftHandAttach;
    public Transform rightHandAttach;

    private bool leftHandTouching;
    private bool rightHandTouching;
    private bool hasGivenTissue = false;

    void Start()
    {
        // Ensure tissue is initially disabled
        if (tissueObject != null)
            tissueObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand"))
            leftHandTouching = true;

        if (other.CompareTag("RightHand"))
            rightHandTouching = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LeftHand"))
            leftHandTouching = false;

        if (other.CompareTag("RightHand"))
            rightHandTouching = false;
    }

    void Update()
    {
        if (hasGivenTissue || tissueObject == null)
            return;

        bool leftTrigger =
            OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.2f;

        bool rightTrigger =
            OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.2f;

        if (leftHandTouching && leftTrigger)
        {
            GiveTissue(leftHandAttach);
        }
        else if (rightHandTouching && rightTrigger)
        {
            GiveTissue(rightHandAttach);
        }
    }

    void GiveTissue(Transform handAttach)
    {
        hasGivenTissue = true;

        // Enable tissue object and parent it to hand
        tissueObject.SetActive(true);
        tissueObject.transform.SetParent(handAttach);
        tissueObject.transform.localPosition = Vector3.zero;
        tissueObject.transform.localRotation = Quaternion.identity;
    }
}
