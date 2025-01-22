using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsMoving : MonoBehaviour
{
    [SerializeField]
    List<GameObject> waypoints = new List<GameObject>();
    [SerializeField]
    private float speed;
    [SerializeField]
    Animator oldManAnimator, oldWomanAnimator;

    private bool toPlayer;
    private int index = 0;
    private bool moveAway;

    private void Awake()
    {
        toPlayer = true;
    }

    public void parentsMoveAway()
    {
        moveAway = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Hallucination start, move towards player
        if (toPlayer) { 
            Vector3 destination = waypoints[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);

            if (distance <= 0.05f)
            {
                oldManAnimator.SetTrigger("Idle");
                oldWomanAnimator.SetTrigger("Idle");
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0,30,0), Time.time * 0.05f);
                Debug.Log(transform.localRotation.eulerAngles.ToVector3f());
                if(transform.localRotation.eulerAngles == new Vector3(0, 30, 0))
                {
                    toPlayer = false;
                    index++;
                }
            }
        }
        // Moving away after parents talk
        if (moveAway)
        {
            oldManAnimator.SetTrigger("Walk");
            oldWomanAnimator.SetTrigger("Walk");
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, 0), Time.time * 0.05f);
            if (transform.localRotation.eulerAngles == new Vector3(0, 0, 0))
            {
                Vector3 destination = waypoints[index].transform.position;
                Vector3 newPos = Vector3.MoveTowards(transform.position, destination, 1 * Time.deltaTime);
                transform.position = newPos;

                float distance = Vector3.Distance(transform.position, destination);
                if (distance <= 0.05f)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
