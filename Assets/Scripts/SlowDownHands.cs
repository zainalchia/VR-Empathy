using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownHands : MonoBehaviour
{
    [SerializeField] private GameObject[] leftHandObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in leftHandObjects)
        {
            obj.transform.position = Vector3.zero;
        }
    }
}
