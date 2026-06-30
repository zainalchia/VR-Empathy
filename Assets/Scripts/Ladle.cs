using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ladle : MonoBehaviour
{
    public UnityEvent PouredFood;

    [Header("Objects that activate one-by-one in order")]
    [SerializeField] private List<GameObject> requiredObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> porridgeObjects = new List<GameObject>();

    private bool PlayOnce = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FoodBowl"))
        {
            ActivateNextObject();

            if (PlayOnce && AllObjectsActive())
            {
                PouredFood.Invoke();
                PlayOnce = false;
            }
        }
    }

    private void ActivateNextObject()
    {
        foreach (GameObject go in porridgeObjects)
            go.SetActive(false);

        foreach (GameObject go in requiredObjects)
            go.SetActive(true);
    }

    private bool AllObjectsActive()
    {
        for (int i = 0; i < requiredObjects.Count; i++)
        {
            if (requiredObjects[i] == null || !requiredObjects[i].activeInHierarchy)
                return false;
        }
        return true;
    }
}
