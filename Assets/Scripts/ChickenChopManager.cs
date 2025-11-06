using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using System.Collections;

public class ChickenChopManager : MonoBehaviour
{
    public GameObject chickenPiecesGroup;
    public List<Rigidbody> pieces = new List<Rigidbody>();
    public List<GameObject> cutLines = new List<GameObject>();

    public HeartbeatUI uiManager;
    private int currentPiece = 0; //track what piece is being cut
    private bool isHolding = false;

    // prevents multiple cuts per swing
    private bool canCut = true;
    [SerializeField] private float cutCooldown = 0.3f;

    [SerializeField] private Renderer handRenderer;
    [SerializeField] private Material normalHandMaterial;
    [SerializeField] private Material bleedingHandMaterial;
    [SerializeField] private GameObject bloodEffect;

    private bool customerVO = false; 
    private ScenarioManagerReneeTest sceneManager; 
    private void Start()
    {
        sceneManager = FindObjectOfType<ScenarioManagerReneeTest>();
        chickenPiecesGroup.SetActive(true);
        //hide red lines at the start
        foreach (var line in cutLines)
            line.SetActive(false);
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

        //stop if all pieces already cut
        if (!canCut || currentPiece >= pieces.Count)
            return;

        // Detach current piece
        Rigidbody piece = pieces[currentPiece];
        piece.isKinematic = false;
        piece.useGravity = true;

        // Unparent the piece
        piece.transform.SetParent(null);

        //small upward and backward push, aka just fall naturally
        piece.AddForce(Vector3.up * 0.35f + Vector3.back * 0.35f, ForceMode.Impulse);

        // Hide the current guide line
        if (currentPiece < cutLines.Count)
            cutLines[currentPiece].SetActive(false);

        // Show the next line if it exists
        if (currentPiece + 1 < cutLines.Count)
            cutLines[currentPiece + 1].SetActive(true);

        if (uiManager != null)
        {
            if (currentPiece == 2)
            {
                // slight pulse first tension
                uiManager.StartSoftRed();
                cutCooldown = 0.8f;
            }
            else if (currentPiece == 3)
            {
                // stronger
                uiManager.StartRed();
                cutCooldown = 1.0f;
            }
            else if (currentPiece == 4)
            {
                // strongest
                uiManager.StartDeepRed();
                cutCooldown = 1.2f;
            }
            else if (currentPiece == 5)
            {
                // knife accident
                uiManager.KnifeAccidentFlash();

                if (bloodEffect != null)
                    StartCoroutine(ActivateBloodEffect(bloodEffect)); //blood particles

                cutCooldown = 1.7f;
                StartCoroutine(BleedingHand()); //changes the normal hand to bleeding hand
                sceneManager.PlayChoppedHand();
            }
        }
        

        //move next piece
        currentPiece++;

        if (currentPiece >= pieces.Count)
        {
            cutCooldown = 0.3f;

            // release knife after cut
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

        // Start cooldown so only one cut per swing
        canCut = false;
        Invoke(nameof(ResetCut), cutCooldown);
    }
    private IEnumerator BleedingHand()
    {
        if (handRenderer == null || bleedingHandMaterial == null)
            yield break;

        yield return new WaitForSeconds(0.3f);

        // change the original hand mat to bleeding mat
        handRenderer.material = bleedingHandMaterial;
    }
    private IEnumerator ActivateBloodEffect(GameObject effect)
    {
        effect.SetActive(true);
        yield return new WaitForEndOfFrame(); 
        var particle = effect.GetComponent<ParticleSystem>();
        if (particle != null)
        {
            particle.Play();
        }
    }

    public int GetCurrentPieceIndex() //get cut progress number
    {
        return currentPiece;
    }

    public void ChickenHold(bool holding) // tracks
    {
        isHolding = holding;
    }
    private void ResetCut()
    {
        canCut = true;
    }
}
