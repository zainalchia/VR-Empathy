using UnityEngine;

public class SmoothPivotRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Vector3 targetEulerAngles = Vector3.zero;
    public float rotationSpeed = 2f;

    [Header("Auto Return Settings")]
    public bool autoReturn = false;
    public float returnDelay = 3f;

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    public bool isRotating = false;
    private bool returning = false;

    void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(targetEulerAngles);
    }

    void Update()
    {
        if (!isRotating)
            return;

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        float angleDiff = Quaternion.Angle(transform.rotation, targetRotation);
        if (angleDiff < 0.1f)
        {
            transform.rotation = targetRotation;
            isRotating = false;

            // If we just finished the forward rotation and autoReturn is on
            if (autoReturn && !returning)
                Invoke(nameof(ReturnToInitialRotation), returnDelay);
        }
    }

    public void StartDefaultRotation()
    {
        StartRotationTo(targetEulerAngles);
    }

    public void StartRotationTo(Vector3 eulerAngles)
    {
        initialRotation = transform.rotation; // Update in case object was rotated elsewhere
        targetRotation = Quaternion.Euler(eulerAngles);
        isRotating = true;
        returning = false;
    }

    public void ReturnToInitialRotation()
    {
        targetRotation = initialRotation;
        isRotating = true;
        returning = true;
    }

    public void StopRotation()
    {
        isRotating = false;
        CancelInvoke(nameof(ReturnToInitialRotation));
    }
}
