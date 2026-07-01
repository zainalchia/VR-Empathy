using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;

public class CaneTeleport : MonoBehaviour
{
    /* NOTE:
     *      If teleport not working, or if teleport location is off...
     *      Disable ControllerTurnerInteractor for both controllers
     *      and remove it from the LocomotionControllerInteractorGroup scripts in the OVR GameObject
     */

    [SerializeField] float maxDistanceMoveable = 1f;
    [SerializeField] LayerMask teleportLayer;
    [SerializeField] float defaultTimeBeforeNextMove = 2; // adds a delay in between teleports, set to 0 for no delay
    [SerializeField] GameObject[] teleportHotspots;
    [SerializeField] AudioSource playerAudio;
    [SerializeField] AudioClip[] maleSighAudio;
    [SerializeField] AudioClip[] femaleSighAudio;
    public UnityEvent OnFirstTeleport;
    public UnityEvent OnLastTeleport;

    bool buttonPressed = false;

    GameObject lastHitGameObject;
    bool canMove = false;
    float posX = 0;
    float posZ = 0;
    float timer = 0;
    float showWaypointTimer = 0;

    int currentHotspotIndex = -1;

    private bool moved = false;
    private bool grabbedFirstTime = false;
    public UnityEvent OnFirstGrab;

    void CheckIfCanMove()
    {
        // Raycast to floor to check there are any hotspot
        Ray ray = new Ray(transform.position, -transform.forward);

        UnityEngine.Debug.DrawRay(
            ray.origin,
            ray.direction * maxDistanceMoveable,
            Color.red
        );

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistanceMoveable, teleportLayer, QueryTriggerInteraction.Collide))
        {
            canMove = true;
            lastHitGameObject = hit.collider.gameObject;
            posX = lastHitGameObject.transform.position.x;
            posZ = lastHitGameObject.transform.position.z;

            if (lastHitGameObject.activeSelf && timer >= defaultTimeBeforeNextMove && showWaypointTimer <= 0) lastHitGameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("hover", true);
        }
        else
        {
            canMove = false;
            if (lastHitGameObject != null)
                lastHitGameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("hover", false);
        }
    }

    public void MoveToLocation()
    {
        if (canMove && timer >= defaultTimeBeforeNextMove)
        {
            // Move OVRCameraRig gameobject with offset
            float offsetX = GameManager.instance.centerEyeAnchor.transform.localPosition.x;
            float offsetZ = GameManager.instance.centerEyeAnchor.transform.localPosition.z;
            GameManager.instance.ovrCamRig.transform.position = new Vector3(posX - offsetX, GameManager.instance.ovrCamRig.transform.position.y, posZ - offsetZ);
            timer = 0;
            defaultTimeBeforeNextMove = 1.5f; // in general

            currentHotspotIndex += 1;

            if (currentHotspotIndex == 0)
                OnFirstTeleport.Invoke();

            PlaySighSound();
            
            if (currentHotspotIndex == 4)
            {
                defaultTimeBeforeNextMove = 16; // delay showing of next hotspot for blurring of eyes and voicelines
            }

            teleportHotspots[currentHotspotIndex].gameObject.SetActive(false); // hide current hotspot instantly

            StartCoroutine(ShowingNextHotspot(defaultTimeBeforeNextMove - 0.5f)); // by default 1 second delay unless its hotspot 5 which is the food table (-0.5 to show hotspot first before being able to move)

            if (currentHotspotIndex == teleportHotspots.Length - 1)
                OnLastTeleport.Invoke();
        }
    }

    private void PlaySighSound()
    {
        playerAudio.volume = 0.8f;
        if (currentHotspotIndex == 1)
        {
            if (MainMenuManager.isGenderMale)
                playerAudio.PlayOneShot(maleSighAudio[0]);
            else
                playerAudio.PlayOneShot(femaleSighAudio[0]);
        }
        else if (currentHotspotIndex == 6)
        {
            if (MainMenuManager.isGenderMale)
                playerAudio.PlayOneShot(maleSighAudio[1]);
            else
                playerAudio.PlayOneShot(femaleSighAudio[1]);
        }        
    }

    void ShowNextHotspot()
    {
        if (currentHotspotIndex == 0)
        {
            teleportHotspots[currentHotspotIndex + 1].gameObject.SetActive(true);
            teleportHotspots[currentHotspotIndex + 1].gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (currentHotspotIndex == teleportHotspots.Length - 1) // when last teleport hotspot, no need to enable next one
        {
            teleportHotspots[currentHotspotIndex].gameObject.SetActive(false);
        }
        else
        {
            teleportHotspots[currentHotspotIndex + 1].gameObject.SetActive(true);
            teleportHotspots[currentHotspotIndex + 1].gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public bool HasTeleportedOnce() // check if player has teleported first time
    {
        if (currentHotspotIndex != -1)
            return true;
        else
            return false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (GetComponent<Grabbable>().enabled)
        {
            if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() != null)
            {
                if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>().HasSelectedInteractable) // only runs when player is holding cane
                {
                    // check if this is first time grabbing the cane
                    if (grabbedFirstTime == false)
                    {
                        OnFirstGrab.Invoke();
                        grabbedFirstTime = true;
                    }

                    CheckIfCanMove();

                    // move input to a manager script if possible
                    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !buttonPressed && timer >= defaultTimeBeforeNextMove)
                    {
                        buttonPressed = true;
                        MoveToLocation();
                    }
                    else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && buttonPressed)
                    {
                        buttonPressed = false;
                    }
                }
            }
            else
            {
                if (lastHitGameObject != null)
                {
                    lastHitGameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("hover", false);
                    lastHitGameObject = null;
                }
            }
        }

        if (Vector3.Distance(this.gameObject.transform.position, GameManager.instance.centerEyeAnchor.transform.position) > 5f) // cane will appear in front of user if it is too far away
        {
            this.gameObject.transform.position = GameManager.instance.centerEyeAnchor.transform.position + GameManager.instance.centerEyeAnchor.transform.forward;
        }
    }

    // returns current hotspot index
    public int GetCurrentHotspotIndex()
    {
        return currentHotspotIndex;
    }

    IEnumerator ShowingNextHotspot(float delay)
    {
        yield return new WaitForSeconds(delay);

        ShowNextHotspot();
    }

}
