using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaneChickenChopper : MonoBehaviour
{
    [Header("Blendshape References")]
    public SkinnedMeshRenderer chickenMesh;
    public List<int> blendShapeIndices;
    public float blendLerpTime = 0.25f;

    [Header("Cut Line Objects (Pre-Placed)")]
    public List<GameObject> cutLines;

    [Header("Chop Settings")]
    public float chopCooldown = 0.75f;

    [Header("Grab Settings")]
    public GrabInteractable grabInteractable;
    public ForceStayGrabbed forceStayGrabbed;

    public int currentCutIndex = 0;

    private bool canChop = true;
    private bool leftHandHolding = false;
    private bool hasDropped = false;

    private void Awake()
    {
        ResetChicken();
    }

    private void Update()
    {
        // Show cut lines ONLY if left hand is holding
        for (int i = 0; i < cutLines.Count; i++)
        {
            cutLines[i].SetActive(leftHandHolding && i == currentCutIndex);
        }
    }

    private IEnumerator LerpBlendShape(int index, float start, float end, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            float val = Mathf.Lerp(start, end, t / duration);
            chickenMesh.SetBlendShapeWeight(blendShapeIndices[index], val);
            t += Time.deltaTime;
            yield return null;
        }

        chickenMesh.SetBlendShapeWeight(blendShapeIndices[index], end);
    }

    private IEnumerator ChopCooldownRoutine()
    {
        canChop = false;
        yield return new WaitForSeconds(chopCooldown);
        canChop = true;
    }

    public void ResetChicken()
    {
        currentCutIndex = 0;
        canChop = true;
        leftHandHolding = false;
        hasDropped = false;

        for (int i = 0; i < cutLines.Count; i++)
        {
            cutLines[i].SetActive(false);
            chickenMesh.SetBlendShapeWeight(blendShapeIndices[i], 0);
        }

        if (grabInteractable != null)
            grabInteractable.enabled = true;

        if (forceStayGrabbed != null)
            forceStayGrabbed.SetForceGrabActive(true);
    }

    public void NextCut()
    {
        if (!canChop)
            return;

        if (currentCutIndex >= blendShapeIndices.Count)
            return;

        StartCoroutine(LerpBlendShape(currentCutIndex, 0, 100, blendLerpTime));
        StartCoroutine(ChopCooldownRoutine());

        // Drop the cleaver on 6th cut 
        if (currentCutIndex == 5 && !hasDropped)
        {
            DropCleaver();
        }

        currentCutIndex++;
    }

    private void DropCleaver()
    {
        hasDropped = true;

        if (forceStayGrabbed != null)
            forceStayGrabbed.SetForceGrabActive(false);

        if (grabInteractable != null)
            grabInteractable.enabled = false;

        // Force both hands to release (safe even if not holding)
        if (ControllerInteractionsManager.instance != null)
        {
            ControllerInteractionsManager.instance.leftGrabInteractor.ForceRelease();
            ControllerInteractionsManager.instance.rightGrabInteractor.ForceRelease();
        }
    }

    // Called by LeftHandHoldPositive
    public void SetLeftHandHolding(bool holding)
    {
        leftHandHolding = holding;
    }
}
