using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HeartbeatUI : MonoBehaviour
{
    public AudioSource heartbeat;
    public Volume globalVolume;
    private Vignette vignette; //vignette effect
    private Coroutine vignetteRoutine;
    [SerializeField] private float pulseSpeedMultiplier = 1.35f;

    private bool lockedRed = false; //ensure red entire time
    void Start()
    {
        // ensure heartbeat sound is ready
        if (heartbeat != null)
        {
            heartbeat.volume = 0f; //start silent
            heartbeat.loop = true;
            heartbeat.Play();
        }

        // get the vignette effect
        if (globalVolume != null && globalVolume.profile.TryGet(out Vignette v))
        {
            vignette = v; //assign vignette
            vignette.intensity.value = 0f; 
            vignette.color.value = Color.black;
        }
    }
    public void StartSoftRed()
    {
        if (lockedRed) return; // ignore if locked red

        StopAllCoroutines();
        vignetteRoutine = StartCoroutine(VignettePulse(0.45f, 0.9f, Color.black)); //soft pulse
        if (heartbeat != null)
        {
            heartbeat.volume = 0.4f; // volume
            heartbeat.pitch = 1.1f; // faster beat
        }
    }
    public void StartRed()
    {
        if (lockedRed) return;

        StopAllCoroutines();
        vignetteRoutine = StartCoroutine(VignettePulse(0.75f, 1.3f, Color.black)); //mid pulse
        if (heartbeat != null)
        {
            heartbeat.volume = 0.7f;
            heartbeat.pitch = 1.3f;
        }
    }
    public void StartDeepRed()
    {
        if (lockedRed) return;

        StopAllCoroutines();
        vignetteRoutine = StartCoroutine(VignettePulse(0.9f, 1.5f, Color.black)); //strong pulse
        if (heartbeat != null)
        {
            heartbeat.volume = 0.9f;
            heartbeat.pitch = 1.4f;
        }
    }
    public void KnifeAccidentFlash()
    {
        StopAllCoroutines();
        lockedRed = true;
        StartCoroutine(KnifeAccidentSequence()); //play strong flash + always red
        if (heartbeat != null)
        {
            heartbeat.volume = 1.0f;
            heartbeat.pitch = 1.5f;
        }
    }

    private IEnumerator KnifeAccidentSequence() //flash and hold red when knife accident happen
    {
        // Flash white-red for shock
        vignette.color.value = new Color(0.9f, 0.1f, 0.1f);
        vignette.intensity.value = 1.0f;
        yield return new WaitForSeconds(0.2f);

        // Stay heavy dark red
        vignette.color.value = new Color(0.4f, 0, 0);
        vignette.intensity.value = 1.05f;

        // wait to fade back
        yield return new WaitForSeconds(8f);

        // Fade back to normal screen
        StartCoroutine(FadeVignette(0f, Color.black, 1.2f));
        StartCoroutine(FadeHeartbeat());

        lockedRed = false;

    }

    //Called after player applies plaster (TODO)
    public void StopRed()
    {
        lockedRed = false;
        StopAllCoroutines();
        StartCoroutine(FadeVignette(0f, Color.black, 1.2f)); //fade vignette out to normal
        StartCoroutine(FadeHeartbeat()); //lower heartbeat
    }

    //Vignette pulsing loop pattern
    private IEnumerator VignettePulse(float maxIntensity, float speed, Color color)
    {
        vignette.color.value = color;
        float intensity = 0f;
        bool isIncreasing = true; //direction of pulse

        while (true)
        {
            if (isIncreasing)
            {
                intensity += Time.deltaTime * speed * pulseSpeedMultiplier; //increase pulse
                if (intensity >= maxIntensity) isIncreasing = false; // reached top intensity
            }
            else
            {
                intensity -= Time.deltaTime * speed * pulseSpeedMultiplier; //decrease pulse
                if (intensity <= 0.1f) isIncreasing = true; //reach bottom intensity
            }

            vignette.intensity.value = intensity; //apply to vignette
            yield return null;
        }
    }

    //Smoothly fade vignette to black
    private IEnumerator FadeVignette(float target, Color color, float speed)
    {
        vignette.color.value = color;
        while (true)
        {
            if (vignette.intensity.value > target)
                vignette.intensity.value -= Time.deltaTime * speed; // if above target color, reduce gradualy
            else
                vignette.intensity.value = target;

            if (vignette.intensity.value <= target) //stop when done (normal)
                break;

            yield return null;
        }
    }


    //slowly return heartbeat to normal
    private IEnumerator FadeHeartbeat()
    {
        float duration = 3f; 
        float timer = 0f;
        float startVol = heartbeat.volume; //current vol
        float startPitch = heartbeat.pitch; //current pitch

        while (timer < duration)
        {
            heartbeat.volume -= (startVol / duration) * Time.deltaTime; //lower vol
            heartbeat.pitch -= ((startPitch - 1f) / duration) * Time.deltaTime; //lower pitch spped
            timer += Time.deltaTime;
            yield return null;
        }

        heartbeat.volume = 0f;
        heartbeat.pitch = 1f;
    }
}