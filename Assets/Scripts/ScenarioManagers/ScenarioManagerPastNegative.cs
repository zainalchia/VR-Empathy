using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManagerPastNegative : MonoBehaviour
{
    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject firstTeleportToiletHotspot;

    [Header("Player Movement")]
    [SerializeField] PlayerTeleport playerTeleport;

    // Start is called before the first frame update
    void Start()
    {
        playerTeleport.currentScene = ScenarioID.PastNegative;

        playerTeleport.SetCurrentHotspotIndex(-1);
        firstTeleportToiletHotspot.SetActive(true);
        playerTeleport.MoveToToiletDoor = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
