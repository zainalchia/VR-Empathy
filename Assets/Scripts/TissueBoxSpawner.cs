using UnityEngine;

public class TissueBoxSpawner : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject tissuePrefab;
    public Transform leftHandAttach;
    public Transform rightHandAttach;

    private bool leftHandTouching;
    private bool rightHandTouching;
    private bool hasGivenTissue = false;

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
        if (hasGivenTissue)
            return;

        bool leftTrigger =
            OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.2f;

        bool rightTrigger =
            OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.2f;

        // Left hand gets tissue
        if (leftHandTouching && leftTrigger)
        {
            GiveTissue(leftHandAttach);
        }
        // Right hand gets tissue
        else if (rightHandTouching && rightTrigger)
        {
            GiveTissue(rightHandAttach);
        }
    }

    void GiveTissue(Transform handAttach)
    {
        hasGivenTissue = true;

        GameObject tissue = Instantiate(
            tissuePrefab,
            handAttach.position,
            handAttach.rotation
        );

        tissue.transform.SetParent(handAttach);
        tissue.transform.localPosition = Vector3.zero;
        tissue.transform.localRotation = Quaternion.identity;
    }
}
