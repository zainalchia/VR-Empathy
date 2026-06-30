using System.Collections;
using UnityEngine;

public class AudioFade : MonoBehaviour
{
    [SerializeField]
    AudioSource AudioSource;

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
    }
}
