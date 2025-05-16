using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField] GameObject[] leftTaichiHitboxes;
    [SerializeField] GameObject[] rightTaichiHitboxes;
    [SerializeField] GameObject taichiNPCLeftMiddleFinger; // npc left middle finger position
    [SerializeField] GameObject taichiNPCRightMiddleFinger; // npc right middle finger position
    [SerializeField] GameObject taichiNPCHip; // npc hip position
    public GameObject taichiNPCLeftBall; // not what you're thinking. it's the ball at the hand, showing whether your hand is in the correct place ;)
    public GameObject taichiNPCRightBall;

    // Segment 1 - 0 to 4, Segment 2 - 4 to 8, Segment 3 - 8 to 13
    private int current = 0;
    private bool lastHitbox = false;
    private int segment = 1;
    private bool firstHitbox = true;

    private bool segmentResetter = false;

    public UnityEvent taichiFinished;
    public UnityEvent resumeTaichi;

    public bool toSpawnSmallBalls = false;
    private float spawnSmallBallsTimer = 0;
    private float spawnSmallBallsInterval = 0.5f;
    private List<GameObject> smallBalls = new List<GameObject>();

    private void Start()
    {
    }

    public void deactivateCurrent()
    {
        if (!lastHitbox) {
            // Deactivate current hitbox
            leftTaichiHitboxes[current].SetActive(false);
            rightTaichiHitboxes[current].SetActive(false);

            taichiNPCLeftBall.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            taichiNPCRightBall.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            
            DestroySmallBalls();
            toSpawnSmallBalls = true;
        }
        else
        {
            leftTaichiHitboxes[current].SetActive(false);
            rightTaichiHitboxes[current].SetActive(false);

            taichiNPCLeftBall.SetActive(false);
            taichiNPCRightBall.SetActive(false);

            DestroySmallBalls();
        }
    }

    void DestroySmallBalls()
    {
        // destroy previous small balls
        if (smallBalls.Count > 0 && toSpawnSmallBalls == false)
        {
            foreach (GameObject go in smallBalls)
            {
                Destroy(go);
            }
            smallBalls.Clear();
            Debug.Log("destroyed");
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
        leftTaichiHitboxes[current].transform.position = new Vector3(taichiNPCRightMiddleFinger.transform.position.x + (2.3f - 2 * (taichiNPCRightMiddleFinger.transform.position.x - taichiNPCHip.transform.position.x)), taichiNPCRightMiddleFinger.transform.position.y, taichiNPCRightMiddleFinger.transform.position.z);
        leftTaichiHitboxes[current].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

        rightTaichiHitboxes[current].transform.position = new Vector3(taichiNPCLeftMiddleFinger.transform.position.x + (2.3f - 2 * (taichiNPCLeftMiddleFinger.transform.position.x - taichiNPCHip.transform.position.x)), taichiNPCLeftMiddleFinger.transform.position.y, taichiNPCLeftMiddleFinger.transform.position.z);
        rightTaichiHitboxes[current].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

        leftTaichiHitboxes[current].SetActive(true);
        rightTaichiHitboxes[current].SetActive(true);

        taichiNPCLeftBall.SetActive(true);
        taichiNPCRightBall.SetActive(true);

        taichiNPCLeftBall.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        taichiNPCRightBall.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        taichiNPCLeftBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);
        taichiNPCRightBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);

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

        toSpawnSmallBalls = false;
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

    private void Update()
    {
        if (toSpawnSmallBalls)
        {
            if (spawnSmallBallsTimer > spawnSmallBallsInterval)
            {
                // automate hitboxes position according to where taichi npc hands(aka their middle fingers center of their hands) are at
                // the player one is mirror image of the instructor one
                GameObject newTaichiRightSmallBall = Instantiate(taichiNPCRightBall, taichiNPCRightMiddleFinger.transform.position, Quaternion.identity);
                GameObject newPlayerLeftSmallBall = Instantiate(leftTaichiHitboxes[current], new Vector3(taichiNPCRightMiddleFinger.transform.position.x + (2.3f - 2 * (taichiNPCRightMiddleFinger.transform.position.x - taichiNPCHip.transform.position.x)), taichiNPCRightMiddleFinger.transform.position.y, taichiNPCRightMiddleFinger.transform.position.z), Quaternion.identity);
                newTaichiRightSmallBall.SetActive(true);
                newPlayerLeftSmallBall.SetActive(true);
                newPlayerLeftSmallBall.GetComponent<TaichiHitbox>().linkedBall = newTaichiRightSmallBall;   

                GameObject newTaichiLeftSmallBall = Instantiate(taichiNPCLeftBall, taichiNPCLeftMiddleFinger.transform.position, Quaternion.identity);
                GameObject newPlayerRightSmallBall = Instantiate(rightTaichiHitboxes[current], new Vector3(taichiNPCLeftMiddleFinger.transform.position.x + (2.3f - 2 * (taichiNPCLeftMiddleFinger.transform.position.x - taichiNPCHip.transform.position.x)), taichiNPCLeftMiddleFinger.transform.position.y, taichiNPCLeftMiddleFinger.transform.position.z), Quaternion.identity);
                newTaichiLeftSmallBall.SetActive(true);
                newPlayerRightSmallBall.SetActive(true);
                newPlayerRightSmallBall.GetComponent<TaichiHitbox>().linkedBall = newTaichiLeftSmallBall;

                newTaichiRightSmallBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);
                newPlayerLeftSmallBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0);
                newTaichiLeftSmallBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);
                newPlayerRightSmallBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0);

                smallBalls.Add(newTaichiRightSmallBall);
                smallBalls.Add(newPlayerLeftSmallBall);
                smallBalls.Add(newTaichiLeftSmallBall);
                smallBalls.Add(newPlayerRightSmallBall);

                Debug.Log("spawned. parent is: " + gameObject.transform.parent.gameObject.name);

                spawnSmallBallsTimer = 0;
            }
            else
            {
                spawnSmallBallsTimer += Time.deltaTime;
            }
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
}
