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
                }
                else
                {
                    Debug.LogWarning("ChoppingBlockController: 'Food Item On Board' or 'Left Hand Snap Point' is not assigned in the Inspector!");
                }
            }
        }
    }
}