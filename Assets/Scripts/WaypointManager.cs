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

    [Header("Rotation Adjustment")]
    [SerializeField] float yRotationOffset = 0f; // added Y rotation adjuster

    [SerializeField] bool isMoving;
    [Tooltip("put 0 to make it infinite")]
    [SerializeField] int HowManyLoops;

    bool isLoop = false;
    int loopRound = 0;

    void Start()
    {
        BeginMovement();
    }

    void Update()
    {
        if (!isMoving)
            return;

        if (wayPointIndex < wayPoints.Count)
        {
            // Move
            transform.position = Vector3.MoveTowards(
                transform.position,
                wayPoints[wayPointIndex].position,
                Time.deltaTime * moveSpeed);

            // Rotate toward waypoint
            var direction = transform.position - wayPoints[wayPointIndex].position;
            var targetRot = Quaternion.LookRotation(direction, Vector3.up);

            // APPLY Y ROTATION OFFSET
            targetRot *= Quaternion.Euler(0f, yRotationOffset, 0f);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRot,
                Time.deltaTime * rotSpeed);

            // Check arrival
            var distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
            if (distance <= 0.05f)
            {
                wayPointIndex++;

                if (isLoop && wayPointIndex >= wayPoints.Count)
                {
                    wayPointIndex = 0;
                    loopRound++;

                    if (loopRound >= HowManyLoops && HowManyLoops != 0)
                    {
                        //Destroy(gameObject);
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
