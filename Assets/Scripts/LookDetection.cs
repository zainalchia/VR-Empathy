using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDetection : MonoBehaviour
{
    [SerializeField] string tagName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootRay();
    }
    void ShootRay()
    {
        float length = 10.0f;
        RaycastHit hit;
        Vector3 rayDirection = gameObject.transform.TransformDirection(Vector3.forward);
        Vector3 rayStart = gameObject.transform.position + rayDirection;     // Start the ray away from the player to avoid hitting itself
        Debug.DrawRay(rayStart, rayDirection * length, Color.green);
        if (Physics.Raycast(rayStart, rayDirection, out hit, length))
        {
            print(hit.collider.name);
            if (hit.collider.tag == tagName)
            {
                print("Hit object");

                gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
