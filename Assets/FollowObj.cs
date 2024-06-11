using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObj : MonoBehaviour
{
    private Vector3 ownInitialPos;
    [SerializeField] Transform objToFollow;
    [SerializeField] bool lockYAxisTo0 = true;

    // Start is called before the first frame update
    void Start()
    {
        ownInitialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, objToFollow.transform.eulerAngles.y, 0);
        transform.position = objToFollow.transform.position - objToFollow.transform.forward * ownInitialPos.z;
        if (lockYAxisTo0)
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
