using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouthwash : MonoBehaviour
{
    [SerializeField] GameObject grabPoint;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "LeftHand") grabPoint.transform.localPosition = new Vector3(-0.00427f, 0, 0.00980000012f);
        else if (collision.gameObject.tag == "RightHand") grabPoint.transform.localPosition = new Vector3(0.00279000006f, 0, 0.00980000012f);
    }
}
