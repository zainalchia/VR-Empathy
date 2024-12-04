using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiChiManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] leftTaichiHitboxes;
    [SerializeField]
    GameObject[] rightTaichiHitboxes;

    private int current = 0;
    private bool lastHitbox = false;

    private void Awake()
    {
        leftTaichiHitboxes[current].SetActive(true);
        rightTaichiHitboxes[current].SetActive(true);
    }

    public void nextHitbox()
    {
        if (!lastHitbox) {
            // Deactivate current hitbox
            leftTaichiHitboxes[current].SetActive(false);
            rightTaichiHitboxes[current].SetActive(false);


            current++;
            leftTaichiHitboxes[current].SetActive(true);
            rightTaichiHitboxes[current].SetActive(true);

            if (current == leftTaichiHitboxes.Length - 1) {
                Debug.Log("Triggered last hitbox");
                lastHitbox = true;
            }
        }
        else
        {
            leftTaichiHitboxes[current].SetActive(false);
            rightTaichiHitboxes[current].SetActive(false);
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
