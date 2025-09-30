using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comb : MonoBehaviour
{
    [SerializeField] GameObject grabPoint;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "LeftHand")
        {
            grabPoint.transform.localEulerAngles = new Vector3(-180, 0, -90);
            grabPoint.transform.localPosition.Set(0, 0, -2);
        }
        //else grabPoint.transform.localEulerAngles = new Vector3(-180, 0, -90);
        else if (collision.gameObject.tag == "RightHand") 
        {
            //grabPoint.transform.localEulerAngles = new Vector3(90, 0, 125); 
            //grabPoint.transform.localEulerAngles = new Vector3(180, -90, 0);
            //grabPoint.transform.localEulerAngles = new Vector3(-180, 0, -90);
            grabPoint.transform.localEulerAngles = new Vector3(180, 180, 125);


        }
    }
}
