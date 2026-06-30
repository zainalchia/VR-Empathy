using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class DentureCup : MonoBehaviour
{
    public UnityEvent OnDenturePlaced;
    [SerializeField] GameObject secondDenture;

    void PositionDentureInCup(GameObject denture)
    {
        denture.GetComponent<Grabbable>().enabled = false;
        denture.GetComponent<Rigidbody>().isKinematic = true;
        denture.GetComponent<BoxCollider>().enabled = false;
        denture.SetActive(false);
        secondDenture.SetActive(true);
        OnDenturePlaced.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameManager.instance.dentures)
            PositionDentureInCup(GameManager.instance.dentures);
    }
}
