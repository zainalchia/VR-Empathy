using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    #region Singleton Stuff
    public static MinigameManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }
    #endregion


    [SerializeField] TextMeshPro debugText;

    #region Medication Minigame
    [Header("Medication Minigame")]
    [SerializeField] GameObject[] medicationsToEat;
    [SerializeField] PlayerFace playerFace; // rmb to disable in hierarchy
    public bool toEatMedication = false;
    bool medicationWasEaten = false;

    public void MedicationMinigameEnabled(bool trueOrFalse)
    {
        toEatMedication = trueOrFalse;
        playerFace.enabled = trueOrFalse;
    }

    public void EatMedication(GameObject obj)
    {
        if (toEatMedication)
        {
            foreach (GameObject medicine in medicationsToEat)
            {
                if (obj == medicine)
                {
                    obj.SetActive(false);
                    medicationWasEaten = true;
                    debugText.text = "Medication eaten";
                }
            }

            if (!medicationWasEaten)
            {
                debugText.text = "This is not the medicine to take";
            }
            medicationWasEaten = false;
        }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
