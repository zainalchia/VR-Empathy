using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toothpaste : MonoBehaviour
{
    bool hasBeenUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasBeenUsed) return;


        if (collision.gameObject.name == "Toothbrush")
        {
            bool haveToothpaste = false;
            bool haveToothbrush = false;
            foreach (GameObject go in ControllerInteractionsManager.instance.GetItemsGrabbedInHand())
            {
                if (go.name == this.gameObject.name)
                    haveToothpaste = true;
                else if (go.name == collision.gameObject.name)
                    haveToothbrush = true;
            }

            //if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(this.gameObject))
            if (haveToothpaste && haveToothbrush)
            {
                GetComponent<AudioSource>().Play();
                hasBeenUsed = true;
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                collision.gameObject.GetComponent<IObjectInteractable>().SetInteractive(true);
            }
        }
    }
}
