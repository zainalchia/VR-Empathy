using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject[] MoveToLivingRoomHotspots;
    [SerializeField] GameObject[] MoveToMainDoorHotspots;
    [SerializeField] GameObject[] MoveToOthelloChairHotspots;
    [SerializeField] GameObject[] MoveToReadingCornerHotspots;
    [SerializeField] float defaultTimeBeforeNextMove = 2;
    bool buttonPressed = false;
    public UnityEvent OnLastTeleport; // for othello transition and main door opening (both different scenes so can use same unity event)
    public UnityEvent OnLastTeleport2;// for reading corner (othello and reading corner same scene so need 2 unity events)
    int currentHotspotIndex = -1;
    float timer = 0;
    public bool MovingToLivingRoom = false;
    public bool MovingToMainDoor = false;
    public bool MovingToOthelloChair = false;
    public bool MovingToReadingCorner = false;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // move input to a manager script if possible
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !buttonPressed && timer >= defaultTimeBeforeNextMove)
        {
            buttonPressed = true;

            if (MovingToLivingRoom && currentHotspotIndex != MoveToLivingRoomHotspots.Length - 1)
            {
                currentHotspotIndex += 1;

                MoveToLocation(MoveToLivingRoomHotspots[currentHotspotIndex], MoveToLivingRoomHotspots);
            }
            else if (MovingToMainDoor && currentHotspotIndex != MoveToMainDoorHotspots.Length - 1)
            {
                currentHotspotIndex += 1;

                MoveToLocation(MoveToMainDoorHotspots[currentHotspotIndex], MoveToMainDoorHotspots);
            }
            else if (MovingToOthelloChair && currentHotspotIndex != MoveToOthelloChairHotspots.Length - 1)
            {
                currentHotspotIndex += 1;

                MoveToLocation(MoveToOthelloChairHotspots[currentHotspotIndex], MoveToOthelloChairHotspots);
            }
            else if(MovingToReadingCorner && currentHotspotIndex != MoveToReadingCornerHotspots.Length - 1)
            {
                currentHotspotIndex += 1;

                MoveToLocation(MoveToReadingCornerHotspots[currentHotspotIndex], MoveToReadingCornerHotspots);
            }
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && buttonPressed)
        {
            buttonPressed = false;
        }

    }

    public void MoveToLocation(GameObject hotspot, GameObject[] hotspotArray)
    {
        if (timer >= defaultTimeBeforeNextMove)
        {
            // Move OVRCameraRig gameobject with offset
            float offsetX = GameManager.instance.middleEyeAnchor.transform.localPosition.x;
            float offsetZ = GameManager.instance.middleEyeAnchor.transform.localPosition.z;
            GameManager.instance.ovrCamRig.transform.position = new Vector3(hotspot.transform.position.x - offsetX, GameManager.instance.ovrCamRig.transform.position.y,hotspot.transform.position.z - offsetZ);
            timer = 0;
            defaultTimeBeforeNextMove = 1.5f; // in general

            hotspot.SetActive(false);

            StartCoroutine(ShowingNextHotspot(defaultTimeBeforeNextMove - 0.5f,hotspotArray)); // by default 1 second delay unless its hotspot 5 which is the food table (-0.5 to show hotspot first before being able to move)

            if (currentHotspotIndex == hotspotArray.Length - 1)
            {
                if(hotspotArray == MoveToLivingRoomHotspots)
                {
                    MovingToLivingRoom = false;
                }
                else if(hotspotArray == MoveToMainDoorHotspots)
                {
                    OnLastTeleport.Invoke();
                    MovingToMainDoor = false;
                }
                else if(hotspotArray == MoveToOthelloChairHotspots)
                {
                    OnLastTeleport.Invoke();
                    MovingToOthelloChair = false;
                }
                else if(hotspotArray == MoveToReadingCornerHotspots)
                {
                    OnLastTeleport2.Invoke();
                    MovingToReadingCorner = false;
                }
            }
        }
    }
                  
    IEnumerator ShowingNextHotspot(float delay, GameObject[] hotspotArray)
    {
        yield return new WaitForSeconds(delay);

        ShowNextHotspot(hotspotArray);
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
