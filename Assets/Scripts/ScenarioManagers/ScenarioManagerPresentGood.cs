using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;
using static UnityEngine.Rendering.DebugUI;
using static Unity.VisualScripting.Member;
using UnityEngine.Events;

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

    Coroutine lastRoutine = null;

    void SetupNarrationBathroomLivingRoom()
    {
        narration_1[0] = "Open the door and head to the sofa";
        narration_1[1] = "Press GRIP button to move to highlighted circle";
        narration_1[2] = "Someone is calling,pick up the call";
    }

    void SetupNarrationVoiddeck()
    {
        narration_2[0] = "[Pick up highlighted othello piece and place it on outlined spot]";
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

        GameManager.instance.ShowAlert(narration_1[1]);

        knob.GetComponent<Outline>().enabled = false;

        firstTeleportHotspot.SetActive(true); // enable first teleport hotspot
      
        toGoLivingRoom = true;
    }

    #endregion

    #region Segment 1 Part 3 (Living room)
    [Header("In living room")]
    [SerializeField] GameObject phone;
    [SerializeField] MobilePhone mobilePhone;
    [SerializeField] GameObject glasses;
    [SerializeField] GameObject phoneOutline;
    [SerializeField] GameObject glassesOutline;


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
        phoneOutline.SetActive(true);

        yield return new WaitForSeconds(2.5f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[2]);

        GameManager.instance.toPickUpPhone = true;
    }

    public void PhonePickedUp() // called in UnityEvent in MobilePhone
    {
        StopPrevDialogue();
        phoneOutline.SetActive(false);
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

        //PlayAudioAndNarration(narrationAudioClips_1[4], narration_1[13], 3f);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[4]);
        yield return new WaitForSeconds(3f + 1.1f);

        //GameManager.instance.ShowAlert(narration_1[14], 8f);
        yield return new WaitForSeconds(8f + 1.1f);

        //PlayAudioAndNarration(narrationAudioClips_1[5], narration_1[15], narrationAudioClips_1[4].length);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[5]);
        yield return new WaitForSeconds(narrationAudioClips_1[4].length - 3f);

        // play phone hang up here
        mobilePhone.SetPhoneHangUp();

        PlaySegment1Part4();
    }

    #endregion

    #region Segment 1 Part 4(From living room to main door)

    [Header("Living room to main door")]
    [SerializeField] DoorKnob mainDoor;
    [SerializeField] AudioSource RingingSoundSource;

    public void PlaySegment1Part4()
    {
        lastRoutine = StartCoroutine(Segment1Part3_1());
    }

    IEnumerator Segment1Part4_1()
    {
        yield return new WaitForSeconds(1f); // delay between phone hang up and door ring

        mainDoor.GetComponent<Outline>().enabled = true;

        RingingSoundSource.Play();

        GameManager.instance.ShowAlert(narration_1[1]); // shows prompt to press grip button to move towards door
    }

    // used as unity event in main door 
    public void MainDoorOpen()
    {

    }

    #endregion 

    #region Segment 2 Part 1 (Voiddeck, Tai chi)

    [Header("Voiddeck - Taichi")]
    [SerializeField]
    TaiChiManager taiChiManager;
    void PlaySegment2Part1()
    {
        PostProcessingController.instance.UsingGlasses(true); // no blur effect
        StartCoroutine(playTaichi());
    }

    IEnumerator playTaichi()
    {
        yield return new WaitForSeconds(4f); // screen fade in timing
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
    int times;
    IEnumerator MovingFromTaichiToChess()
    {
        times++;
        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeIn");
        player.transform.position = teleportPoint.transform.position;
        player.transform.rotation = teleportPoint.transform.rotation;
        taichiNPC.SetActive(false);
        chessNPC.SetActive(true);
        FirstPlayerPieceDestination.SetActive(true);
        GameManager.instance.ShowAlert(narration_2[0]);
        yield return new WaitForSeconds(4f);
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
        // NPC lose animation
        NPC.GetComponent<Animator>().SetTrigger("lose");
        yield return new WaitForSeconds(5); // lose animation is around 5 secs

        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeIn");
        player.transform.position = TeleportPointReadingCorner.transform.position;
        player.transform.rotation = TeleportPointReadingCorner.transform.rotation;

        chessNPC.SetActive(false);
        readingCornerNPCs.SetActive(true);

        //Set Reading corner NPC active here!
        TVScreen.SetActive(true);
        GameManager.instance.toLookAtObjective = true;

        yield return new WaitForSeconds(4f);
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
            foreach (TaiChiInstructor anim in GameManager.instance.taiChiAnimations)
            {
                anim.NextPose();
            }
            PlaySegment2Part1();
            //StartCoroutine(MovingFromTaichiToChess());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            #region Going to living room
            // remove alert after first teleport
            if (!alertRemovedAfterFirstTP)
            {
                //if (/*cane.GetComponent<CaneTeleport>().HasTeleportedOnce()*/)
                //{
                //    StopPrevDialogue(); // removes alert text of picking up cane lmao
                //    alertRemovedAfterFirstTP = true;
                //}
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
