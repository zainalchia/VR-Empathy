using UnityEngine;

public class SlowDownHands : MonoBehaviour
{
    [SerializeField] private GameObject[] leftHandObjects;

    void Update()
    {
        foreach (GameObject obj in leftHandObjects)
        {
            obj.transform.position = Vector3.zero;
        }
    }
}
