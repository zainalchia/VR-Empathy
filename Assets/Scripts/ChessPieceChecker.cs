using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ChessPieceChecker : MonoBehaviour
{
    [SerializeField]
    GameObject FirstOthelloPiece,SecondOthelloPiece;

    [SerializeField]
    UnityEvent TriggerNPCMove;
    [SerializeField]
    UnityEvent EndOfChess;

    private List<GameObject> piecesToFlip = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() != null)
        {
            if (!other.gameObject.GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>().HasSelectedInteractable)
            {
                SetPieceInPlace(other.gameObject);
            }
        }
    }

    private void SetPieceInPlace(GameObject piece)
    {
        if(piece == FirstOthelloPiece)
        {
            FirstOthelloPiece.GetComponent<Rigidbody>().isKinematic = true;
            FirstOthelloPiece.GetComponent<Outline>().enabled = false;
            FirstOthelloPiece.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            FirstOthelloPiece.transform.localPosition = transform.localPosition;
            StartCoroutine(FindPiecesToFlip(piece,TriggerNPCMove));
        }
        else if(piece == SecondOthelloPiece)
        {
            SecondOthelloPiece.GetComponent<Rigidbody>().isKinematic = true;
            SecondOthelloPiece.GetComponent<Outline>().enabled = false;
            SecondOthelloPiece.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            SecondOthelloPiece.transform.localPosition = transform.localPosition;
            StartCoroutine(FindPiecesToFlip(piece,EndOfChess));
        }

        piece.GetComponent<Grabbable>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<Collider>().enabled = false;
    }

    private IEnumerator FindPiecesToFlip(GameObject pieceToCheck,UnityEvent unityEvent)
    {
        piecesToFlip = GameManager.instance.FindPiecesToFlip(pieceToCheck);

        yield return StartCoroutine(GameManager.instance.AnimateFlippingPieces(piecesToFlip));

        unityEvent.Invoke();
    }
}
