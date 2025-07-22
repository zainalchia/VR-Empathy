using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text fpsCounter;
    private string FPSCounterText = "FPS: ";
    private float _currentFPS = 0f;
    private float _targetFPS = 72; // Target FPS for the application

    // Start is called before the first frame update
    void Start()
    {
        fpsCounter.text = "it's working";
        StartCoroutine(DisplayFramesPerSecond());
    }

    // Update is called once per frame
    void Update()
    {
        GenerateFramesPerSecond();
    }
    private void GenerateFramesPerSecond()
    {
        _currentFPS = (int)(1f / Time.unscaledDeltaTime);
    }

    private IEnumerator DisplayFramesPerSecond()
    {
        while (true)
        {
            fpsCounter.text = FPSCounterText + _currentFPS.ToString();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
