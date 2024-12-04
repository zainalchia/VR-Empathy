using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaichiHitbox : MonoBehaviour
{
    public bool isHit = false;
    public UnityEvent nextHitbox;

    private void Awake()
    {
        StartCoroutine(Runtime());
    }

    IEnumerator Runtime()
    {
        yield return new WaitForSeconds(3f);
        nextHitbox.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<GrabInteractor>() != null)
        {
            isHit = true;
            gameObject.SetActive(false);
            nextHitbox.Invoke();
        }

    }
}
