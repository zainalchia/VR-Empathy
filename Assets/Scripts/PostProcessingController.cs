using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingController : MonoBehaviour
{
    #region Singleton Stuff
    public static PostProcessingController instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }
    #endregion

    #region Blurry Effect
    [SerializeField] private float interval = 2;

    [SerializeField, Tooltip("Max weight of Post-Processing Volume")] public float targetWeight = 1f;
    [SerializeField, Tooltip("Min weight of Post-Processing Volume")] public float initalWeight = 0.75f;
    float interpolateRatio = 0;
    [SerializeField] bool isUsingGlasses = false;
    private DepthOfField DepthOfField;

    private void VisionBlurEffect()
    {
        print("visionblureffect");
        //interpolateRatio += Time.deltaTime / interval;
        DepthOfField.aperture.value = targetWeight;
        //if (interpolateRatio >= 1) 
        //{
        //    interpolateRatio = 0;
        //    (initalWeight, targetWeight) = (targetWeight, initalWeight);
        //}
    }

    public void UsingGlasses(bool trueOrFalse) // call when glasses has been put on or taken off
    {
        if (trueOrFalse == true) 
        {
            DepthOfField.aperture.value = initalWeight;
        }

        isUsingGlasses = trueOrFalse;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Volume>().profile.TryGet(out DepthOfField);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUsingGlasses)
        {
            VisionBlurEffect();
        }
    }

}
