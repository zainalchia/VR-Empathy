using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTeleport : MonoBehaviour
{
    #region Present Positive Hotspots
    [Header("Present Positive Hotspots")]
    public GameObject[] MoveToLivingRoomHotspots;
    [SerializeField] GameObject[] MoveToMainDoorHotspots;
    [SerializeField] GameObject[] MoveToCheckersChairHotspots;
    [SerializeField] GameObject[] MoveToKaraokeCornerHotspots;

    public GameObject[] GetMoveToLivingRoomHotspots() => MoveToLivingRoomHotspots;
    public GameObject[] GetMoveToMainDoorHotspots() => MoveToMainDoorHotspots;
    public GameObject[] GetMoveToCheckersChairHotspots() => MoveToCheckersChairHotspots;
    public GameObject[] GetMoveToKaraokeCornerHotspots() => MoveToKaraokeCornerHotspots;
    #endregion

    #region Past Negative Hotspots
    [Header("Past Negative Hotspots")]
    [SerializeField] private ScenarioPromptManager sceneToPlay;
    public GameObject[] MoveToToiletDoorHotspots;
    [SerializeField] GameObject[] MoveToHawkerStallHotspots;
    [SerializeField] GameObject[] MoveToJobPositionHotspots;
    [SerializeField] GameObject[] MoveToTableHotspots;

    public GameObject[] GetMoveToToiletDoorHotspots() => MoveToToiletDoorHotspots;
    public GameObject[] GetMoveToHawkerStallHotspots() => MoveToHawkerStallHotspots;
    public GameObject[] GetMoveToJobPositionHotspots() => MoveToJobPositionHotspots;
    public GameObject[] GetMoveToTableHotspots() => MoveToJobPositionHotspots;
    #endregion

    #region Past Positive Hotspots
    //[Header("Past Positive Hotspots")]
    //[SerializeField] GameObject[] MoveToHouseHotspots;
    //[SerializeField] GameObject[] MoveToDiningTableHotspots;
    #endregion

    //#region Past Positive Hotspots
    //[Header("Past Positive Hotspots")]
    ////IDK how you wna name it and what to name them
    ////public GameObject[] MoveToLivingRoomHotspots;
    ////[SerializeField] GameObject[] MoveToMainDoorHotspots;
    //#endregion

    [Header("Teleporting Settings")]
    [SerializeField] float defaultTimeBeforeNextMove = 2;
    bool buttonPressed = false;
    public UnityEvent OnLastTeleport; // for checkers transition and main door opening (both different scenes so can use same unity event)
    public UnityEvent OnLastTeleport2;// for reading corner (othello and reading corner same scene so need 2 unity events)
    private bool isNarrating = false; // flag to block TP while VO

    int currentHotspotIndex = -1;
    float timer = 0;

    [Header("Scene Manager")]
    //present positive
    public bool MovingToLivingRoom = false;
    public bool MovingToMainDoor = false;
    public bool MovingToCheckersChair = false;
    public bool MovingToKaraokeCorner = false;

    //past negative
    public bool MoveToToiletDoor = false;
    public bool MoveToHawkerStall = false;
    public bool MoveToTable = false;
    public bool MoveToSection = false;

    //Past positive==============================================================================================================
    //public bool MovingToLivingRoom = false;
    //public bool MovingToMainDoor = false;
    //public bool MovingToCheckersChair = false;
    //public bool MovingToKaraokeCorner = false;

    public ScenarioID currentScene;
    public bool testPressTrigger = false; // used for TesterScript to simulate trigger button press in editor.
    [SerializeField] ScenarioManagerPresentGood scenarioManagerPresentGood;

    void Update()
    {
        timer += Time.deltaTime;
        if (isNarrating) return; // if VO happening, skip update
        if (currentScene == ScenarioID.PresentGood) {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !buttonPressed && timer >= defaultTimeBeforeNextMove)
            {
                buttonPressed = true;

                if (MovingToLivingRoom && currentHotspotIndex != MoveToLivingRoomHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
                {
                    timer = 0;

                    defaultTimeBeforeNextMove = 1.5f; // in general

                    currentHotspotIndex += 1;

                    MoveToLocation(MoveToLivingRoomHotspots[currentHotspotIndex], MoveToLivingRoomHotspots);
                    PlayerCamera.instance.RecenterPlayer();
                }
                else if (MovingToMainDoor && currentHotspotIndex != MoveToMainDoorHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
                {
                    timer = 0;

                    defaultTimeBeforeNextMove = 1.5f; // in general

                    currentHotspotIndex += 1;

                    MoveToLocation(MoveToMainDoorHotspots[currentHotspotIndex], MoveToMainDoorHotspots);
                    PlayerCamera.instance.RecenterPlayer();

                }
                //else if (MovingToCheckersChair /*&& currentHotspotIndex != MoveToCheckersChairHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove*/)
                //{

                //    Debug.Log(currentHotspotIndex);
                //    timer = 0;

                //    defaultTimeBeforeNextMove = 1.5f; // in general

                //    currentHotspotIndex += 1;

                //    MoveToLocation(MoveToCheckersChairHotspots[currentHotspotIndex], MoveToCheckersChairHotspots);
                //}
                //else if (MovingToKaraokeCorner && currentHotspotIndex != MoveToKaraokeCornerHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
                //{
                //    timer = 0;

                //    defaultTimeBeforeNextMove = 1.5f; // in general

                //    currentHotspotIndex += 1;

                //    MoveToLocation(MoveToKaraokeCornerHotspots[currentHotspotIndex], MoveToKaraokeCornerHotspots);
                //}
            }
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && buttonPressed)
            {
                buttonPressed = false;
            }

            if (MovingToCheckersChair) // Teleport to checkers seat wihtout trigger press
            {
                currentHotspotIndex += 1;
                MoveToLocation(MoveToCheckersChairHotspots[currentHotspotIndex], MoveToCheckersChairHotspots);
                PlayerCamera.instance.RecenterPlayer();
                MoveToCheckersChairHotspots = null;
            }

            if (MovingToKaraokeCorner)
            {
                currentHotspotIndex += 1;
                MoveToLocation(MoveToKaraokeCornerHotspots[currentHotspotIndex], MoveToKaraokeCornerHotspots);
                PlayerCamera.instance.RecenterPlayer();
            }


            // move input to a manager script if possible
        }
        else if(currentScene == ScenarioID.PastNegative)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || testPressTrigger && !buttonPressed && timer >= defaultTimeBeforeNextMove)
            {
                if (MoveToToiletDoor && currentHotspotIndex != MoveToToiletDoorHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
                {
                    timer = 0;

                    defaultTimeBeforeNextMove = 1.5f; // in general

                    currentHotspotIndex += 1;

                    MoveToLocation(MoveToToiletDoorHotspots[currentHotspotIndex], MoveToToiletDoorHotspots);
                    PlayerCamera.instance.RecenterPlayer();

                }
                else if (MoveToHawkerStall && currentHotspotIndex != MoveToHawkerStallHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
                {
                    timer = 0;

                    defaultTimeBeforeNextMove = 1.5f; // in general

                    currentHotspotIndex += 1;

                    MoveToLocation(MoveToHawkerStallHotspots[currentHotspotIndex], MoveToHawkerStallHotspots);
                    PlayerCamera.instance.RecenterPlayer();

                }
                else if (MoveToTable && currentHotspotIndex != MoveToTableHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
                {
                    timer = 0;

                    defaultTimeBeforeNextMove = 1.5f; // in general

                    currentHotspotIndex += 1;

                    MoveToLocation(MoveToTableHotspots[currentHotspotIndex], MoveToTableHotspots);
                    PlayerCamera.instance.RecenterPlayer();

                }
                else if (MoveToSection && currentHotspotIndex != MoveToMainDoorHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
                {
                    timer = 0;

                    defaultTimeBeforeNextMove = 1.5f; // in general

                    currentHotspotIndex += 1;

                    MoveToLocation(MoveToJobPositionHotspots[currentHotspotIndex], MoveToJobPositionHotspots);
                    PlayerCamera.instance.RecenterPlayer();

                }
                testPressTrigger = false;
            }
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && buttonPressed)
            {
                buttonPressed = false;
            }
        }
        else if (currentScene == ScenarioID.PastPositive)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !buttonPressed && timer >= defaultTimeBeforeNextMove)
            {
                
            }
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && buttonPressed)
            {
                buttonPressed = false;
            }
        }
    }

    public void MoveToLocation(GameObject hotspot, GameObject[] hotspotArray)
    {
       // Move OVRCameraRig gameobject with offset
       float offsetX = GameManager.instance.centerEyeAnchor.transform.localPosition.x;
       float offsetZ = GameManager.instance.centerEyeAnchor.transform.localPosition.z;
       //GameManager.instance.ovrCamRig.transform.position = new Vector3(hotspot.transform.position.x - offsetX,hotspot.transform.position.y,hotspot.transform.position.z - offsetZ);
       GameManager.instance.ovrCamRig.transform.position = new Vector3(hotspot.transform.position.x, hotspot.transform.position.y, hotspot.transform.position.z);

       hotspot.SetActive(false);

        if (currentScene == ScenarioID.PresentGood)
        {
            if (currentHotspotIndex == 4) // Weather + Lunch VO 
            {
                StartCoroutine(PlayTwoNarrationsInSequence(
                    scenarioManagerPresentGood.narrationAudioClips_1[2],  // Weather
                    scenarioManagerPresentGood.narrationAudioClips_1[3],  // Lunch
                    hotspotArray
                ));
                return; 
            }
        }
        StartCoroutine(ShowingNextHotspot(defaultTimeBeforeNextMove - 0.5f,hotspotArray)); // by default 1 second delay unless its hotspot 5 which is the food table (-0.5 to show hotspot first before being able to move)

        if (currentScene == ScenarioID.PresentGood)
        {
            if (currentHotspotIndex == hotspotArray.Length - 1)
            {
                if (hotspotArray == MoveToLivingRoomHotspots)
                {
                    OnLastTeleport.Invoke();
                    MovingToLivingRoom = false;
                }
                else if (hotspotArray == MoveToMainDoorHotspots)
                {
                    //OnLastTeleport2.Invoke();
                    MovingToMainDoor = false;
                }
                else if (hotspotArray == MoveToCheckersChairHotspots)
                {
                    OnLastTeleport.Invoke();
                    MovingToCheckersChair = false;
                }
                else if (hotspotArray == MoveToKaraokeCornerHotspots)
                {
                    OnLastTeleport2.Invoke();
                    MovingToKaraokeCorner = false;
                }
            }
    }
        else if (currentScene == ScenarioID.PastNegative)
        {
            if (currentHotspotIndex == hotspotArray.Length - 1)
            {
                if (hotspotArray == MoveToToiletDoorHotspots)
                {                    
                    OnLastTeleport.Invoke();
                    MoveToToiletDoor = false;
                }                
                else if (hotspotArray == MoveToHawkerStallHotspots)
                {
                    OnLastTeleport2.Invoke();
                    MoveToHawkerStall = false;
                    
                }
                else if (hotspotArray == MoveToJobPositionHotspots)
                {
                    MoveToSection = false;
                }
            }
        }
        else if (currentScene == ScenarioID.PastPositive)
        {

        }
    }

    IEnumerator ShowingNextHotspot(float delay, GameObject[] hotspotArray)
    {
        yield return new WaitForSeconds(delay);

        ShowNextHotspot(hotspotArray); 
        yield return new WaitForSeconds(0.2f); //small delay to avoid instant tp
    }
    IEnumerator PlayTwoNarrationsInSequence(AudioClip firstClip, AudioClip secondClip, GameObject[] hotspotArray)
    {
        isNarrating = true; //block tp when VO
        scenarioManagerPresentGood.narrationAudioSource.Stop();

        // Play first line
        scenarioManagerPresentGood.narrationAudioSource.PlayOneShot(firstClip);
        yield return new WaitForSeconds(firstClip.length + 0.5f); // add 0.5s gap after VO play

        // Play second line
        scenarioManagerPresentGood.narrationAudioSource.PlayOneShot(secondClip);
        yield return new WaitForSeconds(secondClip.length); //wait until done 

        // After both finish, show the hotspot
        yield return StartCoroutine(ShowingNextHotspot(defaultTimeBeforeNextMove - 0.5f, hotspotArray));

        isNarrating = false;
    }
    void ShowNextHotspot(GameObject[] hotspotArray)
    {
        if(currentHotspotIndex != hotspotArray.Length - 1)
        {
            hotspotArray[currentHotspotIndex + 1].gameObject.SetActive(true);
            hotspotArray[currentHotspotIndex + 1].gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else // when last teleport hotspot, no need to enable next one
        {
            hotspotArray[currentHotspotIndex].gameObject.SetActive(false);
        }
    }

    public void SetCurrentHotspotIndex(int newCurrentHotspotIndex)
    {
        currentHotspotIndex = newCurrentHotspotIndex;
    }

    public int GetCurrentHotspotIndex()
    {
        return currentHotspotIndex;
    }

}
