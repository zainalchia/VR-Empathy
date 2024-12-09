using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomPropOutline : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BathroomProp"))
        {
            gameObject.GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BathroomProp"))
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
