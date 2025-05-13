using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaichiHitbox : MonoBehaviour
{
    public bool isHit = false;
    private bool isActivated = false;
    private enum Hand { left, right }
    [SerializeField] private Hand hand = Hand.left;
    public GameObject linkedBall; // this ball is linked to a ball on the instructor side. u hit this one, the corresponding one at instructor side will disappear too

    private void Awake()
    {
        StartCoroutine(Runtime());
    }

    IEnumerator Runtime()
    {
        yield return new WaitForSeconds(1f);
        isActivated = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null && isActivated)
        {
            isHit = true;
            this.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.02f);

            // the player one is mirror image of the instructor one. so left = right and vice versa
            if (hand == Hand.left)
            {
                TaiChiManager.instance.taichiNPCRightBall.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);

                // for the small balls to get wiped out
                if (linkedBall != null)
                {
                    Destroy(linkedBall);
                    Destroy(gameObject);
                }
            }
            else if (hand == Hand.right)
            {
                TaiChiManager.instance.taichiNPCLeftBall.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);

                // for the small balls to get wiped out
                if (linkedBall != null)
                {
                    Destroy(linkedBall);
                    Destroy(gameObject);
                }
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null && isActivated)
        {
            isHit = true;
            this.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.02f);

            // the player one is mirror image of the instructor one. so left = right and vice versa
            if (hand == Hand.left)
            {
                TaiChiManager.instance.taichiNPCRightBall.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);

                // for the small balls to get wiped out
                if (linkedBall != null)
                {
                    Destroy(linkedBall);
                    Destroy(gameObject);
                }
            }
            else if (hand == Hand.right)
            {
                TaiChiManager.instance.taichiNPCLeftBall.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);

                // for the small balls to get wiped out
                if (linkedBall != null)
                {
                    Destroy(linkedBall);
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null && isActivated)
        {
            isHit = false;
            this.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.02f);

            // the player one is mirror image of the instructor one. so left = right and vice versa
            if (hand == Hand.left)
            {
                TaiChiManager.instance.taichiNPCRightBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);
            }
            else if (hand == Hand.right)
            {
                TaiChiManager.instance.taichiNPCLeftBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);
            }
        }
    }
}
