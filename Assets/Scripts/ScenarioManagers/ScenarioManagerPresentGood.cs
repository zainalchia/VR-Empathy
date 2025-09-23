using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;
using UnityEngine.Video;
using Meta.WitAi;

public class ScenarioManagerPresentGood : MonoBehaviour
{
    [SerializeField] SceneToPlay sceneToPlay = SceneToPlay.Bathroom;
    enum SceneToPlay
    {
        Bathroom,
        Bedroom,
        BedroomPart2,
        Voiddeck,
        LivingRoom
    }

    [Header("Narration Variables")]
    public AudioSource narrationAudioSource;
    [SerializeField] AudioSource playerAudioSource;

    // for bathroom and living room scene
    [HideInInspector] public AudioClip[] narrationAudioClips_1;
    [SerializeField] AudioClip[] narrationAudioClips_1_Male;
    [SerializeField] AudioClip[] narrationAudioClips_1_Female;
    string[] narration_1 = new string[30];

    // for voiddeck scene
    AudioClip[] narrationAudioClips_2;
    [SerializeField] AudioClip[] narrationAudioClips_2_Male;
    [SerializeField] AudioClip[] narrationAudioClips_2_Female;
    string[] narration_2 = new string[30];    
    
    // for bedroom scene
    AudioClip[] narrationAudioClips_3;
    [SerializeField] AudioClip[] narrationAudioClips_3_Male;
    [SerializeField] AudioClip[] narrationAudioClips_3_Female;
    string[] narration_3 = new string[30];

    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject firstTeleportHotspot;

    [Header("Player Movement")]
    [SerializeField] PlayerTeleport playerTeleport;

    [Header("Scenario Prompters")]
    [SerializeField] ScenarioPromptManager promptManager;
    [SerializeField] ScenarioID scenarioID = ScenarioID.PresentGood;
    [SerializeField] SceneID sceneID = SceneID.Bathroom;

    bool alertAtLastTeleport = false;

    bool canSeeWindow = false; // if can see window then can say weather looks good

    Coroutine lastRoutine = null;

    [SerializeField] private float MaxAlertHideTimer = 3;

    private float AlertHideTimer = 0;

    [SerializeField] GameObject BathroomItems;
    private bool StartGame = true;
    private bool PlayStart = true;

    //void SetupNarrationBathroomLivingRoom()
    //{
    //    narration_1[0] = "Open the door and head to the sofa";
    //    narration_1[1] = "Press TRIGGER button to move to highlighted circle";
    //    narration_1[2] = "Someone is calling,pick up the call";
    //    narration_1[3] = "Open gate and leave to void deck by interacting with gate knob";
    //}

    void SetupNarrationVoiddeck()
    {
        narration_2[0] = "[Look at highlighted othello NPC to start othello minigame]";
        //narration_2[1] = "[Pick up highlighted checkers piece and place it on highlighted spot]";
        //narration_2[2] = "[Press TRIGGER button to move to highlighted circle]";
        //narration_2[3] = "[Pick up highlighted mic]";
        //narration_2[4] = "[Follow taichi instructor's movements]"; // this narration appears at the start but the number is 4 cus i got lazy to change everything by 1 if i put this as narration_2[0]
        //narration_2[5] = "[Put mic to face]";
    }    
    
    void SetupNarrationBedroom()
    {
        if (MainMenuManager.isGenderMale)
            narrationAudioClips_3 = narrationAudioClips_3_Male;        
        else
            narrationAudioClips_3 = narrationAudioClips_3_Female;        
    }

    void SetupNarrationBathroomLivingRoom()
    {
        if (MainMenuManager.isGenderMale)        
            narrationAudioClips_1 = narrationAudioClips_1_Male;        
        else        
            narrationAudioClips_1 = narrationAudioClips_1_Female;        
    }

    void SetupNarrationVoiddeck2()
    {
        if (MainMenuManager.isGenderMale)        
            narrationAudioClips_2 = narrationAudioClips_2_Male;        
        else        
            narrationAudioClips_2 = narrationAudioClips_2_Female;        
    }


    #region Segment 1 Part 1 (In the Bathroom)
    [Header("In the bathroom")]
    [SerializeField] float timeForWashingUp = 30f;

    public void PlaySegment1Part1()
    {
        lastRoutine = StartCoroutine(Segment1Part1());
    }

    IEnumerator Segment1Part1()
    {
        //PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        ControllerInteractionsManager.instance.autoDropItems = false; // no dropping item yet

        yield return new WaitForSeconds(4f); // screen fade in timing

        //Lines 1-2
        //PlayAudioAndNarration(narrationAudioClips_1[0], narration_1[0], 7.0f);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[0]);

        // Give time for player to wash up
        yield return new WaitForSeconds(narrationAudioClips_1[0].length + timeForWashingUp);
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[1]);

        yield return new WaitForSeconds(narrationAudioClips_1[1].length);

        PlaySegment1Part2();
    }

    #endregion

    #region Segment 1 Part 2 (From bathroom to living room)
    [Header("Moving towards living room")]
    [SerializeField] DoorKnob bathroomDoor;
    [SerializeField] GameObject knob;
    //[SerializeField] GameObject mug;
    //[SerializeField] GameObject toothpaste;
    //[SerializeField] GameObject toothbrush;
    //[SerializeField] GameObject soap;
    //[SerializeField] GameObject comb;
    bool toGoLivingRoom = false;
    bool alertRemovedAfterFirstTP = false;

    public void PlaySegment1Part2()
    {
        StopPrevDialogue();
        sceneID = SceneID.LivingRoom;
        lastRoutine = StartCoroutine(Segment1Part2());
    }

    IEnumerator Segment1Part2()
    {
        //GameManager.instance.ShowAlert(narration_1[0]);

        promptManager.ShowPrompt(sceneID, 0, false, 5f);

        // can open bathroom door from here
        knob.GetComponent<Outline>().enabled = true;
        bathroomDoor.AllowDoorOpen();

        yield return null;
    }

    public void BathroomDoorOpen() // called in UnityEvent in bathroom door
    {
        StopPrevDialogue();

        AlertHideTimer = MaxAlertHideTimer;

        //GameManager.instance.ShowAlert(narration_1[1]);
        /*promptManager.ShowPrompt(sceneID, 1);
        knob.GetComponent<Outline>().enabled = false;
        mug.GetComponent<Outline>().enabled = false;
        toothpaste.GetComponent<Outline>().enabled = false;
        toothbrush.GetComponent<Outline>().enabled = false;
        soap.GetComponent<Outline>().enabled = false;
        comb.GetComponent<Outline>().enabled = false;

        firstTeleportHotspot.SetActive(true); // enable first teleport hotspot
        playerTeleport.MovingToLivingRoom = true;

        toGoLivingRoom = true;*/

        lastRoutine = StartCoroutine(ExitBathroom());
    }
    IEnumerator ExitBathroom()
    {
        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().speed = 4; // to make it fade it in 1 sec. may need to lower back the speed later
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);

        // load next scene here
        SceneManager.LoadScene("PresentGoodLivingRoom", LoadSceneMode.Single);
    }

    public void SetupSegment1Part2_1()
    {
        // to make a fade in
        GameManager.instance.fadePanel.GetComponent<Animator>().speed = 4; // to make it fade it in 1 sec. may need to lower back the speed later

        //PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        firstTeleportHotspot.SetActive(true); // enable first teleport hotspot
        promptManager.ShowPrompt(sceneID, 0, false, 5f);
        playerTeleport.MovingToLivingRoom = true;
        toGoLivingRoom = true;
        lastRoutine = null;
    }

    #endregion

    #region Segment 1 Part 3 (Living room)
    [Header("In living room")]
    [SerializeField] GameObject phone;
    [SerializeField] GameObject secondPhone;
    [SerializeField] MobilePhone mobilePhone;
    [SerializeField] Outline glassesOutline;
    //[SerializeField] Transform OutsideHouse; // just outside house for friends to walk to
    [SerializeField] private GameObject[] MaleFriends;
    [SerializeField] private GameObject[] FemaleFriends;
    private GameObject[] friends;
    [SerializeField] private float moveSpeed;

    public void PlaySegment1Part3_1()
    {
        lastRoutine = StartCoroutine(Segment1Part3_1());

        // clip to play is the lighthearted music clip

        //narrationAudioSource.Stop();
        //narrationAudioSource.PlayOneShot(clipToPlay);
    }

    IEnumerator Segment1Part3_1()
    {
        
        // play phone calling
        mobilePhone.SetPhoneCalling();
        promptManager.ShowPrompt(sceneID, 1, false, 5f);
        phone.transform.GetChild(0).GetComponent<Outline>().enabled = true;

        yield return new WaitForSeconds(2.5f + 1.1f);

        GameManager.instance.toPickUpPhone = true;
    }

    public void PhonePickedUp() // called in UnityEvent in MobilePhone
    {
        StopPrevDialogue();
        phone.transform.GetChild(0).GetComponent<Outline>().enabled = false;
        phone.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
        GameManager.instance.toPutGlassesOn = true;
        glassesOutline.enabled = true;

        // my phone is ringing, let me get my glasses
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[4]);
    }

    public void GlassesPutOn() // called in UnityEvent in PlayerFace
    {
        StopPrevDialogue();
        GameManager.instance.canAnswerPhone = true;
        ControllerInteractionsManager.instance.autoDropItems = false; // no more dropping after glasses put on
        glassesOutline.enabled = false;
        mobilePhone.UnblurPhone();

        //GameManager.instance.ShowAlert(narration_1[12]);
    }

    public void PhoneAnswered() // called in UnityEvent in MobilePhone
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(Segment1Part3_3());
    }

    IEnumerator Segment1Part3_3() // Dialogue between player and caller
    {
        if (MainMenuManager.isGenderMale)
        {
            friends = MaleFriends;
        }
        else
        {
            friends = FemaleFriends;
        }

        yield return new WaitForSeconds(3f); // the call takes a few second to be answered so wait a few seconds first

        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[5]);

        yield return new WaitForSeconds(2f);

        //StartCoroutine(MoveFriendsWithDelay(1));

        yield return new WaitForSeconds(narrationAudioClips_1[5].length - 2f);

        // play phone hang up here
        mobilePhone.SetPhoneHangUp();

        yield return new WaitForSeconds(1f);

        phone.GetComponent<ForceStayGrabbed>().SetForceGrabActive(false); // drops phone
        phone.GetComponent<Grabbable>().enabled = false; // ensures that phone cannot be grabbed again
        phone.SetActive(false);
        secondPhone.SetActive(true);

        secondPhone.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;

        yield return new WaitForSeconds(0.5f);

        secondPhone.transform.GetComponent<MeshRenderer>().enabled = true;

        playerTeleport.SetCurrentHotspotIndex(-1); // reset back to prepare for move to main door

        PlaySegment1Part4();
    }

    //IEnumerator MoveFriendsWithDelay(float delayBetweenFriends)
    //{
    //    StartCoroutine(MoveFriendPosition(friends[0],0.5f,OutsideHouse.position,180));
    //    yield return new WaitForSeconds(delayBetweenFriends);
    //    StartCoroutine(MoveFriendPosition(friends[1],1f,OutsideHouse.position,180));
    //}
    IEnumerator MoveFriendPosition(GameObject friend, float stopDistance, Vector3 targetDestination, float targetYRotation)
    {
        var directionVector = (targetDestination - friend.transform.position).normalized;

        friend.GetComponent<Animator>().SetBool("isWalking", true);

        while (Vector3.Distance(targetDestination, friend.transform.position) > stopDistance)
        {
            friend.transform.position += directionVector * moveSpeed * Time.deltaTime;
            yield return null;
        }

        friend.GetComponent<Animator>().SetBool("isWalking", false);
        yield return new WaitForSeconds(1);

        // Start rotation lerp
        float rotationDuration = 1.0f; // Adjust this value for faster/slower rotation
        float elapsedTime = 0;

        Quaternion startRotation = friend.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(
            friend.transform.rotation.eulerAngles.x,
            targetYRotation,
            friend.transform.rotation.eulerAngles.z
        );

        while (elapsedTime < rotationDuration)
        {
            // Calculate the lerp value (0 to 1) based on elapsed time
            float t = elapsedTime / rotationDuration;

            // Use a smoothing function if you want (optional)
            t = Mathf.SmoothStep(0, 1, t);

            // Use Quaternion.Slerp for the shortest rotation path
            friend.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure we end at the exact target rotation
        friend.transform.rotation = targetRotation;
    }

    public void PlaySegment1Part4()
    {
        lastRoutine = StartCoroutine(ToBedroom());
    }

    IEnumerator ToBedroom()
    {
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("PresentGoodBedroom", LoadSceneMode.Single);
    }

    #endregion

    //#region stuff to clear, the interaction with friends outside

    //#region Segment 1 Part 4(From living room to main door)

    //[Header("Living room to main door")]
    //[SerializeField] AudioSource RingingSoundSource;
    //[SerializeField] GameObject firstToDoorHotspot;
    //[SerializeField] private DoorKnob MainGate;
    //[SerializeField] private Outline MainGateOutline;



    ////IEnumerator Segment1Part4()
    ////{
    ////    yield return new WaitForSeconds(2f); // delay between phone hang up and door ring

    ////    RingingSoundSource.Play(); // need ring sfx

    ////    //GameManager.instance.ShowAlert(narration_1[1]); // shows prompt to press grip button to move towards gate

    ////    playerTeleport.MovingToMainDoor = true;

    ////    firstToDoorHotspot.SetActive(true);
    ////}

    ////// used as unity event in player teleport
    ////public void OpenDoorPrompt()
    ////{
    ////    StopPrevDialogue();
    ////    StartCoroutine(Segment1Part5());
    ////}

    //#endregion

    //#region Segment 1 Part 5 (Interaction with friends outside main door)

    //public void PlaySegment1Part5()
    //{
    //    lastRoutine = StartCoroutine(Segment1Part5());
    //}

    //IEnumerator Segment1Part5()
    //{
    //    friends[0].GetComponent<Animator>().SetTrigger("Wave");

    //    yield return new WaitForSeconds(1f);

    //    friends[1].GetComponent<Animator>().SetTrigger("Wave");

    //    //yield return new WaitForSeconds(3.2f); // make sure waving animation is done first

    //    //friends[0].GetComponent<Animator>().SetTrigger("TalkBegin");

    //    //yield return new WaitForSeconds(1.2f);

    //    friends[0].GetComponent<AudioSource>().clip = narrationAudioClips_1[4];

    //    friends[0].GetComponent<AudioSource>().Play();

    //    //friends[0].GetComponent<Animator>().SetTrigger("Talking");

    //    yield return new WaitForSeconds(narrationAudioClips_1[4].length);

    //    //friends[0].GetComponent<Animator>().SetTrigger("TalkEnd");

    //    //yield return new WaitForSeconds(2f);

    //    //GameManager.instance.ShowAlert(narration_1[3]);
    //    promptManager.ShowPrompt(sceneID, 1);

    //    MainGateOutline.enabled = true;

    //    MainGate.AllowDoorOpen();
    //}

    //public void OffMainGateOutline()
    //{
    //    MainGateOutline.enabled = false;
    //}

    //public void PlayMainGateOpen()
    //{
    //    lastRoutine = StartCoroutine(MainGateOpen());
    //}

    //IEnumerator MainGateOpen()
    //{
    //    GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
    //    yield return new WaitForSeconds(4f);

    //    SceneManager.LoadScene("PresentGoodVoiddeck", LoadSceneMode.Single); 
    //}

    //#endregion

    //#endregion

    #region Segment 2 (In the bedroom)
    [Header("Bedroom 1st Part")]
    [SerializeField] GameObject Glass;
    [SerializeField] Outline CupOutline;

    public void PlaySegment2Part1()
    {
        sceneID = SceneID.Bedroom;
        lastRoutine = StartCoroutine(Segment2Part1_1());

    }

    IEnumerator Segment2Part1_1()
    {

        ControllerInteractionsManager.instance.autoDropItems = false; // no dropping items (can also disable in scene)

        yield return new WaitForSeconds(4f); // screen fade in timing

        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_3[0]); // V07
        yield return new WaitForSeconds(narrationAudioClips_3[0].length);

        //GameManager.instance.ShowAlert(narration_2[3]);
        promptManager.ShowPrompt(sceneID, 0);
        AlertTextController.instance.gameObject.SetActive(true); 

        // allow take dentures off from here
        GameManager.instance.toTakeDenturesOff = true; 

        //GameManager.instance.ShowAlert(narration_2[11]);
        CupOutline.enabled = true;
    }

    public void DenturesPlacedInCup() // called in UnityEvent in denture cup
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(AfterDenturesPlaced());
    }

    private IEnumerator AfterDenturesPlaced()
    {
        // Small delay so player can register dentures were placed
        yield return new WaitForSeconds(1f);

        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_3[1]); // VO8
        yield return new WaitForSeconds(narrationAudioClips_3[1].length);

        yield return new WaitForSeconds(1.5f); //delay before fade
        // Fade out
        GameManager.instance.whiteFadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        // Switch to Voiddeck
        SceneManager.LoadScene("PresentGoodVoiddeck", LoadSceneMode.Single);
    }

    #endregion

    #region Segment 3 Part 1 (Voiddeck, Tai chi)

    [Header("Voiddeck - General")]
    [SerializeField]
    GameObject[] KaraokeCornerNPCs;
    [SerializeField] WhiteFade WhiteFadeEffect;

    [Header("Voiddeck - Taichi")]
    [SerializeField]
    TaiChiManager taiChiManager;
    [SerializeField] GameObject taichiInstructor;
    [SerializeField] Transform taichiTargetDestination;
    [SerializeField] AudioSource taichiAudioSource;
    [SerializeField] AudioClip taiChiBGM;
    void PlaySegment3Part1()
    {
        sceneID = SceneID.VoidDeck;
        PostProcessingController.instance.UsingGlasses(true); // no blur effect
        StartCoroutine(playTaichi());
    }

    IEnumerator playTaichi()
    {
        StartCoroutine(SetKaraokeNPCs());
        WhiteFadeEffect.FadeIn();
        // Start taichi bgm
        taichiAudioSource.GetComponent<AudioSource>().clip = taiChiBGM;
        taichiAudioSource.GetComponent <AudioSource>().loop = true;
        taichiAudioSource.GetComponent<AudioSource>().Play();

        // nancy bought me to taichi
        playerAudioSource.GetComponent<AudioSource>().clip = narrationAudioClips_2[0];
        playerAudioSource.GetComponent<AudioSource>().Play();

        //playerAudioSource.GetComponent<AudioSource>().PlayOneShot(narrationAudioClips_2[0]);

        yield return new WaitForSeconds(narrationAudioClips_2[0].length); // screen fade in timing

        yield return StartCoroutine(MoveFriendPosition(taichiInstructor, 0.25f, taichiTargetDestination.position, 90));

        yield return new WaitForSeconds(1); // additional delay to ensure that taichi instructor is back to idle animation before going to talk animations

        taichiInstructor.GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        taichiInstructor.GetComponent<Animator>().SetTrigger("Talking");

        taichiInstructor.GetComponent<AudioSource>().clip = narrationAudioClips_2[1];

        taichiInstructor.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(narrationAudioClips_2[1].length);

        taichiInstructor.GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(4.5f);

        taichiInstructor.GetComponent<TaiChiInstructor>().StartAnimation();

        //taichiInstructor.GetComponent<TaiChiInstructor>().NextPose();

        //yield return new WaitForSeconds(2.8f);

        //GameManager.instance.taiChiAnimations[1].NextPose();

        //GameManager.instance.taiChiAnimations[2].NextPose();

        //taiChiManager.startSegment1();

        //GameManager.instance.ShowAlert(narration_2[4]);
        //promptManager.ShowPrompt(sceneID, 0);
    }

    IEnumerator SetKaraokeNPCs()
    {
        for(int i = 0; i < 4; i++)
        {
            KaraokeCornerNPCs[i].GetComponent<Animator>().SetTrigger("TalkBegin");
            yield return new WaitForSeconds(0.7f);
            KaraokeCornerNPCs[i].GetComponent<Animator>().SetTrigger("Talking");
        }    
    }

    //public void playnextTaichiPose() // called on taichi instructor in scene, OnNextPost event
    //{
    //    taiChiManager.nextTaichiPose();
    //}

    public void TaichiFinished() // Event called in Taichi instructor
    {
        StartCoroutine(MovingFromTaichiToCheckers());
        //taiChiManager.FinishDoTaiChi();
    }

    #endregion

    #region Segment 3 Part 2 (Checkers)

    [Header("Voiddeck - Transition Taichi to Checkers")]
    [SerializeField] GameObject taichiNPC;
    [SerializeField] GameObject checkersNPC;
    [SerializeField] GameObject teleportPoint;
    [SerializeField] GameObject player;
  
    [SerializeField] LookDetection lookDetection;
    [SerializeField] float checkersNPCRotationTime = 2;
    [SerializeField] GameObject firstCheckersHotspot;
    private float currentRotationTime;
    int times;

    IEnumerator MovingFromTaichiToCheckers()
    {
        times++;

        checkersNPC.GetComponent<Animator>().SetTrigger("IdleSeat");

        yield return new WaitForSeconds(0.5f);

        checkersNPC.GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        checkersNPC.GetComponent<Animator>().SetTrigger("Talking");

        checkersNPC.GetComponent<AudioSource>().clip = narrationAudioClips_2[2];

        checkersNPC.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(narrationAudioClips_2[2].length);

        checkersNPC.GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        checkersNPC.GetComponent<Animator>().SetTrigger("BackToIdle");

        yield return StartCoroutine(SetNPCToPlayPos(checkersNPC,90,2));

        //GameManager.instance.ShowAlert(narration_2[0]);
        //promptManager.ShowPrompt(sceneID, 1);

        //checkersNPC.GetComponent<Outline>().enabled = true;

        //yield return new WaitForSeconds(1f);

        //lookDetection.enabled = true;

        // Fadde screen
        //GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        WhiteFadeEffect.FadeOut();

        playerAudioSource.GetComponent<AudioSource>().clip = narrationAudioClips_2[3];
        playerAudioSource.GetComponent<AudioSource>().Play();

        //playerAudioSource.GetComponent<AudioSource>().PlayOneShot(narrationAudioClips_2[3]);

        yield return new WaitForSeconds(narrationAudioClips_2[3].length);
        //GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeIn");
        WhiteFadeEffect.FadeIn();
        //yield return new WaitForSeconds(1f);

        StartWalkingToCheckers();
    }

    public void StartWalkingToCheckers()
    {
        StopPrevDialogue(); // hide alert text
        //lookDetection.enabled = false;
        //firstCheckersHotspot.SetActive(true);
        playerTeleport.MovingToCheckersChair = true;
        //GameManager.instance.ShowAlert(narration_2[2]);
        //promptManager.ShowPrompt(sceneID, 2);
        checkersNPC.GetComponent<Animator>().ResetTrigger("IdleSeat");
        checkersNPC.GetComponent<Animator>().ResetTrigger("TalkBegin");
        checkersNPC.GetComponent<Animator>().ResetTrigger("Talking");
        checkersNPC.GetComponent<Animator>().ResetTrigger("TalkEnd");
    }

    [Header("Voiddeck - Checkers")]
    [SerializeField] GameObject FirstEnemyCheckerPiece;
    [SerializeField] GameObject SecondEnemyCheckerPiece;
    [SerializeField] GameObject EnemyPieceFirstDestination;
    [SerializeField] GameObject EnemyPieceSecondDestination;
    [SerializeField] GameObject EnemyPieceThirdDestination;
    [SerializeField] GameObject PlayerPieceFirstDestination;
    [SerializeField] GameObject PlayerPieceSecondDestination;
    [SerializeField] GameObject PlayerPiece;
    [SerializeField] GameObject PlayerPieceOutline;
    [SerializeField] GameObject CheckerPieces;

    public void PlayCheckersTransition()
    {
        StartCoroutine(CheckersTransition());
    }

    IEnumerator CheckersTransition()
    {
        StopPrevDialogue();
        taichiNPC.SetActive(false);
        checkersNPC.GetComponent<Animator>().SetTrigger("move");
        yield return StartCoroutine(MovePiece(FirstEnemyCheckerPiece,EnemyPieceFirstDestination,0));
        //GameManager.instance.ShowAlert(narration_2[1]);
        //promptManager.ShowPrompt(sceneID, 3);
        //PlayerPiece.GetComponent<Grabbable>().enabled = true;
        //PlayerPieceOutline.SetActive(true);
        PlayerPieceFirstDestination.SetActive(true);
        StartCoroutine(MovePiece(PlayerPiece, PlayerPieceFirstDestination));

    }

    public void PlayFirstPieceCaptured()
    {
        StartCoroutine(FirstPieceCaptured());
    }

    IEnumerator FirstPieceCaptured()
    {
        StopPrevDialogue();
        PlayerPieceOutline.SetActive(false);
        yield return StartCoroutine(MovePiece(FirstEnemyCheckerPiece,EnemyPieceSecondDestination)); // moves enemy piece to symbolise it being captured
        //GameManager.instance.ShowAlert(narration_2[1]);
        //promptManager.ShowPrompt(sceneID, 3);
        //PlayerPiece.GetComponent<Grabbable>().enabled = true;
        //PlayerPieceOutline.SetActive(true);
        PlayerPieceSecondDestination.SetActive(true);

        StartCoroutine(MovePiece(PlayerPiece, PlayerPieceSecondDestination));

    }

    public void PlaySecondPieceCaptured()
    {
        StartCoroutine(SecondPieceCaptured());
    }

    IEnumerator SecondPieceCaptured()
    {
        StopPrevDialogue();
        PlayerPieceOutline.SetActive(false);
        yield return StartCoroutine(MovePiece(SecondEnemyCheckerPiece, EnemyPieceThirdDestination));
        yield return new WaitForSeconds(1);
        StartCoroutine(MovingFromChessToKaraokeCorner());
    }

    IEnumerator MovePiece(GameObject checkerPiece,GameObject Destination,float heightMultiplier = 0.25f)
    {
        float timeSinceStarted = 0f;
        float duration = 1f; // Total movement time

        Vector3 startPosition = checkerPiece.transform.localPosition;
        Vector3 targetPosition = Destination.transform.localPosition;

        while (timeSinceStarted < duration)
        {
            timeSinceStarted += Time.deltaTime;
            float t = timeSinceStarted / duration; // Normalized time (0 to 1)

            // Calculate position with linear interpolation
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, t);

            // Add height using a parabolic function (highest at t=0.5)
            float height = heightMultiplier * Mathf.Sin(t * Mathf.PI); // Peak height of 0.25 units
            currentPosition.y += height;

            // Apply the position
            checkerPiece.transform.localPosition = currentPosition;

            yield return null;
        }

        // Ensure final position is exactly at destination
        checkerPiece.transform.localPosition = targetPosition;
    }

    #endregion

    #region Segment 3 Part 3 (Karoake)

    [Header("Voiddeck - Transition Chess to Karaoke Corner")]
    [SerializeField] GameObject radio;
    [SerializeField] GameObject firstToKaraokeCornerHotspot;
    [SerializeField] GameObject KaraokeMic;
    [SerializeField] GameObject TVScreen;
    [SerializeField] GameObject TVScreen2;
    private bool KaraokeTransitionAfterFirstTP = false;
    private bool hasFinishedSinging = false;
    private float narrationPlaybackPosition = 0f;
    private float tvPlaybackPosition = 0f;
    private bool firstTimeSing = true;

    IEnumerator MovingFromChessToKaraokeCorner()
    {
        // NPC lose animation
        checkersNPC.GetComponent<Animator>().SetTrigger("lose");

        yield return new WaitForSeconds(5f); // lose animation is around 5 secs

        checkersNPC.GetComponent<Animator>().SetTrigger("IdleSeat");

        yield return new WaitForSeconds(0.5f);

        checkersNPC.GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        checkersNPC.GetComponent<Animator>().SetTrigger("Talking");

        playerAudioSource.GetComponent<AudioSource>().clip = narrationAudioClips_2[4];
        playerAudioSource.GetComponent<AudioSource>().Play();

        //playerAudioSource.GetComponent<AudioSource>().PlayOneShot(narrationAudioClips_2[4]);

        yield return new WaitForSeconds(narrationAudioClips_2[4].length);

        checkersNPC.GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        radio.SetActive(false);

        narrationAudioSource.PlayOneShot(narrationAudioClips_2[5]);

        yield return new WaitForSeconds(narrationAudioClips_2[5].length);

        playerAudioSource.PlayOneShot(narrationAudioClips_2[6]);

        yield return new WaitForSeconds(narrationAudioClips_2[6].length);

        checkersNPC.GetComponent<Animator>().ResetTrigger("BackToIdle");

        checkersNPC.GetComponent<Animator>().SetTrigger("BackToIdle");

        KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(1);

        yield return StartCoroutine(SetNPCToPlayPos(KaraokeCornerNPCs[0], 220, 1));

        KaraokeCornerNPCs[0].GetComponent<Animator>().ResetTrigger("TalkBegin");
        KaraokeCornerNPCs[0].GetComponent<Animator>().ResetTrigger("Talking");
        KaraokeCornerNPCs[0].GetComponent<Animator>().ResetTrigger("TalkEnd");

        KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(1.2f);

        //KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("Talking");

        // nancy
        //narrationAudioSource.PlayOneShot(narrationAudioClips_2[8], 0.4f);
        //yield return new WaitForSeconds(narrationAudioClips_2[8].length);

        //KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("TalkEnd");

        //yield return new WaitForSeconds(2f);

        lastRoutine = null;

        playerAudioSource.PlayOneShot(narrationAudioClips_2[7]);
        yield return new WaitForSeconds(narrationAudioClips_2[7].length);

        taichiAudioSource.GetComponent<AudioSource>().Stop();

        // Fade screen
        WhiteFadeEffect.FadeOut();
        playerAudioSource.PlayOneShot(narrationAudioClips_2[8]);
        yield return new WaitForSeconds(narrationAudioClips_2[8].length);
        WhiteFadeEffect.FadeIn();

        playerTeleport.SetCurrentHotspotIndex(-1); // reset hotspot index

        checkersNPC.SetActive(false);
        CheckerPieces.SetActive(false);
        
        firstCheckersHotspot.SetActive(false);
        playerTeleport.MovingToKaraokeCorner = true;
        playerTeleport.MovingToCheckersChair = false;

        firstToKaraokeCornerHotspot.SetActive(true);

        //GameManager.instance.ShowAlert(narration_2[2]);
        //promptManager.ShowPrompt(sceneID, 2);
    }

    public void PlayKaraokeCornerTransition()
    {
        StartCoroutine(KaraokeCornerTransition());
    }

    IEnumerator SetNPCToPlayPos(GameObject NPCToRotate,float TargetRotationY,float NPCRotationTime)
    {
        float startRotationY = NPCToRotate.transform.GetChild(0).localRotation.eulerAngles.y;
        float targetRotationY = TargetRotationY;
        currentRotationTime = 0f;

        while (currentRotationTime < NPCRotationTime)
        {
            currentRotationTime += Time.deltaTime;
            float t = currentRotationTime / NPCRotationTime;

            // Create a new rotation with the lerped y value
            Quaternion newRotation = Quaternion.Euler(
                 NPCToRotate.transform.GetChild(0).localRotation.eulerAngles.x,
                 Mathf.LerpAngle(startRotationY, targetRotationY, t),
                 NPCToRotate.transform.GetChild(0).localRotation.eulerAngles.z
            );

            NPCToRotate.transform.GetChild(0).localRotation = newRotation;

            yield return null;
        }

        // Ensure we end at exactly the target rotation
        NPCToRotate.transform.localRotation = Quaternion.Euler(
            NPCToRotate.transform.localRotation.eulerAngles.x,
            targetRotationY,
            NPCToRotate.transform.localRotation.eulerAngles.z
        );
    }
    IEnumerator KaraokeCornerTransition()
    {
        //GameManager.instance.ShowAlert(narration_2[3]);
          //promptManager.ShowPrompt(sceneID, 4);

        StartCoroutine(SetNPCToPlayPos(KaraokeCornerNPCs[0].gameObject, 300, 1));
                
        //KaraokeMic.GetComponent<MicController>().toBeginKaraokeMinigame = true;
        //KaraokeMic.GetComponent<MicController>().active = true;
        KaraokeMic.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
        ControllerInteractionsManager.instance.rightGrabInteractor.ForceSelect(KaraokeMic.GetComponent<GrabInteractable>());

        narrationAudioSource.clip = narrationAudioClips_2[9];
        PlayKaraoke();
        lastRoutine = null;

        yield return null;
    }

    //
    public void PlayKaraoke()
    {
        for(int i = 1; i < 4; i++)
        {
            KaraokeCornerNPCs[i].GetComponent<Animator>().SetTrigger("TalkEnd");
            StartCoroutine(SetNPCToPlayPos(KaraokeCornerNPCs[i],0,1));
        }

        TVScreen.SetActive(true);
        TVScreen2.SetActive(true);

        //if (MainMenuManager.isGenderMale == false)
        //    TVScreen.GetComponent<AudioSource>().volume = 0.3f;

        TVScreen.GetComponent<AudioSource>().volume = Mathf.Lerp(0, 0.3f, 1);
        
        GameManager.instance.HideAlert();
        KaraokeCornerNPCs[0].GetComponent<Animator>().SetBool("isArmsUpCheering", true);
        KaraokeCornerNPCs[1].GetComponent<Animator>().SetBool("isCheering", true);
        KaraokeCornerNPCs[2].GetComponent<Animator>().SetBool("isClapping", true);
        KaraokeCornerNPCs[3].GetComponent<Animator>().SetBool("isDancing", true);
        if (narrationAudioSource.isPlaying && !firstTimeSing)
        {
            narrationAudioSource.volume = 1.0f;
        }
    }
    
    public void PlayMicOffFace()
    {
        if (lastRoutine != null) StopCoroutine(lastRoutine);
        lastRoutine = null; // Reset the reference to allow starting again
        // Store current playback position before pausing
        if (narrationAudioSource.isPlaying)
        {
            narrationPlaybackPosition = narrationAudioSource.time;
            narrationAudioSource.volume = 0;
        }
        //GameManager.instance.ShowAlert(narration_2[5]);
        promptManager.ShowPrompt(sceneID, 5);
        KaraokeCornerNPCs[0].GetComponent<Animator>().SetBool("isArmsUpCheering", false);
        KaraokeCornerNPCs[1].GetComponent<Animator>().SetBool("isCheering", false);
        KaraokeCornerNPCs[2].GetComponent<Animator>().SetBool("isClapping", false);
        KaraokeCornerNPCs[3].GetComponent<Animator>().SetBool("isDancing", false);
    }

    private void PlayAfterSingingTransition()
    {
        lastRoutine = StartCoroutine(AfterSingingTransition());
    }

    private IEnumerator AfterSingingTransition()
    {
        KaraokeCornerNPCs[0].GetComponent<Animator>().SetBool("isArmsUpCheering", false);
        KaraokeCornerNPCs[1].GetComponent<Animator>().SetBool("isCheering", false);
        KaraokeCornerNPCs[2].GetComponent<Animator>().SetBool("isClapping", false);
        KaraokeCornerNPCs[3].GetComponent<Animator>().SetBool("isDancing", false);

        for (int i = 1; i < 4; i++)
        {
            KaraokeCornerNPCs[i].GetComponent<Animator>().ResetTrigger("TalkBegin");
            KaraokeCornerNPCs[i].GetComponent<Animator>().ResetTrigger("Talking");
            KaraokeCornerNPCs[i].GetComponent<Animator>().SetTrigger("TalkBegin");
            yield return new WaitForSeconds(0.7f);
            KaraokeCornerNPCs[i].GetComponent<Animator>().SetTrigger("Talking");
        }

        StartCoroutine(SetNPCToPlayPos(KaraokeCornerNPCs[2], 270, 1));

        StartCoroutine(SetNPCToPlayPos(KaraokeCornerNPCs[3], 90, 1));

        KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("Talking");

        // nancy
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[10], 0.4f);
        yield return new WaitForSeconds(narrationAudioClips_2[10].length);

        KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("TalkEnd");

        narrationAudioSource.PlayOneShot(narrationAudioClips_2[11]);
        yield return new WaitForSeconds(narrationAudioClips_2[11].length);

        KaraokeCornerNPCs[0].GetComponent<Animator>().ResetTrigger("TalkBegin");
        KaraokeCornerNPCs[0].GetComponent<Animator>().ResetTrigger("Talking");
        KaraokeCornerNPCs[0].GetComponent<Animator>().ResetTrigger("TalkEnd");

        yield return new WaitForSeconds(0.5f);

        KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("Talking");

        // nancy
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[12], 0.4f);
        yield return new WaitForSeconds(narrationAudioClips_2[12].length);

        KaraokeCornerNPCs[0].GetComponent<Animator>().SetTrigger("TalkEnd");

        //narrationAudioSource.PlayOneShot(narrationAudioClips_2[7]);

        //yield return new WaitForSeconds(narrationAudioClips_2[7].length);

        yield return new WaitForSeconds(2f);

        GameManager.instance.whiteFadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("PresentGoodBedroomPart2", LoadSceneMode.Single);


    }

    #endregion

    #region Segment 4 (Bedroom Part 2)
        [Header("Bedroom Part 2")]
        [SerializeField] private AudioSource bedroomAudioSource;
        [SerializeField] private AudioClip bedroomBGM;
        [SerializeField] GameObject MedicineBottle;
        [SerializeField] Outline MedicineOutline;
        [SerializeField] GameObject PhotoFrame;
        [SerializeField] Outline PhotoFrameOutline;

        [SerializeField] private Animator capAnimator;
        [SerializeField] private string capPopTrigger = "PopOff";
        [SerializeField] private GameObject pillPrefab;
        [SerializeField] private Transform pillSpawnPoint;
        [SerializeField] private CapMover capMover;
        public void PlaySegment4Part1()
        {
            lastRoutine = StartCoroutine(Segment4Part1());
        }

        IEnumerator Segment4Part1()
        {
            GameManager.instance.whiteFadePanel.GetComponent<Animator>().SetTrigger("FadeIn");
            yield return new WaitForSeconds(3f);
            bedroomAudioSource.GetComponent<AudioSource>().clip = bedroomBGM;
            bedroomAudioSource.GetComponent<AudioSource>().loop = true;
            bedroomAudioSource.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(1f);
            narrationAudioSource.Stop();
            narrationAudioSource.PlayOneShot(narrationAudioClips_3[2]); // VO20
            yield return new WaitForSeconds(narrationAudioClips_3[2].length);

            MedicineBottle.GetComponent<Grabbable>().enabled = true;
            MedicineBottle.GetComponent<GrabInteractable>().enabled = true;
            MedicineBottle.GetComponent<PhysicsGrabbable>().enabled = true;
            MedicineBottle.GetComponent<ForceStayGrabbed>().enabled = true;
            MedicineBottle.GetComponent<MedicineBottle>().enabled = true;

            yield return null;
            sceneID = SceneID.Bedroom;

            // Show medicine prompt
            MedicineOutline.enabled = true;

            // Allow player to consume medicine
            GameManager.instance.toConsumeMedicine = true;

            // Enable grabbing the bottle
            GameManager.instance.medicine.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
        }

        public void OnMedicineBottleGrabbed()
        {
            if (capAnimator != null)
                capAnimator.SetTrigger(capPopTrigger);

            // slight delay on the cap
            StartCoroutine(MoveCapAfterDelay(0.5f));
        }

        private IEnumerator MoveCapAfterDelay(float delay)
        {
            // wait for anim
            yield return new WaitForSeconds(delay);

            // Stop animator 
            if (capAnimator != null)
                capAnimator.enabled = false;

            // Move the cap to the table
            var capMover = GameManager.instance.medicine.GetComponentInChildren<CapMover>();
            if (capMover != null)

            {
                capMover.MoveToTable();
                capMover.transform.SetParent(null); //detach
            }
        yield return new WaitForSeconds(1f);
        
        SpawnPill();
        }

        public void SpawnPill()
        {
            // Pill inside the bottle
            GameObject pill = Instantiate(pillPrefab, pillSpawnPoint.position, pillSpawnPoint.rotation);
            GameManager.instance.pill = pill;

            // Detect which hands hod the bottle
            int handIndex = ControllerInteractionsManager.instance.ObjInWhichHand(GameManager.instance.medicine);

            // choose where pill suppose to go
            Transform targetPalm = (handIndex == 0) ? GameManager.instance.rightPalm   // bottle in left hand, pill to right palm
            : GameManager.instance.leftPalm;

            // Move the pill into the palm
            StartCoroutine(MovePillToHand(pill, targetPalm, handIndex));
        }
        private IEnumerator CheckPillDistance()
        {
            // Loop continue as the pill exists and the player still needs to eat it
            while (GameManager.instance.pill != null && GameManager.instance.toConsumeMedicine)
            {
                //distance between the pill and face
                float dist = Vector3.Distance(
                    GameManager.instance.pill.transform.position,
                    GameManager.instance.centerEyeAnchor.transform.position);

                if (dist < 0.15f)
                {
                    ConsumePill();
                    yield break;  //stop 
                }
                yield return null;
            }
        }

        private void ConsumePill()
        {
            Destroy(GameManager.instance.pill);
            GameManager.instance.pill = null;

            GameManager.instance.toConsumeMedicine = false;

            MedicineTaken();
            GameManager.instance.OnMedicineConsumed.Invoke();
        }
        private IEnumerator MovePillToHand(GameObject pill, Transform targetPalm, int handIndex, float height = 0.2f, float duration = 1f)
        {
            // take start and target positions
            Vector3 start = pill.transform.position;
            Vector3 target = targetPalm.position;
            float elapsed = 0f;


            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;

                // move pill
                Vector3 current = Vector3.Lerp(start, target, t);

                // arc like checkers
                current.y += Mathf.Sin(t * Mathf.PI) * height;

                // position
                pill.transform.position = current;
                yield return null;
            }

        // pill to hand
        pill.transform.position = targetPalm.position + targetPalm.up * 0.02f;
        pill.transform.rotation = targetPalm.rotation; // optional alignment
        pill.transform.SetParent(targetPalm); // stays consistent

        // auto grab
        var grabInteractable = pill.GetComponent<GrabInteractable>();
            if (handIndex == 0) // bottle lfet hand so pill on the right vice versa
                ControllerInteractionsManager.instance.rightGrabInteractor.ForceSelect(grabInteractable);
            else
                ControllerInteractionsManager.instance.leftGrabInteractor.ForceSelect(grabInteractable);

            var forceGrab = pill.GetComponent<ForceStayGrabbed>();
            if (forceGrab != null)
                forceGrab.SetForceGrabActive(true);

            StartCoroutine(CheckPillDistance());

        }

        public void MedicineTaken()
        {
            StopPrevDialogue();
            MedicineOutline.enabled = false;

            // Reset flag
            GameManager.instance.toConsumeMedicine = false;
            GameManager.instance.medicine.GetComponent<ForceStayGrabbed>().SetForceGrabActive(false);

            Destroy(GameManager.instance.medicine);
            GameManager.instance.medicine = null;

            // Next step
            StartCoroutine(AfterMedicineTaken());
        }

        IEnumerator AfterMedicineTaken()
        {
            yield return new WaitForSeconds(3f);

            PhotoFrameOutline.enabled = true;

        var photoFrame = GameManager.instance.photoFrame;
        photoFrame.GetComponent<Grabbable>().enabled = true;
        photoFrame.GetComponent<GrabInteractable>().enabled = true;
        photoFrame.GetComponent<PhysicsGrabbable>().enabled = true;
        photoFrame.GetComponent<ForceStayGrabbed>().enabled = true;


        var grab = GameManager.instance.photoFrame.GetComponent<ForceStayGrabbed>();
            grab.SetForceGrabActive(true);


            GameManager.instance.toLookAtObjective = true;
        }

        public void PhotoFrameViewed()
        {
            StopPrevDialogue();
            PhotoFrameOutline.enabled = false;

            StartCoroutine(PhotoFrameSequence());
        }

        IEnumerator PhotoFrameSequence()
        {
            narrationAudioSource.Stop();
            narrationAudioSource.PlayOneShot(narrationAudioClips_3[3]); // VO21
            yield return new WaitForSeconds(narrationAudioClips_3[3].length);


            yield return new WaitForSeconds(1.5f);
            PlayEndOfScenario();
        }
        #endregion

    public void PlayEndOfScenario()
    {
        StartCoroutine(EndOfScenario());
    }


    IEnumerator EndOfScenario()
    {
        //reference to anim and image componenet
        var anim = GameManager.instance.fadePanel.GetComponent<Animator>();
        var img = GameManager.instance.fadePanel.GetComponent<UnityEngine.UI.Image>();

        anim.SetTrigger("FadeOut");

        //match fade out
        yield return new WaitForSeconds(4f);

        // stop animator and make it black
        anim.enabled = false;
        img.color = Color.black;

        yield return new WaitForSeconds(2f);

        GameManager.instance.goodbyeText.SetActive(true);
        GameManager.instance.SetCanRestart();

        yield return new WaitForSeconds(10f);

        GameManager.instance.goodbyeText2.SetActive(true); // "press trigger button to restart game"
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTeleport.currentScene = ScenarioID.PresentGood;

        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            SetupNarrationBathroomLivingRoom();
            promptManager.activeScenario = scenarioID;
            sceneID = SceneID.Bathroom;

            foreach (Transform Items in BathroomItems.transform)
            {
                if (Items.GetComponent<Grabbable>() != null) Items.GetComponent<Grabbable>().enabled = false;
                if (Items.GetComponent<PhysicsGrabbable>() != null) Items.GetComponent<PhysicsGrabbable>().enabled = false;
                if (Items.GetComponent<GrabInteractable>() != null) Items.GetComponent<GrabInteractable>().enabled = false;
            }
            //PlaySegment1Part1();
            //StartCoroutine(Segment1Part3_1());
            //secondPhone.GetComponent<MeshRenderer>().enabled = false;
            //secondPhone.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;

            //StartCoroutine(Segment1Part3_3());

            //PlaySegment1Part4();
        }
        else if (sceneToPlay == SceneToPlay.LivingRoom)
        {
            SetupNarrationBathroomLivingRoom();
            promptManager.activeScenario = scenarioID;  
            sceneID = SceneID.LivingRoom;
            SetupSegment1Part2_1(); 
        }
        else if (sceneToPlay == SceneToPlay.Bedroom)
        {
            SetupNarrationBedroom();
            promptManager.activeScenario = scenarioID;
            sceneID = SceneID.Bedroom;
            PlaySegment2Part1();
        }
        else if (sceneToPlay == SceneToPlay.BedroomPart2)
        {
            SetupNarrationBedroom();
            promptManager.activeScenario = scenarioID;
            sceneID = SceneID.Bedroom;
            PlaySegment4Part1();
        }




        else if (sceneToPlay == SceneToPlay.Voiddeck)
        {
            SetupNarrationVoiddeck();
            SetupNarrationVoiddeck2();
            promptManager.activeScenario = scenarioID;
            sceneID = SceneID.VoidDeck;
            //StartCoroutine(MovingFromTaichiToCheckers());

            PlaySegment3Part1();

            //StartCoroutine(MovingFromChessToKaraokeCorner());

            // uncomment these 2 lines below and comment out the line above to test out the karaoke part
            //PlayKaraokeCornerTransition();
            //PlayMicOnFace();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            if(AlertHideTimer > 0)
            {
                AlertHideTimer -= Time.deltaTime;
            }

            if (StartGame && PlayStart)
            {
                PlaySegment1Part1();
                PlayStart = false;
                foreach (Transform Items in BathroomItems.transform)
                {
                    if (Items.GetComponent<Grabbable>() != null) Items.GetComponent<Grabbable>().enabled = true;
                    if (Items.GetComponent<PhysicsGrabbable>() != null) Items.GetComponent<PhysicsGrabbable>().enabled = true;
                    if (Items.GetComponent<GrabInteractable>() != null) Items.GetComponent<GrabInteractable>().enabled = true;
                }

            }


            #region Going to living room
            // remove alert after first teleport
            if (!alertRemovedAfterFirstTP)
            {
                if (AlertHideTimer <= 0)
                {
                    if (playerTeleport.GetCurrentHotspotIndex() >= 0) // which means player either at first hotspot toward main door or living room
                    {
                        StopPrevDialogue(); // stop alert text
                        alertRemovedAfterFirstTP = true;
                    }
                }
            }

            if (!canSeeWindow)
            {
                if (playerTeleport.GetCurrentHotspotIndex() == 6)
                {
                    StopPrevDialogue();
                    narrationAudioSource.PlayOneShot(narrationAudioClips_1[2]);
                    canSeeWindow = true;
                }
            }    

            // check here when player reaches sofa, start segment1Part3
            if (toGoLivingRoom)
            {
                if (GameManager.instance.IsPlayerWithinPosition(-6f, -3.7f, -4f, -1.7f))
                {
                    toGoLivingRoom = false;  
                    PlaySegment1Part3_1();
                }
            }

            if (!alertAtLastTeleport)
            {
                if (playerTeleport.GetCurrentHotspotIndex() == playerTeleport.MoveToLivingRoomHotspots.Length - 1)
                {
                    GameManager.instance.ShowAlert(narration_1[2]); // only show pick up phone after player reached last hotspot
                    alertAtLastTeleport = true;
                }
            }

            #endregion
        }
        else if(sceneToPlay == SceneToPlay.Voiddeck)
        {
            if(!KaraokeTransitionAfterFirstTP && playerTeleport.MovingToKaraokeCorner)
            {
                if (playerTeleport.GetCurrentHotspotIndex() == 0)
                {
                    checkersNPC.SetActive(false);

                    KaraokeTransitionAfterFirstTP = true;
                }
            }

            if (((MainMenuManager.isGenderMale && TVScreen.GetComponent<VideoPlayer>().time >= 16f) ||
                !MainMenuManager.isGenderMale
                /*(MainMenuManager.isGenderMale == false && TVScreen.GetComponent<VideoPlayer>().time >= 17f)*/)
                && firstTimeSing && TVScreen.GetComponent<VideoPlayer>().isPlaying)
            {
                narrationAudioSource.Play();
                TVScreen.GetComponent<VideoPlayer>().Play();
                TVScreen2.GetComponent<VideoPlayer>().Play();
                firstTimeSing = false;
            }

            if (narrationAudioSource.clip != null &&
             narrationAudioSource.time >= narrationAudioSource.clip.length - 1f && !firstTimeSing && !hasFinishedSinging)
            {
                hasFinishedSinging = true;
                //KaraokeMic.GetComponent<MicController>().SetMicDetectionActive(false);
                KaraokeMic.GetComponent<ForceStayGrabbed>().SetForceGrabActive(false);
                PlayAfterSingingTransition();
            }
        }
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

    void PlayAudioAndNarration(AudioClip clipToPlay, string narrationText) // use if text is to stay on screen
    {
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(clipToPlay);
        GameManager.instance.ShowAlert(narrationText);
    }

    void PlayAudioAndNarration(AudioClip clipToPlay, string narrationText, float clipLength) // use if text is to fade after time
    {
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(clipToPlay);
        GameManager.instance.ShowAlert(narrationText, clipLength);
    }

    void PlayAudioAndNarration(AudioClip clipToPlay, string narrationText, Color textColor) // use if text is to be different color
    {
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(clipToPlay);
        GameManager.instance.ShowAlert(narrationText, textColor);
    }

    void PlayAudioAndNarration(AudioClip clipToPlay, string narrationText, float clipLength, Color textColor) // use if text is to fade after time and be different color
    {
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(clipToPlay);
        GameManager.instance.ShowAlert(narrationText, clipLength, textColor);
    }

    public void TriggerStartGame()
    {
        StartGame = true;
    }
}
