using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class ChickenChopManager : MonoBehaviour
{
    [Header("Blendshape References")]
    public SkinnedMeshRenderer chickenMesh;
    public List<int> blendShapeIndices; 
    public float blendLerpTime = 0.25f;

    [Header("Cut Line Objects (Pre-Placed)")]
    public List<GameObject> cutLines;   // <<< ADDED

    [Header("UI / Effects")]
    public HeartbeatUI uiManager;
    [SerializeField] private Renderer handRenderer;
    [SerializeField] private Material normalHandMaterial;
    [SerializeField] private Material bleedingHandMaterial;
    [SerializeField] private GameObject bloodEffect;

    private bool isHolding = false;
    private bool canCut = true;
    private bool customerVO = false;

    [SerializeField] private float cutCooldown = 0.3f;

    private ScenarioManagerReneeTest sceneManager;

    private int currentPiece = 0;

    private void Start()
    {
        sceneManager = FindObjectOfType<ScenarioManagerReneeTest>();

        // Reset blendshapes
        if (chickenMesh != null)
        {
            foreach (var idx in blendShapeIndices)
                chickenMesh.SetBlendShapeWeight(idx, 0f);
        }

        // Hide all cut lines initially
        HideAllCutLines();
    }

    // Called by LeftHandHold when holding stops
    public void ResetHoldState()
    {
        isHolding = false;
        HideAllCutLines();
    }

    private void HideAllCutLines()
    {
        if (cutLines == null) return;

        foreach (var line in cutLines)
            if (line != null)
                line.SetActive(false);
    }

    private void ShowCurrentCutLine()
    {
        if (cutLines == null) return;

        for (int i = 0; i < cutLines.Count; i++)
        {
            if (cutLines[i] != null)
                cutLines[i].SetActive(i == currentPiece);
        }
    }

    public void OnKnifeHit()
    {
        if (!isHolding)
            return;

        if (!customerVO && sceneManager != null)
        {
            sceneManager.narrationAudioSource.PlayOneShot(sceneManager.narrationAudioClips_1[4]);
            customerVO = true;
        }

        if (!canCut || currentPiece >= blendShapeIndices.Count)
            return;

        // ===== Blendshape Animation =====
        int shapeIndex = blendShapeIndices[currentPiece];
        StartCoroutine(LerpBlendShape(shapeIndex, 0f, 100f, blendLerpTime));

        // ===== UI Logic =====
        if (uiManager != null)
        {
            if (currentPiece == 2)
            {
                uiManager.StartSoftRed();
                cutCooldown = 0.8f;
            }
            else if (currentPiece == 3)
            {
                uiManager.StartRed();
                cutCooldown = 1.0f;
            }
            else if (currentPiece == 4)
            {
                uiManager.StartDeepRed();
                cutCooldown = 1.2f;
            }
            else if (currentPiece == 5)
            {
                uiManager.KnifeAccidentFlash();

                if (bloodEffect != null)
                    StartCoroutine(ActivateBloodEffect(bloodEffect));

                StartCoroutine(BleedingHand());

                cutCooldown = 1.7f;
                sceneManager.PlayChoppedHand();
            }
        }

        // ===== Move to Next Cut =====
        currentPiece++;               // increment first
        ShowCurrentCutLine();         // then show the next line

        // ===== Final Cut =====
        if (currentPiece >= blendShapeIndices.Count)
        {
            cutCooldown = 0.3f;

            GameObject knife = GameObject.FindWithTag("Knife");
            if (knife != null)
            {
                var forceGrab = knife.GetComponent<ForceStayGrabbed>();
                if (forceGrab != null)
                    forceGrab.SetForceGrabActive(false);

                ControllerInteractionsManager.instance.rightGrabInteractor.ForceRelease();
                knife.GetComponent<Grabbable>().enabled = false;
            }
        }

        canCut = false;
        Invoke(nameof(ResetCut), cutCooldown);
    }


    private IEnumerator LerpBlendShape(int index, float start, float end, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            float val = Mathf.Lerp(start, end, t / duration);
            chickenMesh.SetBlendShapeWeight(index, val);
            t += Time.deltaTime;
            yield return null;
        }
        chickenMesh.SetBlendShapeWeight(index, end);
    }

    private IEnumerator BleedingHand()
    {
        if (handRenderer == null || bleedingHandMaterial == null)
            yield break;

        yield return new WaitForSeconds(0.3f);
        handRenderer.material = bleedingHandMaterial;
    }

    private IEnumerator ActivateBloodEffect(GameObject effect)
    {
        effect.SetActive(true);
        yield return new WaitForEndOfFrame();

        var particle = effect.GetComponent<ParticleSystem>();
        if (particle != null)
            particle.Play();
    }

    public int GetCurrentPieceIndex()
    {
        return currentPiece;
    }

    public void ChickenHold(bool holding)
    {
        isHolding = holding;
        if (!holding)
            HideAllCutLines();
        else
            ShowCurrentCutLine();
    }

    private void ResetCut()
    {
        canCut = true;
    }
}
