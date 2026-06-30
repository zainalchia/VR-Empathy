using UnityEngine;

public class FanRotator : MonoBehaviour
{
    [SerializeField] float RotationSpeed = 5f;
    [SerializeField] float AngleOfRotation = 25f;
    [SerializeField] float From;

    void Update()
    {
        float rZ = Mathf.SmoothStep(From, From + AngleOfRotation, Mathf.PingPong(Time.time * RotationSpeed, 1));
        transform.rotation = Quaternion.Euler(-90, 0, rZ);
    }
}
