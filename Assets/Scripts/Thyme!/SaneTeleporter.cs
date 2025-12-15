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
	[SerializeField] Quaternion raycastDirectionOffset = Quaternion.identity;
	const float radiusMultiplier = 0.5f;


	private void Update()
	{
		Vector3 targetSize = smallScale;

		// do math to check if ray from controller intersects sphere
		Debug.Log(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger));

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
		Debug.Log("Thyme - Trying to move player");
		GameManager.instance.ovrCamRig.transform.position = transform.position;
        gameObject.SetActive(false);
        if (nextTeleporter != null) nextTeleporter.gameObject.SetActive(true);
    }

}
