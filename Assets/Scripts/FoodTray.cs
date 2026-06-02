using UnityEngine;

public class FoodTray: MonoBehaviour {
    [SerializeField] private GameObject DroppedFood;
    private bool hasHitFloor = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHitFloor)
            return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            hasHitFloor = true;
            OnTrayHitFloor(gameObject.transform.position);
        }
    }
    public void OnTrayHitFloor(Vector3 trayPosition) //called from tray script
    {
        gameObject.SetActive(false);

        DroppedFood.transform.position = new Vector3(
            trayPosition.x,
            0.05f,
            trayPosition.z
        );
        DroppedFood.SetActive(true);

    }

}
