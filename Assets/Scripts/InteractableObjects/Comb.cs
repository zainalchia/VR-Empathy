using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comb : MonoBehaviour
{
    [SerializeField] GameObject grabPoint;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "LeftHand") grabPoint.transform.localEulerAngles = new Vector3(90, 0, -90);
        else grabPoint.transform.localEulerAngles = new Vector3(-180, 0, -90);
    }
}
