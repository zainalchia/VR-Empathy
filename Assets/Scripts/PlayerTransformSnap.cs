using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTransformParent : MonoBehaviour
{
    [SerializeField] Transform transformToSnap;

    // Start is called before the first frame update
    void Start()
    {
        Snap(transformToSnap);
    }

    public void Snap(Transform target)
    {
        Vector3 toMove = transform.position - target.position;
        Quaternion toRotate = transform.rotation * Quaternion.Inverse(target.rotation);

        target.transform.position += toMove;
        target.transform.rotation *= toRotate;
    }
}
