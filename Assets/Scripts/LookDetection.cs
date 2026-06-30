using UnityEngine;
using UnityEngine.Events;

public class LookDetection : MonoBehaviour
{
    [SerializeField] string tagName;
    public UnityEvent HitResponse;
    bool hitTarget = false;

    void Update()
    {
        ShootRay();
    }

    void ShootRay()
    {
        float length = 50.0f;
        RaycastHit hit;
        Vector3 rayDirection = gameObject.transform.TransformDirection(Vector3.forward);
        Vector3 rayStart = gameObject.transform.position + rayDirection;
        rayStart.y = rayStart.y + 0.5f;
        Debug.DrawRay(rayStart, rayDirection * length, Color.green);
        if (Physics.Raycast(rayStart, rayDirection, out hit, length))
        {
            if (hit.collider.tag == tagName)
            {
                hit.collider.gameObject.GetComponent<Outline>().enabled = false;

                if (!hitTarget)
                {
                    hitTarget = true;
                    HitResponse.Invoke();
                }
            }
        }
    }
}
