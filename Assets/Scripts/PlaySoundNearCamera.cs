using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundNearCamera : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] AudioClip clip;
    AudioSource audioSource;
    bool lastFrame = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool thisFrame = (transform.position - Camera.main.transform.position).sqrMagnitude < (distance * distance);
        if (thisFrame && !lastFrame) 
        { 
            audioSource.clip = clip;
            audioSource.Play();
        }
        lastFrame = thisFrame;
    }
}
