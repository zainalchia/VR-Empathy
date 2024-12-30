using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnimSpeed : MonoBehaviour
{
    [Range(0f, 1f)]
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
