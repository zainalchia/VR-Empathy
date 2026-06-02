using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class MicController : MonoBehaviour
{
    //public bool toBeginKaraokeMinigame = false; // set this to true when karaoke game is to begin
    //public bool active = false;
    //public bool micOnFace = false;

    //public UnityEvent OnMicPickUp;
    //public UnityEvent OnMicOnFace;
    ////public UnityEvent OnMicNotOnFace;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (toBeginKaraokeMinigame && !active)
    //    {
    //        // touching the mic will trigger this
    //        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null)
    //        {
    //            GameManager.instance.HideAlert(); // hides narration text
    //            //GameManager.instance.ShowAlert("[Put mic to face]");
    //            GetComponent<Outline>().enabled = false;
    //            SetMicDetectionActive(true);
    //            toBeginKaraokeMinigame = false;
    //            GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
    //            OnMicPickUp.Invoke();
    //        }
    //    }

    //    if (active)
    //    {
    //        //if (other.gameObject.name == "CenterEyeAnchor")
    //        //{
    //            micOnFace = true;
    //            OnMicOnFace.Invoke();
    //        //}
    //    }
    //}

    ////private void OnTriggerExit(Collider other)
    ////{
    ////    if (active)
    ////    {
    ////        if (other.gameObject.name == "CenterEyeAnchor")
    ////        {
    ////            micOnFace = false;
    ////            OnMicNotOnFace.Invoke();
    ////        }
    ////    }
    ////}

    //public void SetMicDetectionActive(bool trueOrFalse)
    //{
    //    active = trueOrFalse;
    //    GameManager.instance.centerEyeAnchor.GetComponent<SphereCollider>().enabled = trueOrFalse;

    //    // disable in view detector
    //    GameManager.instance.centerEyeAnchor.GetComponent<CapsuleCollider>().enabled = !trueOrFalse;
    //    GameManager.instance.centerEyeAnchor.GetComponent<InViewDetector>().enabled = !trueOrFalse;

    //    // disable isKinematic to disable the floating in mid air
    //    gameObject.GetComponent<Rigidbody>().isKinematic = !trueOrFalse;
    //    gameObject.GetComponent<Rigidbody>().useGravity = !trueOrFalse;

    //    // disable isTrigger
    //    gameObject.GetComponent<BoxCollider>().isTrigger = !trueOrFalse;

    //    // enable grabbables
    //    SetGrabbableScripts(trueOrFalse);        
    //}

    //public void SetGrabbableScripts(bool trueOrFalse)
    //{
    //    gameObject.GetComponent<Grabbable>().enabled = trueOrFalse;
    //    gameObject.GetComponent<GrabInteractable>().enabled = trueOrFalse;
    //    gameObject.GetComponent<PhysicsGrabbable>().enabled = trueOrFalse;
    //}
}
