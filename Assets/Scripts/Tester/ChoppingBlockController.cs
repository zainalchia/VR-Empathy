using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input; // Crucial for IHand and Handedness

public class ChoppingBlockController : MonoBehaviour
{
    // Assign the food item GameObject that is already on the chopping board in the Inspector.
    public GameObject foodItemOnBoard;

    // Assign an empty GameObject (Transform) here.
    // This GameObject should be a child of your chopping board,
    // positioned and rotated exactly where you want the player's left virtual hand to snap to.
    public Transform leftHandSnapPoint;

    private void OnTriggerEnter(Collider other)
    {
        // Get the GrabInteractor from the colliding object, if any.
        GrabInteractor enteringInteractor = other.GetComponent<GrabInteractor>();

        // Check if the colliding object has a GrabInteractor
        if (enteringInteractor != null)
        {
            // REVISED: Get IHand from the GrabInteractor's GameObject or its parent
            IHand hand = enteringInteractor.gameObject.GetComponentInParent<IHand>();

            if (hand != null)
            {
                // Check if it's specifically the left hand interactor
                if (hand.Handedness == Handedness.Left)
                {
                    if (foodItemOnBoard != null && leftHandSnapPoint != null)
                    {
                        // Check if the ControllerInteractionsManager instance is available
                        if (ControllerInteractionsManager.instance != null)
                        {
                            ControllerInteractionsManager.instance.LockLeftHandToItem(foodItemOnBoard, leftHandSnapPoint);
                            Debug.Log($"Left hand triggered chopping block. Snapped to {leftHandSnapPoint.name} and locked onto {foodItemOnBoard.name}");
                        }
                        else
                        {
                            Debug.LogWarning("ControllerInteractionsManager.instance is null. Make sure it's in the scene.");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("ChoppingBlockController: 'Food Item On Board' or 'Left Hand Snap Point' is not assigned in the Inspector!");
                    }
                }
            }
        }
    }
}