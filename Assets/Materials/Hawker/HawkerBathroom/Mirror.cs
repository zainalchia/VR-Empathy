using UnityEngine;

public class VRMirror : MonoBehaviour
{
    [Header("References")]
    public Transform playerHead;      // VR head (CenterEyeAnchor)
    public Transform mirrorRoot;      // Mirror object (Y = 90°)
    public Transform mirrorCamera;    // Mirror camera (local X = -1)

    [Header("Movement Limits")]
    public float maxYOffset = 0.5f;   // max local Y movement allowed
    public float maxZOffset = 0.5f;   // max local Z movement allowed

    [Header("Rotation Limits")]
    public float minXRotation = -20f; // lowest tilt allowed
    public float maxXRotation = 20f;  // highest tilt allowed

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

        // Mirror Z axis
        localHeadPos.z = -localHeadPos.z;

        // Lock X axis
        localHeadPos.x = lockedLocalX;

        // Apply movement limits
        localHeadPos.y = Mathf.Clamp(localHeadPos.y, -maxYOffset, maxYOffset);
        localHeadPos.z = Mathf.Clamp(localHeadPos.z, -maxZOffset, maxZOffset);

        mirrorCamera.localPosition = localHeadPos;

        // ---------------------------------------------------------
        // 2. MIRRORED ROTATION + 180 DEGREES
        // ---------------------------------------------------------
        Vector3 localForward = mirrorRoot.InverseTransformDirection(playerHead.forward);
        localForward.z = -localForward.z;

        Vector3 worldForward = mirrorRoot.TransformDirection(localForward);

        Quaternion baseRot = Quaternion.LookRotation(worldForward, Vector3.up);
        Quaternion flippedRot = Quaternion.Euler(0f, 180f, 0f) * baseRot;

        // ---------------------------------------------------------
        // 3. CLAMP X ROTATION OF MIRROR CAMERA
        // ---------------------------------------------------------
        Vector3 euler = flippedRot.eulerAngles;

        // Convert wrapping angles to signed (-180 to 180)
        if (euler.x > 180f) euler.x -= 360f;

        // Clamp X
        euler.x = Mathf.Clamp(euler.x, minXRotation, maxXRotation);

        mirrorCamera.rotation = Quaternion.Euler(euler.x, euler.y, euler.z);
    }
}
