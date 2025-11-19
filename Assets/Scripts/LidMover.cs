using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LidMover : MonoBehaviour
{
    [SerializeField] private Transform targetSpot;
    [SerializeField] private float moveDuration = 1.5f;
    [SerializeField] private float heightMultiplier = 0.2f;

    public void MoveToTable()
    {
        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        // get start and target position of lid
        Vector3 start = transform.position;
        Vector3 target = targetSpot.position;

        float elapsed = 0f;

        //loop until the movement is complete
        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            Vector3 current = Vector3.Lerp(start, target, t); //smootly move to target
            current.y += Mathf.Sin(t * Mathf.PI) * heightMultiplier; //upward arc motion
            transform.position = current; //update lid position
            yield return null;
        }

        transform.position = target; //target reached
        yield return new WaitForSeconds(0.8f);
    }
}
