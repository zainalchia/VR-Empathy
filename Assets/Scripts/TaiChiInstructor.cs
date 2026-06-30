using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TaiChiInstructor : MonoBehaviour
{
    public UnityEvent OnPosesFinish;
    public UnityEvent reachedEndPoint;
    [SerializeField] Animator taiChiAnimator;
    [SerializeField] Animator taiChiInstructorAnimator; // set for npc
    bool finished = false;
    public bool checkStartAnim; // enable for npc
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject taichiTargetDestination;

    public void HideAlert()
    {
        GameManager.instance.HideAlert();
    }

    public void StartAnimation()
    {
        GetComponent<Animator>().SetBool("StartAnimation", true);
    }

    void Update()
    {
        if (checkStartAnim) // npc checks if taichi instructor started animation
            if (taiChiInstructorAnimator.GetBool("StartAnimation"))
            {
                StartAnimation();
                checkStartAnim = false;
            }

        AnimatorStateInfo StateInfo = taiChiAnimator.GetCurrentAnimatorStateInfo(0);

        if (StateInfo.IsTag("FinalTaiChi") && finished == false)
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

        float rotationDuration = 1.0f;
        float elapsedTime = 0;

        Quaternion startRotation = friend.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(
            friend.transform.rotation.eulerAngles.x,
            targetYRotation,
            friend.transform.rotation.eulerAngles.z
        );

        while (elapsedTime < rotationDuration)
        {
            float t = Mathf.SmoothStep(0, 1, elapsedTime / rotationDuration);
            friend.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        friend.transform.rotation = targetRotation;
        reachedEndPoint.Invoke();
    }

    public void StartInstructorAnimation()
    {
        taiChiInstructorAnimator.SetBool("StartAnimation", true);
    }

}
