using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Linq;
using Oculus.Interaction;

using TMPro;

public class CaneTeleport : MonoBehaviour
{
    [SerializeField] GameObject player; // can reference from manager script if possible
    [SerializeField] float maxDistanceMoveable = 0.6f;
    [SerializeField] LayerMask floorLayer;
    [SerializeField] float defaultTimeBeforeNextMove = 2;
    [SerializeField] GameObject indicator;
    [SerializeField] TMP_Text debug_text;

    bool buttonPressed = false;

    bool canMove = false;
    float posX = 0;
    float posZ = 0;
    float timer = 0;

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
        else
        {
            indicator.SetActive(false);
        }

        timer += Time.deltaTime;

        debug_text.text = indicator.activeInHierarchy.ToString();
    }

    void CheckIfCanMove()
    {
        // Raycast to floor to check if it is a moveable location
        Ray ray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistanceMoveable, floorLayer, QueryTriggerInteraction.Ignore))
        {
            canMove = true;
            posX = hit.point.x;
            posZ = hit.point.z;
            indicator.SetActive(true);
            indicator.transform.position = new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z);
            indicator.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            canMove = false;
            indicator.SetActive(false);
        }
        
    }

    void MoveToLocation()
    {
        if (canMove && timer >= defaultTimeBeforeNextMove)
        {
            player.transform.position = new Vector3(posX, player.transform.position.y, posZ);
            timer = 0;
        }
    }
}
