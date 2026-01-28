using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Cloth : MonoBehaviour
{
    [SerializeField] GameObject DroppedFood;

    public UnityEvent WhileCleaning;
    public UnityEvent FinishCleaning;

    [Header("Dialogue Timing")]
    [SerializeField] private float customerDialogueDuration = 3f;

    private bool customerDialoguePlayed = false;
    private bool hasFinished = false;
    private bool waitingForDialogue = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ToClean"))
        {
            other.gameObject.SetActive(false);

            if (!customerDialoguePlayed)
            {
                customerDialoguePlayed = true;
                WhileCleaning.Invoke();
                StartCoroutine(CustomerDialogueTimer());
            }
        }
    }

    private IEnumerator CustomerDialogueTimer()
    {
        waitingForDialogue = true;
        yield return new WaitForSeconds(customerDialogueDuration);
        waitingForDialogue = false;

        // If cleaning already finished, fire now
        if (hasFinished)
        {
            FinishCleaning.Invoke();
        }
    }

    private void Update()
    {
        if (hasFinished)
            return;

        GameObject[] remaining = GameObject.FindGameObjectsWithTag("ToClean");
        if (remaining.Length == 0)
        {
            hasFinished = true;

            // If dialogue is still playing, wait
            if (!waitingForDialogue)
            {
                FinishCleaning.Invoke();
            }
        }
    }
}
