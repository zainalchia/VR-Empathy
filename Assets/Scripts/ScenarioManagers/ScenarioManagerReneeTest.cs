using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainMenuManager;

public class ScenarioManagerReneeTest : MonoBehaviour
{
    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject firstTeleportToiletHotspot;
    [SerializeField] GameObject secondTeleportToiletHotspot;
    [SerializeField] GameObject thirdTeleportToiletHotspot;

    [Header("Player Movement")]
    [SerializeField] PlayerTeleport playerTeleport;

    [Header("Debuggers")]
    [SerializeField] GameObject testitem;

    #region Hawker Bathroom

    [Header("In the bathroom")]
    [SerializeField] float timeForWashingUp = 30f;

    public void HawkerPartOne()
    {
        StartCoroutine(HawkerPart1());
    }

    IEnumerator HawkerPart1()
    {
        PostProcessingController.instance.UsingGlasses(true); // so that no blur effect yet
        ControllerInteractionsManager.instance.autoDropItems = false; // no dropping item yet

        yield return new WaitForSeconds(4f); // screen fade in timing

        // Give time for player to wash up
        yield return new WaitForSeconds(timeForWashingUp);
    }

    #endregion 

    // Start is called before the first frame update
    void Start()
    {
        //playerTeleport.currentScene = ScenarioID.PastNegative;

        //playerTeleport.SetCurrentHotspotIndex(-1);
        //firstTeleportToiletHotspot.SetActive(true);
        //playerTeleport.MoveToToiletDoor = true; 


        //testitem.GetComponent<SmoothPivotRotator>().StartDefaultRotation();
        //testitem.GetComponent<SmoothPivotRotator>().isRotating = true;  

        HawkerPartOne();

        Debug.Log("first part is done");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
