using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DropItemController : MonoBehaviour
{
    [SerializeField] private GrabInteractor[] grabInteractors;
    [SerializeField] private HandGrabInteractor[] handGrabInteractors;
    [SerializeField] private float interval = 10;
    [SerializeField] private float timer = 0;

    private void ActivateItemDrop()
    {
        foreach (GrabInteractor grabInteractor in grabInteractors)
        {
            grabInteractor.ForceRelease();
        }
        foreach (HandGrabInteractor handGrabInteractor in handGrabInteractors)
        {
            handGrabInteractor.ForceRelease();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            ActivateItemDrop();
            timer = interval;
        }
        else
            timer -= Time.deltaTime;
    }
}
