using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerGameplayScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [Header("Voiddeck - Checkers")]
    [SerializeField] GameObject FirstEnemyCheckerPiece;
    [SerializeField] GameObject SecondEnemyCheckerPiece;
    [SerializeField] GameObject EnemyPieceFirstDestination;
    [SerializeField] GameObject EnemyPieceSecondDestination;
    [SerializeField] GameObject EnemyPieceThirdDestination;
    [SerializeField] GameObject PlayerPieceFirstDestination;
    [SerializeField] GameObject PlayerPieceSecondDestination;
    [SerializeField] GameObject PlayerPiece;
    [SerializeField] GameObject PlayerPieceOutline;
    [SerializeField] GameObject CheckerPieces;

    public void PlayCheckersTransition()
    {
        StartCoroutine(CheckersTransition());
    }

    IEnumerator CheckersTransition()
    {
        yield return StartCoroutine(MovePiece(FirstEnemyCheckerPiece, EnemyPieceFirstDestination, 0));
        PlayerPieceFirstDestination.SetActive(true);
        StartCoroutine(MovePiece(PlayerPiece, PlayerPieceFirstDestination));

    }

    public void PlayFirstPieceCaptured()
    {
        StartCoroutine(FirstPieceCaptured());
    }

    IEnumerator FirstPieceCaptured()
    {
        PlayerPieceOutline.SetActive(false);
        yield return StartCoroutine(MovePiece(FirstEnemyCheckerPiece, EnemyPieceSecondDestination)); // moves enemy piece to symbolise it being captured
        PlayerPieceSecondDestination.SetActive(true);

        StartCoroutine(MovePiece(PlayerPiece, PlayerPieceSecondDestination));

    }

    public void PlaySecondPieceCaptured()
    {
        StartCoroutine(SecondPieceCaptured());
    }

    IEnumerator SecondPieceCaptured()
    {
        yield return StartCoroutine(MovePiece(SecondEnemyCheckerPiece, EnemyPieceThirdDestination));
        yield return new WaitForSeconds(1);
        gameManager.flag = true;
    }

    IEnumerator MovePiece(GameObject checkerPiece, GameObject Destination, float heightMultiplier = 0.25f)
    {
        float timeSinceStarted = 0f;
        float duration = 1f; // Total movement time

        Vector3 startPosition = checkerPiece.transform.localPosition;
        Vector3 targetPosition = Destination.transform.localPosition;

        while (timeSinceStarted < duration)
        {
            timeSinceStarted += Time.deltaTime;
            float t = timeSinceStarted / duration; // Normalized time (0 to 1)

            // Calculate position with linear interpolation
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, t);

            // Add height using a parabolic function (highest at t=0.5)
            float height = heightMultiplier * Mathf.Sin(t * Mathf.PI); // Peak height of 0.25 units
            currentPosition.y += height;

            // Apply the position
            checkerPiece.transform.localPosition = currentPosition;

            yield return null;
        }

        // Ensure final position is exactly at destination
        checkerPiece.transform.localPosition = targetPosition;
    }
}
