using UnityEngine;

public class TrayDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Only react to the tray
        if (other.CompareTag("Tray"))
        {
            ScenarioManagerReneeTest manager =
                FindObjectOfType<ScenarioManagerReneeTest>();

            if (manager != null)
            {
                manager.PlayFoodDrop();
            }
        }
    }
}
