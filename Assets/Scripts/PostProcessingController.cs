using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField] private float interval = 10;
    [SerializeField] private float timer = 0;

    private void TogglePostProcessing()
    {
        gameObject.GetComponent<Volume>().enabled = !gameObject.GetComponent<Volume>().enabled;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            TogglePostProcessing();
            timer = interval;
        }
        else
            timer -= Time.deltaTime;
    }
}
