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
            this.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);

            // the player one is mirror image of the instructor one. so left = right and vice versa
            if (hand == Hand.left)
            {
                TaiChiManager.instance.TaichiNPCRightBall.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);
            }
            else if (hand == Hand.right)
            {
                TaiChiManager.instance.TaichiNPCLeftBall.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null && isActivated)
        {
            isHit = true;
            this.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);

            // the player one is mirror image of the instructor one. so left = right and vice versa
            if (hand == Hand.left)
            {
                TaiChiManager.instance.TaichiNPCRightBall.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);
            }
            else if (hand == Hand.right)
            {
                TaiChiManager.instance.TaichiNPCLeftBall.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null && isActivated)
        {
            isHit = false;
            this.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);

            // the player one is mirror image of the instructor one. so left = right and vice versa
            if (hand == Hand.left)
            {
                TaiChiManager.instance.TaichiNPCRightBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);
            }
            else if (hand == Hand.right)
            {
                TaiChiManager.instance.TaichiNPCLeftBall.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.1f);
            }
        }
    }
}
