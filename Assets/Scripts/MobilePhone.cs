using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MobilePhone : MonoBehaviour
{
    [Header("Video Player Variables")]
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoClip phoneCalling;
    [SerializeField] VideoClip phoneCallingBlurred;
    [SerializeField] VideoClip phoneAnswered;
    [SerializeField] VideoClip phoneHangUp;

    [Header("Materials")]
    [SerializeField] Material homeScreenMat;
    [SerializeField] Material videoScreenMat;
    [SerializeField] Material phoneMat;

    public UnityEvent OnPickUpPhoneFirstTime;
    public UnityEvent OnAnswerPhone;

    List<Material> materials = new List<Material>();
    bool hasBeenPickedUpFirstTime = false;

    public void SetPhoneCalling()
    {
        GetComponent<Renderer>().SetMaterials(materials); // to switch to the video material
        if (SceneManager.GetActiveScene().name == "PresentGoodLivingRoom") 
            videoPlayer.clip = phoneCallingBlurred;
        else 
            videoPlayer.clip = phoneCalling;
        videoPlayer.Play();
        GetComponent<AudioSource>().Play(); // will play ringing sound until phone is answered
    }

    // Called in ScenarioManagerPresentGood.cs, GlassesPutOn() function
    public void UnblurPhone()
    {
        videoPlayer.clip = phoneCalling;
        videoPlayer.Play();
    }

    public void SetPhoneAnswered()
    {
        GetComponent<AudioSource>().Stop(); // stop ringing sound once phone is answered
        videoPlayer.Stop();
        videoPlayer.clip = phoneAnswered;
        videoPlayer.Play();
    }

    public void SetPhoneHangUp()
    {
        videoPlayer.Stop();
        videoPlayer.clip = phoneHangUp;
        videoPlayer.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        materials = new List<Material>
        {
            videoScreenMat,
            phoneMat
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenPickedUpFirstTime) // trigger narration to use glasses
        {
            if (GameManager.instance.toPickUpPhone)
            {
                if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(this.gameObject.transform.parent.gameObject))
                {
                    hasBeenPickedUpFirstTime = true;
                    OnPickUpPhoneFirstTime.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.canAnswerPhone)
        {
            if (ControllerInteractionsManager.instance.GetItemsGrabbedInHand().Contains(this.gameObject.transform.parent.gameObject)) // check if holding phone
            {
                if (other.gameObject.GetComponentInParent<GrabInteractor>() != null) // check if collider that touch was a hand
                {
                    if (!this.gameObject.GetComponentInParent<GrabInteractable>().HasSelectingInteractor(other.gameObject.GetComponentInParent<GrabInteractor>())) // check if collider that touch was the hand that is not holding the phone
                    {
                        GameManager.instance.canAnswerPhone = false;
                        SetPhoneAnswered();
                        OnAnswerPhone.Invoke();
                    }
                }
            }
        }
    }
}
