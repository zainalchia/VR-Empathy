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
    [SerializeField] PlayerTeleport playerTeleport;

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
    [SerializeField] float timeForWashingUp = 5f;

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

        promptManager.ShowPrompt(sceneID, 0, false, 5f);

        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);

        //boss should call the player over to get out quickly here and then player starts moving
        promptManager.ShowPrompt(sceneID, 1, false, 5f);
        //============================================================

        yield return new WaitForSeconds(3f);

        playerTeleport.currentScene = ScenarioID.PastNegative;

        playerTeleport.SetCurrentHotspotIndex(-1);
        firstTeleportToiletHotspot.SetActive(true);
        playerTeleport.MoveToToiletDoor = true;

        promptManager.ShowPrompt(sceneID, 2, false, 10f);

        HawkerPartTwo();
    }

    public void HawkerPartTwo()
    {
        if (sceneID != SceneID.Stall)
        {
            Debug.Log("Hey!");
            lastRoutine = StartCoroutine(HawkerPart2());
        }
    }

    IEnumerator HawkerPart2()
    {
        //boss is outside the toilet door and heads into the hawker stall

        promptManager.ShowPrompt(sceneID, 0, false, 5f);

        //wait for boss to walk away
        yield return new WaitForSeconds(5f);
        //playerTeleport.MoveToToiletDoor = false;

        secondTeleportHawkerHotspot.SetActive(true);
        playerTeleport.MoveToHawkerStall = true;
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


    // Update is called once per frame
    void Update()
    {
        
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
