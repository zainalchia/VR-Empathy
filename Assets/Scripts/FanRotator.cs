using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotator : MonoBehaviour
{
    [SerializeField]
    float RotationSpeed = 5f; // Speed of the rotation

    [SerializeField]
    float AngleOfRotation = 25f; // Angle of your rotation that you want

    [SerializeField]
    float From; // The current Z rotation

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rZ = Mathf.SmoothStep(From, From+AngleOfRotation, Mathf.PingPong(Time.time * RotationSpeed, 1));
        transform.rotation = Quaternion.Euler(-90, 0, rZ);
    }
}
