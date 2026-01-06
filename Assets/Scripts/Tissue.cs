using UnityEngine;

public class Tissue: MonoBehaviour
{

    [Header("Collision Target")]
    public GameObject son; // Sean object

    [Header("Settings")]
    public float collisionTimeToTrigger = 3f; // time tissue must touch Sean
    private float collisionTimer = 0f;
    private bool isTouching = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == son)
        {
            isTouching = true;
            collisionTimer = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == son)
        {
            isTouching = false;
            collisionTimer = 0f;
        }
    }

    void Update()
    {
        if (isTouching)
        {
            collisionTimer += Time.deltaTime;

            if (collisionTimer >= collisionTimeToTrigger)
            {
                // Tissue successfully touched Sean for enough time
                // Disable the tissue
                gameObject.SetActive(false);

              
            }
        }
    }
}
