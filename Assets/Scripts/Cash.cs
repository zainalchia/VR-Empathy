using System.Collections;
using UnityEngine;

public class Cash : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip cashSFX;

    [Header("Other")]
    [SerializeField] private Collider registerSlotCollider;
    [SerializeField] private Outline registerOutline;
    private bool hasBeenPlaced = false;
    private bool hasBeenGrabbed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenPlaced && other == registerSlotCollider)
            PlaceCash();
    }

    public void OnGrabbed()
    {
        if (!hasBeenGrabbed)
        {
            hasBeenGrabbed = true;
            if (registerOutline != null)
                registerOutline.enabled = true;
        }
    }

    private void PlaceCash()
    {
        hasBeenPlaced = true;

        if (cashSFX != null)
            AudioSource.PlayClipAtPoint(cashSFX, transform.position, 0.3f);

        if (registerOutline != null)
            registerOutline.enabled = false;

        if (AlertTextController.instance != null)
            AlertTextController.instance.SetInactive();

        StartCoroutine(DisappearAfterDelay(0.2f));
    }

    private IEnumerator DisappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
