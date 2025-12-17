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

        StartCoroutine(CutSequence());
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


    private IEnumerator CutSequence()
    {
        canCut = false;

        // Hide all cut lines while cutting
        HideAllCutLines();

        int shapeIndex = blendShapeIndices[currentPiece];
        bool isFinalCut = (currentPiece == blendShapeIndices.Count - 1);

        if (isFinalCut)
        {
            // Start blendshape but DO NOT wait for it
            StartCoroutine(LerpBlendShape(shapeIndex, 0f, 100f, blendLerpTime));

            HandleUILogic();
            HandleFinalCut();

            currentPiece++;
            canCut = true;
            yield break;
        }

        // Normal cuts wait for blendshape
        yield return StartCoroutine(
            LerpBlendShape(shapeIndex, 0f, 100f, blendLerpTime)
        );

        HandleUILogic();

        currentPiece++;

        // Show next cut line after animation
        ShowCurrentCutLine();

        canCut = true;
    }

    private void HandleUILogic()
    {
        if (uiManager == null)
            return;

        if (currentPiece == 2)
        {
            uiManager.StartSoftRed();
        }
        else if (currentPiece == 3)
        {
            uiManager.StartRed();
        }
        else if (currentPiece == 4)
        {
            uiManager.StartDeepRed();
        }
        else if (currentPiece == 5)
        {
            uiManager.KnifeAccidentFlash();

            if (bloodEffect != null)
                StartCoroutine(ActivateBloodEffect(bloodEffect));

            StartCoroutine(BleedingHand());

            sceneManager.PlayChoppedHand();
        }
    }

    private void HandleFinalCut()
    {
        GameObject knife = GameObject.FindWithTag("Knife");
        if (knife == null)
            return;

        var forceGrab = knife.GetComponent<ForceStayGrabbed>();
        if (forceGrab != null)
            forceGrab.SetForceGrabActive(false);

        ControllerInteractionsManager.instance.rightGrabInteractor.ForceRelease();
        knife.GetComponent<Grabbable>().enabled = false;
    }


}
