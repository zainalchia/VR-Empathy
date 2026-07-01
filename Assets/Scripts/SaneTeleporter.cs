using UnityEngine;
using UnityEngine.Events;

public class SaneTeleporter : MonoBehaviour
{
	[Header("References")]
	[SerializeField] SaneTeleporter nextTeleporter = null;

	[Header("Settings")]
	[SerializeField] Vector3 smallScale;
	[SerializeField] Vector3 largeScale;

	[Header("Events")]
	public UnityEvent OnTeleportHere;

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
		OnTeleportHere.Invoke();
        gameObject.SetActive(false);
        if (nextTeleporter != null) nextTeleporter.gameObject.SetActive(true);
    }

	public void SetCanTeleportHere(bool trueOrFalse)
	{
		canTeleportHere = trueOrFalse;
	}
}
