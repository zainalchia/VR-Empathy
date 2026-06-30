using UnityEngine;

public class FanBladeRotating : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;

    void Update()
    {
        transform.Rotate(rotationSpeed, 0, 0);
    }
}
