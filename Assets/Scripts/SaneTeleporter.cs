using UnityEngine;

public class SaneTeleporter : MonoBehaviour
{
	[Header("Refrences")]
	[SerializeField] SaneTeleporter nextTeleporter = null;

	[Header("Settings")]
	[SerializeField] Vector3 smallScale;
	[SerializeField] Vector3 largeScale;

	private bool canTeleportHere = false;

	private void Update()
	{
		if (canTeleportHere)
		{
			if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                MovePlayerHere();
            }
		}
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
	}
}
