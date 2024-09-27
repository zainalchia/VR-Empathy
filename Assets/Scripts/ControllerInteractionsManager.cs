using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction;
using Oculus.Interaction.Input;

public class ControllerInteractionsManager : MonoBehaviour
{
    #region Singleton Stuff
    public static ControllerInteractionsManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }
    #endregion

    #region Grabbing Items
    private List<GrabInteractor> grabInteractorsWithinRange = new List<GrabInteractor>();
    bool canTakeOffGlasses = false;
    bool toReleaseLeftHand = false;
    bool toReleaseRightHand = false;

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

    // for glasses
    public void CanTakeOffGlasses(GrabInteractor addGrabInteractor)
    {
        if (!grabInteractorsWithinRange.Contains(addGrabInteractor))
        {
            grabInteractorsWithinRange.Add(addGrabInteractor);
            canTakeOffGlasses = true;
        }
    }
    public void CannotTakeOffGlasses(GrabInteractor removeGrabInteractor)
    {
        if (grabInteractorsWithinRange.Contains(removeGrabInteractor))
            grabInteractorsWithinRange.Remove(removeGrabInteractor);

        if (grabInteractorsWithinRange.Count == 0)
            canTakeOffGlasses = false;
    }
    void RemoveGlasses(OVRInput.Controller controllerSide)
    {
        foreach (GrabInteractor grabInteractorWithinRange in grabInteractorsWithinRange)
        {
            if ((controllerSide == OVRInput.Controller.LTouch && grabInteractorWithinRange.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Left))
            {
                canTakeOffGlasses = false;
                GameManager.instance.glasses.transform.position = grabInteractorWithinRange.gameObject.transform.position;
                GameManager.instance.TakeOffGlasses();
                grabInteractorWithinRange.ForceSelect(GameManager.instance.glasses.GetComponent<GrabInteractable>());
                GameManager.instance.glasses.GetComponent<Rigidbody>().useGravity = true;
                toReleaseLeftHand = true;
                GameManager.instance.toTakeGlassesOff = false;
            }
            else if (controllerSide == OVRInput.Controller.RTouch && grabInteractorWithinRange.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Right)
            {
                canTakeOffGlasses = false;
                GameManager.instance.glasses.transform.position = grabInteractorWithinRange.gameObject.transform.position;
                GameManager.instance.TakeOffGlasses();
                grabInteractorWithinRange.ForceSelect(GameManager.instance.glasses.GetComponent<GrabInteractable>());
                GameManager.instance.glasses.GetComponent<Rigidbody>().useGravity = true;
                toReleaseRightHand = true;
                GameManager.instance.toTakeGlassesOff = false;
            }
        }
    }

    #endregion

    #region Dropping Items
    [Header("Drop Items Variables")]
    public bool allowDropItems = true;
    [SerializeField] private float dropInterval = 10;
    
    [SerializeField] private AudioSource audioSource_player;
    [SerializeField] private AudioClip audioClip_sighAfterDrop;

    private float dropTimer = 0;

    void EnableDropTimer()
    {
        bool timerOn = false;
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.HasSelectedInteractable)
                timerOn = true;
        }

        if (timerOn)
            dropTimer -= Time.deltaTime;

        if (dropTimer <= 0)
        {
            ActivateItemDrop();
            dropTimer = dropInterval;
        }
    }

    private void ActivateItemDrop()
    {
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            grabInteractor.ForceRelease();
        }

        //audioSource_player.PlayOneShot(audioClip_sighAfterDrop);
    }

    private void ForceDropItemSpecificHand(OVRInput.Controller controllerSide)
    {
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (controllerSide == OVRInput.Controller.LTouch && grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Left)
            {
                toReleaseLeftHand = false;
                grabInteractor.ForceRelease();
            }
            else if (controllerSide == OVRInput.Controller.RTouch && grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Right)
            {
                toReleaseRightHand = false;
                grabInteractor.ForceRelease(); 
            }
        }
    }
    #endregion

    #region Vibrating Controllers
    [Header("Vibrating Controllers Variables")]
    public bool allowControllerVibration = true;
    [SerializeField] int vibrationStrength = 255; // 0 - 255
    [SerializeField] int vibrationFrequency = 2; // lower == more frequent vibration

    public void TriggerVibration(int iteration, int frequency, int strength, OVRInput.Controller controllerSide)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

        if (controllerSide == OVRInput.Controller.LTouch) // left controller
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controllerSide == OVRInput.Controller.RTouch) // right controller
        {
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }

    void CheckIfHolding()
    {
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.HasSelectedInteractable && grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Left)
                TriggerVibration(40, vibrationFrequency, vibrationStrength, OVRInput.Controller.LTouch);
            else if (grabInteractor.HasSelectedInteractable && grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Right)
                TriggerVibration(40, vibrationFrequency, vibrationStrength, OVRInput.Controller.RTouch);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Grabbing Items
        if (canTakeOffGlasses)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                RemoveGlasses(OVRInput.Controller.LTouch);
            }

            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                RemoveGlasses(OVRInput.Controller.RTouch);
            }
        }

        if (toReleaseLeftHand)
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                ForceDropItemSpecificHand(OVRInput.Controller.LTouch);
            }
        }
        if (toReleaseRightHand)
        {
            if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
            {
                ForceDropItemSpecificHand(OVRInput.Controller.RTouch);
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            GameManager.instance.characterModel.GetComponent<Animator>().SetBool("isLeftGrabbing", true);
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            GameManager.instance.characterModel.GetComponent<Animator>().SetBool("isLeftGrabbing", false);
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            GameManager.instance.characterModel.GetComponent<Animator>().SetBool("isRightGrabbing", true);
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            GameManager.instance.characterModel.GetComponent<Animator>().SetBool("isRightGrabbing", false);
        }
        #endregion

        #region Dropping Items
        if (allowDropItems)
            EnableDropTimer();
        #endregion

        #region Vibrating Controllers
        if (allowControllerVibration)
            CheckIfHolding();
        #endregion
    }
}
