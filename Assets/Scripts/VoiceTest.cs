using System.Collections;
using UnityEngine;
using Oculus.Voice;
using TMPro;

public class VoiceScript : MonoBehaviour
{
    public AppVoiceExperience voiceExperience;
    private bool listening = false;
    private string recordedWords;
    public TextMeshProUGUI userUtterance;

    public void StartListening()
    {
        listening = true;
        voiceExperience.Activate();
    }

    public void IfStopListeningPrematurely(string text)
    {
        StartCoroutine(IfStopListeningPrematurely_Coroutine(text));
    }

    public IEnumerator IfStopListeningPrematurely_Coroutine(string text)
    {
        recordedWords += " " + text;
        userUtterance.text = recordedWords;

        yield return new WaitForSeconds(0.1f);

        if (listening)
        {
            voiceExperience.Activate();
        }
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            StartListening();
        }
    }
}