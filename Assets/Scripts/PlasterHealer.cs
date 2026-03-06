using UnityEngine;

public class PlasterHealer : MonoBehaviour
{
    // references
    private Renderer leftHandRenderer;
    private GameObject bloodEffect;
    private Material plasteredHandMaterial;

    private void Start()
    {
        leftHandRenderer = GameManager.instance.leftHandRenderer;
        bloodEffect = GameManager.instance.bloodEffect;
        plasteredHandMaterial = GameManager.instance.plasteredHandMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("LeftHand"))
            return;

        // Stop bleed effect
        if (bloodEffect != null && bloodEffect.activeInHierarchy)
        {
            bloodEffect.SetActive(false);
        }

        // Change hand material to plaster
        if (leftHandRenderer != null && plasteredHandMaterial != null)
        {
            leftHandRenderer.material = plasteredHandMaterial;
            GameManager.instance.handHealed = true;
        }

        // FORCE RIGHT HAND DROP (runtime safe)
        ForceRightHandDrop();

        // Remove plaster
        Destroy(gameObject, 0.2f);
    }

    private void ForceRightHandDrop()
    {
        if (ControllerInteractionsManager.instance == null)
            return;

        ControllerInteractionsManager.instance.rightGrabInteractor.ForceRelease();
    }
}
