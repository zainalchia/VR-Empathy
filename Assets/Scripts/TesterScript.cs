using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TesterScript : MonoBehaviour
{
    [Header("Press this to begin test")] [SerializeField] bool startTest = false;
    public string currentSceneName;
    [SerializeField] ScenarioManagerPresentBad scenarioManagerPresentBad;
    [SerializeField] ScenarioManagerPresentGood scenarioManagerPresentGood;
    [SerializeField] ScenarioManagerReneeTest scenarioManagerReneeTest;

    private void RunTestMethod(Action methodToTest)
    {
        // Invoke the passed method
        methodToTest();

        Debug.Log("running method: " + nameof(methodToTest));
    }

    private void MoveObj(GameObject go, Vector3 moveVector)
    {
        go.transform.Translate(moveVector, Space.World);
        Debug.Log("moving obj: " + go.name + " with distance of " + moveVector.ToString());
    }

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
            StartCoroutine(StartPresentBadTestPart2_Coroutine());
        }
        catch (Exception e)
        {
            Debug.Log("Error at bathroom part 2 (door opening part): " + e.Message);
        }
    }

    IEnumerator StartPresentBadTestPart2_Coroutine()
    {
        // grab cane
        scenarioManagerPresentBad.AllowDoorOpen();

        yield return new WaitForSeconds(1);

        // open door
        scenarioManagerPresentBad.bathroomDoor.OnDoorOpen.Invoke();

        Debug.Log("Testing over");    
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

    #region Present Good Bathroom
    void StartPresentGoodBathroomTestPart1()
    {
        StartCoroutine(StartPresentGoodBathroomTestPart1_Coroutine());
    }

    IEnumerator StartPresentGoodBathroomTestPart1_Coroutine()
    {
        yield return new WaitForSeconds(5 + scenarioManagerPresentGood.timeForWashingUp + scenarioManagerPresentGood.narrationAudioClips_1[0].length + scenarioManagerPresentGood.narrationAudioClips_1[1].length);
        StartPresentGoodBathroomTestPart2();
    }

    void StartPresentGoodBathroomTestPart2()
    {
        try
        {
            scenarioManagerPresentGood.bathroomDoor.OnDoorOpen.Invoke();
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

    #region Past Negative Bathroom
    void StartPastNegativeBathroomTestPart1()
    {
        try
        {
            StartCoroutine(StartPastBadTestPart1_Coroutine());
        }
        catch (Exception e)
        {
            Debug.Log("Error at bathroom part 1: " + e.Message);
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

        Debug.Log("finish testing");
    }
    #endregion

    #region Past Negative Hawker
    void StartPastNegativeHawkerTestPart1()
    {
        try
        {
            StartCoroutine(StartPastNegativeHawkerTestPart1_Coroutine());
        }
        catch (Exception e)
        {
            Debug.Log("Error at hawker part 1: " + e.Message);
        }
    }

    IEnumerator StartPastNegativeHawkerTestPart1_Coroutine()
    {
        Debug.Log("in past negative hawker test part 1");

        yield return new WaitForSeconds(20f); // to let the dialogue and stuff finish
        MoveObj(scenarioManagerReneeTest.cashObject, new Vector3(-0.5f, 0f, 0f));

        yield return new WaitForSeconds(2f); // to let the dialogue and stuff finish
        scenarioManagerReneeTest.playerTeleport.testPressTrigger = true; // to teleport
        Debug.Log("teleport");

        yield return new WaitForSeconds(2f); // to let the dialogue and stuff finish
        RunTestMethod(scenarioManagerReneeTest.PlayChoppedHand);

        yield return new WaitForSeconds(2f); // to let the dialogue and stuff finish
        scenarioManagerReneeTest.playerTeleport.testPressTrigger = true; // to teleport
        Debug.Log("teleport");

        yield return new WaitForSeconds(2f); // to let the dialogue and stuff finish
        RunTestMethod(scenarioManagerReneeTest.OnTeleportedToBandAid);

        yield return new WaitForSeconds(2f); // to let the dialogue and stuff finish
        scenarioManagerReneeTest.OnPlasterContainerGrabbed();
        Debug.Log("OnPlasterContainerGrabbed");

        yield return new WaitForSeconds(2f); // to let the dialogue and stuff finish
        scenarioManagerReneeTest.SpawnPlaster();
        Debug.Log("SpawnPlaster");

        yield return new WaitForSeconds(2f); // to let the dialogue and stuff finish
        scenarioManagerReneeTest.PlayFoodDrop();
        Debug.Log("PlayFoodDrop");

        Debug.Log("finish testing");
    }



    #endregion
    void StartTest()
    {
        Debug.Log("Test started");

        // get current scene
        currentSceneName = SceneManager.GetActiveScene().name;

        switch (currentSceneName)
        {
            case "PresentBadBathroom":

                try
                {
                    StartPresentBadTestPart1();
                }
                catch (Exception e)
                {
                    Debug.Log("Error at bathroom part 1: " + e.Message);
                }

                break;

            case "PresentBadLivingRoom":

                break;

            case "PresentBadBedroom":

                try
                {
                    StartPresentBadBedroomTestPart1();
                }
                catch (Exception e)
                {
                    Debug.Log("Error at bedroom part 1: " + e.Message);
                }

                break;

            case "PresentGoodBathroom":

                try
                {
                    StartPresentGoodBathroomTestPart1();
                }
                catch (Exception e)
                {
                    Debug.Log("Error at bathroom part 1: " + e.Message);
                }

                break;

            case "PastNegativeBathroom":

                try
                {
                    StartPastNegativeBathroomTestPart1();
                }
                catch (Exception e)
                {
                    Debug.Log("Error at scene start: " + e.Message);
                }

                break;

            case "PastNegativeHawker":

                try
                {
                    StartPastNegativeHawkerTestPart1();
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
        if (startTest)
        {
            StartTest();
            startTest = false;
        }
    }
}
