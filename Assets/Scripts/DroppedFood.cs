using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedFood : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioSource foodDropAudioSource;

    private void Awake()
    {
        if (foodDropAudioSource != null)
        {
            foodDropAudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in transform)
        {
            if (child.transform.localPosition.x < -0.5f ||
                child.transform.localPosition.x > 0.5f ||
                child.transform.localPosition.z < -0.5f ||
                child.transform.localPosition.z > 0.3f)
            {
                child.transform.localPosition.Set(0f, 0f, 0f);
            }
        }
    }
}
