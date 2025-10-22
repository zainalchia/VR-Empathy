using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour
{

    [SerializeField] GameObject DroppedFood;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log(collision.gameObject.tag.ToString());
        if (collision.gameObject.tag == "ToClean")
        {
            Destroy(collision.gameObject);
        }
    }
}
