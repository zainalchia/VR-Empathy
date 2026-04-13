using Oculus.Interaction;
using System.Collections;
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

        GameManager.instance.grabInteractors[1].ForceRelease();
    }
    public void SpawnPlaster()
    {
        Transform targetPalm = GameManager.instance.rightPalm;

        StartCoroutine(MovePlasterToHand(gameObject, targetPalm));
    }

    private IEnumerator MovePlasterToHand(GameObject plaster, Transform targetPalm, float height = 0.2f, float duration = 1f)
    {
        // take start and target positions
        Vector3 start = plaster.transform.position;
        Vector3 target = targetPalm.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            // move plaster
            Vector3 current = Vector3.Lerp(start, target, t);
            // arc like checkers
            current.y += Mathf.Sin(t * Mathf.PI) * height;
            // position
            plaster.transform.position = current;
            yield return null;
        }

        // snap plaster into right palm
        plaster.transform.position = targetPalm.position + targetPalm.up * 0.02f;
        plaster.transform.rotation = targetPalm.rotation;
        plaster.transform.SetParent(targetPalm);

        // Force grab with right hand only
        var grabInteractable = plaster.GetComponent<GrabInteractable>();
        GameManager.instance.grabInteractors[1].ForceSelect(grabInteractable);

    }
}
