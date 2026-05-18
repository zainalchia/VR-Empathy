using Oculus.Interaction;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CapsuleScript: MonoBehaviour
{
    // references
    private Renderer leftHandRenderer;
    private GameObject bloodEffect;
    private Material plasteredHandMaterial;
    private BoxCollider plasterCollider;

    public UnityEvent OnCapsuleAte;
    int handIndex;
    Transform targetPalm;

    private void Start()
    {
        leftHandRenderer = GameManager.instance.leftHandRenderer;
        bloodEffect = GameManager.instance.bloodEffect;
        plasteredHandMaterial = GameManager.instance.plasteredHandMaterial;
        plasterCollider = GetComponent<BoxCollider>();
        plasterCollider.enabled = false;
    }

    private void Awake()
    {
        handIndex = ControllerInteractionsManager.instance.ObjInWhichHand(GameManager.instance.medicine);

        // choose where pill suppose to go
        targetPalm = (handIndex == 0) ? GameManager.instance.rightPalm   // bottle in left hand, pill to right palm
        : GameManager.instance.leftPalm;

        SpawnPlaster();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Face")
            return;

        OnCapsuleAte.Invoke();

        // FORCE RIGHT HAND DROP (runtime safe)
        ForceDrop();

        // Remove pill
        gameObject.SetActive(false);
    }

    private void ForceDrop()
    {
        if (ControllerInteractionsManager.instance == null)
            return;

        GameManager.instance.grabInteractors[handIndex].ForceRelease();
    }
    public void SpawnPlaster()
    {

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
        plasterCollider.enabled = true;

    }
}
