using UnityEngine;

public class Comb : MonoBehaviour
{
    [SerializeField] GameObject grabPoint;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "LeftHand")
        {
            grabPoint.transform.localPosition = new Vector3(0, 0, -0.15f);
            grabPoint.transform.localEulerAngles = new Vector3(-180, 0, -90);
        }
        else if (collision.gameObject.tag == "RightHand")
        {
            grabPoint.transform.localPosition = new Vector3(0, 0, 0.15f);
            grabPoint.transform.localEulerAngles = new Vector3(180, 180, 125);
        }
    }
}
