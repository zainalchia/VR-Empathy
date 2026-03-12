using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaneTeleporter : MonoBehaviour
{

	[Header("Refrences")]
	[SerializeField] SaneTeleporter nextTeleporter = null;

	[Header("Settings")]
	[SerializeField] Vector3 smallScale;
	[SerializeField] Vector3 largeScale;

	// old hand stuff
#if false
	[SerializeField] Quaternion raycastDirectionOffset = Quaternion.identity;
	[SerializeField] float radiusMultiplier = 1.0f;
#endif

	[SerializeField] float viewRadius = 90.0f; // in degrees
	private bool canTeleportHere = false;


	private void Update()
	{
		Vector3 targetSize = smallScale;

		// hand stuff
#if false

		// do math to check if ray from controller intersects sphere

		// left hand
		if(
			CheckSphereIntersect(
				raycastDirectionOffset.normalized * ControllerInteractionsManager.instance.leftGrabInteractor.transform.forward,
				transform.position - ControllerInteractionsManager.instance.leftGrabInteractor.transform.position,
				radiusMultiplier * smallScale.magnitude
				)
		)
		{
			if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
			{
				MovePlayerHere();
				return;
			}

			targetSize = largeScale;
		}

		// right hand
		else if(
			CheckSphereIntersect(
				raycastDirectionOffset.normalized * ControllerInteractionsManager.instance.rightGrabInteractor.transform.forward,
				transform.position - ControllerInteractionsManager.instance.rightGrabInteractor.transform.position,
				radiusMultiplier * smallScale.magnitude
				)
		)
		{
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                MovePlayerHere();
                return;

            }
            targetSize = largeScale;
		}

		transform.localScale = Vector3.Lerp(transform.localScale, targetSize, Time.deltaTime * 5);
#endif

		/*
		float angle = Vector3.Dot(Camera.main.transform.forward, (transform.position - Camera.main.transform.position).normalized);

		// if not within view radius		
		if (angle * 57.2957795131f > viewRadius)
			targetSize = smallScale;
		else
		{
			targetSize = largeScale;
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                MovePlayerHere();
                return;
            }
        }
        transform.localScale = Vector3.Lerp(transform.localScale, targetSize, Time.deltaTime * 5); */

		if (canTeleportHere)
		{
			if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                MovePlayerHere();                
            }
		}
    }

	bool CheckSphereIntersect(Vector3 rayDirection, Vector3 spherePosition, float radius)
	{
		// find closest point to center of sphere along ray
		Vector3 closest = rayDirection.normalized * Vector3.Dot(rayDirection.normalized, spherePosition);

		// check if distance to closest is within radius (square just to make it a bit faster (mutliplying a number is far cheaper than square rooting it (the formula for finding vector magnitude includes square root)))
		float distanceSquare = (closest - spherePosition).sqrMagnitude;
		return (radius * radius) >= distanceSquare;
	}

	void MovePlayerHere()
	{
		GameManager.instance.ovrCamRig.transform.position = transform.position;
        gameObject.SetActive(false);
        if (nextTeleporter != null) nextTeleporter.gameObject.SetActive(true);
    }

	public void SetCanTeleportHere(bool trueOrFalse)
	{
		canTeleportHere = trueOrFalse;
		Debug.Log("looking at " + gameObject.name);
	}
}
