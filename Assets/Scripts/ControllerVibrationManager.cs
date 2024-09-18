using Oculus.Interaction;
using Oculus.Interaction.Input;
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

    [SerializeField] private GrabInteractor[] grabInteractors;
    [SerializeField] bool allowControllerVibration = true;
    [SerializeField] int vibrationStrength = 255; // 0 - 255
    [SerializeField] int vibrationFrequency = 2; // lower == more frequent vibration

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

    void CheckIfHolding()
    {
        foreach (GrabInteractor grabInteractor in grabInteractors) 
        {
            if (grabInteractor.HasSelectedInteractable && grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Left)
                TriggerVibration(40, vibrationFrequency, vibrationStrength, OVRInput.Controller.LTouch);
            else if (grabInteractor.HasSelectedInteractable && grabInteractor.gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Right)
                TriggerVibration(40, vibrationFrequency, vibrationStrength, OVRInput.Controller.RTouch);
        }
    }

    void Update()
    {
        if (allowControllerVibration)
            CheckIfHolding(); 
    }
}
