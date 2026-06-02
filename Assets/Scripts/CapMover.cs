using System.Collections;
using UnityEngine;

public class CapMover : MonoBehaviour
{
    [SerializeField] private Transform targetSpot;
    [SerializeField] private float moveDuration = 1.5f; //how fast from bottle to table
    [SerializeField] private float heightMultiplier = 0.1f; // arc curve 
 
    public void MoveToTable()
    {
        StartCoroutine(MoveCapRoutine());
    }

    private IEnumerator MoveCapRoutine()
    {
        Vector3 start = transform.position;
        Vector3 target = targetSpot.position;// world pos
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;

            Vector3 current = Vector3.Lerp(start, target, t);
            current.y += Mathf.Sin(t * Mathf.PI) * heightMultiplier;

            transform.position = current;
            yield return null;
        }

        transform.position = target;

        yield return new WaitForSeconds(0.8f); 
        //gameObject.SetActive(false);
    }

}
