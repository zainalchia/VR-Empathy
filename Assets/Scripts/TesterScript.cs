using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    public enum Scene { presentBadBathroom, presentBadLivingRoom, presentBadBedroom, presentGood, pastBad, pastGood };
    public Scene scenario;
    [SerializeField] ScenarioManagerPresentBad scenarioManagerPresentBad;
    [SerializeField] ScenarioManagerReneeTest scenarioManagerReneeTest;

    #region Present Bad Bathroom
    void StartPresentBadTestPart1()
    {
        StartCoroutine(StartPresentBadTestPart1_Coroutine());
    }

    IEnumerator StartPresentBadTestPart1_Coroutine()
    {
        yield return new WaitForSeconds(5 + scenarioManagerPresentBad.timeForWashingUp + scenarioManagerPresentBad.narrationAudioClips_Bathroom[1].length);
        StartPresentBadTestPart2();
    }

    void StartPresentBadTestPart2()
    {
        try
        {
            scenarioManagerPresentBad.AllowDoorOpen();
            scenarioManagerPresentBad.BathroomDoorOpen();
        }
        catch (Exception e)
        {
            Debug.Log("Error at bathroom part 2 (door opening part): " + e.Message);
        }
        finally
        {
            Debug.Log("Testing over");
        }
    }
    #endregion

    #region Present Bad Bedroom
    void StartPresentBadBedroomTestPart1()
    {
        StartCoroutine(StartPresentBadBedroomTestPart1_Coroutine());
    }

    IEnumerator StartPresentBadBedroomTestPart1_Coroutine()
    {
        yield return new WaitForSeconds(4f); // screen fade in timing
        yield return new WaitForSeconds(scenarioManagerPresentBad.narrationAudioClips_2[0].length);
        yield return new WaitForSeconds(2f); // buffer time
        scenarioManagerPresentBad.DenturesPlacedInCup();
    }
    #endregion

    #region Past Bad
    void StartPastBadTestPart1()
    {
        try
        {
            StartCoroutine(StartPastBadTestPart1_Coroutine());
        }
        catch (Exception e)
        {
            Debug.Log("Error at bathroom part 1: " + e.Message);
        }
        finally
        {
            Debug.Log("finish testing");
        }
    }

    IEnumerator StartPastBadTestPart1_Coroutine()
    {
        // to let the dialogue and stuff finish
        yield return new WaitForSeconds(4f); // screen fade in timing
        yield return new WaitForSeconds(scenarioManagerReneeTest.timeForWashingUp);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(1f); // buffer time to let the teleport point appear
        scenarioManagerReneeTest.playerTeleport.testPressTrigger = true;
        yield return new WaitForSeconds(1f);
        scenarioManagerReneeTest.playerTeleport.testPressTrigger = true;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        switch (scenario)
        {
            case Scene.presentBadBathroom:

                try
                {
                    StartPresentBadTestPart1();
                }
                catch (Exception e)
                {
                    Debug.Log("Error at bathroom part 1: " + e.Message);
                }

                break;

            case Scene.presentBadLivingRoom:

                break;

            case Scene.presentBadBedroom:

                try
                {
                    StartPresentBadBedroomTestPart1();
                }
                catch (Exception e)
                {
                    Debug.Log("Error at bedroom part 1: " + e.Message);
                }

                break;

            case Scene.pastBad:

                try
                {
                    StartPastBadTestPart1();
                }
                catch (Exception e)
                {
                    Debug.Log("Error at scene start: " + e.Message);
                }

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
