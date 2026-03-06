using UnityEngine;

public class TrayGive : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Only react to the tray
        if (other.CompareTag("Tray"))
        {
            // Disable the tray
            other.gameObject.SetActive(false);

          
        }
    }
}
