using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartbeatUI : MonoBehaviour
{
    public Image redOverlay;           
    public AudioSource heartbeat;   

    // how fast red and heartbeat change
    [SerializeField] private float fadeSpeed = 1.5f;
    private float targetAlpha = 0f; 

    void Start()
    {
        // ensure heartbeat sound is ready
        if (heartbeat != null)
        {
            heartbeat.volume = 0f; //start silent
            heartbeat.loop = true;
            heartbeat.Play(); 
        }
    }

    void Update()
    {
        // Smoothly fade the red overlay
        if (redOverlay != null)
        {
            Color color = redOverlay.color;
            color.a = Mathf.Lerp(color.a, targetAlpha, Time.deltaTime * fadeSpeed); // slowly chyange fade transparent (basically fade)
            color.a += Mathf.Sin(Time.time * 4f) * 0.02f * targetAlpha; // soft pulse effect
            redOverlay.color = color;
        }

        // Smoothly adjust heartbeat volume and pitch
        if (heartbeat != null)
        {
            heartbeat.volume = Mathf.Lerp(heartbeat.volume, targetAlpha, Time.deltaTime * fadeSpeed); // volume fade
            heartbeat.pitch = Mathf.Lerp(heartbeat.pitch, 1f + targetAlpha * 0.3f, Time.deltaTime * fadeSpeed); // speed up slightly
        }
    }

    // change red/heartbeat strength
    public void SetWarningLevel(float intensity)
    {
        targetAlpha = Mathf.Clamp01(intensity);
    }
    // reset the screen and becomes normal
    public void ResetWarning()
    {
        targetAlpha = 0f;
    }
}
