using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    public void RecenterPlayer()
    {
        OVRManager.display.RecenterPose();
        Debug.Log("OVR Camera RecenterPose called.");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
