using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Find parent script and notify the impact
        FindObjectOfType<ScenarioManagerReneeTest>().PlateImpact();
        
    }
}

