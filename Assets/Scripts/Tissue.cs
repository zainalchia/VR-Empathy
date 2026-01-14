using UnityEngine;

public class Handkerchief: MonoBehaviour
{

    [Header("Collision Target")]
    public GameObject son; // Sean object

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == son.transform)
        {
            gameObject.SetActive(false);
        }
    }



}
