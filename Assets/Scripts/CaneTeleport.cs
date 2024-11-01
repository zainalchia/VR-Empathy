using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using Oculus.Interaction;

public class CaneTeleport : MonoBehaviour
{
    /* NOTE:
     *      If teleport not working, or if teleport location is off...
     *      Disable ControllerTurnerInteractor for both controllers
     *      and remove it from the LocomotionControllerInteractorGroup scripts in the OVR GameObject
     */


    [SerializeField] float maxDistanceMoveable = 0.6f;
    [SerializeField] LayerMask teleportLayer;
    [SerializeField] float defaultTimeBeforeNextMove = 2;
    [SerializeField] GameObject[] teleportHotspots;

    bool buttonPressed = false;

    GameObject lastHitGameObject;
    bool canMove = false;
    float posX = 0;
    float posZ = 0;
    float timer = 0;

    int currentHotspotIndex = -1;

    void CheckIfCanMove()
    {
        // Raycast to floor to check there are any hotspot
        Ray ray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistanceMoveable, teleportLayer, QueryTriggerInteraction.Ignore))
        {
            canMove = true;
            lastHitGameObject = hit.collider.gameObject;
            posX = lastHitGameObject.transform.position.x;
            posZ = lastHitGameObject.transform.position.z;

            // enable hotspot indicator when pointing cane at hotspot
            //lastHitGameObject.GetComponent<MeshRenderer>().enabled = true;
            lastHitGameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("hover", true);
        }
        else
        {
            canMove = false;
            if (lastHitGameObject != null) // disable hotspot indicator when not pointing at hotspot
            {
                //lastHitGameObject.GetComponent<MeshRenderer>().enabled = false;
                lastHitGameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("hover", false);
            }
        }
    }

    void MoveToLocation()
    {
        if (canMove && timer >= defaultTimeBeforeNextMove)
        {
            // Move OVRCameraRig gameobject with offset
            float offsetX = GameManager.instance.middleEyeAnchor.transform.localPosition.x;
            float offsetZ = GameManager.instance.middleEyeAnchor.transform.localPosition.z;
            GameManager.instance.ovrCamRig.transform.position = new Vector3(posX - offsetX, GameManager.instance.ovrCamRig.transform.position.y, posZ - offsetZ);
            timer = 0;

            currentHotspotIndex += 1;
            ShowNextHotspot();
            //lastHitGameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void ShowNextHotspot()
    {
        if (currentHotspotIndex == 0)
        {
            teleportHotspots[currentHotspotIndex].gameObject.SetActive(false);
            teleportHotspots[currentHotspotIndex + 1].gameObject.SetActive(true);
        }
        else if (currentHotspotIndex == teleportHotspots.Length - 1)
        {
            teleportHotspots[currentHotspotIndex].gameObject.SetActive(false);
        }
        else
        {
            teleportHotspots[currentHotspotIndex].gameObject.SetActive(false);
            teleportHotspots[currentHotspotIndex + 1].gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() != null)
        {
            if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>().HasSelectedInteractable)
            {
                CheckIfCanMove();

                // move input to a manager script if possible
                if (OVRInput.GetDown(OVRInput.Button.One) && !buttonPressed)
                {
                    buttonPressed = true;
                    MoveToLocation();
                }
                else if (OVRInput.GetUp(OVRInput.Button.One))
                {
                    buttonPressed = false;
                }
            }
        }
        else
        {
            if (lastHitGameObject != null) // disable any hotspot indicator when not holding cane
            {
                //lastHitGameObject.GetComponent<MeshRenderer>().enabled = false;
                lastHitGameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("hover", false);
                lastHitGameObject = null;
            }
        }

        timer += Time.deltaTime;

        if (Vector3.Distance(this.gameObject.transform.position, GameManager.instance.middleEyeAnchor.transform.position) > 5f)
        {
            this.gameObject.transform.position = GameManager.instance.middleEyeAnchor.transform.position + GameManager.instance.middleEyeAnchor.transform.forward;
        }
    }
}
