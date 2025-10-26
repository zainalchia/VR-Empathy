using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

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

    private void Start()
    {
        chickenPiecesGroup.SetActive(true);
        //hide red lines at the start
        foreach (var line in cutLines)
            line.SetActive(false);
    }

    public void OnKnifeHit()
    {

        if (!isHolding)
            return;

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

        // control heartbeat + red flash
        if (uiManager != null)
        {
            float progress = (float)currentPiece / pieces.Count; // how many pieces cut

            if (progress > 0.6f && progress < 1f) // 4-5th cut should happen
            {
                float intensity = Mathf.Lerp(0.2f, 0.8f, progress); // slowly smooth build effect 
                uiManager.SetWarningLevel(intensity);
            }
            else if (progress >= 1f) //all cut return to normal
            {
                uiManager.ResetWarning(); // fade out when finished
            }
        }

        //move next piece
        currentPiece++;

        // Start cooldown so only one cut per swing
        canCut = false;
        Invoke(nameof(ResetCut), cutCooldown);
    }
    public void ChickenHold(bool holding)
    {
        isHolding = holding;
    }
    private void ResetCut()
    {
        canCut = true;
    }
}

