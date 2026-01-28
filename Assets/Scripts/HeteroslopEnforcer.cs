using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HetroslopEnforcer : MonoBehaviour
{
    [SerializeField]
    UnityEvent eventIfFemale;

    [SerializeField]
    UnityEvent eventIfMale;

    // Start is called before the first frame update
    void Start()
    {
        if (MainMenuManager.isGenderMale)
            eventIfMale.Invoke();
        else
            eventIfFemale.Invoke();
    }

}