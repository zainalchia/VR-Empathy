using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Cloth : MonoBehaviour
{
    [SerializeField] GameObject DroppedFood;
    public UnityEvent FinishCleaning;
    public UnityEvent WhileCleaning;

    private float cleanInterval = 1f;
    private bool AbleToClean = true;
    private bool startTimer = false;
    private float timer = 0f;
    private bool CustomerDialogue = true;
    private bool hasFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ToClean"))
        {
            if (AbleToClean)
            {
                other.gameObject.SetActive(false);
                AbleToClean = false;
                startTimer = true;

                if (CustomerDialogue)
                {
                    WhileCleaning.Invoke();
                    CustomerDialogue = false;
                }
            }
        }
    }

    private void Update()
    {

        // Handle cleaning cooldown
        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= cleanInterval)
            {
                timer = 0f;
                startTimer = false;
                AbleToClean = true;
            }
        }

        // NEW: Check if all "ToClean" objects are gone
        if (!hasFinished)
        {
            GameObject[] remaining = GameObject.FindGameObjectsWithTag("ToClean");
            if (remaining.Length == 0)
            {
                hasFinished = true;
                FinishCleaning.Invoke();
            }
        }
    }
}
