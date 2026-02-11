using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    [SerializeField] public AudioSource narrationAudioSource;
    [SerializeField] public AudioSource bossAudioSource;

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
    [SerializeField] GameObject door;
    [SerializeField] GameObject doorOutline;
    [SerializeField] GameObject comb;
    [SerializeField] GameObject glasses;
    [SerializeField] GameObject cup;
    [SerializeField] GameObject book;
    [SerializeField] GameObject meds;
    [SerializeField] AudioSource walkingSound;

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
        door.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(4f); // screen fade in timing

        // Another horrible day at work. Been working here at the hawker center for so long, still the same.
        // Sigh. Okay just have to wash my face and freshen up and get back to work
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[0]);
        yield return new WaitForSeconds(narrationAudioClips_1[0].length);
        promptManager.ShowPrompt(sceneID, 0, false, 3f);

        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);

        //boss should call the player over to get out quickly here and then player starts moving
        promptManager.ShowPrompt(sceneID, 1, false, 5f);
        //============================================================

        // Oi Robert / Ling! How long you want to use the toilet?! Faster come back work!
        bossAudioSource.PlayOneShot(narrationAudioClips_1[1]);
        door.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(narrationAudioClips_1[1].length);

        // sigh. Okay, coming boss.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[2]);
        yield return new WaitForSeconds(narrationAudioClips_1[2].length);

        // Teleport from sink to toilet door
        promptManager.ShowPrompt(sceneID, 2, false, 10f);
        doorOutline.GetComponent<Outline>().enabled = true;
        comb.GetComponent<Outline>().enabled = false;
        glasses.GetComponent<Outline>().enabled = false;
        book.GetComponent<Outline>().enabled = false;
        cup.GetComponent<Outline>().enabled = false;
        meds.GetComponent<Outline>().enabled = false;
        comb.GetComponent<GrabInteractable>().enabled = false;
        glasses.GetComponent<GrabInteractable>().enabled = false;
        book.GetComponent<GrabInteractable>().enabled = false;
        cup.GetComponent<GrabInteractable>().enabled = false;
        meds.GetComponent<GrabInteractable>().enabled = false;

        playerTeleport.SetCurrentHotspotIndex(-1);
        firstTeleportToiletHotspot.SetActive(true);
        playerTeleport.MoveToToiletDoor = true;
      
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
        walkingSound.Play();
        yield return new WaitForSeconds(8f);

        // load next scene 
        SceneManager.LoadScene("PastNegativeHawker", LoadSceneMode.Single);
    }

    public void PlayAllowOpenDoor()
    {
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
    [SerializeField] GameObject BossAudio;
    [SerializeField] GameObject bossThrowPosition;
    private bool playOnce = true;
    [SerializeField] private HeartbeatUI heartbeatUI;
    [SerializeField] private GameObject Customer;
    [SerializeField] private GameObject ChoppingBlock;
    [SerializeField] private GameObject Chicken;
 
    [Header("Plaster")]
    [SerializeField] private GameObject bandaidContainer;
    [SerializeField] private Animator lidAnimator;
    [SerializeField] private string lidPopTrigger = "PopOff";
    [SerializeField] private LidMover lidMover;
    [SerializeField] private GameObject plasterPrefab;
    [SerializeField] private Transform plasterSpawnPoint;

    [Header("Cleaver")]
    [SerializeField] private GameObject cleaverObject;
    private Outline cleaverOutline;

    [Header("Teleporter")]
    [SerializeField] private GameObject ToTray;

    [Header("Tray")]
    [SerializeField] private Outline trayOutline;

    public void PlayHawkerStart()
    {
        lastRoutine = StartCoroutine(HawkerStart());
    }
    IEnumerator HawkerStart()
    {
        cashObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);

        // Finally. Faster la serve customer!
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[0]);
        yield return new WaitForSeconds(narrationAudioClips_1[0].length);

        Customer.GetComponent<Animator>().SetBool("SheakHead", true);

        // How long you want to make me wait? I wait here very long already.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[1]);
        yield return new WaitForSeconds(narrationAudioClips_1[1].length);

        // Sorry about that can I take your order
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[2]);
        yield return new WaitForSeconds(narrationAudioClips_1[2].length);
        // Give me 2 chicken rice
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[3]);
        yield return new WaitForSeconds(narrationAudioClips_1[3].length);

        Customer.GetComponent<Animator>().SetBool("HandOverMoney", true);

        Customer.GetComponent<Animator>().SetBool("Idle", true);

        promptManager.ShowPrompt(SceneID.Stall, 0, false, 6f);
        // Hand over cash
        cashObject.SetActive(true);
        //promptManager.ShowPrompt(SceneID.Stall, 1);

    }
    public void OnCashPlaced()
    {
        // player has put cash into register
        playerTeleport.hasPlacedCash = true;

        if (cleaverOutline != null)
            cleaverOutline.enabled = true;

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

        Boss.transform.position = bossThrowPosition.transform.position;
        Boss.transform.eulerAngles = Vector3.zero;
    }
    public void PlayChoppedHand()
    {
        StopPrevDialogue();
        lastRoutine = StartCoroutine(ChoppedHand());
    }

    IEnumerator ChoppedHand()
    {
        // ow
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[5]);
        heartbeatUI.KnifeAccidentFlash();
        yield return new WaitForSeconds(narrationAudioClips_1[5].length);


        // Boss scolds player
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[6]);
        //Boss.gameObject.SetActive(true);
        yield return new WaitForSeconds(narrationAudioClips_1[6].length);

        promptManager.ShowPrompt(SceneID.Stall, 3, false, 6f); //grab the plaster

        if (playerTeleport != null)
        {
            playerTeleport.GoToFirstAid = true; //enables to tp

            var jobHotspots = playerTeleport.GetMoveToJobPositionHotspots(); //get all hotspots
            if (jobHotspots.Length > 2) //index 2
            {
                jobHotspots[2].SetActive(true); //show hotspot
                if (jobHotspots[2].transform.childCount > 0) //visuals
                    jobHotspots[2].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        
        // Enable bandaid interaction
        GameManager.instance.toUsePlaster = true;
        bandaidContainer.GetComponent<Grabbable>().enabled = true;
        bandaidContainer.GetComponent<GrabInteractable>().enabled = true;
        bandaidContainer.GetComponent<PhysicsGrabbable>().enabled = true;
        bandaidContainer.GetComponent<PlasterContainer>().enabled = true;
        bandaidContainer.GetComponent<Outline>().enabled = true;

        yield return new WaitUntil(() => GameManager.instance.handHealed); //only happen when handhealed is true
                                                                           //MovePLayer();
                                                                           // Boss.gameObject.SetActive(true);
                                                                           //Boss.GetComponent<WaypointManager>().startwalktrigger();
                                                                           //Boss.GetComponent<Animator>().SetBool("IsWalking", true);
                                                                           //yield return new WaitForSeconds(1.5f);
                                                                           //Boss.GetComponent<Animator>().SetBool("IsWalking", false);
        BossAudio.GetComponent<WaypointManager>().startwalktrigger();
        yield return new WaitForSeconds(2F);
        // boss confront
        BossAudio.GetComponent<AudioSource>().Play();

        BossAudio.GetComponent<WaypointManager>().enabled = false;
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[7]);
        yield return new WaitForSeconds(narrationAudioClips_1[7].length);

        if (trayOutline != null)
            trayOutline.enabled = true;

        promptManager.ShowPrompt(SceneID.Stall, 4, false, 6f);

        ToTray.SetActive(true);

    }

    public void OnTeleportedToBandAid()
    {
        if (cleaverObject != null)
            cleaverObject.SetActive(false);

        if (ChoppingBlock != null)
            ChoppingBlock.SetActive(false);

        if (Chicken != null)
            Chicken.SetActive(false);
    }


    public void OnPlasterContainerGrabbed()
    {
        if (lidAnimator != null)
            lidAnimator.SetTrigger(lidPopTrigger);
        bandaidContainer.GetComponent<Outline>().enabled = false;
        // slight delay on the lid
        StartCoroutine(MoveLidAfterDelay(0.5f));
    }

    private IEnumerator MoveLidAfterDelay(float delay)
    {
        // wait for anim
        yield return new WaitForSeconds(delay);

        // Stop animator 
        if (lidAnimator != null)
            lidAnimator.enabled = false;


        // Move the lid to the table
        var mover = bandaidContainer.GetComponentInChildren<LidMover>();
        if (mover != null)
        {
            mover.MoveToTable();
            mover.transform.SetParent(null); //detach from parent
        }

        yield return new WaitForSeconds(1f);
        SpawnPlaster();
    }

    public void SpawnPlaster()
    {
        TrayOfFood.SetActive(true);

        // plaster inside the bottle
        GameObject plaster = Instantiate(plasterPrefab, plasterSpawnPoint.position, plasterSpawnPoint.rotation);
        GameManager.instance.plaster = plaster;

        // Always send plaster to the right hand
        Transform targetPalm = GameManager.instance.rightPalm;

        // Move the pill into the palm
        StartCoroutine(MovePlasterToHand(plaster, targetPalm));
    }

    private IEnumerator MovePlasterToHand(GameObject plaster, Transform targetPalm, float height = 0.2f, float duration = 1f)
    {
        // take start and target positions
        Vector3 start = plaster.transform.position;
        Vector3 target = targetPalm.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            // move plaster
            Vector3 current = Vector3.Lerp(start, target, t);
            // arc like checkers
            current.y += Mathf.Sin(t * Mathf.PI) * height;
            // position
            plaster.transform.position = current;
            yield return null;
        }

        // snap plaster into right palm
        plaster.transform.position = targetPalm.position + targetPalm.up * 0.02f;
        plaster.transform.rotation = targetPalm.rotation;
        plaster.transform.SetParent(targetPalm);

        // Force grab with right hand only
        var grabInteractable = plaster.GetComponent<GrabInteractable>();
        ControllerInteractionsManager.instance.rightGrabInteractor.ForceSelect(grabInteractable);

    }

    [SerializeField] GameObject TrayOfFood;
    [SerializeField] GameObject DroppedFood;
    [SerializeField] GameObject PlayerCloth;
    [SerializeField] GameObject PlateProjectilePrefab;   // plate to spawn & throw
    public Transform PlateSpawnPoint;   // where plate appears
    public Transform PlateTargetPoint;  // where the plate flies toward

    [SerializeField] float plateSpeed = 10f;             // how fast it flies

    [Header("Plate Collision")]
    [SerializeField] private LayerMask wallLayer;


    

    public void PlayFoodDrop()
    {

        // Drop the tray
        TrayOfFood.transform.SetParent(null);
        Rigidbody rb = TrayOfFood.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;

        TrayOfFood.GetComponent<ForceStayGrabbed>().SetForceGrabActive(false);
        TrayOfFood.GetComponent<Grabbable>().enabled = false;

        ControllerInteractionsManager.instance.rightGrabInteractor.ForceRelease();
        ControllerInteractionsManager.instance.leftGrabInteractor.ForceRelease();

       
    }

    public void OnTrayHitFloor(Vector3 trayPosition) //called from tray script
    {
        TrayOfFood.SetActive(false);

        DroppedFood.transform.position = new Vector3(
            trayPosition.x,
            0.05f,
            trayPosition.z
        );
        DroppedFood.SetActive(true);

        if (playOnce)
        {
            playOnce = false;
            lastRoutine = StartCoroutine(ThrowPlate());
        }
    }

    // ----------------------------------------------------------------------
    // NEW MAIN EVENT — Boss throws a plate at the player
    // ----------------------------------------------------------------------
    public IEnumerator ThrowPlate()
    {
        yield return new WaitForSeconds(2f);

        Boss.transform.localRotation = Quaternion.Euler(0f, 75f, 0f);
        yield return new WaitForSeconds(0.6f);

        // Dialogue
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[8]);
        yield return new WaitForSeconds(narrationAudioClips_1[8].length);

        Boss.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
        Boss.GetComponent<Animator>().SetTrigger("ThrowingPlate");
        yield return new WaitForSeconds(0.5f);

        

        // ------------------------------------------------------------------
        // ENABLE EXISTING PLATE (instead of Instantiate)
        // ------------------------------------------------------------------
        GameObject proj = PlateProjectilePrefab;

        proj.SetActive(true);
        proj.transform.position = PlateSpawnPoint.position;
        proj.transform.rotation = Quaternion.identity;
        proj.transform.SetParent(null);


        proj.layer = LayerMask.NameToLayer("Plate");

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = false;
        rb.useGravity = true;

        plateHitGround = false;

        Vector3 direction = (PlateTargetPoint.position - PlateSpawnPoint.position).normalized;

        while (proj != null && !plateHitGround)
        {
            rb.velocity = direction * plateSpeed;
            yield return null;
        }

        // ------------------------------------------------------------------
        // Enable cleaning
        // ------------------------------------------------------------------
        PlayerCloth.GetComponent<Outline>().enabled = true;
        PlayerCloth.GetComponent<Cloth>().enabled = true;
        PlayerCloth.GetComponent<GrabInteractable>().enabled = true;
        PlayerCloth.GetComponent<ForceStayGrabbed>().enabled = true;
        PlayerCloth.GetComponent<Grabbable>().enabled = true;
        PlayerCloth.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);

        promptManager.ShowPrompt(SceneID.Stall, 5, false, 6f);
    }


  


    // You need to set this from a collision script on the plate
    private bool plateHitGround = false;

    public void PlateImpact()
    {
        // Call this from OnCollisionEnter on the Plate object
        plateHitGround = true;

        narrationAudioSource.PlayOneShot(narrationAudioClips_1[9]);
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

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("PastNegativeHome", LoadSceneMode.Single);
    }
    #endregion

    #region Family
    [Header("In Home")]
    [SerializeField] GameObject Ladle;
    [SerializeField] GameObject Sean;
    [SerializeField] GameObject Model;
    [SerializeField] AudioSource SeanAudioSource;
    [SerializeField] Light HomeLight;
    [Header("Sean Tissue Box")]
    [SerializeField] private GameObject tissueBox;
    private Outline tissueBoxOutline;
    public void PlayFamilyStart()
    {
        lastRoutine = StartCoroutine(FamilyStart());
    }

    IEnumerator FamilyStart()
    {

        //GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeIn");
        //yield return new WaitForSeconds(2);
        //GameManager.instance.fadePanel.GetComponent<Animator>().ResetTrigger("FadeIn");

        // I’m home
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[0]);
        yield return new WaitForSeconds(narrationAudioClips_1[0].length);

        // Finally, why come back so late?? Food cold already.
        Model.GetComponent<Animator>().SetBool("GetAngry", true);
        Debug.Log("wife get angry");
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

        Model.GetComponent<Animator>().SetBool("GetAngry", false);
        Debug.Log("wife get angry");

        promptManager.ShowPrompt(sceneID, 0, false, 2f);

        // Pour food segment
        Ladle.GetComponent<Grabbable>().enabled = true;
        Ladle.GetComponent<ForceStayGrabbed>().enabled = true;
        Ladle.GetComponent<PhysicsGrabbable>().enabled = true;
        Ladle.GetComponent<GrabInteractable>().enabled = true;
        Ladle.GetComponent<ForceStayGrabbed>().SetForceGrabActive(true);
    }
    public void PlayLightOFf() // Called in Ladle.cs
    {
        lastRoutine = StartCoroutine(LightOff());
    }
    IEnumerator LightOff()
    {
        // Drop ladle
        Ladle.GetComponent<Grabbable>().enabled = false;
        Ladle.GetComponent<ForceStayGrabbed>().enabled = false;
        Ladle.GetComponent<PhysicsGrabbable>().enabled = false;
        Ladle.GetComponent<GrabInteractable>().enabled = false;
        Ladle.GetComponent<Rigidbody>().isKinematic = false;
        Ladle.GetComponent<Rigidbody>().useGravity = true;
        ControllerInteractionsManager.instance.rightGrabInteractor.ForceRelease();
        ControllerInteractionsManager.instance.leftGrabInteractor.ForceRelease();

        // Disable Ladle
        //Ladle.gameObject.SetActive(false);


        // I’m sorry, son.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[4]);
        yield return new WaitForSeconds(narrationAudioClips_1[4].length);

        // Our water and electricity bills how long haven’t pay already...
        // Somemore every month our parents make us give them so much money…
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[5]);
        yield return new WaitForSeconds(narrationAudioClips_1[5].length);

        // Turn off lights and dim environment and sean's hand is messy and full of food
        HomeLight.color = Color.black;

        // Daddy / Mummy what happened??? I cannot see!! [pause] Daddy / Mummy I’m scared
        Sean.GetComponent<Animator>().SetBool("Crying", true);
        Debug.Log("child starts crying");
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[6]);
        yield return new WaitForSeconds(narrationAudioClips_1[6].length);

        // It's ok son, it's ok.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[7]);
        yield return new WaitForSeconds(narrationAudioClips_1[7].length);

        Sean.GetComponent<Animator>().SetBool("Crying", false);
        Debug.Log("child stop crying");


        promptManager.ShowPrompt(sceneID, 1, false, 2f);

        // Tissue Cry Segment
        if (tissueBoxOutline != null)
            tissueBoxOutline.enabled = true;
    }
    public void PlayFinalHome() // Called in Sean.cs
    {
        lastRoutine = StartCoroutine(FinalHome());
    }

    IEnumerator FinalHome()
    {
        // Daddy / Mummy why no light??
        Sean.GetComponent<Animator>().SetBool("Crying", true);
        Debug.Log("child starts crying");
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[8]);
        yield return new WaitForSeconds(narrationAudioClips_1[8].length);
        Sean.GetComponent<Animator>().SetBool("Crying", false);
        Debug.Log("child stop crying");

        // fade out
        GameManager.instance.fadePanel.GetComponent<Animator>().SetTrigger("FadeOut");

        // Sean crying volume gets lower
        SeanAudioSource.Play();
        LowerVolume(SeanAudioSource, 0.1f);

        //I work so hard for my family.
        //I get bullied, scolded, even beaten at work, and nobody can help me do anything about it.
        //My wife / husband still not happy, I still can’t provide for my family. Sigh.
        narrationAudioSource.PlayOneShot(narrationAudioClips_1[9]);
        yield return new WaitForSeconds(narrationAudioClips_1[9].length);

    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetupNarration();
        playerTeleport.currentScene = ScenarioID.PastNegative;
        if (cleaverObject != null)
        {
            cleaverOutline = cleaverObject.GetComponent<Outline>();
            if (cleaverOutline != null)
                cleaverOutline.enabled = false;
        }
        // Tissue box setup
        if (tissueBox != null)
        {
           tissueBoxOutline = tissueBox.GetComponent<Outline>();

            if (tissueBoxOutline != null)
                tissueBoxOutline.enabled = false; // disabled until Sean segment
        }

        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            sceneID = SceneID.Bathroom;
            PlayBathroom();
        }
        else if (sceneToPlay == SceneToPlay.Stall)
        {
            sceneID = SceneID.Stall;
            PlayHawkerStart();
            //PlayChoppedHand();
        }
        else if (sceneToPlay == SceneToPlay.Home)
        {
            sceneID = SceneID.Family;
            PlayFamilyStart();
            //PlayLightOFf();
        }
       

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayChoppedHand();
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

    void LowerVolume(AudioSource source, float TargetVolume)
    {
        source.volume = Mathf.Lerp(source.volume, TargetVolume, Time.deltaTime);
    }
    [SerializeField] GameObject PlayerDestination;
    [SerializeField] GameObject Player;
    void MovePLayer()
    {
        //Player.transform.position = Vector3.MoveTowards(Player.transform.position,PlayerDestination.transform.position,1* Time.deltaTime);
        Player.transform.position = PlayerDestination.transform.position;
    }

}
