using UnityEngine;

public class CharacterMoverTest : MonoBehaviour
{
    float sensitivity = 0.1f;

    void Update()
    {
        Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        transform.Translate(new Vector3(thumbstickInput.x * sensitivity, 0, thumbstickInput.y * sensitivity));
    }
}
