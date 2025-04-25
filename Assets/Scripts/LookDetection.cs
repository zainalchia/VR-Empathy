using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LookDetection : MonoBehaviour
{
    [SerializeField] string tagName;

    public UnityEvent HitResponse;

    bool hitTarget = false;

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
        float length = 50.0f;
        RaycastHit hit;
        Vector3 rayDirection = gameObject.transform.TransformDirection(Vector3.forward);
        Vector3 rayStart = gameObject.transform.position + rayDirection;  // Start the ray away from the player to avoid hitting itself
        rayStart.y = rayStart.y + 0.5f;
        Debug.DrawRay(rayStart, rayDirection * length, Color.green);
        if (Physics.Raycast(rayStart, rayDirection, out hit, length))
        {
            print(hit.collider.name);
            if (hit.collider.tag == tagName)
            {
                print("Hit object");

                hit.collider.gameObject.GetComponent<Outline>().enabled = false;

                if(!hitTarget) // ensures hit response is only triggered once
                {
                    hitTarget = true;
                    HitResponse.Invoke();
                }
            }
        }
    }

}
