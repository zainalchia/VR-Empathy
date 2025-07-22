using System.Collections;
using System.Collections.Generic;
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
        Debug.Log(recordedWords);
        userUtterance.text = recordedWords;

        yield return new WaitForSeconds(0.1f);

        if (listening)
        {
            voiceExperience.Activate();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            StartListening();
        }
    }
}