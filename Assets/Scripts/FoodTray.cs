using UnityEngine;

public class FoodTray: MonoBehaviour {
    private bool hasHitFloor = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHitFloor)
            return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            hasHitFloor = true;

            ScenarioManagerReneeTest manager =
                FindObjectOfType<ScenarioManagerReneeTest>();

            if (manager != null)
                manager.OnTrayHitFloor(transform.position);
        }
    }


}
