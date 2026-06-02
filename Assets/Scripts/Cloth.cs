using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Cloth : MonoBehaviour
{
    [SerializeField] GameObject DroppedFood;

    [Header("Dialogue Timing")]
    [SerializeField] private float customerDialogueDuration = 3f;
    [SerializeField] private AudioSource customerAudioSource;
    [SerializeField] private AudioClip customerAudioClip;

    private bool customerDialoguePlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ToClean"))
        {
            other.gameObject.SetActive(false);

            if (!customerDialoguePlayed)
            {
                customerDialoguePlayed = true; 
                customerAudioSource.PlayOneShot(customerAudioClip);
            }
        }
    }
}
