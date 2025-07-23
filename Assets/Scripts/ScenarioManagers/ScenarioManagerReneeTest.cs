using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainMenuManager;

public class ScenarioManagerReneeTest : MonoBehaviour
{
    [SerializeField] SceneToPlay sceneToPlay = SceneToPlay.Bathroom;
    enum SceneToPlay
    {
        Bathroom,
        Stall
    }

    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject firstTeleportToiletHotspot;
    [SerializeField] GameObject secondTeleportToiletHotspot;
    [SerializeField] GameObject thirdTeleportToiletHotspot;

    [Header("Scenario Prompts")]
    [SerializeField] ScenarioPromptManager promptManager;
    [SerializeField] ScenarioID scenarioID = ScenarioID.PresentBad;
    [SerializeField] SceneID sceneID = SceneID.Bathroom;

    [Header("Player Movement")]
    [SerializeField] PlayerTeleport playerTeleport;

    [Header("Debuggers")]
    [SerializeField] GameObject testitem;

    [Header("Narration Variables")]
    [SerializeField] AudioSource narrationAudioSource;

    // for general audio clips used in both scenes
    public AudioClip[] narrationAudioClips_General_Male;
    public AudioClip[] narrationAudioClips_General_Female;
    AudioClip[] narrationAudioClips_General;

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

    #region Hawker Bathroom

    [Header("In the bathroom")]
    [SerializeField] float timeForWashingUp = 5f;
    bool moveToToiletDoor =  false;

    public void HawkerPartOne()
    {
        lastRoutine = StartCoroutine(HawkerPart1());
    }

    IEnumerator HawkerPart1()
    {
        PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        ControllerInteractionsManager.instance.autoDropItems = false; // no dropping item yet

        yield return new WaitForSeconds(4f); // screen fade in timing

        narrationAudioSource.volume = 1;
        narrationAudioSource.Stop();

        promptManager.ShowPrompt(sceneID, 0);

        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);

        playerTeleport.currentScene = ScenarioID.PastNegative;

        playerTeleport.SetCurrentHotspotIndex(-1);
        firstTeleportToiletHotspot.SetActive(true);
        moveToToiletDoor = true;
    }

    #endregion 

    // Start is called before the first frame update
    void Start()
    {
        SetupNarrationGeneral();
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
