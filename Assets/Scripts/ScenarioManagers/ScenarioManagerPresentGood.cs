using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;
using UnityEngine.UIElements;

public class ScenarioManagerPresentGood : MonoBehaviour
{
    [SerializeField] SceneToPlay sceneToPlay = SceneToPlay.Bathroom;
    enum SceneToPlay
    {
        Bathroom,
        Voiddeck
    }

    [Header("Narration Variables")]
    [SerializeField] AudioSource narrationAudioSource;

    // for bathroom and living room scene
    [SerializeField] AudioClip[] narrationAudioClips_1;
    string[] narration_1 = new string[30];

    // for voiddeck scene
    [SerializeField] AudioClip[] narrationAudioClips_2;
    string[] narration_2 = new string[30];

    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject firstTeleportHotspot;

    [Header("Player Movement")]
    [SerializeField] PlayerTeleport playerTeleport;

    bool alertAtLastTeleport = false;

    bool canSeeWindow = false; // if can see window then can say weather looks good

    Coroutine lastRoutine = null;

    [SerializeField] private float MaxAlertHideTimer = 3;

    private float AlertHideTimer = 0;

    void SetupNarrationBathroomLivingRoom()
    {
        narration_1[0] = "Open the door and head to the sofa";
        narration_1[1] = "Press TRIGGER button to move to highlighted circle";
        narration_1[2] = "Someone is calling,pick up the call";
        narration_1[3] = "Open gate and leave to void deck by interacting with gate knob";
    }

    void SetupNarrationVoiddeck()
    {
        narration_2[0] = "[Pick up highlighted othello piece and place it on outlined spot]";
        narration_2[1] = "[Look at highlighted othello NPC to start othello minigame]";
        narration_2[2] = "[Press TRIGGER button to move to highlighted circle]";
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
        PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
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
    [SerializeField] GameObject mug;
    [SerializeField] GameObject toothpaste;
    [SerializeField] GameObject toothbrush;
    [SerializeField] GameObject soap;
    [SerializeField] GameObject comb;
    bool toGoLivingRoom = false;
    bool alertRemovedAfterFirstTP = false;

    public void PlaySegment1Part2()
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(Segment1Part2());
    }

    IEnumerator Segment1Part2()
    {
        knob.GetComponent<Outline>().enabled = true;

        GameManager.instance.ShowAlert(narration_1[0]);

        // can open bathroom door from here
        bathroomDoor.AllowDoorOpen();

        yield return null;
    }

    public void BathroomDoorOpen() // called in UnityEvent in bathroom door
    {
        StopPrevDialogue();

        AlertHideTimer = MaxAlertHideTimer;

        GameManager.instance.ShowAlert(narration_1[1]); 

        knob.GetComponent<Outline>().enabled = false;

        mug.GetComponent<Outline>().enabled = false;

        toothpaste.GetComponent<Outline>().enabled = false;

        toothbrush.GetComponent<Outline>().enabled = false;

        soap.GetComponent<Outline>().enabled = false;

        comb.GetComponent<Outline>().enabled = false;

        firstTeleportHotspot.SetActive(true); // enable first teleport hotspot

        playerTeleport.MovingToLivingRoom = true;

        toGoLivingRoom = true;
    }

    #endregion

    #region Segment 1 Part 3 (Living room)
    [Header("In living room")]
    [SerializeField] GameObject phone;
    [SerializeField] GameObject secondPhone;
    [SerializeField] MobilePhone mobilePhone;
    [SerializeField] MobilePhone secondmobilePhone;
    
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
        phone.GetComponent<Outline>().enabled = true;

        yield return new WaitForSeconds(2.5f + 1.1f);

        GameManager.instance.toPickUpPhone = true;
    }

    public void PhonePickedUp() // called in UnityEvent in MobilePhone
    {
        StopPrevDialogue();
        phone.GetComponent<Outline>().enabled = false;
        phone.GetComponent<ForceStayGrabbed>().SetActive(true);
        GlassesPutOn();
    }

    public void GlassesPutOn() // called in UnityEvent in PlayerFace
    {
        StopPrevDialogue();
        GameManager.instance.canAnswerPhone = true;
        ControllerInteractionsManager.instance.autoDropItems = false; // no more dropping after glasses put on
        //GameManager.instance.ShowAlert(narration_1[12]);
    }

    public void PhoneAnswered() // called in UnityEvent in MobilePhone
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(Segment1Part3_3());
    }

    IEnumerator Segment1Part3_3() // Dialogue between player and caller
    {
        yield return new WaitForSeconds(3f); // the call takes a few second to be answered so wait a few seconds first

        ////PlayAudioAndNarration(narrationAudioClips_1[4], narration_1[13], 3f);
        //narrationAudioSource.Stop();
        //narrationAudioSource.PlayOneShot(narrationAudioClips_1[2]);
        //yield return new WaitForSeconds(3f + 1.1f);

        ////GameManager.instance.ShowAlert(narration_1[14], 8f);
        //yield return new WaitForSeconds(8f + 1.1f);

        //PlayAudioAndNarration(narrationAudioClips_1[5], narration_1[15], narrationAudioClips_1[4].length);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[3]);
        yield return new WaitForSeconds(narrationAudioClips_1[3].length);

        // play phone hang up here
        mobilePhone.SetPhoneHangUp();

        yield return new WaitForSeconds(3f);

        phone.GetComponent<ForceStayGrabbed>().SetActive(false); // drops phone
        phone.GetComponent<Grabbable>().enabled = false; // ensures that phone cannot be grabbed again
        phone.SetActive(false);

        secondmobilePhone.SetPhoneHangUp();

        secondPhone.SetActive(true);

        playerTeleport.SetCurrentHotspotIndex(-1); // reset back to prepare for move to main door

        PlaySegment1Part4();
    }

    #endregion

    #region Segment 1 Part 4(From living room to main door)

    [Header("Living room to main door")]
    [SerializeField] AudioSource RingingSoundSource;
    [SerializeField] GameObject firstToDoorHotspot;
    [SerializeField] private DoorKnob MainGate;
    [SerializeField] private Outline MainGateOutline;

    public void PlaySegment1Part4()
    {
        lastRoutine = StartCoroutine(Segment1Part4());
    }

    IEnumerator Segment1Part4()
    {
        yield return new WaitForSeconds(2f); // delay between phone hang up and door ring

        RingingSoundSource.Play(); // need ring sfx

        GameManager.instance.ShowAlert(narration_1[1]); // shows prompt to press grip button to move towards gate

        playerTeleport.MovingToMainDoor = true;

        firstToDoorHotspot.SetActive(true);
    }

    // used as unity event in player teleport
    public void OpenDoorPrompt()
    {
        StopPrevDialogue();
        StartCoroutine(Segment1Part5());
    }

    #endregion

    #region Segment 1 Part 5 (Interaction with friends outside main door)

    [Header("At main door")]
    [SerializeField] private GameObject[] MaleFriends;
    [SerializeField] private GameObject[] FemaleFriends;
    private GameObject[] friends;

    public void PlaySegment1Part5()
    {
        lastRoutine = StartCoroutine(Segment1Part5());
    }

    IEnumerator Segment1Part5()
    {
        if (MainMenuManager.isGenderMale)
        {
            friends = MaleFriends;

            foreach(var friend in MaleFriends)
            {
                friend.SetActive(true);
            }
        }
        else
        {
            friends = FemaleFriends;

            foreach (var friend in FemaleFriends)
            {
                friend.SetActive(true);
            }
        }

        friends[0].GetComponent<Animator>().SetTrigger("Wave");

        yield return new WaitForSeconds(1f);

        friends[1].GetComponent<Animator>().SetTrigger("Wave");

        yield return new WaitForSeconds(3.2f); // make sure waving animation is done first

        friends[0].GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(1.2f);

        friends[0].GetComponent<AudioSource>().clip = narrationAudioClips_1[4];

        friends[0].GetComponent<AudioSource>().Play();

        friends[0].GetComponent<Animator>().SetTrigger("Talking");

        yield return new WaitForSeconds(narrationAudioClips_1[4].length);

        friends[0].GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        GameManager.instance.ShowAlert(narration_1[3]);

        MainGateOutline.enabled = true;

        MainGate.AllowDoorOpen();
    }

    public void OffMainGateOutline()
    {
        MainGateOutline.enabled = false;
    }

    public void PlayMainGateOpen()
    {
        lastRoutine = StartCoroutine(MainGateOpen());
    }

    IEnumerator MainGateOpen()
    {
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("PresentGoodVoiddeck", LoadSceneMode.Single); 
    }

    #endregion

    #region Segment 2 Part 1 (Voiddeck, Tai chi)

    [Header("Voiddeck - Taichi")]
    [SerializeField]
    TaiChiManager taiChiManager;
    [SerializeField] GameObject taichiInstructor;

    void PlaySegment2Part1()
    {
        PostProcessingController.instance.UsingGlasses(true); // no blur effect
        StartCoroutine(playTaichi());
    }

    IEnumerator playTaichi()
    {
        yield return new WaitForSeconds(4f); // screen fade in timing

        taichiInstructor.GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        taichiInstructor.GetComponent<Animator>().SetTrigger("Talking");

        taichiInstructor.GetComponent<AudioSource>().clip = narrationAudioClips_2[0];

        taichiInstructor.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(narrationAudioClips_2[0].length);

        taichiInstructor.GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        taichiInstructor.GetComponent<TaiChiInstructor>().NextPose();

        yield return new WaitForSeconds(2.8f);

        GameManager.instance.taiChiAnimations[1].NextPose();

        GameManager.instance.taiChiAnimations[2].NextPose();

        taiChiManager.startSegment1();
    }

    public void playnextTaichiPose()
    {
        taiChiManager.nextTaichiPose();
    }

    public void TaichiFinished() // Event called in Taichi instructor
    {
        StartCoroutine(MovingFromTaichiToChess());
    }
    #endregion

    [Header("Voiddeck - Transition Taichi to Chess")]
    [SerializeField] GameObject taichiNPC;
    [SerializeField] GameObject chessNPC;
    [SerializeField] GameObject teleportPoint;
    [SerializeField] GameObject player;
    [SerializeField] GameObject FirstPlayerPieceDestination;
    [SerializeField] GameObject SecondPlayerPieceDestination;
    [SerializeField] GameObject FirstPlayerPiece;
    [SerializeField] LookDetection lookDetection;
    [SerializeField] float ChessNPCRotationTime = 2;
    [SerializeField] GameObject firstOthelloHotspot;
    private float currentRotationTime;
    int times;

    IEnumerator MovingFromTaichiToChess()
    {
        times++;

        chessNPC.GetComponent<Animator>().SetTrigger("IdleSeat");

        yield return new WaitForSeconds(0.5f);

        chessNPC.GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        chessNPC.GetComponent<Animator>().SetTrigger("Talking");

        chessNPC.GetComponent<AudioSource>().clip = narrationAudioClips_2[1];

        chessNPC.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(narrationAudioClips_2[1].length);

        chessNPC.GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        GameManager.instance.ShowAlert(narration_2[1]);

        chessNPC.GetComponent<Outline>().enabled = true;

        yield return new WaitForSeconds(1f);

        lookDetection.enabled = true;
    }

    public void StartWalkingToOthello()
    {
        StopPrevDialogue(); // hide alert text
        lookDetection.enabled = false;
        firstOthelloHotspot.SetActive(true);
        playerTeleport.MovingToOthelloChair = true;
        chessNPC.GetComponent<Animator>().ResetTrigger("IdleSeat");
        chessNPC.GetComponent<Animator>().ResetTrigger("TalkBegin");
        chessNPC.GetComponent<Animator>().ResetTrigger("Talking");
        chessNPC.GetComponent<Animator>().ResetTrigger("TalkEnd");
        StartCoroutine(SetOthelloNPCToPlayPos());
    }

    IEnumerator SetOthelloNPCToPlayPos()
    {
        float startRotationY = chessNPC.transform.localRotation.eulerAngles.y;
        float targetRotationY = 280f;
        currentRotationTime = 0f;

        while (currentRotationTime < ChessNPCRotationTime)
        {
            currentRotationTime += Time.deltaTime;
            float t = currentRotationTime / ChessNPCRotationTime;

            // Create a new rotation with the lerped y value
            Quaternion newRotation = Quaternion.Euler(
                chessNPC.transform.localRotation.eulerAngles.x,
                Mathf.LerpAngle(startRotationY, targetRotationY, t),
                chessNPC.transform.localRotation.eulerAngles.z
            );

            chessNPC.transform.localRotation = newRotation;

            yield return null;
        }

        // Ensure we end at exactly the target rotation
        chessNPC.transform.localRotation = Quaternion.Euler(
            chessNPC.transform.localRotation.eulerAngles.x,
            targetRotationY,
            chessNPC.transform.localRotation.eulerAngles.z
        );

        chessNPC.GetComponent<Animator>().SetTrigger("BackToIdle");
    }
    
    public void PlayOthelloTransition()
    {
        taichiNPC.SetActive(false);
        FirstPlayerPieceDestination.SetActive(true);
        FirstPlayerPiece.GetComponent<Outline>().enabled = true;
        GameManager.instance.ShowAlert(narration_2[0]);
    }

    [Header("Voiddeck - Chess")]
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject FirstFriendOthelloPiece;
    [SerializeField] GameObject SecondPlayerOthelloPiece;
    [SerializeField] GameObject SecondFriendOthelloPiece;
    [SerializeField] GameObject FirstDestination;
    [SerializeField] GameObject SecondDestination;
    
    public void TriggerNPC()
    {
        StopPrevDialogue(); // hides alert
        NPC.GetComponent<Animator>().SetTrigger("move");
        StartCoroutine(MovePiece());
    }

    IEnumerator MovePiece()
    {
        yield return new WaitForSeconds(2f);
        float timeSinceStarted = 0f;
        float duration = 2f; // Total movement time

        Vector3 startPosition = FirstFriendOthelloPiece.transform.localPosition;
        Vector3 targetPosition = FirstDestination.transform.localPosition;

        while (timeSinceStarted < duration)
        {
            timeSinceStarted += Time.deltaTime;
            float t = timeSinceStarted / duration; // Normalized time (0 to 1)

            // Calculate position with linear interpolation
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, t);

            // Add height using a parabolic function (highest at t=0.5)
            float height = 0.25f * Mathf.Sin(t * Mathf.PI); // Peak height of 0.5 units
            currentPosition.y += height;

            // Apply the position
            FirstFriendOthelloPiece.transform.localPosition = currentPosition;

            yield return null;
        }

        // Ensure final position is exactly at destination
        FirstFriendOthelloPiece.transform.localPosition = targetPosition;

        yield return StartCoroutine(FindPiecesToFlip(FirstFriendOthelloPiece)); // wait until flipping animation is done

        // Enable interaction with the second piece
        SecondPlayerOthelloPiece.GetComponent<Outline>().enabled = true;
        SecondPlayerOthelloPiece.GetComponent<Grabbable>().enabled = true;
        SecondPlayerOthelloPiece.GetComponent<GrabInteractable>().enabled = true;
        SecondPlayerOthelloPiece.GetComponent<PhysicsGrabbable>().enabled = true;
        SecondPlayerPieceDestination.SetActive(true);
    }

    public void EndOfChess()
    {
        StopPrevDialogue(); // hides alert
        NPC.GetComponent<Animator>().ResetTrigger("move");
        NPC.GetComponent<Animator>().SetTrigger("move");
        StartCoroutine(FinalMove());
    }

    [Header("Voiddeck - Transition Chess to Reading Corner")]
    [SerializeField]
    GameObject TeleportPointReadingCorner;
    [SerializeField]
    GameObject TVScreen;
    [SerializeField]
    GameObject readingCornerNPCs;
    [SerializeField] GameObject firstToReadingCornerHotspot;

    IEnumerator FinalMove()
    {
        yield return new WaitForSeconds(2f);
        float timeSinceStarted = 0f;
        float duration = 2f; // Total movement time

        Vector3 startPosition = SecondFriendOthelloPiece.transform.localPosition;
        Vector3 targetPosition = SecondDestination.transform.localPosition;

        while (timeSinceStarted < duration)
        {
            timeSinceStarted += Time.deltaTime;
            float t = timeSinceStarted / duration; // Normalized time (0 to 1)

            // Calculate position with linear interpolation
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, t);

            // Add height using a parabolic function (highest at t=0.5)
            float height = 0.25f * Mathf.Sin(t * Mathf.PI); // Peak height of 0.5 units
            currentPosition.y += height;

            // Apply the position
            SecondFriendOthelloPiece.transform.localPosition = currentPosition;

            yield return null;
        }

        // Ensure final position is exactly at destination
        SecondFriendOthelloPiece.transform.localPosition = targetPosition;

        StartCoroutine(MovingFromChessToReadingCorner());
    }

    IEnumerator MovingFromChessToReadingCorner()
    {
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[2]);

        // NPC lose animation
        NPC.GetComponent<Animator>().SetTrigger("lose");

        yield return new WaitForSeconds(6f); // lose animation is around 5 secs

        chessNPC.GetComponent<Animator>().SetTrigger("IdleSeat");

        yield return new WaitForSeconds(0.5f);

        chessNPC.GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        chessNPC.GetComponent<Animator>().SetTrigger("Talking");

        NPC.GetComponent<AudioSource>().clip = narrationAudioClips_2[3];

        NPC.GetComponent<AudioSource>().Play();
        
        yield return new WaitForSeconds(narrationAudioClips_2[3].length);

        chessNPC.GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        chessNPC.GetComponent<Animator>().ResetTrigger("BackToIdle");

        chessNPC.GetComponent<Animator>().SetTrigger("BackToIdle");

        playerTeleport.SetCurrentHotspotIndex(-1); // reset hotspot index

        playerTeleport.MovingToReadingCorner = true;

        firstToReadingCornerHotspot.SetActive(true);
    }

    public void PlayReadingCornerTransition()
    {
        StartCoroutine(ReadingCornerTransition());
    }

    IEnumerator SetReadingCornerNPCToPlayPos(float TargetRotationY)
    {
        float startRotationY = readingCornerNPCs.transform.GetChild(0).localRotation.eulerAngles.y;
        float targetRotationY = TargetRotationY;
        currentRotationTime = 0f;

        while (currentRotationTime < ChessNPCRotationTime)
        {
            currentRotationTime += Time.deltaTime;
            float t = currentRotationTime / ChessNPCRotationTime;

            // Create a new rotation with the lerped y value
            Quaternion newRotation = Quaternion.Euler(
                 readingCornerNPCs.transform.GetChild(0).localRotation.eulerAngles.x,
                 Mathf.LerpAngle(startRotationY, targetRotationY, t),
                 readingCornerNPCs.transform.GetChild(0).localRotation.eulerAngles.z
            );

            readingCornerNPCs.transform.GetChild(0).localRotation = newRotation;

            yield return null;
        }

        // Ensure we end at exactly the target rotation
        chessNPC.transform.localRotation = Quaternion.Euler(
            chessNPC.transform.localRotation.eulerAngles.x,
            targetRotationY,
            chessNPC.transform.localRotation.eulerAngles.z
        );
    }

    IEnumerator ReadingCornerTransition()
    {
        yield return StartCoroutine(SetReadingCornerNPCToPlayPos(-70));

        readingCornerNPCs.transform.GetChild(0).GetComponent<Animator>().SetTrigger("IdleSeat");

        yield return new WaitForSeconds(0.5f);

        readingCornerNPCs.transform.GetChild(0).GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        readingCornerNPCs.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Talking");

        readingCornerNPCs.transform.GetChild(0).GetComponent<AudioSource>().clip = narrationAudioClips_2[4];

        readingCornerNPCs.transform.GetChild(0).GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(narrationAudioClips_2[4].length);

        readingCornerNPCs.transform.GetChild(0).GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(SetReadingCornerNPCToPlayPos(-130));

        readingCornerNPCs.transform.GetChild(0).GetComponent<Animator>().ResetTrigger("BackToIdle");

        readingCornerNPCs.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BackToIdle");

        TVScreen.SetActive(true);

        GameManager.instance.toLookAtObjective = true;
    }

    public void FinishedLookingAtTV()
    {
        StartCoroutine(EndOfScenario());
    }

    IEnumerator EndOfScenario()
    {
        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        GameManager.instance.goodbyeText.SetActive(true);
    }

    private IEnumerator FindPiecesToFlip(GameObject pieceToCheck)
    {
        List<GameObject> piecesToFlip = new List<GameObject>();

        piecesToFlip = GameManager.instance.FindPiecesToFlip(pieceToCheck);

        yield return StartCoroutine(GameManager.instance.AnimateFlippingPieces(piecesToFlip));
    }

    // Start is called before the first frame update
    void Start()
    {
        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            SetupNarrationBathroomLivingRoom();
            PlaySegment1Part1();
        }
        else if (sceneToPlay == SceneToPlay.Voiddeck)
        {
            SetupNarrationVoiddeck();
            PlaySegment2Part1();
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
                if (playerTeleport.GetCurrentHotspotIndex() == 5)
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

        Debug.Log(times);
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
}
