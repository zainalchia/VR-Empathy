using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction;
using TMPro;

public class GrabItemController : MonoBehaviour
{
    [SerializeField] TextMeshPro debugText;

    public List<GameObject> GetItemsGrabbedInHand()
    {
        List<GameObject> items = new List<GameObject>();
        
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.HasSelectedInteractable)
            {
                if (!items.Contains(grabInteractor.SelectedInteractable.gameObject)) // in case both hands are holding the same item
                    items.Add(grabInteractor.SelectedInteractable.gameObject);
            }
        }

        return items;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two)) // debugging delete soon
        {
            debugText.text = string.Empty;
            foreach (GameObject item in GetItemsGrabbedInHand())
            {
                debugText.text += item.name;
            }
        }
    }
}
