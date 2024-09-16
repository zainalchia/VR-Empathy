using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVibrationManager : MonoBehaviour
{
    #region Singleton Stuff
    public static ControllerVibrationManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }
    #endregion

    bool isVibrating = false;

    public void TriggerVibration(int iteration, int frequency, int strength, OVRInput.Controller controllerSide)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

        if (controllerSide == OVRInput.Controller.LTouch) // left controller
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controllerSide == OVRInput.Controller.RTouch) // right controller
        {
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }

    public void TriggerVibration(float frequency, float amplitude)
    {
        if (!isVibrating)
        {
            isVibrating = true;
            OVRInput.SetControllerVibration(frequency, amplitude);
        }            
    }

    public void NoVibration()
    {
        if (isVibrating)
        {
            isVibrating = false;
            OVRInput.SetControllerVibration(0, 0);
        }
    }
}
