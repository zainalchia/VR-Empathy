using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

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
    private float BlurTime = 0;
    private Coroutine currentCoroutine = null;
    public bool initialBlurDone = false;

    private IEnumerator VisionBlurEffect()
    {
        while (BlurTime < interval)
        {
            BlurTime += Time.deltaTime;
            DepthOfField.aperture.value = Mathf.Lerp(DepthOfField.aperture.value, targetWeight, BlurTime / interval);
            yield return null; // This yields control back to Unity until the next frame
        }
        DepthOfField.aperture.value = targetWeight;
        currentCoroutine = null;
    }

    public void UsingGlasses(bool trueOrFalse) // call when glasses has been put on or taken off
    {
        isUsingGlasses = trueOrFalse;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "PresentBadLivingRoom") // for blurry effect
        {
            GetComponent<Volume>().profile.TryGet(out DepthOfField);
            DepthOfField.aperture.value = 32;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "PresentBadLivingRoom") // for blurry effect
        {
            if (!isUsingGlasses)
            {
                if (!initialBlurDone)
                {
                    targetWeight = 1;
                }
                else
                {
                    interval = 3; // decreases bluriness across a span of 3 seconds
                    targetWeight = 3;
                }
            }
            else
            {
                targetWeight = 32;
            }

            if (DepthOfField.aperture.value != targetWeight && currentCoroutine == null) // ensures that only one coroutine runs at any time and that it only runs when the target weight changes
            {
                BlurTime = 0f; // reset blur time
                currentCoroutine = StartCoroutine(VisionBlurEffect()); // sets current coroutine to new coroutine started to keep track of current coroutine running
            }
        }
    }

}
