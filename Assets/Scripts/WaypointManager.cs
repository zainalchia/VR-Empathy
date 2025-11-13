//******************************************************************************************************
//  Use to control where the cockroach fly
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<Transform> wayPoints = new List<Transform>();
    [SerializeField] int wayPointIndex;
    [SerializeField] float moveSpeed, rotSpeed;
    [SerializeField] bool isMoving;
    [Tooltip("put 0 to make it infinite")]
    [SerializeField] int HowManyLoops;
    bool isLoop = false;
    int loopRound = 0;

    // Start is called before the first frame update
    void Start()
    {
        BeginMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving)
        {
            return;
        }
        if(wayPointIndex<wayPoints.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayPointIndex].position, Time.deltaTime * moveSpeed);
            var direction = transform.position - wayPoints[wayPointIndex].position;
            var targetRot = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotSpeed);
            var distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
            {
                if (distance <= 0.05f)
                {
                    wayPointIndex++;
                    if(isLoop && wayPointIndex>=wayPoints.Count)
                    {
                        wayPointIndex = 0;
                        loopRound++;
                        if(loopRound >= HowManyLoops && HowManyLoops != 0)
                        { 
                            //Destroy(gameObject); 
                        }
                    }
                }
            }
        }
        
    }
    public void BeginMovement()
    {
        wayPointIndex = 0;
        isMoving = true;
    }
}
