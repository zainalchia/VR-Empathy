using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartbeatUI : MonoBehaviour
{
    public Animator redAnimator;
    public AudioSource heartbeat;   

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
    public void StartSoftRed()
    {
        if (redAnimator != null)
        {
            redAnimator.ResetTrigger("StopRed");
            redAnimator.SetTrigger("SoftRed");
        }

        if (heartbeat != null)
        {
            heartbeat.volume = 0.4f;
            heartbeat.pitch = 1.0f;
        }
    }
    public void StartRed()
    {
        if (redAnimator != null)
        {
            redAnimator.ResetTrigger("StopRed");
            redAnimator.SetTrigger("HardRed");
        }
            
        if (heartbeat != null)
        {
            heartbeat.volume = 1f;
            heartbeat.pitch = 1.3f;
        }
    }

    // Stop red flash + heartbeat
    public void StopRed()
    {
        if (redAnimator != null)
            redAnimator.SetTrigger("StopRed");

        if (heartbeat != null)
        {
            heartbeat.volume = 0f;
            heartbeat.pitch = 1f;
        }
    }
}
