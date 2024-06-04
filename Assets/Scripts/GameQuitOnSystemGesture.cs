using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuitOnSystemGesture : MonoBehaviour
{
    [SerializeField] private OVRHand hand;
    [SerializeField] private float gestureTime = 5;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hand != null)
        {
            if (hand.IsTracked)
            {
                if (hand.IsSystemGestureInProgress)
                {
                    timer += Time.deltaTime;

                    if (timer > gestureTime)
                        Application.Quit();
                }
            }
        }
    }
}
