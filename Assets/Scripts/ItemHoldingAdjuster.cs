using UnityEngine;

public class ItemHoldingAdjuster : MonoBehaviour
{
    [SerializeField] GameObject grabPoint;

    [Header("Left Hand Pose")]
    [SerializeField] float lefthandXPosition;
    [SerializeField] float lefthandYPosition;
    [SerializeField] float lefthandZPosition;

    [Header("Left Hand Rotation")]
    [SerializeField] float lefthandXRotation;
    [SerializeField] float lefthandYRotation;
    [SerializeField] float lefthandZRotation;

    [Header("Right Hand Pose")]
    [SerializeField] float righthandXPosition;
    [SerializeField] float righthandYPosition;
    [SerializeField] float righthandZPosition;

    [Header("Right Hand Rotation")]
    [SerializeField] float righthandXRotation;
    [SerializeField] float righthandYRotation;
    [SerializeField] float righthandZRotation;

    private bool leftTouching = false;
    private bool rightTouching = false;

    private void Update()
    {
        // If both hands touch, average the two poses
        if (leftTouching && rightTouching)
        {
            Vector3 avgPos = new Vector3(
                (lefthandXPosition + righthandXPosition) * 0.5f,
                (lefthandYPosition + righthandYPosition) * 0.5f,
                (lefthandZPosition + righthandZPosition) * 0.5f
            );

            Vector3 avgRot = new Vector3(
                (lefthandXRotation + righthandXRotation) * 0.5f,
                (lefthandYRotation + righthandYRotation) * 0.5f,
                (lefthandZRotation + righthandZRotation) * 0.5f
            );

            grabPoint.transform.localPosition = avgPos;
            grabPoint.transform.localEulerAngles = avgRot;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("LeftHand"))
        {
            leftTouching = true;

            if (!rightTouching)
            {
                grabPoint.transform.localPosition =
                    new Vector3(lefthandXPosition, lefthandYPosition, lefthandZPosition);

                grabPoint.transform.localEulerAngles =
                    new Vector3(lefthandXRotation, lefthandYRotation, lefthandZRotation);
            }
        }
        else if (collision.CompareTag("RightHand"))
        {
            rightTouching = true;

            if (!leftTouching)
            {
                grabPoint.transform.localPosition =
                    new Vector3(righthandXPosition, righthandYPosition, righthandZPosition);

                grabPoint.transform.localEulerAngles =
                    new Vector3(righthandXRotation, righthandYRotation, righthandZRotation);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("LeftHand")) leftTouching = false;
        if (collision.CompareTag("RightHand")) rightTouching = false;
    }
}
