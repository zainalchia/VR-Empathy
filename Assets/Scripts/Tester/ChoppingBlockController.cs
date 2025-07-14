using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input; 

public class ChoppingBlockController : MonoBehaviour
{
    // Assign the food item GameObject that is already on the chopping board in the Inspector.
    public GameObject foodItemOnBoard;

    // Assign an empty GameObject (Transform) here.
    public Transform leftHandSnapPoint;

    private void OnTriggerEnter(Collider other)
    {
        // Ensure ControllerInteractionsManager instance and LeftHandAnchor are available.
        if (ControllerInteractionsManager.instance != null && ControllerInteractionsManager.instance.leftHandAnchor != null)
        {
            if (other.gameObject == ControllerInteractionsManager.instance.leftHandAnchor)
            {
                if (foodItemOnBoard != null && leftHandSnapPoint != null)
                {
                    ControllerInteractionsManager.instance.LockLeftHandToItem(foodItemOnBoard, leftHandSnapPoint);
                    Debug.Log($"LeftHandAnchor triggered chopping block. Snapped to {leftHandSnapPoint.name} and locked onto {foodItemOnBoard.name}");

                    // Optional: If you only want this to trigger once per chopping session,
                    // you might disable this collider or destroy this script.
                    // For example: GetComponent<Collider>().enabled = false;
                }
                else
                {
                    Debug.LogWarning("ChoppingBlockController: 'Food Item On Board' or 'Left Hand Snap Point' is not assigned in the Inspector!");
                }
            }
            else
            {
                // Optional: Debug if a non-LeftHandAnchor object triggered
                // Debug.Log($"Chopping block triggered by: {other.gameObject.name}, but not the LeftHandAnchor.");
            }
        }
        else
        {
            Debug.LogWarning("ControllerInteractionsManager.instance or its leftHandAnchor is null. Make sure it's in the scene and assigned.");
        }
    }

    // You might also need an OnTriggerExit if you want to allow players to back out
    // before the lock, or if the lock is temporary.
    // For this specific setup (fixed hand), OnTriggerExit wouldn't automatically unlock.
    // The UnlockLeftHand() function must be called programmatically (e.g., after the chopping minigame ends).
}