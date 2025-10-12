using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManagerPastNegative : MonoBehaviour
{
    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject firstTeleportToiletHotspot;
    [SerializeField] GameObject secondTeleportToiletHotspot;
    [SerializeField] GameObject thirdTeleportToiletHotspot;

    [Header("Player Movement")]
    [SerializeField] PlayerTeleport playerTeleport;

    [Header("Debuggers")]
    [SerializeField] GameObject testitem;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.scenarioID = ScenarioID.PastNegative;

        playerTeleport.SetCurrentHotspotIndex(-1);
        firstTeleportToiletHotspot.SetActive(true);
        playerTeleport.MoveToToiletDoor = true; 


        //testitem.GetComponent<SmoothPivotRotator>().StartDefaultRotation();
        //testitem.GetComponent<SmoothPivotRotator>().isRotating = true;  
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
