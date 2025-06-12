using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;
using static MainMenuManager;

public class  Trans2
{
    public Vector3 position;
    public Vector3 scale;
    public Quaternion rotation;
}

public class ScenarioManagerPresentBad : MonoBehaviour
{
    [SerializeField]
    Material normalSkybox;

    [SerializeField] SceneToPlay sceneToPlay = SceneToPlay.Bathroom;
    enum SceneToPlay
    {
        Bathroom,
        Bedroom
    }

    [Header("Narration Variables")]
    [SerializeField] AudioSource narrationAudioSource;

    // for general audio clips used in both scenes
    [SerializeField] AudioClip[] narrationAudioClips_General_Male;
    [SerializeField] AudioClip[] narrationAudioClips_General_Female;
    AudioClip[] narrationAudioClips_General;

    // for bathroom and living room scene
    [SerializeField] AudioClip[] narrationAudioClips_Bathroom_Male;
    [SerializeField] AudioClip[] narrationAudioClips_Bathroom_Female;
    AudioClip[] narrationAudioClips_Bathroom;
    private bool hasBlurredEyes = false;
    string[] narration_1 = new string[30];

    // for bedroom scene
    [SerializeField] AudioClip[] narrationAudioClips_Bedroom_Male;
    [SerializeField] AudioClip[] narrationAudioClips_Bedroom_Female;
    AudioClip[] narrationAudioClips_2;
    string[] narration_2 = new string[30];

    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject cane;
    [SerializeField] Outline caneOutline;
    [SerializeField] GameObject firstTeleportHotspot;

    Coroutine lastRoutine = null;

    void SetupNarrationGeneral()
    {
        if (MainMenuManager.isGenderMale)
        {
            narrationAudioClips_General = narrationAudioClips_General_Male;
        }
        else
        {
            narrationAudioClips_General = narrationAudioClips_General_Female;
        }
    }

    void SetupNarrationBathroomLivingRoom()
    {
        narration_1[0] = "Sigh, I am balding even more.";
        narration_1[1] = "Let me wash up so I can rest.?";

        narration_1[2] = "My legs are tired from all this standing.";
        narration_1[3] = "I need to take a break in the living room.";
        narration_1[4] = "Let me grab my trusty cane.";
        narration_1[5] = "Grab your cane and place your hand on the door handle to open the door.";
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
        narration_1[16] = "Take your cane and place your hand on the door to open it.";
        narration_1[17] = "Aim the tip of the cane on the floor and press the 'Trigger' button";
        narration_1[18] = "Someone is calling, pick up the phone.";
        narration_1[19] = "Use your other hand to put on your glasses.";

        if (MainMenuManager.isGenderMale)
        {
            narrationAudioClips_Bathroom = narrationAudioClips_Bathroom_Male;
        }
        else
        {
            narrationAudioClips_Bathroom = narrationAudioClips_Bathroom_Female;
        }
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

        narration_2[11] = "Grab near your face to take out your dentures.";


        if (MainMenuManager.isGenderMale)
        {
            narrationAudioClips_2 = narrationAudioClips_Bedroom_Male;
        }
        else
        {
            narrationAudioClips_2 = narrationAudioClips_Bedroom_Female;
        }

    }

    #region Segment 1 Part 1 (In the Bathroom)

    [Header("In the bathroom")]
    [SerializeField] float timeForWashingUp = 30f;
    [SerializeField] GameObject frame;

    public void PlaySegment1Part1()
    {
        lastRoutine = StartCoroutine(Segment1Part1());
    }

    IEnumerator Segment1Part1()
    {
        PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        ControllerInteractionsManager.instance.autoDropItems = false; // no dropping item yet
        cane.GetComponent<Grabbable>().enabled = false; // disable cane grabbable first
        frame.GetComponent<ForceStayGrabbed>().active = true;

        yield return new WaitForSeconds(4f); // screen fade in timing

        //Lines 1-2
        //PlayAudioAndNarration(narrationAudioClips_1[0], narration_1[0], 7.0f);
        narrationAudioSource.volume = 1;
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_Bathroom[0]);

        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);

        PlaySegment1Part2();
    }

    #endregion

    #region Segment 1 Part 2 (From bathroom to living room)

    [Header("Moving towards living room")]
    [SerializeField] DoorKnob bathroomDoor;
    [SerializeField] GameObject knob;
    [SerializeField] GameObject questControllerImage;
    bool toGoLivingRoom = false;
    bool alertRemovedAfterFirstTP = false;

    public void PlaySegment1Part2()
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(Segment1Part2());
    }

    IEnumerator Segment1Part2()
    {
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_Bathroom[1]);

        yield return new WaitForSeconds(narrationAudioClips_Bathroom[1].length);

        cane.GetComponent<Grabbable>().enabled = true; // can be grabbed from here
        cane.GetComponent<ForceStayGrabbed>().active = true;
        caneOutline.enabled = true;
        knob.GetComponent<Outline>().enabled = true;

        // can open bathroom door from here
        bathroomDoor.AllowDoorOpen();
        GameManager.instance.ShowAlert(narration_1[16]);
    }
    
    public void BathroomDoorOpen() // called in UnityEvent in bathroom door
    {
        StopPrevDialogue();

        ControllerInteractionsManager.instance.autoDropItems = false; // no more dropping after picking up cane
        caneOutline.enabled = false;
        knob.GetComponent<Outline>().enabled = false;

        firstTeleportHotspot.SetActive(true); // enable first teleport hotspot
        GameManager.instance.ShowAlert(narration_1[17]);
        toGoLivingRoom = true;
        lastRoutine = null;
    }

    #endregion

    #region Segment 1 Part 2.5 (Reached sidetable with food)

    public void PlaySegment1Part2Half()
    {
        lastRoutine = StartCoroutine(Segment1Part2Half());
    }

    IEnumerator Segment1Part2Half()
    {
        narrationAudioSource.PlayOneShot(narrationAudioClips_Bathroom[2]);

        yield return new WaitForSeconds(6); // food cold voiceline plus a bit of delay

        PostProcessingController.instance.UsingGlasses(false);

        yield return new WaitForSeconds(1);

        narrationAudioSource.PlayOneShot(narrationAudioClips_Bathroom[3]);

        yield return new WaitForSeconds(narrationAudioClips_Bathroom[3].length);

        PostProcessingController.instance.initialBlurDone = true;
    }

    #endregion

    #region Segment 1 Part 3 (Living room)
    [Header("In living room")]
    [SerializeField] GameObject phone;
    [SerializeField] MobilePhone mobilePhone;
    [SerializeField] GameObject glasses;
    [SerializeField] AudioClip glassesDrop;
    [SerializeField] Outline glassesOutline;
    [SerializeField] GameObject tvAudio;

    int dropGlassesCount = 0;

    public void PlaySegment1Part3_1()
    {
        lastRoutine = StartCoroutine(Segment1Part3_1());
    }

    IEnumerator Segment1Part3_1()
    {
        //tvAudio.GetComponent<AudioSource>().mute = false;

        // Can drop cane
        //ControllerInteractionsManager.instance.allowDropItems = true; // old implementation, not working

        yield return new WaitForSeconds(2); // delay for sighing voiceline

        // play phone calling
        mobilePhone.SetPhoneCalling();
        phone.transform.GetChild(0).GetComponent<Outline>().enabled = true;
        GameManager.instance.ShowAlert(narration_1[18]);

        //GameManager.instance.ShowAlert(narration_1[7], 2.5f);
        yield return new WaitForSeconds(2.5f + 1.1f);

        GameManager.instance.toPickUpPhone = true;

        phone.GetComponent<ForceStayGrabbed>().SetActive(true);
    }

    public void PhonePickedUp() // called in UnityEvent in MobilePhone
    {
        phone.transform.GetChild(0).GetComponent<Outline>().enabled = false;
        GameManager.instance.HideAlert();
        StopPrevDialogue();
        lastRoutine = StartCoroutine(Segment1Part3_2());
    }

    IEnumerator Segment1Part3_2()
    {
        GameManager.instance.ShowAlert(narration_1[19]);

        glassesOutline.enabled = true;

        ControllerInteractionsManager.instance.autoDropItems = true; // will drop items from here
        GameManager.instance.toPutGlassesOn = true;

        // Trying to pick up glasses 1st time
        //PlayAudioAndNarration(narrationAudioClips_1[2], narration_1[8], narrationAudioClips_1[2].length);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_Bathroom[4]);
        yield return new WaitForSeconds(1f);

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
            narrationAudioSource.PlayOneShot(narrationAudioClips_Bathroom[5]);
        }

        //else if (dropGlassesCount == 2)
            //GameManager.instance.ShowAlert(narration_1[10], 3f);
    }

    public void GlassesPutOn() // called in UnityEvent in PlayerFace
    {
        StopPrevDialogue();
        glassesOutline.enabled = false;
        ControllerInteractionsManager.instance.autoDropItems = false; // no more dropping after glasses put on
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
        narrationAudioSource.PlayOneShot(narrationAudioClips_Bathroom[6]);
        //GameManager.instance.ShowAlert(narration_1[14], 8f);

        yield return new WaitForSeconds(narrationAudioClips_Bathroom[6].length - 5f);
        mobilePhone.SetPhoneHangUp();

        yield return new WaitForSeconds(5f + 1.1f);

        //PlayAudioAndNarration(narrationAudioClips_1[5], narration_1[15], narrationAudioClips_1[4].length);

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
        ControllerInteractionsManager.instance.autoDropItems = false; // no dropping items (can also disable in scene)

        yield return new WaitForSeconds(4f); // screen fade in timing

        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[0]);

        yield return new WaitForSeconds(narrationAudioClips_2[0].length);

        GameManager.instance.ShowAlert(narration_2[3]);

        // allow take dentures off from here
        GameManager.instance.toTakeDenturesOff = true;
        //GameManager.instance.ShowAlert(narration_2[11]);
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
    [SerializeField] GameObject parents;
    [SerializeField] GameObject mother;
    [SerializeField] GameObject father;
    [SerializeField] GameObject tableWithMedicine;
    [SerializeField] GameObject sideTable;
    [SerializeField] GameObject hallucinationParticleFX;
    [SerializeField] GameObject chair;
    [SerializeField] GameObject cabinet;
    [SerializeField] GameObject originallyHeldMedicine;
    [SerializeField] GameObject animatedMedicine;
    [SerializeField] GameObject SecondOriginallyHeldMedicine;
    [SerializeField] GameObject SecondAnimatedMedicine;
    [SerializeField] GameObject PillBottleHighlight;
    [SerializeField] GameObject SecondPillBottleHighlight;
    [SerializeField] GameObject photoFrame;
    [SerializeField] GameObject NewPhotoFrame;
    [SerializeField] GameObject TransformPlace;
    [SerializeField] GameObject oldMode;
    [SerializeField] GameObject newMode;
    [SerializeField] GameObject photoFrameOutline;
    [SerializeField] AnimationClip HandsUp;
    [SerializeField] AnimationClip HandsDown;
    Trans2 photoFrameOriginalPosition = new();
    Animator animator;
    static public bool canMedicineSpill;

    IEnumerator Segment2Part2_1()
    {
        StopPrevDialogue();
        canMedicineSpill = false;
        CupOutline.enabled = false;
        // Buffer time for them to put dentures in cup
        yield return new WaitForSeconds(3f);

        //SaveGOTransform(photoFrame.transform,photoFrameOriginalPosition);

        // start furniture moving here
        sideTable.GetComponent<Animator>().SetTrigger("move");
        hallucinationParticleFX.SetActive(true);
        yield return new WaitForSeconds(5f); // side table move to center of room first to direct player attention to center of room
        GameManager.instance.toStartSpasming = true;
        yield return new WaitForSeconds(5f);
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[1]);

        // wait a while to let players look around
        yield return new WaitForSeconds(6f);

        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        oldMode.SetActive(true);
        newMode.SetActive(false);
        parents.SetActive(true);

        // Turn to old room
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(4f);

        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[2]);
        yield return new WaitForSeconds(narrationAudioClips_2[2].length + 1f);

        if (MainMenuManager.isGenderMale)
        {
            animator = father.GetComponent<Animator>();
        }
        else
        {
            animator = mother.GetComponent<Animator>();
        }

        animator.SetTrigger("TalkBegin");
        yield return new WaitForSeconds(HandsUp.length); // wait for hands up animation to finish before start talking
        animator.SetTrigger("Talking");

        narrationAudioSource.PlayOneShot(narrationAudioClips_2[3]);
        yield return new WaitForSeconds(narrationAudioClips_2[3].length + 1f);

        animator.SetTrigger("TalkEnd");

        narrationAudioSource.PlayOneShot(narrationAudioClips_2[4]);
        yield return new WaitForSeconds(narrationAudioClips_2[4].length + 1f);
Destroy(photoFrame);
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);
        //Turn back to normal here
        oldMode.SetActive(false);
        newMode.SetActive(true);

        //Re enable the furniture
        GameManager.instance.toStartSpasming = false;
        sideTable.SetActive(true);
        //SetGOTransform(NewPhotoFrame.transform,photoFrameOriginalPosition);
        NewPhotoFrame.SetActive(true);
        NewPhotoFrame.transform.position = TransformPlace.transform.position;
        tableWithMedicine.SetActive(true);
        cabinet.SetActive(true);
        chair.SetActive(true);
        parents.SetActive(false);
        hallucinationParticleFX.SetActive(false);

        // play this voiceover while the screen is black
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[5]);
        yield return new WaitForSeconds(narrationAudioClips_2[5].length + 1f);
        
        

        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(4f);

        //GameManager.instance.ShowAlert(narration_2[6], 12f);
        yield return new WaitForSeconds(2f);

        //PlayAudioAndNarration(narrationAudioClips_2[3], narration_2[8], narrationAudioClips_2[3].length);
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[6]);
        yield return new WaitForSeconds(narrationAudioClips_2[6].length + 1.1f);

        canMedicineSpill = true;
        PillBottleHighlight.SetActive(true);
    }

    public void FirstMedicationDropped()
    {
        StopPrevDialogue();
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_General[0]); // sigh sfx

        // for the scripted animation of medicine getting toppled over
        originallyHeldMedicine.SetActive(false);
        animatedMedicine.SetActive(true);
        animatedMedicine.GetComponent<Animator>().enabled = true;
        animatedMedicine.GetComponent<AudioSource>().Play(); // play pill dropping sound

        StartCoroutine(ShowSecondPillBottleOutline());
    }

    IEnumerator ShowSecondPillBottleOutline()
    {
        yield return new WaitForSeconds(2);

        SecondPillBottleHighlight.SetActive(true);

        yield return new WaitForSeconds(0.5f); // add a bit of delay between outline showing and being able to interact with 2nd pill bottle

        SecondOriginallyHeldMedicine.GetComponent<Medicine>().enabled = true;
    }

    public void SecondMedicationDropped()
    {
        StopPrevDialogue();
        narrationAudioSource.Stop();
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[7]);

        SecondOriginallyHeldMedicine.SetActive(false);
        SecondAnimatedMedicine.SetActive(true);
        SecondAnimatedMedicine.GetComponent<Animator>().enabled = true;
        SecondAnimatedMedicine.GetComponent<AudioSource>().Play(); // play pill dropping sound

        StartCoroutine(Segment2Part2_2());
    }
    
    IEnumerator Segment2Part2_2()
    {
        yield return new WaitForSeconds(10f); // buffer time
        GameManager.instance.toLookAtObjective = true;
        //photoFrame.GetComponent<Grabbable>().enabled = true;
        

        photoFrameOutline.SetActive(true);
        NewPhotoFrame.GetComponent<TurnOffOutlineWhenGrabbed>().enabled = true;
        NewPhotoFrame.GetComponent<ForceStayGrabbed>().active = true;
        NewPhotoFrame.transform.GetComponentInChildren<LookAtObjective>().enabled = true;

        // add new dialogue here
        yield return null;
    }

    public void StaredAtPhoto()
    {
        lastRoutine = StartCoroutine(Segment2Part2_3());
    }

    IEnumerator Segment2Part2_3()
    {
        narrationAudioSource.PlayOneShot(narrationAudioClips_2[8]);
        yield return new WaitForSeconds(narrationAudioClips_2[8].length + 1.1f);

        photoFrameOutline.SetActive(false);
        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);
        MainMenuManager.videoOrMenu = true;
        MainMenuManager.video = VideoToPlay.AfterPresentBad;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetupNarrationGeneral();
        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            SetupNarrationBathroomLivingRoom();
            PlaySegment1Part1();
            RenderSettings.skybox = normalSkybox;
        }
        else if (sceneToPlay == SceneToPlay.Bedroom)
        {
            SetupNarrationBedroom();
            //PlaySegment2Part1();
            StartCoroutine(Segment2Part2_1());
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
                    questControllerImage.SetActive(false);
                    StopPrevDialogue();
                    alertRemovedAfterFirstTP = true;
                }
            }

            // check here when player reaches sofa, start segment1Part3
            if (toGoLivingRoom)
            {
                if(cane.GetComponent<CaneTeleport>().GetCurrentHotspotIndex() == 5 && lastRoutine == null)
                {
                    PlaySegment1Part2Half();
                }
                
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

    public void SetGOTransform(Transform gameObjectTransform,Trans2 desiredTransform) // set go transform to previously saved transform
    {
        gameObjectTransform.position = desiredTransform.position;
        gameObjectTransform.rotation = desiredTransform.rotation;
        gameObjectTransform.localScale = desiredTransform.scale;
    }

    public void SaveGOTransform(Transform gameObjectTransform,Trans2 savedGOTransform) // saves gameobject transform to a variable
    {
        savedGOTransform.position = gameObjectTransform.position;
        savedGOTransform.rotation = gameObjectTransform.rotation;
        savedGOTransform.scale = gameObjectTransform.localScale;
    }

}
