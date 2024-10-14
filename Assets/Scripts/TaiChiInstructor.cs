using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiChiInstructor : MonoBehaviour
{
    float timerForPose = 0f;
    float timerToGoNext = 0f;

    public void ReadyForNextPose() // called in animation event 1 frame before the last frame
    {
        timerToGoNext = MinigameManager.instance.timeDelayBeforeNextPose;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerToGoNext > 0)
        {
            timerToGoNext -= Time.deltaTime;
            if (timerToGoNext <= 0)
            {
                MinigameManager.instance.NextPose();
            }
        }
    }

    
}
