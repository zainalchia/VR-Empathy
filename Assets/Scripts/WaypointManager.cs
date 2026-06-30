//******************************************************************************************************
//  Use to control where the cockroach fly
//******************************************************************************************************
using UnityEngine;
using System.Collections.Generic;

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

    [SerializeField] bool startwalk = true;

    void Start()
    {
        BeginMovement();
    }

    public void startwalktrigger()
    {
        startwalk = true;
    }

    void Update()
    {
        if (startwalk == false)
            return;

        if (!isMoving)
            return;

        if (wayPointIndex < wayPoints.Count)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                wayPoints[wayPointIndex].position,
                Time.deltaTime * moveSpeed);

            var direction = transform.position - wayPoints[wayPointIndex].position;
            var targetRot = Quaternion.LookRotation(direction, Vector3.up);
            targetRot *= Quaternion.Euler(0f, yRotationOffset, 0f);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRot,
                Time.deltaTime * rotSpeed);

            var distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
            if (distance <= 0.05f)
                wayPointIndex++;
        }
    }

    public void BeginMovement()
    {
        wayPointIndex = 0;
        isMoving = true;
    }
}
