using UnityEngine;
using UnityEngine.Events;

public class Mug : MonoBehaviour, IObjectInteractable
{
    bool hadWater = false;
    bool canInteract = false;
    public UnityEvent OnInteractEvent;
    [SerializeField] GameObject waterInMug;
    [SerializeField] GameObject grabPoint;

    public void OnInteract()
    {
        OnInteractEvent.Invoke();
    }

    public void SetInteractive(bool trueOrFalse)
    {
        canInteract = trueOrFalse;
    }

    public bool ShouldInteractWithFace()
    {
        return canInteract;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!hadWater)
        {
            if (collision.gameObject.name == "WaterCollider") // adds water into mug
            {
                hadWater = true;
                waterInMug.SetActive(true);
                GetComponent<AudioSource>().Play();
                canInteract = true;
            }
        }

        if (collision.gameObject.tag.Contains("Hand")) grabPoint.transform.localEulerAngles = new Vector3(90, 90, 90);
    }
}
