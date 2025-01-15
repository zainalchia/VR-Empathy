using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;
using static UnityEngine.Rendering.DebugUI;
using static Unity.VisualScripting.Member;

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
    [SerializeField] GameObject cane;
    [SerializeField] GameObject caneOutline;
    [SerializeField] GameObject firstTeleportHotspot;

    Coroutine lastRoutine = null;

    void SetupNarrationBathroomLivingRoom()
    {

    }

    void SetupNarrationVoiddeck()
    {

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
        ControllerInteractionsManager.instance.allowDropItems = false; // no dropping item yet
        cane.GetComponent<Grabbable>().enabled = false; // disable cane grabbable first

        yield return new WaitForSeconds(4f); // screen fade in timing

        //Lines 1-2
        //PlayAudioAndNarration(narrationAudioClips_1[0], narration_1[0], 7.0f);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[0]);
        yield return new WaitForSeconds(7.0f + 1.5f);

        //GameManager.instance.ShowAlert(narration_1[1], 3f);
        yield return new WaitForSeconds(3f + 1.1f);


        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);

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
        cane.GetComponent<Grabbable>().enabled = true; // can be grabbed from here
        caneOutline.SetActive(true);
        knob.GetComponent<Outline>().enabled = true;

        //PlayAudioAndNarration(narrationAudioClips_1[1], narration_1[2], 4.0f);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[1]);
        yield return new WaitForSeconds(4.0f);

        //GameManager.instance.ShowAlert(narration_1[3], 2.5f);
        yield return new WaitForSeconds(2.5f);
        //GameManager.instance.ShowAlert(narration_1[4], 2.5f);
        yield return new WaitForSeconds(2.5f + 1.1f);

        //GameManager.instance.ShowAlert(narration_1[5]);

        // can open bathroom door from here
        bathroomDoor.AllowDoorOpen();
    }

    public void BathroomDoorOpen() // called in UnityEvent in bathroom door
    {
        StopPrevDialogue();

        caneOutline.SetActive(false);
        knob.GetComponent<Outline>().enabled = false;

        firstTeleportHotspot.SetActive(true); // enable first teleport hotspot
        //GameManager.instance.ShowAlert(narration_1[6]);
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
    }

    IEnumerator Segment1Part3_1()
    {
        PostProcessingController.instance.UsingGlasses(false); // start blur effect
        
        yield return new WaitForSeconds(1f);

        // play phone calling
        mobilePhone.SetPhoneCalling();
        phoneOutline.SetActive(true);

        //GameManager.instance.ShowAlert(narration_1[7], 2.5f);
        yield return new WaitForSeconds(2.5f + 1.1f);

        GameManager.instance.toPickUpPhone = true;
    }

    public void PhonePickedUp() // called in UnityEvent in MobilePhone
    {
        StopPrevDialogue();
        phoneOutline.SetActive(false);
        lastRoutine = StartCoroutine(Segment1Part3_2());
    }

    IEnumerator Segment1Part3_2()
    {
        GameManager.instance.toPutGlassesOn = true;

        // Trying to pick up glasses 1st time
        //PlayAudioAndNarration(narrationAudioClips_1[2], narration_1[8], narrationAudioClips_1[2].length);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[2]);
        yield return new WaitForSeconds(1f);

        glassesOutline.SetActive(true);        
    }

    public void GlassesPutOn() // called in UnityEvent in PlayerFace
    {
        StopPrevDialogue();
        glassesOutline.SetActive(false);
        GameManager.instance.canAnswerPhone = true;
        ControllerInteractionsManager.instance.allowDropItems = false; // no more dropping after glasses put on
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

        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        // load next scene here
        SceneManager.LoadScene("PresentGoodVoidDeck", LoadSceneMode.Single); // Or whatever number present bad bedroom scene is
    }

    #endregion


    #region Segment2 Part 1 (Voiddeck, Tai chi)

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
        yield return new WaitForSeconds(4f);
    }

    [Header("Voiddeck - Chess")]
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject Piece;
    [SerializeField] GameObject Bishop;

    public void TriggerNPC()
    {
        NPC.GetComponent<Animator>().SetTrigger("move");
        StartCoroutine(movePiece());
    }

    IEnumerator movePiece()
    {
        yield return new WaitForSeconds(2f);
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            Piece.transform.localPosition = Vector3.Lerp(Piece.transform.localPosition, new Vector3(0.22f, 0f, -0.66f), timeSinceStarted);
            if (Piece.transform.localPosition == new Vector3(0.22f, 0f, -0.66f))
            {
                Bishop.GetComponent<Outline>().enabled = true;
                Bishop.GetComponent<Grabbable>().enabled = true;
                Bishop.GetComponent<GrabInteractable>().enabled = true;
                Bishop.GetComponent<PhysicsGrabbable>().enabled = true;
                yield break;
            }
            yield return null;
        }
    }

    public void EndOfChess()
    {
        StartCoroutine(MovingFromChessToReadingCorner());
    }

    [Header("Voiddeck - Transition Chess to Reading Corner")]
    [SerializeField]
    GameObject TeleportPointReadingCorner;
    [SerializeField]
    GameObject TVScreen;
    [SerializeField]
    GameObject readingCornerNPCs;

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
            foreach (TaiChiInstructor anim in GameManager.instance.taiChiAnimations)
            {
                anim.NextPose();
            }
            PlaySegment2Part1();
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
                if (cane.GetComponent<CaneTeleport>().HasTeleportedOnce())
                {
                    StopPrevDialogue();
                    alertRemovedAfterFirstTP = true;
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
