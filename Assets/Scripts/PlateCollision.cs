using System.Collections.Generic;
using UnityEngine;

public class PlateCollision : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip plateSmashSFX;

    [Header("Shards")]
    [SerializeField] private List<GameObject> shardPrefabs;

    private bool hasImpacted = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasImpacted)
            return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
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

            // Spawn shards exactly where the plate breaks
            Vector3 spawnPos = transform.position;

            foreach (GameObject shard in shardPrefabs)
            {
                Instantiate(shard, spawnPos, Quaternion.identity);
            }

            // Notify scenario manager
            ScenarioManagerReneeTest manager = FindObjectOfType<ScenarioManagerReneeTest>();
            if (manager != null)
            {
                manager.PlateImpact();
            }

            Destroy(gameObject);
        }
    }
}
