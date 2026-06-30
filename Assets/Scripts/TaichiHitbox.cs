using System.Collections;
using UnityEngine;

public class TaichiHitbox : MonoBehaviour
{
    private bool isActivated = false;
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

    void LinkedBallDisappear()
    {
        // for the small balls to get wiped out
        if (linkedBall != null)
        {
            linkedBall.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.1f);
            Destroy(linkedBall, 0.3f);
            Destroy(gameObject);
        }
    }
}
