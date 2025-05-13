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
    [SerializeField] GameObject[] MoveToCheckersChairHotspots;
    [SerializeField] GameObject[] MoveToKaraokeCornerHotspots;
    [SerializeField] float defaultTimeBeforeNextMove = 2;
    bool buttonPressed = false;
    public UnityEvent OnLastTeleport; // for checkers transition and main door opening (both different scenes so can use same unity event)
    public UnityEvent OnLastTeleport2;// for reading corner (othello and reading corner same scene so need 2 unity events)
    int currentHotspotIndex = -1;
    float timer = 0;
    public bool MovingToLivingRoom = false;
    public bool MovingToMainDoor = false;
    public bool MovingToCheckersChair = false;
    public bool MovingToKaraokeCorner = false;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // move input to a manager script if possible
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !buttonPressed && timer >= defaultTimeBeforeNextMove)
        {
            buttonPressed = true;

            if (MovingToLivingRoom && currentHotspotIndex != MoveToLivingRoomHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
            {
                timer = 0;

                defaultTimeBeforeNextMove = 1.5f; // in general

                currentHotspotIndex += 1;

                MoveToLocation(MoveToLivingRoomHotspots[currentHotspotIndex], MoveToLivingRoomHotspots);
            }
            else if (MovingToMainDoor && currentHotspotIndex != MoveToMainDoorHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
            {
                timer = 0;

                defaultTimeBeforeNextMove = 1.5f; // in general

                currentHotspotIndex += 1;

                MoveToLocation(MoveToMainDoorHotspots[currentHotspotIndex], MoveToMainDoorHotspots);
            }
            else if (MovingToCheckersChair && currentHotspotIndex != MoveToCheckersChairHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
            {
                timer = 0;

                defaultTimeBeforeNextMove = 1.5f; // in general

                currentHotspotIndex += 1;

                MoveToLocation(MoveToCheckersChairHotspots[currentHotspotIndex], MoveToCheckersChairHotspots);
            }
            else if(MovingToKaraokeCorner && currentHotspotIndex != MoveToKaraokeCornerHotspots.Length - 1 && timer >= defaultTimeBeforeNextMove)
            {
                timer = 0;

                defaultTimeBeforeNextMove = 1.5f; // in general

                currentHotspotIndex += 1;

                MoveToLocation(MoveToKaraokeCornerHotspots[currentHotspotIndex], MoveToKaraokeCornerHotspots);
            }
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && buttonPressed)
        {
            buttonPressed = false;
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
           else if(hotspotArray == MoveToCheckersChairHotspots)
           {
               OnLastTeleport.Invoke();
               MovingToCheckersChair = false;
           }
           else if(hotspotArray == MoveToKaraokeCornerHotspots)
           {
               OnLastTeleport2.Invoke();
               MovingToKaraokeCorner = false;
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
