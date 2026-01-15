using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class SinkTap : MonoBehaviour
{
    [SerializeField] GameObject water;
    bool waterIsOn = true;
    bool canInteract = true;
    [SerializeField] GameObject handle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            TurnHandle();
        }
    }

    private void TurnHandle()
    {
        float desiredRotation; 

        if (waterIsOn) 
        {
            desiredRotation = 30f;
        }
        else
        {
            desiredRotation = 0f;
        }
        float rY = Mathf.Lerp(handle.transform.localRotation.y, desiredRotation, 1f);
        handle.transform.localRotation = Quaternion.Euler(0, rY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canInteract) return;

        //if (other.gameObject.GetComponentInParent<GrabInteractor>() != null) // when touched by hand
        //{
            if (waterIsOn)
            {
                waterIsOn = false;
                water.SetActive(false);
            }
            else
            {
                waterIsOn = true;
                water.SetActive(true);
            }
            TurnHandle();
            canInteract = false;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (canInteract) return;

        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null)
        {
            canInteract = true;
        }
    }
}
