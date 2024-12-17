using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaichiHitbox : MonoBehaviour
{
    public bool isHit = false;
    public UnityEvent nextHitbox;
    private bool isActivated = false;

    private void Awake()
    {
        StartCoroutine(Runtime());
    }

    IEnumerator Runtime()
    {
        yield return new WaitForSeconds(1f);
        isActivated = true;

        yield return new WaitForSeconds(2f);
        nextHitbox.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null && isActivated)
        {
            isHit = true;
            this.GetComponent<Renderer>().material.color = Color.green;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null && isActivated)
        {
            isHit = true;
            this.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
