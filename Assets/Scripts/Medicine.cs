using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class Medicine : MonoBehaviour
{
    public UnityEvent OnDroppedMedication;

    bool hasTriggeredEvent = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggeredEvent && other.gameObject.GetComponentInParent<GrabInteractor>() && ScenarioManagerPresentBad.canMedicineSpill)
        {
            hasTriggeredEvent = true;
            OnDroppedMedication.Invoke();
        }
    }
}
