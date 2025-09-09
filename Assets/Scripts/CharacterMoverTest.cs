using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoverTest : MonoBehaviour
{
    float sensitivity = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // returns a Vector2 of the primary (typically the Left) thumbstick?s current state.
        // (X/Y range of -1.0f to 1.0f)
        Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        transform.Translate(new Vector3(thumbstickInput.x * sensitivity, 0, thumbstickInput.y * sensitivity));
    }
}
