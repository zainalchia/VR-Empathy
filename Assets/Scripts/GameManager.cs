using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction;
using UnityEngine.Events;

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

    // OVR PLAYER
    [Header("OVR PLAYER")]
    public GameObject ovrCamRig;
    public GameObject middleEyeAnchor;
    public GrabInteractor[] grabInteractors;
    public GameObject characterModel;

    // PUTTING ON & TAKING OFF GLASSES
    [Header("GLASSES")]
    public GameObject glasses;
    public bool toPutGlassesOn = false;
    public bool toTakeGlassesOff = false;
    public UnityEvent OnGlassesTakeOff;

    // MINIGAMES
    [Header("MINIGAMES")]
    public bool toDoTaiChi = false;
    public bool toEatMedication = false;

    public void TakeOffGlasses()
    {
        glasses.SetActive(true);
        OnGlassesTakeOff.Invoke();
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
