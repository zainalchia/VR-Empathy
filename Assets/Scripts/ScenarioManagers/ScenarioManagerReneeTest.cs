using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainMenuManager;

public class ScenarioManagerReneeTest : MonoBehaviour
{
    [SerializeField] SceneToPlay sceneToPlay = SceneToPlay.Bathroom;
    public enum SceneToPlay
    {
        Bathroom,
        Stall
    }

    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject firstTeleportToiletHotspot;
    [SerializeField] GameObject secondTeleportHawkerHotspot;
    [SerializeField] GameObject FinalHotspot;

    [Header("Scenario Prompts")]
    [SerializeField] ScenarioPromptManager promptManager;
    [SerializeField] ScenarioID scenarioID = ScenarioID.PastNegative;
    [SerializeField] SceneID sceneID = SceneID.Bathroom;

    [Header("Player Movement")]
    public PlayerTeleport playerTeleport;

    [Header("Debuggers")]
    [SerializeField] GameObject testitem;

    [Header("Narration Variables")]
    //[SerializeField] AudioSource narrationAudioSource;

    // for general audio clips used in both scenes
    //public AudioClip[] narrationAudioClips_General_Male;
    //public AudioClip[] narrationAudioClips_General_Female;
    //AudioClip[] narrationAudioClips_General;

    Coroutine lastRoutine = null;

    void SetupNarrationGeneral()
    {
        //if (MainMenuManager.isGenderMale)
        //{
        //    narrationAudioClips_General = narrationAudioClips_General_Male;
        //}
        //else
        //{
        //    narrationAudioClips_General = narrationAudioClips_General_Female;
        //}
    }

    #region Hawker Bathroom

    [Header("In the bathroom")]
    public float timeForWashingUp = 5f;


    public void HawkerPartOne()
    {
        lastRoutine = StartCoroutine(HawkerPart1());
    }

    IEnumerator HawkerPart1()
    {
        //PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        //ControllerInteractionsManager.instance.autoDropItems = false; // no dropping item yet

        yield return new WaitForSeconds(4f); // screen fade in timing

        //narrationAudioSource.volume = 1;
        //narrationAudioSource.Stop();

        promptManager.ShowPrompt(sceneID, 0, false, 2f);

        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);

        //boss should call the player over to get out quickly here and then player starts moving
        promptManager.ShowPrompt(sceneID, 1, false, 2f);
        //============================================================

        yield return new WaitForSeconds(3f);

        playerTeleport.currentScene = ScenarioID.PastNegative;

        playerTeleport.SetCurrentHotspotIndex(-1);
        firstTeleportToiletHotspot.SetActive(true);
        playerTeleport.MoveToToiletDoor = true;

        promptManager.ShowPrompt(sceneID, 2, false, 5f);
    }

    public void HawkerPartTwo()
    {
        sceneID = SceneID.Stall;
        lastRoutine = StartCoroutine(HawkerPart2());
    }

    IEnumerator HawkerPart2()
    {
        //boss is outside the toilet door and heads into the hawker stall

        //promptManager.ShowPrompt(sceneID, 0, false, 5f);

        //wait for boss to walk away

        if (playerTeleport.MoveToToiletDoor == false)
        {
            Debug.Log("oioioi bakaaaa");
        }
        else if(playerTeleport.MoveToToiletDoor != false)
        {
            Debug.Log("HMMMMM");
            playerTeleport.MoveToHawkerStall = true;
            secondTeleportHawkerHotspot.SetActive(true);
        }

        yield return null;
    }
    #endregion


    [SerializeField] GameObject TrayOfFood;
    [SerializeField] GameObject DroppedFood;

    #region Hawker

    IEnumerator DropFood()
    {
        playFoodDrop = true;
        yield return null;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetupNarrationGeneral();
        playerTeleport.currentScene = ScenarioID.PastNegative;

        if (sceneToPlay == SceneToPlay.Bathroom)
        {
            sceneID = SceneID.Bathroom;
            //SetupNarrationBathroomLivingRoom();
            HawkerPartOne();
        }
        else if (sceneToPlay == SceneToPlay.Stall)
        {
            //sceneID = SceneID.Stall;
            //SetupNarrationBedroom();
            //PlaySegment2Part1();
        }
    }


    private bool playFoodDrop = false;
    // Update is called once per frame
    void Update()
    {
        if (playFoodDrop)
        {
            TrayOfFood.GetComponent<Rigidbody>().useGravity = true;
            if (TrayOfFood.transform.position.y <= 0)
            {
                playFoodDrop = false;
                TrayOfFood.gameObject.SetActive(false);
                DroppedFood.gameObject.SetActive(true);
            }
            //TrayOfFood.transform.localPosition = new Vector3()
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
}
