using System.Collections;
using UnityEngine;

public class DoorInactive : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DisableAfterDelay());
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        targetObject.SetActive(false);
    }
}
