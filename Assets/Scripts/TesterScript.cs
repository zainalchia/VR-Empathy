using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    public enum Scenario { presentBad, presentGood, pastBad, pastGood };
    public Scenario scenario;
    [SerializeField] ScenarioManagerPresentBad scenarioManagerPresentBad;

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

    // Start is called before the first frame update
    void Start()
    {
        if (scenario == Scenario.presentBad)
        {
            try
            {
                StartPresentBadTestPart1();
            }
            catch (Exception e)
            {
                Debug.Log("Error at bathroom part 1: " + e.Message);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
