using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{
    [SerializeField]
    AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator FadeIn(float duration, float TargetVolume)
    {
        AudioSource.volume = 0;
        float volume = AudioSource.volume;

        float currentTime = 0;
        while (currentTime < duration) { 
            currentTime += Time.deltaTime;
            volume = Mathf.Lerp(volume, TargetVolume, currentTime / duration);

            AudioSource.volume = volume;

            yield return null;
        }
        yield break;
    }

    public IEnumerator FadeOut(float duration, float TargetVolume)
    {
        float volume = AudioSource.volume;

        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            volume = Mathf.Lerp(volume, TargetVolume, currentTime / duration);

            AudioSource.volume = volume;

            yield return null;
        }
        yield break;
    }
}
