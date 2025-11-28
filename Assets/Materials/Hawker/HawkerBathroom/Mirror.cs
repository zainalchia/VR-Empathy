using UnityEngine;

public class VRMirror : MonoBehaviour
{
    [Header("References")]
    public Transform playerHead;      // VR head (CenterEyeAnchor)
    public Transform mirrorRoot;      // Mirror object (Y = 90°)
    public Transform mirrorCamera;    // Mirror camera (local X = -1)

    private float lockedLocalX;

    private void Awake()
    {
        if (mirrorCamera == null)
            mirrorCamera = transform;

        if (mirrorRoot == null && mirrorCamera != null)
            mirrorRoot = mirrorCamera.parent;

        lockedLocalX = mirrorCamera.localPosition.x; // should be -1
    }

    private void LateUpdate()
    {
        if (!playerHead || !mirrorRoot || !mirrorCamera)
            return;

        // ---------------------------------------------------------
        // 1. MIRRORED POSITION
        // ---------------------------------------------------------
        Vector3 localHeadPos = mirrorRoot.InverseTransformPoint(playerHead.position);

        // Mirror the Z axis (mirror operation)
        localHeadPos.z = -localHeadPos.z;

        // Lock X axis
        localHeadPos.x = lockedLocalX;

        // Apply
        mirrorCamera.localPosition = localHeadPos;

        // ---------------------------------------------------------
        // 2. MIRRORED ROTATION + 180 DEGREES
        // ---------------------------------------------------------
        // Mirror the forward
        Vector3 localForward = mirrorRoot.InverseTransformDirection(playerHead.forward);
        localForward.z = -localForward.z;

        Vector3 worldForward = mirrorRoot.TransformDirection(localForward);

        // Base mirrored orientation
        Quaternion baseRot = Quaternion.LookRotation(worldForward, Vector3.up);

        // Add 180 degrees rotation around Y
        Quaternion flippedRot = Quaternion.Euler(0f, 180f, 0f) * baseRot;

        mirrorCamera.rotation = flippedRot;
    }
}
