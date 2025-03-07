using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton Stuff
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

    }
    #endregion

    public TextMeshPro debugText;

    // OVR PLAYER
    [Header("OVR PLAYER")]
    public GameObject ovrCamRig;
    public GameObject middleEyeAnchor;
    public GrabInteractor[] grabInteractors; // if can left controller should be index 0, right controller should be index 1
    [SerializeField]
    GameObject MaleModel, FemaleModel;
    public GameObject leftHand;
    public GameObject rightHand;
    [HideInInspector]
    public GameObject characterModel;

    // ALERT TEXT
    [Header("ALERT TEXT")]
    public GameObject alertText;

    // UI FADE IN-OUT
    [Header("FADE IN-OUT PANEL")]
    public GameObject fadePanel;

    [Header("Goodbye Text Panel")]
    public GameObject goodbyeText;

    // PUTTING ON & TAKING OFF GLASSES
    [Header("GLASSES")]
    public GameObject glasses;
    public bool toPutGlassesOn = false;
    public bool toTakeGlassesOff = false;
    public UnityEvent OnGlassesTakeOff;

    // PUTTING ON & TAKING OFF DENTURES
    [Header("DENTURES")]
    public GameObject dentures;
    public bool toTakeDenturesOff = false;
    public UnityEvent OnDenturesTakeOff;

    [Header("Any Look at Objectives")]
    public bool toLookAtObjective = false;

    [Header("MOBILE PHONE")]
    public bool toPickUpPhone = false;
    public bool canAnswerPhone = false;

    [Header("TAICHI")]
    public TaiChiInstructor[] taiChiAnimations;
    public bool toDoTaiChi = false;

    // FURNITURE SPASMING (Bedroom Scene of Present-Bad)
    [Header("FURNITURE SPASMING")]
    public bool toStartSpasming = false;

    public void DebugLog(string text)
    {
        debugText.text = text;
    }

    #region Alert Text Functions
    public void ShowAlert(string textToShow)
    {
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow);
    }
    public void ShowAlert(string textToShow, float length)
    {
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow, length);
    }
    public void ShowAlert(string textToShow, Color color)
    {
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow, color);
    }
    public void ShowAlert(string textToShow, float length, Color color)
    {
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow, length, color);
    }

    public void ShowAlertWithDelay(string textToShow, float length, float delay)
    {
        StartCoroutine(ShowAlertWithDelay_Coroutine(textToShow, length, delay));
    }
    public IEnumerator ShowAlertWithDelay_Coroutine(string textToShow, float length, float delay)
    {
        yield return new WaitForSeconds(delay);
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow, length);
    }
    public void HideAlert()
    {
        AlertTextController.instance.HideAlert();
    }
    #endregion

    #region Player's Position
    public bool IsPlayerWithinPosition(float minXInclusive, float minZInclusive, float maxXInclusive, float maxZInclusive)
    {
        if ((middleEyeAnchor.transform.position.x >= minXInclusive && middleEyeAnchor.transform.position.x <= maxZInclusive) 
            && (middleEyeAnchor.transform.position.z >= minZInclusive && middleEyeAnchor.transform.position.z <= maxZInclusive))
            return true;
        else
            return false;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (MaleModel != null && FemaleModel != null)
        {
            if (MainMenuManager.isGenderMale)
            {
                characterModel = MaleModel;
                FemaleModel.SetActive(false);
            }
            else
            {
                characterModel = FemaleModel;
                MaleModel.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
