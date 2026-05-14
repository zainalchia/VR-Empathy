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
    public UnityEvent reachedEndPoint;
    [SerializeField] Animator taiChiAnimator;
    [SerializeField] Animator taiChiInstructorAnimator; // set for npc
    float timerToGoNext = 0f;
    bool timerstart = false;
    int currentPose = 0;
    public bool checkStartAnim; // enable for npc
    bool finished = false;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject taichiTargetDestination;

    //public void ReadyForNextPose() // called in animation event 1 frame before the last frame
    //{
    //    timerToGoNext = timeDelayBeforeNextPose;
    //    timerstart = true;
    //}

    //public void NextPose() // call to start taichi in scenario manager, will invoke UnityEvent once all taichi animations have been played
    //{
    //    if (GameManager.instance.toDoTaiChi)
    //    {
    //        timerstart = false;
    //        if (currentPose < numOfPoses)
    //        {
    //            currentPose += 1;
    //            GetComponent<Animator>().SetInteger("Pose", currentPose);
    //            Debug.Log("Current pose:" + currentPose);
    //            if (currentPose > 1)
    //            {
    //                OnNextPose.Invoke();
    //            }
    //        }
    //        else
    //        {
    //            GameManager.instance.toDoTaiChi = false;
    //            OnPosesFinish.Invoke();
    //        }
    //    }
    //}

    //public void PausePose()
    //{
    //    gameObject.GetComponent<Animator>().speed = 0f;        

    //    if (triggerHitbox)
    //    {
    //        spawnNextHitboxes.Invoke();
    //    }
    //}

    //public void UnpausePose()
    //{
    //    foreach (var anim in GameManager.instance.taiChiAnimations)
    //    {
    //        anim.GetComponent<Animator>().speed = 1f;
    //    }
    //}

    public void HideAlert()
    {
        GameManager.instance.HideAlert();
    }
    public void StartAnimation()
    {
        GetComponent<Animator>().SetBool("StartAnimation", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //    if (timerstart)
        //    {
        //        timerToGoNext -= Time.deltaTime;
        //        if (timerToGoNext <= 0)
        //        {
        //            NextPose();
        //        }
        //    }

        if (checkStartAnim) // npc checks if taichi instructor started animation
            if (taiChiInstructorAnimator.GetBool("StartAnimation"))
            {
                StartAnimation();
                checkStartAnim = false;
            }

        AnimatorStateInfo StateInfo = taiChiAnimator.GetCurrentAnimatorStateInfo(0);
        
        if (StateInfo.IsTag("FinalTaiChi") && finished == false) // StateInfo.normalizedTIme 0 -> Start of animation, 1 -> End of animation
        {
            GetComponent<Animator>().SetBool("StartAnimation", false);
            if (StateInfo.normalizedTime >= 0.95f)
            {
                OnPosesFinish.Invoke();
                finished = true;
            }
        }


    }

    public void InstructorWalk()
    {
        StartCoroutine(MoveFriendPosition(gameObject, 0.25f, taichiTargetDestination.transform.position, 180));
    }


    IEnumerator MoveFriendPosition(GameObject friend, float stopDistance, Vector3 targetDestination, float targetYRotation)
    {
        var directionVector = (targetDestination - friend.transform.position).normalized;

        friend.GetComponent<Animator>().SetBool("isWalking", true);

        while (Vector3.Distance(targetDestination, friend.transform.position) > stopDistance)
        {
            friend.transform.position += directionVector * moveSpeed * Time.deltaTime;
            yield return null;
        }

        friend.GetComponent<Animator>().SetBool("isWalking", false);
        yield return new WaitForSeconds(1);

        // Start rotation lerp
        float rotationDuration = 1.0f; // Adjust this value for faster/slower rotation
        float elapsedTime = 0;

        Quaternion startRotation = friend.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(
            friend.transform.rotation.eulerAngles.x,
            targetYRotation,
            friend.transform.rotation.eulerAngles.z
        );

        while (elapsedTime < rotationDuration)
        {
            // Calculate the lerp value (0 to 1) based on elapsed time
            float t = elapsedTime / rotationDuration;

            // Use a smoothing function if you want (optional)
            t = Mathf.SmoothStep(0, 1, t);

            // Use Quaternion.Slerp for the shortest rotation path
            friend.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure we end at the exact target rotation
        friend.transform.rotation = targetRotation;
        reachedEndPoint.Invoke();
    }



}
