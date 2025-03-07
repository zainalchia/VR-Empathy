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
            FirstOthelloPiece.GetComponent<BoxCollider>().enabled = false;
            FirstOthelloPiece.GetComponent<Outline>().enabled = false;
            FirstOthelloPiece.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            FirstOthelloPiece.transform.localPosition = transform.localPosition;
            TriggerNPCMove.Invoke();
        }
        else if(piece == SecondOthelloPiece)
        {
            SecondOthelloPiece.GetComponent<Rigidbody>().isKinematic = true;
            SecondOthelloPiece.GetComponent<BoxCollider>().enabled = false;
            SecondOthelloPiece.GetComponent<Outline>().enabled = false;
            SecondOthelloPiece.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            SecondOthelloPiece.transform.localPosition = transform.localPosition;
            EndOfChess.Invoke();
        }

        piece.GetComponent<Grabbable>().enabled = false;
        GetComponent<Outline>().enabled = false; // disable its own outline
    }

}
