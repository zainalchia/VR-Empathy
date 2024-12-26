using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaiChiInstructor : MonoBehaviour
{
    [SerializeField] int numOfPoses = 8;
    [SerializeField] float timeDelayBeforeNextPose;
    [SerializeField] bool triggerHitbox;
    public UnityEvent OnNextPose;
    public UnityEvent OnPosesFinish;
    public UnityEvent spawnNextHitboxes;
    float timerToGoNext = 0f;
    bool timerstart = false;

    int currentPose = 0;

    public void ReadyForNextPose() // called in animation event 1 frame before the last frame
    {
        timerToGoNext = timeDelayBeforeNextPose;
        timerstart = true;
    }

    public void NextPose() // call to start taichi in scenario manager, will invoke UnityEvent once all taichi animations have been played
    {
        if (GameManager.instance.toDoTaiChi)
        {
            timerstart = false;
            if (currentPose < numOfPoses)
            {
                currentPose += 1;
                GetComponent<Animator>().SetInteger("Pose", currentPose);
                Debug.Log("Current pose:" + currentPose);
                if (currentPose > 1)
                {
                    OnNextPose.Invoke();
                }
            }
            else
            {
                GameManager.instance.toDoTaiChi = false;
                OnPosesFinish.Invoke();
            }
        }
    }

    public void PausePose()
    {
        GetComponent<Animator>().speed = 0f;

        if (triggerHitbox)
        {
            spawnNextHitboxes.Invoke();
        }
    }

    public void UnpausePose()
    {
        GetComponent<Animator>().speed = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerstart)
        {
            timerToGoNext -= Time.deltaTime;
            if (timerToGoNext <= 0)
            {
                NextPose();
            }
        }
    }

    
}
