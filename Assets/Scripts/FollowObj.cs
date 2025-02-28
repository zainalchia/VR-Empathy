using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObj : MonoBehaviour
{
    Vector3 initialPos;
    Quaternion initialRot;
    [SerializeField] Transform objToFollow;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = initialRot * objToFollow.transform.rotation;
        transform.position = initialPos + objToFollow.transform.position;
    }
}
