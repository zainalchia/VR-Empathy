using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    [Header("References")]
    //[SerializeField] private ScenarioPromptManager promptManager;
    [SerializeField] private SceneID sceneID = SceneID.Stall;

    [Header("SFX")]
    [SerializeField] private AudioClip cashSFX;

    [Header("Other")]
    [SerializeField] private Collider registerSlotCollider; //collider to the place the cash
    [SerializeField] private Outline registerOutline;
    private bool hasBeenPlaced = false; //cash into slot
    private bool hasBeenGrabbed = false;
    private void OnTriggerEnter(Collider other)
    {
        //when cash collides the register slot
        if (!hasBeenPlaced && other == registerSlotCollider)
        {
            PlaceCash();
        }
    }
    public void OnGrabbed()
    {
        if (!hasBeenGrabbed)
        {
            hasBeenGrabbed = true;

            var teleport = FindObjectOfType<PlayerTeleport>();
            teleport.teleportLocked = true; // prevent teleport while grabbing

            if (registerOutline != null)
                registerOutline.enabled = true;

            // small cooldown (so grab doesn’t trigger teleport)
            teleport.StartCoroutine(UnlockTeleport(teleport, 1f));
        }
    }

    private IEnumerator UnlockTeleport(PlayerTeleport tp, float delay)
    {
        yield return new WaitForSeconds(delay);
        tp.teleportLocked = false;
    }

    private void PlaceCash()
    {
        hasBeenPlaced = true;

        if (cashSFX != null)
        {
            AudioSource.PlayClipAtPoint(
                cashSFX,
                transform.position,
                0.3f
            );
        }

        //turn off outline
        if (registerOutline != null)
            registerOutline.enabled = false;

        //hide alert
        if (AlertTextController.instance != null)
            AlertTextController.instance.SetInactive();

        //hide cash
        StartCoroutine(DisappearAfterDelay(0.2f));
    }

    private IEnumerator DisappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Hide the cash
        gameObject.SetActive(false);

        // Trigger the next prompt
        //promptManager.ShowPrompt(SceneID.Stall, 1, false, 6f);
    }
}
