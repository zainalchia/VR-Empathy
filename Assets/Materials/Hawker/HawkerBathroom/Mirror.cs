using UnityEngine;

public class VRMirror : MonoBehaviour
{
    [Header("References")]
    public Transform playerHead;      // VR head (CenterEyeAnchor)
    public Transform mirrorRoot;      // Mirror object (Y = 90°)
    public Transform mirrorCamera;    // Mirror camera (local X = -1)

    [Header("Movement Limits")]
    public float maxYOffset = 0.5f;
    public float maxZOffset = 0.5f;

    [Header("Rotation Limits")]
    public float minXRotation = -20f;
    public float maxXRotation = 20f;

    public float minYRotation = -30f;     // new
    public float maxYRotation = 30f;      // new

    private float lockedLocalX;

    private void Awake()
    {
        if (mirrorCamera == null)
            mirrorCamera = transform;

        if (mirrorRoot == null && mirrorCamera != null)
            mirrorRoot = mirrorCamera.parent;

        lockedLocalX = mirrorCamera.localPosition.x;
    }

    private void LateUpdate()
    {
        if (!playerHead || !mirrorRoot || !mirrorCamera)
            return;

        // ---------------------------------------------------------
        // 1. MIRRORED POSITION
        // ---------------------------------------------------------
        Vector3 localHeadPos = mirrorRoot.InverseTransformPoint(playerHead.position);

        localHeadPos.z = -localHeadPos.z;
        localHeadPos.x = lockedLocalX;

        localHeadPos.y = Mathf.Clamp(localHeadPos.y, -maxYOffset, maxYOffset);
        localHeadPos.z = Mathf.Clamp(localHeadPos.z, -maxZOffset, maxZOffset);

        mirrorCamera.localPosition = localHeadPos;

        // ---------------------------------------------------------
        // 2. MIRRORED ROTATION + 180
        // ---------------------------------------------------------
        Vector3 localForward = mirrorRoot.InverseTransformDirection(playerHead.forward);
        localForward.z = -localForward.z;

        Vector3 worldForward = mirrorRoot.TransformDirection(localForward);

        Quaternion baseRot = Quaternion.LookRotation(worldForward, Vector3.up);
        Quaternion flippedRot = Quaternion.Euler(0f, 180f, 0f) * baseRot;

        // ---------------------------------------------------------
        // 3. CLAMP X + Y ROTATION
        // ---------------------------------------------------------
        Vector3 euler = flippedRot.eulerAngles;

        // unwrap angles
        if (euler.x > 180f) euler.x -= 360f;
        if (euler.y > 180f) euler.y -= 360f;

        // clamp X tilt
        euler.x = Mathf.Clamp(euler.x, minXRotation, maxXRotation);

        // clamp Y turn
        euler.y = Mathf.Clamp(euler.y, minYRotation, maxYRotation);

        mirrorCamera.rotation = Quaternion.Euler(euler.x, euler.y, euler.z);
    }
}
