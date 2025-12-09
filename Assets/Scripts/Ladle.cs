using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ladle : MonoBehaviour
{
    public UnityEvent PouredFood;

    [Header("Objects that activate one-by-one in order")]
    [SerializeField] private List<GameObject> requiredObjects = new List<GameObject>();

    private int currentIndex = 0;
    private bool PlayOnce = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FoodBowl"))
        {
            Debug.Log("Bowl has been contacted");

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
        // If all objects already activated, do nothing
        if (currentIndex >= requiredObjects.Count)
            return;

        GameObject obj = requiredObjects[currentIndex];

        if (obj != null)
        {
            obj.SetActive(true);
            Debug.Log("Activated object: " + obj.name);
        }

        currentIndex++;
    }

    private bool AllObjectsActive()
    {
        for (int i = 0; i < requiredObjects.Count; i++)
        {
            if (requiredObjects[i] == null)
                return false;

            if (!requiredObjects[i].activeInHierarchy)
                return false;
        }
        return true;
    }
}
