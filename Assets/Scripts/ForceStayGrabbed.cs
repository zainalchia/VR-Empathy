using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class ForceStayGrabbed : MonoBehaviour
{
    public bool active = false;
    public bool forceStay = false;

    private bool leftHandGrabbing = false;
    private bool rightHandGrabbing = false;

    private float grabTimeout = 3f; // seconds to wait before giving up if not held
    private float timeSinceGrabAttempt = 0f;

    public void SetActive(bool trueOrFalse)
    {
        active = trueOrFalse;

        if (!trueOrFalse)
        {
            ControllerInteractionsManager.instance.ActivateItemDrop();

            forceStay = false;
            leftHandGrabbing = false;
            rightHandGrabbing = false;
            timeSinceGrabAttempt = 0f;
        }
    }

    void Update()
    {
        if (!active)
            return;

        // Try to detect the initial grab
        if (!forceStay)
        {
            if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject))
            {
                int hand = ControllerInteractionsManager.instance.ObjInWhichHand(gameObject);
                if (hand == 0)
                    leftHandGrabbing = true;
                else if (hand == 1)
                    rightHandGrabbing = true;

                forceStay = true;
                timeSinceGrabAttempt = 0f;

                Debug.Log($"[ForceStayGrabbed] {gameObject.name} grabbed and locked in.");
            }
            else
            {
                timeSinceGrabAttempt += Time.deltaTime;
                if (timeSinceGrabAttempt > grabTimeout)
                {
                    Debug.LogWarning($"[ForceStayGrabbed] {gameObject.name} never grabbed. Deactivating.");
                    SetActive(false);
                }
            }
        }

        // Re-select if trigger is released and object dropped
        if (forceStay)
        {
            bool stillHeld = ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject);

            if (!stillHeld)
            {
                leftHandGrabbing = false;
                rightHandGrabbing = false;
                forceStay = false;
                timeSinceGrabAttempt = 0f;

                Debug.Log($"[ForceStayGrabbed] {gameObject.name} was dropped. Awaiting regrab.");
                return;
            }

            if (leftHandGrabbing && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(GetComponent<GrabInteractable>());
                Debug.Log($"[ForceStayGrabbed] Re-attaching {gameObject.name} to left hand.");
            }

            if (rightHandGrabbing && OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                ControllerInteractionsManager.instance.rightGrabInteractor.ForceSelect(GetComponent<GrabInteractable>());
                Debug.Log($"[ForceStayGrabbed] Re-attaching {gameObject.name} to right hand.");
            }
        }
    }
}




//using System.Collections;
//using System.Collections.Generic;
//using Oculus.Interaction;
//using Unity.VisualScripting;
//using UnityEngine;

//public class ForceStayGrabbed : MonoBehaviour
//{
//    public bool active = false;
//    public bool forceStay = false;
//    private bool leftHandGrabbing = false;
//    private bool rightHandGrabbing = false;

//    public void SetActive(bool trueOrFalse)
//    {
//        active = trueOrFalse;

//        if (trueOrFalse == false)
//        {
//            ControllerInteractionsManager.instance.ActivateItemDrop();
//            forceStay = false;
//            leftHandGrabbing = false;
//            rightHandGrabbing = false;
//        }
//    }

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (active)
//        {
//            if (forceStay == false)
//            {
//                if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject))
//                {
//                    if (ControllerInteractionsManager.instance.ObjInWhichHand(gameObject) == 0)
//                    {
//                        leftHandGrabbing = true;
//                    }
//                    else if (ControllerInteractionsManager.instance.ObjInWhichHand(gameObject) == 1)
//                    {
//                        rightHandGrabbing = true;
//                    }

//                    forceStay = true;
//                }
//            }            
//        }

//        if (forceStay && active)
//        {
//            if (leftHandGrabbing)
//            {
//                if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
//                {
//                    // force select left hand
//                    ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
//                }
//            }

//            if (rightHandGrabbing)
//            {
//                if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
//                {
//                    // force select right hand
//                    ControllerInteractionsManager.instance.rightGrabInteractor.ForceSelect(gameObject.GetComponent<GrabInteractable>());
//                }
//            }
//        }

//        /*
//        string debug = "";
//        foreach (GameObject go in ControllerInteractionsManager.instance.GetItemsGrabbedInHand())
//        {
//            debug += go.name;
//        }
//        GameManager.instance.DebugLog(active.ToString() + ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(gameObject).ToString() + forceStay.ToString() + ControllerInteractionsManager.instance.ObjInWhichHand(gameObject) +  leftHandGrabbing.ToString() + rightHandGrabbing.ToString() + debug);
//        */
//    }    
//}
