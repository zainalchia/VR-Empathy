using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField] SceneToPlay sceneToPlay = SceneToPlay.Bathroom;
    enum SceneToPlay
    {
        Bathroom,
        Bedroom
    }

    [SerializeField] AudioSource narrationAudioSource;

    // for bathroom and living room scene
    [SerializeField] AudioClip[] narrationAudioClips_1;
    string[] narration_1 = new string[50];

    // for bedroom scene
    [SerializeField] AudioClip[] narrationAudioClips_2;
    string[] narration_2 = new string[50];

    Coroutine lastRoutine = null;

    void SetupNarrationBathroomLivingRoom()
    {
        narration_1[0] = "I am balding.";
        narration_1[1] = "Cool mirror.";
        narration_1[2] = "I need to put my dentures on and wash up.";
        narration_1[3] = "Can't forget my dentures!"; // stay on screen until dentures put on

        narration_1[4] = "Time to relax in the living room.";
        narration_1[5] = "I have to use the cane and move to living room.";
        narration_1[6] = "Open the door and go to the sofa.";
        narration_1[7] = "[Use the cane to find spots to move to and then press 'A']";

        narration_1[8] = "Someone is calling. Pick up the phone.";
        narration_1[9] = "I can't see that well.";
        narration_1[10] = "I need to use my glasses.";
        narration_1[11] = "Answer the phone."; // stay on screen until phone is answered

        narration_1[12] = "Dialogue from man";
        narration_1[13] = "reply";
        narration_1[14] = "...";
        narration_1[15] = "...";
    }

    void SetupNarrationBedroom()
    {

    }

    #region Segment 1 Part 1 (In the Bathroom)
    [Header("In the bathroom")]
    [SerializeField] float timeForWashingUp = 30f;
    bool hasWashedUp = false;
    bool isDenturesOn = false;

    public void PlaySegment1Part1()
    {
        lastRoutine = StartCoroutine(Segment1Part1());
    }

    IEnumerator Segment1Part1()
    {
        yield return new WaitForSeconds(1);

        GameManager.instance.ShowAlert(narration_1[0], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[1], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[2], 6f);

        GameManager.instance.toPutDenturesOn = true;

        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);
        hasWashedUp = true;

        if (!isDenturesOn)
        {
            GameManager.instance.ShowAlert(narration_1[3], Color.red);
        }
        else
            PlaySegment1Part2();
    }

    public void PutDenturesOn() // called in UnityEvent from PlayerFace
    {
        isDenturesOn = true;
        if (hasWashedUp)
        {
            PlaySegment1Part2();
        }
    }

    #endregion

    #region Segment 1 Part 2 (From bathroom to living room)
    [Header("Moving towards living room")]
    [SerializeField] DoorKnob bathroomDoor;
    bool toGoLivingRoom = false;

    public void PlaySegment1Part2()
    {
        lastRoutine = StartCoroutine(Segment1Part2());
    }

    IEnumerator Segment1Part2()
    {
        StopPrevDialogue();

        GameManager.instance.ShowAlert(narration_1[4], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[5], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        // can open bathroom door from here
        bathroomDoor.AllowDoorOpen();

        GameManager.instance.ShowAlert(narration_1[6], 3f);
        yield return new WaitForSeconds(3f + 1.1f);
        
        GameManager.instance.ShowAlert(narration_1[7], 10f);
        yield return new WaitForSeconds(10f + 1.1f);

        toGoLivingRoom = true;
    }
    #endregion

    #region Segment 1 Part 3 (Living room)
    [Header("In living room")]
    [SerializeField] MobilePhone mobilePhone;

    public void PlaySegment1Part3_1()
    {
        lastRoutine = StartCoroutine(Segment1Part3_1());
    }

    IEnumerator Segment1Part3_1()
    {
        yield return new WaitForSeconds(1f);

        // play phone calling
        mobilePhone.SetPhoneCalling();

        GameManager.instance.ShowAlert(narration_1[8], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.toPickUpPhone = true;
    }

    public void PhonePickedUp() // called in UnityEvent in MobilePhone
    {
        lastRoutine = StartCoroutine(Segment1Part3_2());
    }

    IEnumerator Segment1Part3_2()
    {
        StopPrevDialogue();

        GameManager.instance.ShowAlert(narration_1[9], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[10], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.toPutGlassesOn = true;
    }

    public void PutGlassesOn() // called in UnityEvent in PlayerFace
    {
        GameManager.instance.ShowAlert(narration_1[11]);
        GameManager.instance.canAnswerPhone = true;
    }

    public void PhoneAnswered() // called in UnityEvent in MobilePhone
    {
        lastRoutine = StartCoroutine(Segment1Part3_3());
    }

    IEnumerator Segment1Part3_3() // Dialogue between player and caller
    {
        StopPrevDialogue();
        GameManager.instance.ShowAlert(narration_1[12], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[13], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[14], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[15], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        // play phone hang up here
        mobilePhone.SetPhoneHangUp();

        // fade screen here

        // load next scene here
        //SceneManager.LoadScene("", LoadSceneMode.Single);
    }


    #endregion


    // Start is called before the first frame update
    void Start()
    {
        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            SetupNarrationBathroomLivingRoom();
            PlaySegment1Part1();
        }
        else if (sceneToPlay == SceneToPlay.Bedroom)
        {
            SetupNarrationBedroom();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            #region Going to living room
            // check here when player reaches sofa, call segment3
            if (toGoLivingRoom)
            {
                if (GameManager.instance.IsPlayerWithinPosition(-4.5f, -1.7f))
                {
                    toGoLivingRoom = false;
                    PlaySegment1Part3_1();
                }
            }

            #endregion
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
        narrationAudioSource.PlayOneShot(clipToPlay);
        GameManager.instance.ShowAlert(narrationText);
    }

    void PlayAudioAndNarration(AudioClip clipToPlay, string narrationText, float clipLength) // use if text is to fade after time
    {
        narrationAudioSource.PlayOneShot(clipToPlay);
        GameManager.instance.ShowAlert(narrationText, clipLength);
    }

    void PlayAudioAndNarration(AudioClip clipToPlay, string narrationText, Color textColor) // use if text is to be different color
    {
        narrationAudioSource.PlayOneShot(clipToPlay);
        GameManager.instance.ShowAlert(narrationText, textColor);
    }

    void PlayAudioAndNarration(AudioClip clipToPlay, string narrationText, float clipLength, Color textColor) // use if text is to fade after time and be different color
    {
        narrationAudioSource.PlayOneShot(clipToPlay);
        GameManager.instance.ShowAlert(narrationText, clipLength, textColor);
    }
}
