using UnityEngine;

public class LeftHandHoldPositive : MonoBehaviour
{
    public SaneChickenChopper chopper;

    private bool inContact = false;
    private bool isHolding = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            inContact = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            inContact = false;
            isHolding = false;

            if (chopper != null)
                chopper.SetLeftHandHolding(false);
        }
    }

    private void Update()
    {
        bool triggerPressed =
            OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.2f;

        if (inContact && triggerPressed)
        {
            if (!isHolding)
            {
                isHolding = true;

                if (chopper != null)
                    chopper.SetLeftHandHolding(true);
            }
        }
        else
        {
            if (isHolding)
            {
                isHolding = false;

                if (chopper != null)
                    chopper.SetLeftHandHolding(false);
            }
        }
    }
}
