using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class Sean : MonoBehaviour
{
    public UnityEvent OnGrab;
    bool PlayOnce = true;
    //[SerializeField] TMP_Text debugText;

    // testing
    private bool LTouching;
    private bool RTouching;
    private bool Holding;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeftHand")
            LTouching = true;
        if (other.gameObject.tag == "RightHand")
            RTouching = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //LTouching = RTouching = false;
        if (other.gameObject.tag == "LeftHand")
            LTouching = false;
        if (other.gameObject.tag == "RightHand")
            RTouching = false;

    }

    private void Update()
    {
        bool LTriggerPressed = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.2f;
        bool RTriggerPressed = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.2f;
        //debugText.text = Holding.ToString();


        if (LTouching && RTouching && LTriggerPressed && RTriggerPressed)
        {
            Holding = true;
            GameManager.instance.grabInteractors[1].ForceSelect(gameObject.GetComponent<GrabInteractable>());
            if (PlayOnce)
            {
                OnGrab.Invoke();
                PlayOnce = false;
            }
        }


        if (!LTouching || !RTouching || !LTriggerPressed || !RTriggerPressed)
        {
            Holding = false;
            GameManager.instance.grabInteractors[1].ForceRelease();
        }

        GetComponent<Grabbable>().enabled = GetComponent<PhysicsGrabbable>().enabled = GetComponent<GrabInteractable>().enabled = Holding;

        GetComponent<Rigidbody>().isKinematic = Holding;
        GetComponent<Rigidbody>().useGravity = !Holding;
    }
}
