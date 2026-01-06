using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ladle : MonoBehaviour
{
    public UnityEvent PouredFood;

    [Header("Objects that activate one-by-one in order")]
    [SerializeField] private List<GameObject> requiredObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> porridgeObjects = new List<GameObject>();

    private bool hasInteractedWith = false;
    private int currentIndex = 0;
    private bool PlayOnce = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FoodBowl") && hasInteractedWith == true)
        {
            Debug.Log("Bowl has been contacted");

            ActivateNextObject();

            hasInteractedWith = false;

            if (PlayOnce && AllObjectsActive())
            {
                PouredFood.Invoke();
                PlayOnce = false;
            }
        }

        if (other.CompareTag("Porridge") && hasInteractedWith == false)
        {
            Debug.Log("porridge has been contacted");

            DeactivateNextObject();
            hasInteractedWith = true;
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

    private void DeactivateNextObject()
    {
        if (currentIndex >= porridgeObjects.Count) return;

        GameObject obj = porridgeObjects[currentIndex];

        if (obj != null) 
        {
            obj .SetActive(false);
            Debug.Log("Deactivate object: " + obj.name);
        }
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

        for (int i = 0; i < porridgeObjects.Count; i++)
        {
            if (porridgeObjects[i] == null)
                return false;

            if (!porridgeObjects[i].activeInHierarchy)
                return false;
        }
        return true;
    }
}
