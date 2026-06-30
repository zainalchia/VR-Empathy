using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCollision : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip plateSmashSFX;

    [Header("Shards (disabled in scene)")]
    [SerializeField] private List<GameObject> shardObjects;

    private bool hasImpacted = false;
    private bool plateHitGround;

    public Transform PlateSpawnPoint;   // where plate appears
    public Transform PlateTargetPoint;  // where the plate flies toward

    [SerializeField] float plateSpeed = 10f;             // how fast it flies
    [SerializeField] Transform bossTransform;
    [SerializeField] Transform playerTransform;

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

            plateHitGround = true;

            // Remove plate
            Destroy(gameObject);
        }
    }

    public void PlateThrown()
    {
        StartCoroutine(ThrowPlate());
    }

    public IEnumerator ThrowPlate()
    {
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.SetParent(null);


        gameObject.layer = LayerMask.NameToLayer("Plate");

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = false;
        rb.useGravity = true;

        plateHitGround = false;

        Vector3 direction = (PlateTargetPoint.position - PlateSpawnPoint.position).normalized;

        while (gameObject != null && !plateHitGround)
        {
            rb.velocity = direction * plateSpeed;
            yield return null;
        }

    }

    public void BossLookAt()
    {
        bossTransform.LookAt(playerTransform);
    }
}
