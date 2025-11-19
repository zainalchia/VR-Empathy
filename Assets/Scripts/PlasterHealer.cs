using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasterHealer : MonoBehaviour
{
    //references
    private Renderer leftHandRenderer;
    private ParticleSystem bloodEffect;
    private Material plasteredHandMaterial;

    private void Start()
    {
        // get reference from game manager
        leftHandRenderer = GameManager.instance.leftHandRenderer;
        bloodEffect = GameManager.instance.bloodEffect;
        plasteredHandMaterial = GameManager.instance.plasteredHandMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            //stop bleed effect
            if (bloodEffect != null && bloodEffect.isPlaying)
            {
                bloodEffect.Stop();
            }

            //change hand material to plaster
            if (leftHandRenderer != null && plasteredHandMaterial != null)
            {
                leftHandRenderer.material = plasteredHandMaterial;
            }

            // remove plaster 
            Destroy(gameObject, 0.2f);
        }
    }
}
