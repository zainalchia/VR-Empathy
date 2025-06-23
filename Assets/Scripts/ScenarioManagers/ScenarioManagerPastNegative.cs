using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManagerPastNegative : MonoBehaviour
{
    [Header("Multi-Scene Objects")]
    [SerializeField] GameObject firstTeleportToiletHotspot;

    // Start is called before the first frame update
    void Start()
    {
        firstTeleportToiletHotspot.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
