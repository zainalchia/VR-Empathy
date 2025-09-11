using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CheckersHighlightChecker : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerCheckerPiece;

    [SerializeField] private int HighlightNumber;

    [SerializeField]
    UnityEvent AfterFirstMove;
    [SerializeField]
    UnityEvent AfterSecondMove;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == PlayerCheckerPiece)
        {
            SetPieceInPlace(other.gameObject);
        }
    }

    private void SetPieceInPlace(GameObject piece)
    {
        if(piece == PlayerCheckerPiece)
        {
            switch (HighlightNumber)
            {
                case 1:
                    AfterFirstMove.Invoke();
                    PlayerCheckerPiece.transform.localPosition = transform.localPosition;
                    PlayerCheckerPiece.transform.localRotation = Quaternion.identity;
                    piece.GetComponent<Grabbable>().enabled = false;
                    transform.gameObject.SetActive(false);
                break;

                case 2:
                    AfterSecondMove.Invoke();
                    PlayerCheckerPiece.transform.localPosition = transform.localPosition;
                    PlayerCheckerPiece.transform.localRotation = Quaternion.identity;
                    piece.GetComponent<Grabbable>().enabled = false;
                    transform.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                break;
            }
        }
    }

}
