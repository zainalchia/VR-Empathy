using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaiChiManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] leftTaichiHitboxes;
    [SerializeField]
    GameObject[] rightTaichiHitboxes;

    // Segment 1 - 0 to 4, Segment 2 - 4 to 8, Segment 3 - 8 to 13
    private int current = 0;
    private bool lastHitbox = false;
    private int segment = 1;
    private bool firstHitbox = true;



    public UnityEvent taichiFinished;
    public UnityEvent resumeTaichi;

    public void deactivateCurrent()
    {
        if (!lastHitbox) {
            // Deactivate current hitbox
            leftTaichiHitboxes[current].SetActive(false);
            rightTaichiHitboxes[current].SetActive(false);
        }
        else
        {
            leftTaichiHitboxes[current].SetActive(false);
            rightTaichiHitboxes[current].SetActive(false);
            if (segment == 3) {
                taichiHasFinished();
            }
        }
    }

    public void spawnNext()
    {
        if (firstHitbox) 
        {
            firstHitbox = false;
        }
        else
        {
            current++;
        }
        leftTaichiHitboxes[current].SetActive(true);
        rightTaichiHitboxes[current].SetActive(true);

        switch (segment)
        {
            case 1:
                if (current == 3)
                {
                    lastHitbox = true;
                }
                break;
            case 2:
                if (current == 7)
                {
                    lastHitbox = true;
                }
                break;
            case 3:
                if (current == 12)
                {
                    lastHitbox = true;
                }
                break;
            default:
                lastHitbox = false;
                break;
        }
    }

    public void startSegment1()
    {
        //leftTaichiHitboxes[0].SetActive(true);
        //rightTaichiHitboxes[0].SetActive(true);

    }

    public void startSegment2()
    {
        lastHitbox = false;
        //leftTaichiHitboxes[4].SetActive(true);
        //rightTaichiHitboxes[4].SetActive(true);
    }
    public void startSegment3()
    {
        lastHitbox = false;
        //leftTaichiHitboxes[8].SetActive(true);
        //rightTaichiHitboxes[8].SetActive(true);
    }

    private void taichiHasFinished()
    {
        taichiFinished.Invoke();
    }
    public void nextTaichiPose()
    {
        switch (segment)
        {
            case 1:
                segment = 2;
                startSegment2();
                break;
            case 2:
                segment = 3;
                startSegment3();
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
}
