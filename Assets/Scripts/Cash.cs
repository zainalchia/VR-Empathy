using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ScenarioPromptManager promptManager;
    [SerializeField] private SceneID sceneID = SceneID.Stall;

    [Header("Other")]
    [SerializeField] private Collider registerSlotCollider; //collider to the place the cash
    private bool hasBeenPlaced = false; //cash into slot

    private void OnTriggerEnter(Collider other)
    {
        //when cash collides the register slot
        if (!hasBeenPlaced && other == registerSlotCollider)
        {
            PlaceCash();
        }
    }
    private void PlaceCash()
    {
        hasBeenPlaced = true;

        //confirm cash have been placed, tells manager
        FindObjectOfType<ScenarioManagerReneeTest>().OnCashPlaced();

        //hide cash
        StartCoroutine(DisappearAfterDelay(0.2f));
    }

    private IEnumerator DisappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Hide the cash
        gameObject.SetActive(false);

        // Trigger the next prompt
        //promptManager.ShowPrompt(SceneID.Stall, 2, false, 2f);
    }
}
