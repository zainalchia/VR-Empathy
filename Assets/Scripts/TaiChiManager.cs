using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.AI;

public class TaiChiManager : MonoBehaviour
{
    #region Singleton Stuff
    public static TaiChiManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

    }
    #endregion

    [SerializeField]
    GameObject[] leftTaichiHitboxes;
    [SerializeField]
    GameObject[] rightTaichiHitboxes;
    [SerializeField]
    LineRenderer rightLinerenderer, leftLinerenderer;
    [SerializeField] GameObject TaichiNPCLeftMiddleFinger; // npc left middle finger position
    [SerializeField] GameObject TaichiNPCRightMiddleFinger; // npc right middle finger position
    [SerializeField] GameObject TaichiNPCHip; // npc hip position
    public GameObject TaichiNPCLeftBall; // not what you're thinking. it's the ball at the hand, showing whether your hand is in the correct place ;)
    public GameObject TaichiNPCRightBall;

    // Segment 1 - 0 to 4, Segment 2 - 4 to 8, Segment 3 - 8 to 13
    private int current = 0;
    private bool lastHitbox = false;
    private int segment = 1;
    private bool firstHitbox = true;

    private bool segmentResetter = false;

    public UnityEvent taichiFinished;
    public UnityEvent resumeTaichi;

    private void Start()
    {
    }

    public void deactivateCurrent()
    {
        if (!lastHitbox) {
            // Deactivate current hitbox
            leftTaichiHitboxes[current].SetActive(false);
            rightTaichiHitboxes[current].SetActive(false);

            TaichiNPCLeftBall.SetActive(false);
            TaichiNPCRightBall.SetActive(false);

            SetLineRenderer();
        }
        else
        {
            leftTaichiHitboxes[current].SetActive(false);
            rightTaichiHitboxes[current].SetActive(false);

            TaichiNPCLeftBall.SetActive(false);
            TaichiNPCRightBall.SetActive(false);
        }
    }

    public void spawnNext()
    {
        segmentResetter = false;
        if (firstHitbox) 
        {
            firstHitbox = false;
        }
        else
        {
            current++;
        }

        // automate hitboxes position according to where taichi npc hands(aka their middle fingers center of their hands) are at
        // the player one is mirror image of the instructor one
        leftTaichiHitboxes[current].transform.position = new Vector3(TaichiNPCRightMiddleFinger.transform.position.x + (2.3f - 2 * (TaichiNPCRightMiddleFinger.transform.position.x - TaichiNPCHip.transform.position.x)), TaichiNPCRightMiddleFinger.transform.position.y, TaichiNPCRightMiddleFinger.transform.position.z);
        leftTaichiHitboxes[current].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        rightTaichiHitboxes[current].transform.position = new Vector3(TaichiNPCLeftMiddleFinger.transform.position.x + (2.3f - 2 * (TaichiNPCLeftMiddleFinger.transform.position.x - TaichiNPCHip.transform.position.x)), TaichiNPCLeftMiddleFinger.transform.position.y, TaichiNPCLeftMiddleFinger.transform.position.z);
        rightTaichiHitboxes[current].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        leftTaichiHitboxes[current].SetActive(true);
        rightTaichiHitboxes[current].SetActive(true);

        TaichiNPCLeftBall.SetActive(true);
        TaichiNPCRightBall.SetActive(true);
        TaichiNPCLeftBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);
        TaichiNPCRightBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);


        rightLinerenderer.enabled = false;
        leftLinerenderer.enabled = false;

        switch (segment)
        {
            case 1:
                if (current == 3)
                {
                    lastHitbox = true;
                }
                break;
            case 2:
                if (current == 6)
                {
                    lastHitbox = true;
                }
                break;
            case 3:
                if (current == 11)
                {
                    lastHitbox = true;
                }
                break;
        }
    }

    public void startSegment1()
    {

    }

    public void startSegment2()
    {
        lastHitbox = false;
    }
    public void startSegment3()
    {
        lastHitbox = false;
    }

    public void nextTaichiPose()
    {
        switch (segment)
        {
            case 1:
                if (!segmentResetter)
                {
                    segment = 2;
                    startSegment2();
                    segmentResetter = true;
                }
                break;
            case 2:
                if (!segmentResetter)
                {
                    segment = 3;
                    startSegment3();
                    segmentResetter = true;
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        if(leftTaichiHitboxes[current].GetComponent<TaichiHitbox>().isHit && rightTaichiHitboxes[current].GetComponent<TaichiHitbox>().isHit)
        {
            deactivateCurrent();
            resumeTaichi.Invoke();
        }
    }

    private void OnDrawGizmos() // Gizmos to see how the hitbox are connected drawing a line from one to the other
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < leftTaichiHitboxes.Length -1; i++) {
            if (leftTaichiHitboxes[i].activeInHierarchy && leftTaichiHitboxes[i+1].activeInHierarchy)
            {
                Gizmos.DrawLine(leftTaichiHitboxes[i].transform.position, leftTaichiHitboxes[i + 1].transform.position);
            }
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < rightTaichiHitboxes.Length - 1; i++)
        {
            if (rightTaichiHitboxes[i].activeInHierarchy && rightTaichiHitboxes[i + 1].activeInHierarchy)
            {
                Gizmos.DrawLine(rightTaichiHitboxes[i].transform.position, rightTaichiHitboxes[i + 1].transform.position);
            }
        }
    }

    private void SetLineRenderer()
    {
        rightLinerenderer.enabled = true;
        rightLinerenderer.SetPosition(0,rightTaichiHitboxes[current].transform.position);
        rightLinerenderer.SetPosition(1,rightTaichiHitboxes[current + 1].transform.position);
        leftLinerenderer.enabled = true;
        leftLinerenderer.SetPosition(0, leftTaichiHitboxes[current].transform.position);
        leftLinerenderer.SetPosition(1, leftTaichiHitboxes[current + 1].transform.position);
    }
}
