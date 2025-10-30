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

        if (uiManager != null)
        {

            if (currentPiece == 3)
            {
                uiManager.StartSoftRed();
                cutCooldown = 0.5f;
            }
            else if (currentPiece == 4) 
            {
                uiManager.StartRed();
                cutCooldown = 0.8f;
            }
        }

        //move next piece
        currentPiece++;

        if (currentPiece >= pieces.Count)
        {
            uiManager.StopRed();
            cutCooldown = 0.3f; 
        }

        // Start cooldown so only one cut per swing
        canCut = false;
        Invoke(nameof(ResetCut), cutCooldown);
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

