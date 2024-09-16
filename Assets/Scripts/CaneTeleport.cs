using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Linq;
using Oculus.Interaction;

using TMPro;
using Oculus.Interaction.Input;

public class CaneTeleport : MonoBehaviour
{
    /* NOTE:
     *      If teleport not working, or if teleport location is off...
     *      Disable ControllerTurnerInteractor for both controllers
     *      and remove it from the LocomotionControllerInteractorGroup scripts in the OVR GameObject
     */

    [SerializeField] GameObject ovrCamRig;
    [SerializeField] GameObject middleEyeAnchor;
    [SerializeField] float maxDistanceMoveable = 0.6f;
    [SerializeField] LayerMask floorLayer;
    [SerializeField] float defaultTimeBeforeNextMove = 2;
    //[SerializeField] GameObject indicator;
    [SerializeField] TMP_Text debug_text;

    bool buttonPressed = false;

    GameObject lastHitGameObject;
    bool canMove = false;
    float posX = 0;
    float posZ = 0;
    float timer = 0;

    bool isVibrating = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, -transform.forward / 2, Color.yellow);

        if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>() != null)
        {
            if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>().HasSelectedInteractable)
            {
                // move this to a general vibration script if possible
                if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>().gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Left)
                    ControllerVibrationManager.instance.TriggerVibration(40, 2, 255, OVRInput.Controller.LTouch);
                else if (GetComponent<GrabInteractable>().Interactors.FirstOrDefault<GrabInteractor>().gameObject.GetComponent<ControllerRef>().Handedness == Handedness.Right)
                    ControllerVibrationManager.instance.TriggerVibration(40, 2, 255, OVRInput.Controller.RTouch);

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
            //indicator.SetActive(false);
            if (lastHitGameObject != null) // disable any hotspot indicator when not holding cane
            {
                lastHitGameObject.GetComponent<MeshRenderer>().enabled = false;
                lastHitGameObject = null;
            }
        }


        timer += Time.deltaTime;

        debug_text.text = ovrCamRig.transform.localPosition.ToString() + '\n' + middleEyeAnchor.transform.localPosition.ToString();
    }

    void CheckIfCanMove()
    {
        // Raycast to floor to check there are any hotspot
        Ray ray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistanceMoveable, floorLayer, QueryTriggerInteraction.Ignore))
        {
            canMove = true;
            lastHitGameObject = hit.collider.gameObject;
            posX = lastHitGameObject.transform.position.x;
            posZ = lastHitGameObject.transform.position.z;

            // enable hotspot indicator when pointing cane at hotspot
            lastHitGameObject.GetComponent<MeshRenderer>().enabled = true;
            //indicator.SetActive(true);
            //indicator.transform.position = new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z);
            //indicator.transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else
        {
            canMove = false;
            //indicator.SetActive(false);
            if (lastHitGameObject != null) // disable hotspot indicator when not pointing at hotspot
            {
                lastHitGameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        
    }

    void MoveToLocation()
    {
        if (canMove && timer >= defaultTimeBeforeNextMove)
        {
            // Move OVRCameraRig gameobject with offset
            float offsetX = middleEyeAnchor.transform.localPosition.x;
            float offsetZ = middleEyeAnchor.transform.localPosition.z;
            ovrCamRig.transform.position = new Vector3(posX - offsetX, ovrCamRig.transform.position.y, posZ - offsetZ);
            timer = 0;
        }
    }
}
