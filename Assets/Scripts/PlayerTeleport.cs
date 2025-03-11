using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] GameObject[] teleportHotspots;
    [SerializeField] float defaultTimeBeforeNextMove = 2;
    bool buttonPressed = false;
    public UnityEvent OnLastTeleport;
    int currentHotspotIndex = -1;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move input to a manager script if possible
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) && !buttonPressed)
        {
            buttonPressed = true;
            //MoveToLocation();
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && buttonPressed)
        {
            buttonPressed = false;
        }
    }

    //public void MoveToLocation()
    //{
    //    canMove = true;

    //    if (canMove && timer >= defaultTimeBeforeNextMove)
    //    {
    //        // Move OVRCameraRig gameobject with offset
    //        float offsetX = GameManager.instance.middleEyeAnchor.transform.localPosition.x;
    //        float offsetZ = GameManager.instance.middleEyeAnchor.transform.localPosition.z;
    //        GameManager.instance.ovrCamRig.transform.position = new Vector3(posX - offsetX, GameManager.instance.ovrCamRig.transform.position.y, posZ - offsetZ);
    //        timer = 0;
    //        defaultTimeBeforeNextMove = 1.5f; // in general

    //        currentHotspotIndex += 1;

    //        if (currentHotspotIndex == 2 || currentHotspotIndex == 7)
    //        {
    //            PlaySighSound();
    //        }
    //        else if (currentHotspotIndex == 5)
    //        {
    //            defaultTimeBeforeNextMove = 22; // delay showing of next hotspot for blurring of eyes and voicelines
    //        }

    //        teleportHotspots[currentHotspotIndex].gameObject.SetActive(false); // hide current hotspot instantly

    //        StartCoroutine(ShowingNextHotspot(defaultTimeBeforeNextMove - 0.5f)); // by default 1 second delay unless its hotspot 5 which is the food table (-0.5 to show hotspot first before being able to move)

    //        if (currentHotspotIndex == teleportHotspots.Length - 1)
    //            OnLastTeleport.Invoke();
    //    }
    //}
}
