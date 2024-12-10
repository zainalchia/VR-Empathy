using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericToiletries : MonoBehaviour, IObjectInteractable
{
    // currently used on: Toothbrush, Mouthwash
    [SerializeField] bool canInteract = false;
    public UnityEvent OnInteractEvent;

    public void OnInteract()
    {
        OnInteractEvent.Invoke();
    }

    public void SetInteractive(bool trueOrFalse)
    {
        canInteract = trueOrFalse;
    }

    public bool ShouldInteractWithFace()
    {
        return canInteract;
    }    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
