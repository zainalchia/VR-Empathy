using System.Collections.Generic;
using UnityEngine;

public class PlateCollision : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip plateSmashSFX;

    [Header("Shards (disabled in scene)")]
    [SerializeField] private List<GameObject> shardObjects;

    private bool hasImpacted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasImpacted)
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            hasImpacted = true;

            // Play sound at 50% volume
            if (plateSmashSFX != null)
            {
                AudioSource.PlayClipAtPoint(
                    plateSmashSFX,
                    transform.position,
                    0.5f
                );
            }

            // Enable pre-placed shards (no repositioning)
            foreach (GameObject shard in shardObjects)
            {
                if (shard == null) continue;

                shard.SetActive(true);

                Rigidbody rb = shard.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    rb.WakeUp();
                }
            }

            // Notify scenario manager
            ScenarioManagerReneeTest manager = FindObjectOfType<ScenarioManagerReneeTest>();
            if (manager != null)
            {
                manager.PlateImpact();
            }

            // Remove plate
            Destroy(gameObject);
        }
    }
}
