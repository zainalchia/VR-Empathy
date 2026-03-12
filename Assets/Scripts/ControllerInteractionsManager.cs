using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction;
using Oculus.Interaction.Input; // Crucial for IHand and Handedness
using UnityEngine.Events;
using System.Linq;
using UnityEngine.SceneManagement;

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
    bool canTakeOffDentures = false;
    bool toReleaseLeftHand = false;
    bool toReleaseRightHand = false;

    // dropping glasses as glasses collider may be to small for force select to work properly
    bool leftHandForceSelected;
    bool rightHandForceSelected;
    GameObject lastHeldObjLeftHand;
    GameObject lastHeldObjRightHand;

    private bool isLeftHandLocked = false;
    private GameObject lockedItemLeftHand = null;

    public Behaviour leftHandTrackingComponent; // Should be your OVR Hand (Script) from LeftOVRHand
    private bool wasLeftHandTrackingComponentEnabled = false; // To store its original state

    // time taken to close/open fist
    [SerializeField] float timeToOpenCloseFist = 0.2f;
    bool leftFistClosed = false;
    bool rightFistClosed = false;
    float timerToOpenCloseFistLeft = 0.0f;
    float timerToOpenCloseFistRight = 0.0f;

    public List<GameObject> GetItemsGrabbedInHand()
    {
        List<GameObject> items = new List<GameObject>();

        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.HasSelectedInteractable)
            {
                if (!items.Contains(grabInteractor.SelectedInteractable.gameObject))
                    items.Add(grabInteractor.SelectedInteractable.gameObject);
            }
        }
        return items;
    }

    // 0 = left hand, 1 = right hand, 2 = not holding
    public int ObjInWhichHand(GameObject obj)
    {
        int i = 0;
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.HasSelectedInteractable)
            {
                if (grabInteractor.SelectedInteractable.gameObject == obj)
                {
                    return i;
                }
            }
            i++;
        }
        return i;
    }

    public void ForceSelectedObjectFollow(GrabInteractor grabInteractor) // called when force select is used as object does not follow hand, this function makes it follow the hand until it is let go
    {
        if (grabInteractor.HasSelectedInteractable)
        {
            grabInteractor.SelectedInteractable.transform.position = grabInteractor.gameObject.transform.position;
        }
        else
        {
            if (grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Left)
            {
                leftHandForceSelected = false;
                lastHeldObjLeftHand.GetComponent<Rigidbody>().isKinematic = false;
            }
            else if (grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Right)
            {
                rightHandForceSelected = false;
                lastHeldObjRightHand.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    #region Glasses
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
            // REVISED: Get IHand from the GrabInteractor's GameObject or its parent
            IHand hand = grabInteractorWithinRange.gameObject.GetComponentInParent<IHand>();
            if (hand != null)
            {
                if (controllerSide == OVRInput.Controller.LTouch && hand.Handedness == Handedness.Left)
                {
                    canTakeOffGlasses = false;
                    grabInteractorsWithinRange.Clear();

                    leftHandForceSelected = true;
                    lastHeldObjLeftHand = GameManager.instance.glasses;
                    GameManager.instance.glasses.GetComponent<Rigidbody>().isKinematic = true;

                    GameManager.instance.glasses.transform.position = grabInteractorWithinRange.gameObject.transform.position;
                    GameManager.instance.glasses.SetActive(true);
                    grabInteractorWithinRange.ForceSelect(GameManager.instance.glasses.GetComponent<GrabInteractable>());

                    GameManager.instance.OnGlassesTakeOff.Invoke();
                    toReleaseLeftHand = true;
                    GameManager.instance.toTakeGlassesOff = false;
                }
                else if (controllerSide == OVRInput.Controller.RTouch && hand.Handedness == Handedness.Right)
                {
                    canTakeOffGlasses = false;
                    grabInteractorsWithinRange.Clear();

                    rightHandForceSelected = true;
                    lastHeldObjRightHand = GameManager.instance.glasses;
                    GameManager.instance.glasses.GetComponent<Rigidbody>().isKinematic = true;

                    GameManager.instance.glasses.transform.position = grabInteractorWithinRange.gameObject.transform.position;
                    GameManager.instance.glasses.SetActive(true);
                    grabInteractorWithinRange.ForceSelect(GameManager.instance.glasses.GetComponent<GrabInteractable>());

                    GameManager.instance.OnGlassesTakeOff.Invoke();
                    toReleaseRightHand = true;
                    GameManager.instance.toTakeGlassesOff = false;
                }
            }
        }
    }
    #endregion

    #region Dentures
    public void CanTakeOffDentures(GrabInteractor addGrabInteractor)
    {
        if (!grabInteractorsWithinRange.Contains(addGrabInteractor))
        {
            grabInteractorsWithinRange.Add(addGrabInteractor);
            canTakeOffDentures = true;
        }
    }
    public void CannotTakeOffDentures(GrabInteractor removeGrabInteractor)
    {
        if (grabInteractorsWithinRange.Contains(removeGrabInteractor))
            grabInteractorsWithinRange.Remove(removeGrabInteractor);

        if (grabInteractorsWithinRange.Count == 0)
            canTakeOffDentures = false;
    }
    void RemoveDentures(OVRInput.Controller controllerSide)
    {
        foreach (GrabInteractor grabInteractorWithinRange in grabInteractorsWithinRange)
        {
            if ((controllerSide == OVRInput.Controller.LTouch && grabInteractorWithinRange.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Left))
            {
                canTakeOffDentures = false;
                grabInteractorsWithinRange.Clear();

                // for force selected objects
                leftHandForceSelected = true;
                lastHeldObjLeftHand = GameManager.instance.dentures;
                GameManager.instance.dentures.GetComponent<Rigidbody>().isKinematic = true;
                // positions dentures to hand that force selected                
                GameManager.instance.dentures.SetActive(true);
                GameManager.instance.dentures.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true); // force dentures to be on hand of player (basically cant drop)
                GameManager.instance.dentures.transform.position = grabInteractorWithinRange.gameObject.transform.position;
                GameManager.instance.dentures.transform.forward = Camera.main.transform.forward;
                GameManager.instance.dentures.transform.eulerAngles += new Vector3(-90, 0, 0);
                grabInteractorWithinRange.ForceSelect(GameManager.instance.dentures.GetComponent<GrabInteractable>());

                //GameManager.instance.OnDenturesTakeOff.Invoke();
                GameManager.instance.toTakeDenturesOff = false;
            }
            else if (controllerSide == OVRInput.Controller.RTouch && grabInteractorWithinRange.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Right)
            {
                canTakeOffDentures = false;
                grabInteractorsWithinRange.Clear();

                // for force selected objects
                rightHandForceSelected = true;
                lastHeldObjRightHand = GameManager.instance.dentures;
                GameManager.instance.dentures.GetComponent<Rigidbody>().isKinematic = true;

                // positions dentures to hand that force selected
                GameManager.instance.dentures.SetActive(true);
                GameManager.instance.dentures.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
                GameManager.instance.dentures.transform.position = grabInteractorWithinRange.gameObject.transform.position;
                GameManager.instance.dentures.transform.forward = Camera.main.transform.forward;
                GameManager.instance.dentures.transform.eulerAngles += new Vector3(-90, 0, 0);
                grabInteractorWithinRange.ForceSelect(GameManager.instance.dentures.GetComponent<GrabInteractable>());

                //GameManager.instance.OnDenturesTakeOff.Invoke();
                GameManager.instance.toTakeDenturesOff = false;
            }
        }
    }
    #endregion

    public void LockLeftHandToItem(GameObject itemToLock, Transform targetHandPose)
    {
        if (GameManager.instance.grabInteractors[0] != null && itemToLock != null && targetHandPose != null)
        {
            GameManager.instance.grabInteractors[0].gameObject.transform.position = targetHandPose.position;
            GameManager.instance.grabInteractors[0].gameObject.transform.rotation = targetHandPose.rotation;

            if (leftHandTrackingComponent != null)
            {
                wasLeftHandTrackingComponentEnabled = leftHandTrackingComponent.enabled;
                leftHandTrackingComponent.enabled = false;
            }

            Rigidbody handRb = GameManager.instance.grabInteractors[0].gameObject.GetComponent<Rigidbody>();
            if (handRb != null)
            {
                handRb.isKinematic = true;
            }

            GameManager.instance.grabInteractors[0].ForceSelect(itemToLock.GetComponent<GrabInteractable>());
            lockedItemLeftHand = itemToLock;
            isLeftHandLocked = true;

            if (itemToLock.GetComponent<Rigidbody>() != null)
            {
                itemToLock.GetComponent<Rigidbody>().isKinematic = true;
            }

            Debug.Log($"Left hand snapped to {targetHandPose.name} and locked onto: {itemToLock.name}");
        }
        else
        {
            Debug.LogWarning("LockLeftHandToItem called with null references (interactor, item, or target pose).");
        }
    }

    public void UnlockLeftHand()
    {
        if (isLeftHandLocked && GameManager.instance.grabInteractors[0] != null)
        {
            GameManager.instance.grabInteractors[0].ForceRelease();

            if (lockedItemLeftHand != null && lockedItemLeftHand.GetComponent<Rigidbody>() != null)
            {
                lockedItemLeftHand.GetComponent<Rigidbody>().isKinematic = false;
            }

            if (leftHandTrackingComponent != null)
            {
                leftHandTrackingComponent.enabled = wasLeftHandTrackingComponentEnabled;
            }
            Rigidbody handRb = GameManager.instance.grabInteractors[0].gameObject.GetComponent<Rigidbody>();
            if (handRb != null)
            {
                // handRb.isKinematic = false; 
            }

            isLeftHandLocked = false;
            lockedItemLeftHand = null;
            Debug.Log("Left hand unlocked.");
        }
    }

    #endregion

    #region Dropping Items
    [Header("Drop Items Variables")]
    public bool autoDropItems = true;
    [SerializeField] private float dropGlassesInterval = 1;
    [SerializeField] private int dropGlassesCount = 2;

    [SerializeField] private GameObject dropItemFX;
    [SerializeField] public GameObject leftHandAnchor;
    [SerializeField] private GameObject rightHandAnchor;

    public UnityEvent OnGlassesDrop;

    private float dropGlassesTimer = 1;

    private Handedness lastHandToHold;

    void EnableDropTimer()
    {
        bool glassesTimerOn = false;
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.HasSelectedInteractable)
            {
                if (GameManager.instance.toPutGlassesOn)
                {
                    if (GameManager.instance.glasses != null)
                    {
                        if (grabInteractor.SelectedInteractable.gameObject == GameManager.instance.glasses && dropGlassesCount > 0)
                        {
                            glassesTimerOn = true;
                            lastHandToHold = grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness;
                        }
                    }
                }
            }
        }

        #region Glasses scripted dropping
        if (SceneManager.GetActiveScene().name == "PresentBadLivingRoom")
        {
            if (glassesTimerOn)
                dropGlassesTimer -= Time.deltaTime;

            if (dropGlassesTimer <= 0)
            {
                if (lastHandToHold == Handedness.Left)
                {
                    ForceDropItemSpecificHand(OVRInput.Controller.LTouch);

                    Instantiate(dropItemFX, leftHandAnchor.transform);
                }
                else if (lastHandToHold == Handedness.Right)
                {
                    ForceDropItemSpecificHand(OVRInput.Controller.RTouch);

                    Instantiate(dropItemFX, rightHandAnchor.transform);
                }

                OnGlassesDrop.Invoke();
                dropGlassesCount -= 1;
                if (dropGlassesCount >= 1)
                    dropGlassesTimer = dropGlassesInterval;
                else
                    dropGlassesTimer = dropGlassesInterval / 2.0f;
            }
        }
        #endregion
    }

    public void ActivateItemDrop()
    {
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            grabInteractor.ForceRelease();
        }
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
    [SerializeField] int vibrationStrength = 255;
    [SerializeField] int vibrationFrequency = 2;

    public void TriggerVibration(int iteration, int frequency, int strength, OVRInput.Controller controllerSide)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

        if (controllerSide == OVRInput.Controller.LTouch)
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controllerSide == OVRInput.Controller.RTouch)
        {
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }

    void CheckIfHolding()
    {
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.HasSelectedInteractable && grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Left && !grabInteractor.SelectedInteractable.gameObject.CompareTag("NoVibration"))
                TriggerVibration(40, vibrationFrequency, vibrationStrength, OVRInput.Controller.LTouch);
            else if (grabInteractor.HasSelectedInteractable && grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Right && !grabInteractor.SelectedInteractable.gameObject.CompareTag("NoVibration"))
                TriggerVibration(40, vibrationFrequency, vibrationStrength, OVRInput.Controller.RTouch);
        }
    }
    #endregion

    void Start()
    {
        dropGlassesTimer = dropGlassesInterval;
    }

    void Update()
    {
        #region Hand Animations
        
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (GameManager.instance.characterModel != null)
                GameManager.instance.characterModel.GetComponent<Animator>().SetBool("isLeftGrabbing", true);
            
            leftFistClosed = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (GameManager.instance.characterModel != null)
                GameManager.instance.characterModel.GetComponent<Animator>().SetBool("isLeftGrabbing", false);
            
            leftFistClosed = false;
        }
        

        if (GameManager.instance.leftHand != null)
        {
            if (leftFistClosed)
            {
                if (timerToOpenCloseFistLeft < 1.0f)
                    timerToOpenCloseFistLeft += Time.deltaTime / timeToOpenCloseFist;
            }
            else
            {
                if (timerToOpenCloseFistLeft > 0.0f)
                    timerToOpenCloseFistLeft -= Time.deltaTime / timeToOpenCloseFist;
            }
            GameManager.instance.leftHand.GetComponent<Animator>().SetFloat("Flex", timerToOpenCloseFistLeft);
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (GameManager.instance.characterModel != null)
                GameManager.instance.characterModel.GetComponent<Animator>().SetBool("isRightGrabbing", true);
            
            rightFistClosed = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (GameManager.instance.characterModel != null)
                GameManager.instance.characterModel.GetComponent<Animator>().SetBool("isRightGrabbing", false);
            
            rightFistClosed = false;
        }

        if (GameManager.instance.rightHand != null)
        {
            if (rightFistClosed)
            {
                if (timerToOpenCloseFistRight < 1.0f)
                    timerToOpenCloseFistRight += Time.deltaTime / timeToOpenCloseFist;
            }
            else
            {
                if (timerToOpenCloseFistRight > 0.0f)
                    timerToOpenCloseFistRight -= Time.deltaTime / timeToOpenCloseFist;
            }
            GameManager.instance.rightHand.GetComponent<Animator>().SetFloat("Flex", timerToOpenCloseFistRight);
        }
        #endregion

        #region Grabbing Items
        if (canTakeOffGlasses && !isLeftHandLocked)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                RemoveGlasses(OVRInput.Controller.LTouch);
            }

            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                RemoveGlasses(OVRInput.Controller.RTouch);
            }
        }

        if (canTakeOffDentures && !isLeftHandLocked)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                RemoveDentures(OVRInput.Controller.LTouch);
            }

            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                RemoveDentures(OVRInput.Controller.RTouch);
            }
        }

        if (toReleaseLeftHand && !isLeftHandLocked)
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                ForceDropItemSpecificHand(OVRInput.Controller.LTouch);
            }
        }
        if (toReleaseRightHand)
        {
            if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                ForceDropItemSpecificHand(OVRInput.Controller.RTouch);
            }
        }

        if (leftHandForceSelected && !isLeftHandLocked)
        {
            ForceSelectedObjectFollow(GameManager.instance.grabInteractors[0]);
        }

        if (rightHandForceSelected)
        {
            ForceSelectedObjectFollow(GameManager.instance.grabInteractors[1]);
        }
        #endregion

        #region Dropping Items
        if (autoDropItems)
            EnableDropTimer();
        #endregion

        #region Vibrating Controllers
        if (allowControllerVibration)
            CheckIfHolding();
        #endregion

        #region Restart Game (at end game)
        if (GameManager.instance.CheckIfCanRestart())
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))            
                GameManager.instance.RestartGame();            
        }
        #endregion
    }
}