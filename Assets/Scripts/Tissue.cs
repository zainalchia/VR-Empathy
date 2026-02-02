using UnityEngine;

public class Tissue: MonoBehaviour
{
    [Header("External Audio Source")]
    [SerializeField] private AudioSource musicSource;

    private void OnDisable()
    {
        if (musicSource == null)
            return;

        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
