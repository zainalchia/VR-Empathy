using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;
using static UnityEngine.Rendering.DebugUI;
using static Unity.VisualScripting.Member;

public class ScenarioManagerPresentBad : MonoBehaviour
{
    [SerializeField] SceneToPlay sceneToPlay = SceneToPlay.Bathroom;
    enum SceneToPlay
    {
        Bathroom,
        Bedroom
    }

    [Header("Narration Variables")]
    [SerializeField] AudioSource narrationAudioSource;

    // for bathroom and living room scene
    [SerializeField] AudioClip[] narrationAudioClips_1;
    string[] narration_1 = new string[30];

    // for bedroom scene
    [SerializeField] AudioClip[] narrationAudioClips_2;
    string[] narration_2 = new string[30];

    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject cane;
    [SerializeField] Outline caneOutline;
    [SerializeField] GameObject firstTeleportHotspot;

    Coroutine lastRoutine = null;

    void SetupNarrationBathroomLivingRoom()
    {
        narration_1[0] = "Sigh, I am balding even more.";
        narration_1[1] = "Let me wash up so I can rest. ";

        narration_1[2] = "My legs are tired from all this standing.";
        narration_1[3] = "I need to take a break in the living room.";
        narration_1[4] = "Let me grab my trusty cane.";
        narration_1[5] = "Place your hand on the door handle to open the door.";
        narration_1[6] = "[Use the cane to find spots to move to and then press 'A']"; // stay on screen until first tp

        narration_1[7] = "Someone is calling. Pick up the phone.";
        narration_1[8] = "Aiya, old already cannot see. I need my glasses.";
        narration_1[9] = "Useless hand cannot hold my glasses.";
        narration_1[10] = "Aiya... dropped my glasses again.";
        narration_1[11] = "Grab the phone with one hand and tap with the other hand to answer."; // stay on screen until phone is answered

        narration_1[12] = "Swipe on the phone to answer the call";
        narration_1[13] = "Pa, Hello Pa.";
        narration_1[14] = "Hellllllo Pa. This deaf father so hard to talk to him.";
        narration_1[15] = "HELLO, SON IS THAT YOU? HOW ARE YOU? WHEN YOU WANT COME";


        // Text prompts
        narration_1[16] = "Open the door and head to the sofa";
        narration_1[17] = "Aim the tip of the cane on the floor and press the 'Grip' button";
        narration_1[18] = "Someone is calling, pick up the phone.";
    }

    void SetupNarrationBedroom()
    {
        narration_2[0] = "Another day over";
        narration_2[1] = "Hmm useless son when is he going to visit me?";
        narration_2[2] = "Im tired";
        narration_2[3] = "I have to take off my dentures and place in the cup. [Grab your face area]"; // stay on screen until placed in cup
        narration_2[4] = "Now my glasses. [Grab your face area]"; // stay on screen until take off
        narration_2[5] = "Hmm what is this? Am I mad?";
        narration_2[6] = "Ah yes, my medication. I need my medication. Forgot, I must have forgot.";
        narration_2[7] = "Use the cane to move towards the medicine table.";
        narration_2[8] = "Calendar where? Calendar wall. Okay. Hmmm Okay. [Grab the yellow pill bottle]";
        narration_2[9] = "This is not the medicine. Put it aside.";
        narration_2[10] = "Aiya spilled everywhere already. Useless hand. Wish my son is here to help.";
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
        caneOutline.enabled = true;
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
        GameManager.instance.ShowAlert(narration_1[16]);
    }

    public void BathroomDoorOpen() // called in UnityEvent in bathroom door
    {
        StopPrevDialogue();

        ControllerInteractionsManager.instance.allowDropItems = false; // no more dropping after picking up cane
        caneOutline.enabled = false;
        knob.GetComponent<Outline>().enabled = false;

        firstTeleportHotspot.SetActive(true); // enable first teleport hotspot
        GameManager.instance.ShowAlert(narration_1[17]);
        toGoLivingRoom = true;
    }


    #endregion

    #region Segment 1 Part 3 (Living room)
    [Header("In living room")]
    [SerializeField] GameObject phone;
    [SerializeField] MobilePhone mobilePhone;
    [SerializeField] GameObject glasses;
    [SerializeField] AudioClip glassesDrop;
    [SerializeField] Outline phoneOutline;
    [SerializeField] Outline glassesOutline;
    [SerializeField] GameObject tvAudio;


    int dropGlassesCount = 0;

    public void PlaySegment1Part3_1()
    {
        lastRoutine = StartCoroutine(Segment1Part3_1());
    }

    IEnumerator Segment1Part3_1()
    {
        tvAudio.GetComponent<AudioSource>().mute = false;
        PostProcessingController.instance.UsingGlasses(false); // start blur effect
        ControllerInteractionsManager.instance.allowDropItems = true; // Can drop cane

        yield return new WaitForSeconds(1f);

        // play phone calling
        mobilePhone.SetPhoneCalling();
        phoneOutline.enabled = true;
        GameManager.instance.ShowAlert(narration_1[18]);

        //GameManager.instance.ShowAlert(narration_1[7], 2.5f);
        yield return new WaitForSeconds(2.5f + 1.1f);

        GameManager.instance.toPickUpPhone = true;
    }

    public void PhonePickedUp() // called in UnityEvent in MobilePhone
    {
        GameManager.instance.HideAlert();
        StopPrevDialogue();
        phoneOutline.enabled = false;
        lastRoutine = StartCoroutine(Segment1Part3_2());
    }

    IEnumerator Segment1Part3_2()
    {
        ControllerInteractionsManager.instance.allowDropItems = true; // will drop items from here
        GameManager.instance.toPutGlassesOn = true;

        // Trying to pick up glasses 1st time
        //PlayAudioAndNarration(narrationAudioClips_1[2], narration_1[8], narrationAudioClips_1[2].length);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[3]);
        yield return new WaitForSeconds(1f);

        glassesOutline.enabled = true;
        yield return new WaitForSeconds(3f + 1.1f);
        
    }

    public void DropGlassesReaction() // called in UnityEvent in ControllerInteractionsManager
    {
        StopPrevDialogue();

        dropGlassesCount++;

        narrationAudioSource.PlayOneShot(glassesDrop);

        // Narration when player drops glasses, can play audio here each time player drops glasses
        if (dropGlassesCount == 1)
        {
            //PlayAudioAndNarration(narrationAudioClips_1[3], narration_1[9], 9f);
            narrationAudioSource.Stop();
            narrationAudioSource.PlayOneShot(narrationAudioClips_1[4]);
        }

        //else if (dropGlassesCount == 2)
            //GameManager.instance.ShowAlert(narration_1[10], 3f);

    }

    public void GlassesPutOn() // called in UnityEvent in PlayerFace
    {
        StopPrevDialogue();
        glassesOutline.enabled = false;
        ControllerInteractionsManager.instance.allowDropItems = false; // no more dropping after glasses put on
        //GameManager.instance.ShowAlert(narration_1[12]);
        GameManager.instance.canAnswerPhone = true;
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
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[5]);
        yield return new WaitForSeconds(3f + 1.1f);

        //GameManager.instance.ShowAlert(narration_1[14], 8f);
        yield return new WaitForSeconds(8f + 1.1f);

        //PlayAudioAndNarration(narrationAudioClips_1[5], narration_1[15], narrationAudioClips_1[4].length);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[6]);
        yield return new WaitForSeconds(narrationAudioClips_1[4].length - 3f);

        // play phone hang up here
        mobilePhone.SetPhoneHangUp();

        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        // load next scene here
        SceneManager.LoadScene("PresentBadBedroom", LoadSceneMode.Single); // Or whatever number present bad bedroom scene is
    }

    #endregion

    #region Segment 2 Part 1 (Bedroom - Taking off glasses and dentures)
    [Header("Bedroom 1st Part")]
    [SerializeField] GameObject Glass;
    [SerializeField] Outline CupOutline;


    public void PlaySegment2Part1()
    {
        lastRoutine = StartCoroutine(Segment2Part1_1());
    }
    IEnumerator Segment2Part1_1()
    {
        PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        ControllerInteractionsManager.instance.allowDropItems = false; // no dropping items (can also disable in scene)

        yield return new WaitForSeconds(4f); // screen fade in timing

        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[0]);

        yield return new WaitForSeconds(3f);

        //GameManager.instance.ShowAlert(narration_2[0], 2f);
        yield return new WaitForSeconds(2f + 1.1f);

        //GameManager.instance.ShowAlert(narration_2[1], 5f);
        yield return new WaitForSeconds(5f + 1.1f);

        //GameManager.instance.ShowAlert(narration_2[2], 2f);
        yield return new WaitForSeconds(2f + 1.1f);

        //GameManager.instance.ShowAlert(narration_2[3]);

        // allow take dentures off from here
        GameManager.instance.toTakeDenturesOff = true;
        CupOutline.enabled = true;
    }

    public void DenturesPlacedInCup() // called in UnityEvent in denture cup
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(Segment2Part2_1());
    }

    #endregion

    #region Segment 2 Part 2 (Bedroom - Medicine)
    [Header("Bedroom 2nd Part")]
    [SerializeField] GameObject flyingShip;
    [SerializeField] GameObject cloudy1;
    [SerializeField] GameObject cloudy2;
    [SerializeField] GameObject rain;
    [SerializeField] GameObject tableWithMedicine;
    [SerializeField] GameObject chair;
    [SerializeField] GameObject cabinet;
    [SerializeField] GameObject originallyHeldMedicine;
    [SerializeField] GameObject animatedMedicine;
    [SerializeField] GameObject PillBottleHighlight;
    [SerializeField] AudioFade fade;
    [SerializeField] GameObject photoFrame;
    [SerializeField] Outline photoFrameOutline;
    static public bool canMedicineSpill;

    IEnumerator Segment2Part2_1()
    {
        canMedicineSpill = false;
        CupOutline.enabled = false;
        // Buffer time for them to put dentures in cup
        yield return new WaitForSeconds(3f);

        // start furniture moving here
        GameManager.instance.toStartSpasming = true;

        // wait a while to let players look around
        yield return new WaitForSeconds(8f);

        // clouds and ship illusions here
        flyingShip.SetActive(true);
        flyingShip.GetComponent<DisappearObject>().AllowedToMove(true);
        cloudy1.GetComponent<ParticleSystem>().Play();
        cloudy2.GetComponent<ParticleSystem>().Play();
        rain.SetActive(true);

        StartCoroutine(fade.FadeIn(4f, 0.4f));

        yield return new WaitForSeconds(5f);

        yield return new WaitForSeconds(1f);

        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[2]); // play audio, got a space in the beginning
        yield return new WaitForSeconds(3.5f);

        //GameManager.instance.ShowAlert(narration_2[5], 6f);
        yield return new WaitForSeconds(6f + 1.1f);

        //Re enable the furniture
        GameManager.instance.toStartSpasming = false;
        tableWithMedicine.SetActive(true);
        cabinet.SetActive(true);
        chair.SetActive(true);

        StartCoroutine(fade.FadeOut(5f, 0f));
        flyingShip.GetComponent<DisappearObject>().AllowedToMove(false);
        flyingShip.SetActive(false);


        //GameManager.instance.ShowAlert(narration_2[6], 12f);
        yield return new WaitForSeconds(12f + 1.1f);

        // stop all illusions

        cloudy1.GetComponent<ParticleSystem>().Stop();
        cloudy2.GetComponent<ParticleSystem>().Stop();
        rain.SetActive(false);


        //GameManager.instance.ShowAlert(narration_2[7]);

        //PlayAudioAndNarration(narrationAudioClips_2[3], narration_2[8], narrationAudioClips_2[3].length);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[3]);

        yield return new WaitForSeconds(narrationAudioClips_2[3].length + 1.1f);

        canMedicineSpill = true;
        PillBottleHighlight.SetActive(true);
    }

    public void MedicationDropped()
    {
        StopPrevDialogue();
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[5]);

        // for the scripted animation of medicine getting toppled over
        originallyHeldMedicine.SetActive(false);
        animatedMedicine.SetActive(true);
        animatedMedicine.GetComponent<Animator>().enabled = true;
        lastRoutine = StartCoroutine(Segment2Part2_2());
    }

    IEnumerator Segment2Part2_2()
    {
        yield return new WaitForSeconds(10f); // buffer time
        GameManager.instance.toLookAtObjective = true;
        photoFrame.GetComponent<Grabbable>().enabled = true;
        photoFrameOutline.enabled = true;
        // add new dialogue here
        yield return null;
    }


    public void StaredAtPhoto()
    {
        lastRoutine = StartCoroutine(Segment2Part2_3());
    }


    IEnumerator Segment2Part2_3()
    {
        photoFrameOutline.enabled = false;
        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        GameManager.instance.goodbyeText.SetActive(true);
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
