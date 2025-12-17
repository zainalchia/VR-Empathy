using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            FindObjectOfType<ScenarioManagerReneeTest>().PlateImpact();
        }
    }
}

