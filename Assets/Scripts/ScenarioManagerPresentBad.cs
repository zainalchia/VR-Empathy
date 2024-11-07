using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;

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
    string[] narration_1 = new string[50];

    // for bedroom scene
    [SerializeField] AudioClip[] narrationAudioClips_2;
    string[] narration_2 = new string[50];

    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject cane;
    [SerializeField] GameObject firstTeleportHotspot;

    Coroutine lastRoutine = null;

    void SetupNarrationBathroomLivingRoom()
    {
        narration_1[0] = "I am balding.";
        narration_1[1] = "Cool mirror.";
        narration_1[2] = "I need to put my dentures on and wash up.";
        narration_1[3] = "Can't forget my dentures!"; // stay on screen until dentures put on

        narration_1[4] = "Time to relax in the living room.";
        narration_1[5] = "I have to use the cane and move to living room.";
        narration_1[6] = "Open the door and go to the sofa."; // stay on screen until open
        narration_1[7] = "[Use the cane to find spots to move to and then press 'A']"; // stay on screen until first tp

        narration_1[8] = "Someone is calling. Pick up the phone.";
        narration_1[9] = "I can't see that well.";
        narration_1[10] = "I need to use my glasses.";
        narration_1[11] = "Aiya... dropped my glasses.";
        narration_1[12] = "Aiya... dropped my glasses again.";
        narration_1[13] = "Grab the phone with one hand and tap with the other hand to answer."; // stay on screen until phone is answered

        narration_1[14] = "Dialogue from man";
        narration_1[15] = "reply";
        narration_1[16] = "...";
        narration_1[17] = "...";
    }

    void SetupNarrationBedroom()
    {
        narration_2[0] = "Another day goes by again";
        narration_2[1] = "Time to get ready to sleep";
        narration_2[2] = "I have to take off my dentures and place in the cup. [Grab your face area]"; // stay on screen until placed in cup
        narration_2[3] = "I need to take off my glasses as well. [Grab your face area]"; // stay on screen until take off
        narration_2[4] = "Is this real? Am I going mad";
        narration_2[5] = "I'm seeing things because I forgot to take my medicine.";
        narration_2[6] = "Use the cane to move towards the medicine table.";
        narration_2[7] = "I need to check the calendar so I know which medicine to eat.";
        narration_2[8] = "This is not the medicine. Put it aside.";
        narration_2[9] = "Haiz it spilled everywhere.";
    }

    #region Segment 1 Part 1 (In the Bathroom)
    [Header("In the bathroom")]
    [SerializeField] float timeForWashingUp = 30f;
    //bool hasWashedUp = false;
    //bool isDenturesOn = false;

    public void PlaySegment1Part1()
    {
        lastRoutine = StartCoroutine(Segment1Part1());
    }

    IEnumerator Segment1Part1()
    {
        PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        ControllerInteractionsManager.instance.allowDropItems = false; // no dropping item yet
        cane.GetComponent<Grabbable>().enabled = false; // disable cane grabbable first

        yield return new WaitForSeconds(4f);

        GameManager.instance.ShowAlert(narration_1[0], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[1], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[2], 6f);

        //GameManager.instance.toPutDenturesOn = true;

        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);
        
        //hasWashedUp = true;
        //if (!isDenturesOn)
        //{
        //    GameManager.instance.ShowAlert(narration_1[3], Color.red);
        //}
        //else
        //    PlaySegment1Part2();
        PlaySegment1Part2();
    }

    //public void DenturesPutOn() // called in UnityEvent from PlayerFace
    //{
    //    isDenturesOn = true;
    //    if (hasWashedUp)
    //    {
    //        PlaySegment1Part2();
    //    }
    //}

    #endregion

    #region Segment 1 Part 2 (From bathroom to living room)
    [Header("Moving towards living room")]
    [SerializeField] DoorKnob bathroomDoor;
    [SerializeField] GameObject arrowToCane;
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
        arrowToCane.SetActive(true);

        GameManager.instance.ShowAlert(narration_1[4], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[5], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[6]);

        // can open bathroom door from here
        bathroomDoor.AllowDoorOpen();
    }

    public void BathroomDoorOpen() // called in UnityEvent in bathroom door
    {
        StopPrevDialogue();

        firstTeleportHotspot.SetActive(true); // enable first teleport hotspot
        GameManager.instance.ShowAlert(narration_1[7]);
        toGoLivingRoom = true;
    }


    #endregion

    #region Segment 1 Part 3 (Living room)
    [Header("In living room")]
    [SerializeField] MobilePhone mobilePhone;
    [SerializeField] GameObject arrowToPhone;
    [SerializeField] GameObject arrowToGlasses;

    int dropGlassesCount = 0;

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
        arrowToPhone.SetActive(true);

        GameManager.instance.ShowAlert(narration_1[8], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.toPickUpPhone = true;
    }

    public void PhonePickedUp() // called in UnityEvent in MobilePhone
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(Segment1Part3_2());
    }

    IEnumerator Segment1Part3_2()
    {
        arrowToPhone.SetActive(false);
        ControllerInteractionsManager.instance.allowDropItems = true; // will drop items from here
        GameManager.instance.toPutGlassesOn = true;

        GameManager.instance.ShowAlert(narration_1[9], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        arrowToGlasses.SetActive(true);
        GameManager.instance.ShowAlert(narration_1[10], 3f);
        yield return new WaitForSeconds(3f + 1.1f);
        
    }

    public void DropGlassesReaction() // called in UnityEvent in ControllerInteractionsManager
    {
        StopPrevDialogue();

        dropGlassesCount++;

        
        if (dropGlassesCount == 1)
            GameManager.instance.ShowAlert(narration_1[11], 3f);
        else if (dropGlassesCount == 2)
            GameManager.instance.ShowAlert(narration_1[12], 3f);

    }

    public void GlassesPutOn() // called in UnityEvent in PlayerFace
    {
        StopPrevDialogue();
        arrowToGlasses.SetActive(false);

        ControllerInteractionsManager.instance.allowDropItems = false; // no more dropping after glasses put on
        GameManager.instance.ShowAlert(narration_1[13]);
        GameManager.instance.canAnswerPhone = true;
    }

    public void PhoneAnswered() // called in UnityEvent in MobilePhone
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(Segment1Part3_3());
    }

    IEnumerator Segment1Part3_3() // Dialogue between player and caller
    {
        yield return new WaitForSeconds(2f);

        GameManager.instance.ShowAlert(narration_1[14], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[15], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[16], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_1[17], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        // play phone hang up here
        mobilePhone.SetPhoneHangUp();

        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        // load next scene here
        SceneManager.LoadScene(1, LoadSceneMode.Single); // Or whatever number present bad bedroom scene is
    }


    #endregion

    #region Segment 2 Part 1 (Bedroom - Taking off glasses and dentures)
    [Header("Bedroom 1st Part")]
    [SerializeField] GameObject arrowToCup;

    public void PlaySegment2Part1()
    {
        lastRoutine = StartCoroutine(Segment2Part1_1());
    }
    IEnumerator Segment2Part1_1()
    {
        PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        ControllerInteractionsManager.instance.allowDropItems = false; // no dropping items (can also disable in scene)
        cane.GetComponent<Grabbable>().enabled = false; // disable cane grabbable first

        yield return new WaitForSeconds(4f);

        GameManager.instance.ShowAlert(narration_2[0], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        GameManager.instance.ShowAlert(narration_2[1], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        // allow take dentures off from here
        GameManager.instance.toTakeDenturesOff = true;

        GameManager.instance.ShowAlert(narration_2[2]); 
    }

    public void DenturesPlacedInCup() // called in UnityEvent in denture cup
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(Segment2Part1_2());
    }

    IEnumerator Segment2Part1_2()
    {
        arrowToCup.SetActive(false);
        yield return new WaitForSeconds(1f);

        // allow take glasses off from here
        GameManager.instance.toTakeGlassesOff = true;

        GameManager.instance.ShowAlert(narration_2[3]);
    }

    public void GlassesTakeOff() // called in UnityEvent in GameManager
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
    [SerializeField] GameObject tableWithMedicine;
    [SerializeField] GameObject arrowToPlaceMedicine;
    [SerializeField] GameObject originallyHeldMedicine;
    [SerializeField] GameObject animatedMedicine;

    bool toGoMedicineTable = false;

    float animatedMedicineHeight = 1.078f;
    float medicineOffsetX = -0.046f;
    float medicineOffsetZ = -0.007f;

    IEnumerator Segment2Part2_1()
    {
        // start furniture moving here
        GameManager.instance.toStartSpasming = true;

        // wait a while to let players look around
        yield return new WaitForSeconds(8f);

        // clouds and ship illusions here
        flyingShip.SetActive(true);
        flyingShip.GetComponent<Disappear>().AllowedToMove(true);
        cloudy1.GetComponent<ParticleSystem>().Play();
        cloudy2.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(6f);

        cloudy1.GetComponent<ParticleSystem>().Stop();
        cloudy2.GetComponent<ParticleSystem>().Stop();
        flyingShip.GetComponent<Disappear>().AllowedToMove(false);
        flyingShip.SetActive(false);

        GameManager.instance.ShowAlert(narration_2[4], 3f);
        yield return new WaitForSeconds(3f + 1.1f);

        tableWithMedicine.SetActive(true); // table with medicine will re-appear here

        GameManager.instance.ShowAlert(narration_2[5], 5f);
        yield return new WaitForSeconds(5f + 1.1f);

        cane.GetComponent<Grabbable>().enabled = true; // can be grabbed from here
        firstTeleportHotspot.SetActive(true); // enable first teleport hotspot
        toGoMedicineTable = true;

        GameManager.instance.ShowAlert(narration_2[6], 5f);
        yield return new WaitForSeconds(5f + 1.1f);

    }

    void NearMedicineTable() // called when player is in front of the table
    {
        StopPrevDialogue();
        GameManager.instance.ShowAlert(narration_2[7], 5f);
    }

    public void WrongMedicineGrabbed()
    {
        StopPrevDialogue();
        GameManager.instance.ShowAlert(narration_2[8], 5f);
        arrowToPlaceMedicine.SetActive(true);
    }

    public void MedicationDropped()
    {
        StopPrevDialogue();

        arrowToPlaceMedicine.SetActive(false);
        originallyHeldMedicine.SetActive(false);
        animatedMedicine.transform.position = new Vector3(originallyHeldMedicine.transform.position.x + medicineOffsetX, animatedMedicineHeight, originallyHeldMedicine.transform.position.z + medicineOffsetZ);
        animatedMedicine.SetActive(true);
        animatedMedicine.GetComponent<Animator>().enabled = true;
        lastRoutine = StartCoroutine(Segment2Part2_2());
    }

    IEnumerator Segment2Part2_2()
    {
        //// all furnitures to appear again
        //foreach (GameObject obj in movingFurnitures)
        //{
        //    obj.SetActive(true);
        //}

        GameManager.instance.ShowAlert(narration_2[9], 5f);
        yield return new WaitForSeconds(5f + 1.1f);
        // play sobbing sound instead of text above also can

        // fade screen here
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);

        
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
            // disable arrow when glasses picked up
            if (GameManager.instance.toPutGlassesOn)
            {
                if (GameManager.instance.glasses.GetComponent<GrabInteractable>().SelectingInteractors.Count > 0)
                {
                    arrowToGlasses.SetActive(false);
                }
                else
                {
                    arrowToGlasses.SetActive(true);
                    arrowToGlasses.transform.position = GameManager.instance.glasses.transform.position + new Vector3(0, 0.25f, 0); // move arrow above glasses 
                }
            }
            #endregion
        }
        else if (sceneToPlay == SceneToPlay.Bedroom)
        {
            #region Going towards medicine table
            if (toGoMedicineTable)
            {
                if (cane.GetComponent<CaneTeleport>().HasTeleportedOnce())
                {
                    toGoMedicineTable = false;
                    NearMedicineTable();
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
