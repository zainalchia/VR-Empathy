using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedFood : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip foodDropSFX;

    private bool foodDropped = false;

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
                if (foodDropSFX != null && !foodDropped)
                {
                    AudioSource.PlayClipAtPoint(
                        foodDropSFX,
                        transform.position,
                        2f
                    );
                    foodDropped = true;
                }
                child.transform.localPosition.Set(0f, 0f, 0f);
            }
        }
    }
}
