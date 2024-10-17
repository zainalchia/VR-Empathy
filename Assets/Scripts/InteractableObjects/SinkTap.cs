using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class SinkTap : MonoBehaviour
{
    [SerializeField] GameObject water;
    bool waterIsOn = false;
    bool canInteract = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canInteract) return;

        if (other.gameObject.transform.parent.gameObject.GetComponent<GrabInteractor>() != null)
        {
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
            canInteract = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (canInteract) return;

        if (other.gameObject.transform.parent.gameObject.GetComponent<GrabInteractor>() != null)
        {
            canInteract = true;
        }
    }
}
