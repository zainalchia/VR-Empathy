using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesTeleporter : MonoBehaviour
{
    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if glasses drop to a height below the table height, it will teleport back to initial pos
        if (transform.position.y < 0.6f)
        {
            transform.position = initPos + (Vector3.up * 0.1f);
        }
    }
}
