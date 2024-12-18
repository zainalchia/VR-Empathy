using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaichiHitbox : MonoBehaviour
{
    public bool isHit = false;
    private bool isActivated = false;

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
            this.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.2f);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null && isActivated)
        {
            isHit = true;
            this.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null && isActivated)
        {
            isHit = false;
            this.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.2f);
        }
    }
}
