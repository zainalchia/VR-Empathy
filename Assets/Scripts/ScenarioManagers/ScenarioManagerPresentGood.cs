using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.Video;

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
        narration_2[0] = "[Look at highlighted othello NPC to start othello minigame]";
        narration_2[1] = "[Pick up highlighted checkers piece and place it on highlighted spot]";
        narration_2[2] = "[Press TRIGGER button to move to highlighted circle]";
        narration_2[3] = "[Pick up highlighted mic and hold near face]";
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
    [SerializeField] Transform OutsideHouse; // just outside house for friends to walk to
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
        phone.transform.GetChild(0).GetComponent<Outline>().enabled = true;

        yield return new WaitForSeconds(2.5f + 1.1f);

        GameManager.instance.toPickUpPhone = true;
    }

    public void PhonePickedUp() // called in UnityEvent in MobilePhone
    {
        StopPrevDialogue();
        phone.transform.GetChild(0).GetComponent<Outline>().enabled = false;
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
        if (MainMenuManager.isGenderMale)
        {
            friends = MaleFriends;
        }
        else
        {
            friends = FemaleFriends;
        }

        StartCoroutine(MoveFriendsWithDelay(1));

        yield return new WaitForSeconds(3f); // the call takes a few second to be answered so wait a few seconds first

        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[3]);

        yield return new WaitForSeconds(narrationAudioClips_1[3].length);

        // play phone hang up here
        mobilePhone.SetPhoneHangUp();

        yield return new WaitForSeconds(3f);

        phone.GetComponent<ForceStayGrabbed>().SetActive(false); // drops phone
        phone.GetComponent<Grabbable>().enabled = false; // ensures that phone cannot be grabbed again
        phone.SetActive(false);
        secondPhone.SetActive(true);

        secondPhone.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;

        yield return new WaitForSeconds(0.5f);

        secondPhone.transform.GetComponent<MeshRenderer>().enabled = true;

        playerTeleport.SetCurrentHotspotIndex(-1); // reset back to prepare for move to main door

        PlaySegment1Part4();
    }

    IEnumerator MoveFriendsWithDelay(float delayBetweenFriends)
    {
        StartCoroutine(MoveFriendPosition(friends[0],0.5f,OutsideHouse.position,180));
        yield return new WaitForSeconds(delayBetweenFriends);
        StartCoroutine(MoveFriendPosition(friends[1],1f,OutsideHouse.position,180));
    }

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

    public void PlaySegment1Part5()
    {
        lastRoutine = StartCoroutine(Segment1Part5());
    }

    IEnumerator Segment1Part5()
    {
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
    [SerializeField] Transform taichiTargetDestination;

    void PlaySegment2Part1()
    {
        PostProcessingController.instance.UsingGlasses(true); // no blur effect
        StartCoroutine(playTaichi());
    }

    IEnumerator playTaichi()
    {
        yield return new WaitForSeconds(4f); // screen fade in timing

        yield return StartCoroutine(MoveFriendPosition(taichiInstructor, 0.25f, taichiTargetDestination.position, 90));

        yield return new WaitForSeconds(1); // additional delay to ensure that taichi instructor is back to idle animation before going to talk animations

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
        StartCoroutine(MovingFromTaichiToCheckers());
    }

    #endregion

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

        checkersNPC.GetComponent<AudioSource>().clip = narrationAudioClips_2[1];

        checkersNPC.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(narrationAudioClips_2[1].length);

        checkersNPC.GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        checkersNPC.GetComponent<Animator>().SetTrigger("BackToIdle");

        yield return StartCoroutine(SetNPCToPlayPos(checkersNPC,90,2));

        GameManager.instance.ShowAlert(narration_2[0]);

        checkersNPC.GetComponent<Outline>().enabled = true;

        yield return new WaitForSeconds(1f);

        lookDetection.enabled = true;
    }

    public void StartWalkingToCheckers()
    {
        StopPrevDialogue(); // hide alert text
        lookDetection.enabled = false;
        firstCheckersHotspot.SetActive(true);
        playerTeleport.MovingToCheckersChair = true;
        GameManager.instance.ShowAlert(narration_2[2]);
        checkersNPC.GetComponent<Animator>().ResetTrigger("IdleSeat");
        checkersNPC.GetComponent<Animator>().ResetTrigger("TalkBegin");
        checkersNPC.GetComponent<Animator>().ResetTrigger("Talking");
        checkersNPC.GetComponent<Animator>().ResetTrigger("TalkEnd");
    }

    [Header("Voiddeck - Chess")]
    [SerializeField] GameObject FirstEnemyCheckerPiece;
    [SerializeField] GameObject SecondEnemyCheckerPiece;
    [SerializeField] GameObject EnemyPieceFirstDestination;
    [SerializeField] GameObject EnemyPieceSecondDestination;
    [SerializeField] GameObject EnemyPieceThirdDestination;
    [SerializeField] GameObject PlayerPieceFirstDestination;
    [SerializeField] GameObject PlayerPieceSecondDestination;
    [SerializeField] GameObject PlayerPiece;
    [SerializeField] GameObject PlayerPieceOutline;

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
        GameManager.instance.ShowAlert(narration_2[1]);
        PlayerPiece.GetComponent<Grabbable>().enabled = true;
        PlayerPieceOutline.SetActive(true);
        PlayerPieceFirstDestination.SetActive(true);
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
        GameManager.instance.ShowAlert(narration_2[1]);
        PlayerPiece.GetComponent<Grabbable>().enabled = true;
        PlayerPieceOutline.SetActive(true);
        PlayerPieceSecondDestination.SetActive(true);
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
        yield return new WaitForSeconds(2f);
        float timeSinceStarted = 0f;
        float duration = 2f; // Total movement time

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

    [Header("Voiddeck - Transition Chess to Karaoke Corner")]
    [SerializeField]
    GameObject KaraokeCornerNPCs;
    [SerializeField] GameObject firstToKaraokeCornerHotspot;
    [SerializeField] GameObject[] TaichiToKaraokeCornerNPCs;
    [SerializeField] GameObject KaraokeMic;
    [SerializeField] GameObject TVScreen;
    private bool KaraokeTransitionAfterFirstTP = false;
    private bool hasFinishedSinging = false;
    private float narrationPlaybackPosition = 0f;
    private float tvPlaybackPosition = 0f;
    private bool firstTimeSing = true;

    IEnumerator MovingFromChessToKaraokeCorner()
    {
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[2]);

        // NPC lose animation
        checkersNPC.GetComponent<Animator>().SetTrigger("lose");

        yield return new WaitForSeconds(5f); // lose animation is around 5 secs

        checkersNPC.GetComponent<Animator>().SetTrigger("IdleSeat");

        yield return new WaitForSeconds(0.5f);

        checkersNPC.GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(0.7f);

        checkersNPC.GetComponent<Animator>().SetTrigger("Talking");

        checkersNPC.GetComponent<AudioSource>().clip = narrationAudioClips_2[3];

        checkersNPC.GetComponent<AudioSource>().Play();
        
        yield return new WaitForSeconds(narrationAudioClips_2[3].length);

        checkersNPC.GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        narrationAudioSource.PlayOneShot(narrationAudioClips_2[4]);

        yield return new WaitForSeconds(narrationAudioClips_2[4].length);

        checkersNPC.GetComponent<Animator>().ResetTrigger("BackToIdle");

        checkersNPC.GetComponent<Animator>().SetTrigger("BackToIdle");

        KaraokeCornerNPCs.transform.GetChild(0).gameObject.SetActive(true);

        yield return StartCoroutine(SetNPCToPlayPos(KaraokeCornerNPCs.transform.GetChild(0).gameObject, 210, 1));

        KaraokeCornerNPCs.transform.GetChild(0).GetComponent<Animator>().SetTrigger("TalkBegin");

        yield return new WaitForSeconds(1.2f);

        KaraokeCornerNPCs.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Talking");

        //KaraokeCornerNPCs.transform.GetChild(0).GetComponent<AudioSource>().clip = narrationAudioClips_2[5];

        //KaraokeCornerNPCs.transform.GetChild(0).GetComponent<AudioSource>().Play();

        //yield return new WaitForSeconds(narrationAudioClips_2[5].length);

        yield return new WaitForSeconds(3); // placeholder until ah guan voiceline comes in

        KaraokeCornerNPCs.transform.GetChild(0).GetComponent<Animator>().SetTrigger("TalkEnd");

        yield return new WaitForSeconds(2f);

        lastRoutine = null;

        playerTeleport.SetCurrentHotspotIndex(-1); // reset hotspot index

        playerTeleport.MovingToKaraokeCorner = true;

        firstToKaraokeCornerHotspot.SetActive(true);

        GameManager.instance.ShowAlert(narration_2[2]);
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
        GameManager.instance.ShowAlert(narration_2[3]);

        StartCoroutine(SetNPCToPlayPos(KaraokeCornerNPCs.transform.GetChild(0).gameObject, 250, 1));

        KaraokeMic.GetComponent<Grabbable>().enabled = true;
        KaraokeMic.GetComponent<Outline>().enabled = true;
        KaraokeMic.GetComponent<MicController>().toBeginKaraokeMinigame = true;
        narrationAudioSource.clip = narrationAudioClips_2[5];
        lastRoutine = null;

        yield return null;
    }

    public void PlayMicOnFace()
    {
        if(!TVScreen.activeInHierarchy) TVScreen.SetActive(true);
        if (!TVScreen.GetComponent<VideoPlayer>().isPlaying) TVScreen.GetComponent<VideoPlayer>().Play();
        if (!narrationAudioSource.isPlaying && !firstTimeSing) narrationAudioSource.Play();
        // Start checking for completion
        if(lastRoutine == null && !firstTimeSing) lastRoutine = StartCoroutine(CheckSingingCompletion());
    }

    public void PlayMicOffFace()
    {
        if(lastRoutine != null) StopCoroutine(lastRoutine);
        lastRoutine = null; // Reset the reference to allow starting again
        if (TVScreen.GetComponent<VideoPlayer>().isPlaying) TVScreen.GetComponent<VideoPlayer>().Pause();
        // Store current playback position before pausing
        if (narrationAudioSource.isPlaying)
        {
            narrationPlaybackPosition = narrationAudioSource.time;
            narrationAudioSource.Pause();
        }
    }

    private IEnumerator CheckSingingCompletion()
    {
        // Wait until the narration is not playing anymore (either paused or finished)
        while (narrationAudioSource.isPlaying)
        {
            // Check if we're very close to the end of the clip
            if (narrationAudioSource.clip != null &&
                narrationAudioSource.time >= narrationAudioSource.clip.length - 0.1f)
            {
                hasFinishedSinging = true;
                KaraokeMic.GetComponent<MicController>().SetMicDetectionActive(false);
                PlayAfterSingingTransition();
                yield break;
            }

            yield return null;
        }
    }

    private void PlayAfterSingingTransition()
    {
        lastRoutine = StartCoroutine(AfterSingingTransition());
    }

    private IEnumerator AfterSingingTransition()
    {
        yield return null;
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

    // Start is called before the first frame update
    void Start()
    {
        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            SetupNarrationBathroomLivingRoom();
            PlaySegment1Part1();
            secondPhone.GetComponent<MeshRenderer>().enabled = false;
            secondPhone.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
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
        else if(sceneToPlay == SceneToPlay.Voiddeck)
        {
            if(!KaraokeTransitionAfterFirstTP && playerTeleport.MovingToKaraokeCorner)
            {
                if (playerTeleport.GetCurrentHotspotIndex() == 0)
                {
                    checkersNPC.SetActive(false);

                    if (lastRoutine == null) lastRoutine = StartCoroutine(TaichiToKaraokeNPCsTransition()); // ensures that only one coroutine is ran

                    KaraokeTransitionAfterFirstTP = true;
                }
            }

            if (TVScreen.GetComponent<VideoPlayer>().time >= 17.0f && firstTimeSing && TVScreen.GetComponent<VideoPlayer>().isPlaying)
            {
                narrationAudioSource.Play();
                TVScreen.GetComponent<VideoPlayer>().Play();
                firstTimeSing = false;
            }
        }
    }

    private IEnumerator TaichiToKaraokeNPCsTransition()
    {
        foreach (var npc in TaichiToKaraokeCornerNPCs)
        {
            npc.transform.SetParent(KaraokeCornerNPCs.transform);

            npc.GetComponent<Animator>().Play("Talk");

            yield return new WaitForSeconds(0.5f);
        }

        KaraokeCornerNPCs.transform.GetChild(1).gameObject.SetActive(true);

        KaraokeCornerNPCs.transform.GetChild(1).GetComponent<Animator>().Play("Talk");

        TaichiToKaraokeCornerNPCs[0].transform.localPosition = new Vector3(33.2f, 7.5f, -21);

        TaichiToKaraokeCornerNPCs[1].transform.localPosition = new Vector3(31.85f, 7.5f, -21);

        TaichiToKaraokeCornerNPCs[1].transform.localRotation = Quaternion.Euler(0, 105, 0);

        KaraokeCornerNPCs.SetActive(true);
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
