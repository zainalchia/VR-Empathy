using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    [SerializeField] private HandGrabInteractor[] handGrabInteractors;
    [SerializeField] private float interval = 10;
    [SerializeField] private float timer = 0;

    [SerializeField] private AudioSource audioSource_player;
    [SerializeField] private AudioClip audioClip_sighAfterDrop;

    void EnableDropTimer()
    {
        bool timerOn = false;
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            if (grabInteractor.HasSelectedInteractable)
                timerOn = true;
        }

        if (timerOn)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ActivateItemDrop();
            timer = interval;
        }
    }

    private void ActivateItemDrop()
    {
        foreach (GrabInteractor grabInteractor in GameManager.instance.grabInteractors)
        {
            grabInteractor.ForceRelease();
        }
        foreach (HandGrabInteractor handGrabInteractor in handGrabInteractors)
        {
            handGrabInteractor.ForceRelease();
        }

        //audioSource_player.PlayOneShot(audioClip_sighAfterDrop);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnableDropTimer();
    }
}
