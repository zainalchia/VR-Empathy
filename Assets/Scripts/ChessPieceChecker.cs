using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ChessPieceChecker : MonoBehaviour
{
    [SerializeField]
    GameObject Pawn, Bishop;

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
        if(piece == Pawn)
        {
            Pawn.GetComponent<Rigidbody>().isKinematic = true;
            Pawn.GetComponent<BoxCollider>().enabled = false;
            Pawn.GetComponent<Outline>().enabled = false;
            Pawn.transform.localRotation = Quaternion.identity;

            Pawn.transform.localPosition = new Vector3(0.06f,0.01f,-0.57f);
            TriggerNPCMove.Invoke();
        }
        else if(piece == Bishop)
        {
            Bishop.GetComponent<Rigidbody>().isKinematic = true;
            Bishop.GetComponent<BoxCollider>().enabled = false;
            Bishop.GetComponent<Outline>().enabled = false;
            Bishop.transform.localRotation = Quaternion.identity;

            EndOfChess.Invoke();
        }

        piece.GetComponent<Grabbable>().enabled = false;
    }

}
