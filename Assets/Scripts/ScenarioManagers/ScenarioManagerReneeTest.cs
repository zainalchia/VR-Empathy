using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static MainMenuManager;
using static UnityEngine.Rendering.DebugUI;

public class ScenarioManagerReneeTest : MonoBehaviour
{
    [SerializeField] SceneToPlay sceneToPlay = SceneToPlay.Bathroom;
    public enum SceneToPlay
    {
        Bathroom,
        Stall,
        Home
    }

    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject firstTeleportToiletHotspot;
    //[SerializeField] GameObject TrayTeleportHotspot;

    [Header("Scenario Prompts")]
    public ScenarioPromptManager promptManager;
    [SerializeField] ScenarioID scenarioID = ScenarioID.PastNegative;
    [SerializeField] SceneID sceneID = SceneID.Bathroom;

    [Header("Player Movement")]
    public PlayerTeleport playerTeleport;

    [Header("Debuggers")]
    [SerializeField] GameObject testitem;

    [Header("Narration Variables")]
    [SerializeField] AudioSource narrationAudioSource;

    // For voices
    [HideInInspector] public AudioClip[] narrationAudioClips_1;
    [SerializeField] AudioClip[] narrationAudioClips_1_Male;
    [SerializeField] AudioClip[] narrationAudioClips_1_Female;



    [SerializeField] private GameObject cashObject;
    [SerializeField] private Outline cashOutline;
    [SerializeField] public Outline knifeOutline;
    public GameObject knifeObject;

    void SetupNarration()
    {
        if (MainMenuManager.isGenderMale)
            narrationAudioClips_1 = narrationAudioClips_1_Male;
        else
            narrationAudioClips_1 = narrationAudioClips_1_Female;

        narrationAudioSource.volume = 1;
    }

    #region Bathroom

    [Header("In the bathroom")]
    Coroutine lastRoutine = null;
    [SerializeField] DoorKnob DoorHandle;

    public float timeForWashingUp = 5f;

    public void PlayBathroom()
    {
        lastRoutine = StartCoroutine(StartBathroom());
        // Testing purposes
        //lastRoutine = StartCoroutine(HawkerTraySegment());
    }
    IEnumerator StartBathroom()
    {
        //PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        //ControllerInteractionsManager.instance.autoDropItems = false; // no dropping item yet

        yield return new WaitForSeconds(4f); // screen fade in timing

        // Another horrible day at work. Been working here at the hawker center for so long, still the same.
        // Sigh. Okay just have to wash my face and freshen up and get back to work
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[0]);
        yield return new WaitForSeconds(narrationAudioClips_1[0].length);
        promptManager.ShowPrompt(sceneID, 0, false, 2f);

        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);

        //boss should call the player over to get out quickly here and then player starts moving
        promptManager.ShowPrompt(sceneID, 1, false, 2f);
        //============================================================

        // Oi Robert / Ling! How long you want to use the toilet?! Faster come back work!
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[1]);
        yield return new WaitForSeconds(narrationAudioClips_1[1].length);

        // sigh. Okay, coming boss.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[2]);
        yield return new WaitForSeconds(narrationAudioClips_1[2].length);

        // Teleport from sink to toilet door
        playerTeleport.SetCurrentHotspotIndex(-1);
        firstTeleportToiletHotspot.SetActive(true);
        playerTeleport.MoveToToiletDoor = true;
        promptManager.ShowPrompt(sceneID, 2, false, 5f);
        PlayAllowOpenDoor();
    }

    public void BathroomDoorOpen() // called in UnityEvent in bathroom Handle
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(ExitBathroom());
    }

    IEnumerator ExitBathroom()
    {
        // fade screen 
        GameManager.instance.fadePanel.GetComponent<Animator>().speed = 4;
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);

        // load next scene 
        SceneManager.LoadScene("PastNegativeHawker", LoadSceneMode.Single);
    }

    public void PlayAllowOpenDoor()
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(AllowOpenDoor());
    }


    IEnumerator AllowOpenDoor()
    {
        // can open bathroom door from here
        DoorHandle.AllowDoorOpen();

        yield return null;
    }

    #endregion

    #region Hawker
    [Header("In Hawker stall")]
    [SerializeField] GameObject CashEndPoint;
    [SerializeField] GameObject Boss;
    private bool playOnce = true;

    public void PlayHawkerStart()
    {
        lastRoutine = StartCoroutine(HawkerStart());
    }
    IEnumerator HawkerStart()
    {
        // Finally. Faster la serve customer!
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[0]);
        yield return new WaitForSeconds(narrationAudioClips_1[0].length);
        // How long you want to make me wait? I wait here very long already.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[1]);
        yield return new WaitForSeconds(narrationAudioClips_1[1].length);
        // Sorry about that can I take your order
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[2]);
        yield return new WaitForSeconds(narrationAudioClips_1[2].length);
        // Give me 2 chicken rice
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[3]);
        yield return new WaitForSeconds(narrationAudioClips_1[3].length);
        promptManager.ShowPrompt(SceneID.Stall, 1);
        // Hand over cash
        cashObject.transform.position = Vector3.Lerp(cashObject.transform.position, CashEndPoint.transform.position, 3f);
        //promptManager.ShowPrompt(SceneID.Stall, 1);

    }
    public void OnCashPlaced()
    {
        // player has put cash into register
        playerTeleport.hasPlacedCash = true;
        // TP to the next hotspot
        playerTeleport.MoveToSection = true;
        //reset hotspot
        playerTeleport.SetCurrentHotspotIndex(0);

        //enables the next hotspot (chopping)
        var jobHotspots = playerTeleport.GetMoveToJobPositionHotspots();
        if (jobHotspots.Length > 1)
        {
            // Show chopping board hotspot
            jobHotspots[1].SetActive(true);
            if (jobHotspots[1].transform.childCount > 0)
                jobHotspots[1].transform.GetChild(0).gameObject.SetActive(true);
        }
        knifeObject.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
    }
    public void PlayChoppedHand()
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(ChoppedHand());
    }

    IEnumerator ChoppedHand()
    {

        //ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(PlayerCloth.GetComponent<GrabInteractable>());

        // Aiya this simple thing also you cannot do. I pay you for what?! Useless!
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[6]);
        // Boss moves to cut chicken
        Boss.gameObject.SetActive(true);
        yield return new WaitForSeconds(narrationAudioClips_1[6].length);

        // Set boss animation to chopping 

        // Chop for around 2 seconds?
        yield return new WaitForSeconds(2);

        // I do your job for you already. Go give this to the customer! I don�t want to see your face here.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[7]);
        yield return new WaitForSeconds(narrationAudioClips_1[7].length);

        TrayOfFood.SetActive(true);
    }


    [SerializeField] GameObject TrayOfFood;
    [SerializeField] GameObject DroppedFood;
    [SerializeField] GameObject PlayerCloth;

    public void PlayTraySegment()
    {
        lastRoutine = StartCoroutine(HawkerTraySegment());
    }
    IEnumerator HawkerTraySegment()
    {
        //TrayTeleportHotspot.gameObject.SetActive(true);
        //playerTeleport.MoveToTable = true;
        yield return new WaitForSeconds(2);
        PlayFoodDrop();
    }

    public void PlayFoodDrop()
    {
        // Allow drop
        TrayOfFood.transform.SetParent(null);
        TrayOfFood.GetComponent<FoodTray>().AbleToGrab = false;
        TrayOfFood.GetComponent<Rigidbody>().isKinematic = false;
        TrayOfFood.GetComponent<Rigidbody>().useGravity = true;
        TrayOfFood.GetComponent<ForceStayGrabbed>().SetForceGrabActive(false);
        TrayOfFood.GetComponent<Grabbable>().enabled = false;
        ControllerInteractionsManager.instance.rightGrabInteractor.ForceRelease();
        ControllerInteractionsManager.instance.leftGrabInteractor.ForceRelease();

        if (TrayOfFood.transform.position.y <= 0.2f)
        {
            TrayOfFood.gameObject.SetActive(false);
            DroppedFood.transform.position = new Vector3(TrayOfFood.transform.position.x, 0.0f, TrayOfFood.transform.position.z);
            DroppedFood.gameObject.SetActive(true);
            if (playOnce)
            {
                lastRoutine = StartCoroutine(CleanDroppedFood());
                playOnce = false;
            }
        }
    }
    IEnumerator CleanDroppedFood()
    {
        // Set boss animation to smacking you

        // Wah why you so stupid ah?!! I really cannot with you already! I’m going to cut your pay!
        //narrationAudioSource.clip = narrationAudioClips_1[8];
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[8]);
        yield return new WaitForSeconds(narrationAudioClips_1[8].length);

        // Nah clean this mess up! Stupid!
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[9]);
        yield return new WaitForSeconds(narrationAudioClips_1[9].length);

        PlayerCloth.SetActive(true);
        PlayerCloth.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
        yield return null;
    }

    public void PlayCustomerDialogue() // called in Cloth
    {
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[10]);
    }
    public void PlayFinishedCleaning() // called in Cloth 
    {
        lastRoutine = StartCoroutine(FinishCleaningFoodDroppings());
    }

    IEnumerator FinishCleaningFoodDroppings()
    {
        PlayerCloth.gameObject.SetActive(false);
        // fade out
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");

        //What a horrible day. I really wish I can quit this job.
        //But I need to feed my family, and times are tough, it’s so hard to find work nowadays.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[11]);
        yield return new WaitForSeconds(narrationAudioClips_1[11].length);
        SceneManager.LoadScene("PastNegativeHome", LoadSceneMode.Single);
    }
    #endregion

    #region Family
    [Header("In Home")]
    [SerializeField] GameObject Ladle;
    [SerializeField] GameObject Sean;
    [SerializeField] AudioSource SeanAudioSource;
    public void PlayFamilyStart()
    {
        lastRoutine = StartCoroutine(FamilyStart());
    }

    IEnumerator FamilyStart()
    {
        Debug.Log("Played");
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(2);

        // I’m home
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[0]);
        yield return new WaitForSeconds(narrationAudioClips_1[0].length);

        // Finally, why come back so late?? Food cold already.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[1]);
        yield return new WaitForSeconds(narrationAudioClips_1[1].length);

        // Sorry dear. I had to clean up a mess at work.
        // I had the most horrible day at work. I just had my pay cut-
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[2]);
        yield return new WaitForSeconds(narrationAudioClips_1[2].length);

        // what??! pay cut?? And how are we going to pay for food?
        // Our fridge already running low on groceries also!!
        // Ah boy, you better enjoy your meal. From tomorrow onwards cannot eat like this already.
        // Can only eat rice with vegetables. All thanks to your good for nothing father / mother!
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[3]);
        yield return new WaitForSeconds(narrationAudioClips_1[3].length);

        // Pour food segment
        Ladle.GetComponent<Grabbable>().enabled = true;
        Ladle.GetComponent<ForceStayGrabbed>().enabled = true;
        Ladle.GetComponent<PhysicsGrabbable>().enabled = true;
        Ladle.GetComponent<GrabInteractable>().enabled = true;
        Ladle.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
    }
    public void PlayLightOFf()
    {
        lastRoutine = StartCoroutine(LightOff());
    }
    IEnumerator LightOff()
    {
        // I’m sorry, son.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[4]);
        yield return new WaitForSeconds(narrationAudioClips_1[4].length);

        // Our water and electricity bills how long haven’t pay already...
        // Somemore every month our parents make us give them so much money…
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[5]);
        yield return new WaitForSeconds(narrationAudioClips_1[5].length);

        // Turn off lights and dim environment and sean's hand is messy and full of food

        // Daddy / Mummy what happened??? I cannot see!! [pause] Daddy / Mummy I’m scared
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[6]);
        yield return new WaitForSeconds(narrationAudioClips_1[6].length);

        // It's ok son, it's ok.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[7]);
        yield return new WaitForSeconds(narrationAudioClips_1[7].length);

        // Carry sean segment
        Sean.GetComponent<Grabbable>().enabled = true;
        Sean.GetComponent<ForceStayGrabbed>().enabled = true;
        Sean.GetComponent<PhysicsGrabbable>().enabled = true;
        Sean.GetComponent<GrabInteractable>().enabled = true;
        Sean.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
    }
    public void PlayFinalHome()
    {
        lastRoutine = StartCoroutine(FinalHome());
    }

    IEnumerator FinalHome()
    {
        // Daddy / Mummy why no light??
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[7]);
        yield return new WaitForSeconds(narrationAudioClips_1[7].length);

        // fade out
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");

        // Sean crying volume gets lower
        SeanAudioSource.Play();
        LowerVolume(SeanAudioSource, 30);
        //I work so hard for my family.
        //I get bullied, scolded, even beaten at work, and nobody can help me do anything about it.
        //My wife / husband still not happy, I still can’t provide for my family. Sigh.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[8]);
        yield return new WaitForSeconds(narrationAudioClips_1[8].length);

    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetupNarration();
        playerTeleport.currentScene = ScenarioID.PastNegative;

        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            sceneID = SceneID.Bathroom;
            PlayBathroom();
        }
        else if (sceneToPlay == SceneToPlay.Stall)
        {
            sceneID = SceneID.Stall;
            //PlayHawkerStart();
            PlayChoppedHand();
        }
        else if (sceneToPlay == SceneToPlay.Home)
        {
            sceneID = SceneID.Family;
            PlayFamilyStart();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    void StopPrevDialogue()
    {
        // to stop prev dialogue if it was still going on
        if (lastRoutine != null)
            StopCoroutine(lastRoutine);
        if (AlertTextController.instance)
        {
            if (AlertTextController.instance.gameObject.activeInHierarchy)
                AlertTextController.instance.SetInactive();
        }
    }

    void LowerVolume(AudioSource source, float TargetVolume)
    {
        source.volume = Mathf.Lerp(source.volume,TargetVolume, Time.deltaTime);
    }

}
