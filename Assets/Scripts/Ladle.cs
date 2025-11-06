using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ladle : MonoBehaviour
{
    public UnityEvent PouredFood;
    [SerializeField] GameObject PorridgeInBowl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FoodBowl")
        {
            PorridgeInBowl.gameObject.SetActive(true);
            PouredFood.Invoke();
        }
    }
}
