using UnityEngine;

public class Tissue: MonoBehaviour
{

    [Header("Collision Target")]
    public GameObject son; // Sean object


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == son)
        {
            gameObject.SetActive(false);
        }
    }

    
}
