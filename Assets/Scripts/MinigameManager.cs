using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
    bool debugStart = false;

    #region TaiChi Minigame
    [Header("TaiChi Minigame")]
    [SerializeField] GameObject taichiInstructor;
    [SerializeField] int numOfPoses;
    public float timeDelayBeforeNextPose;
    public UnityEvent OnPosesFinish;

    int currentPose = 0;

    public void NextPose() // call to start taichi in scenario manager, will invoke UnityEvent once all taichi animations have been played
    {
        if (GameManager.instance.toDoTaiChi)
        {
            if (currentPose < numOfPoses)
            {
                currentPose += 1;
                taichiInstructor.GetComponent<Animator>().SetInteger("Pose", currentPose);
            }
            else
            {
                GameManager.instance.toDoTaiChi = false;
                OnPosesFinish.Invoke();
            }
        }
    }
    #endregion

    #region Medication Minigame
    [Header("Medication Minigame")]
    [SerializeField] List<GameObject> medicationsToEat;
    public UnityEvent OnMedicationFinish;
    bool medicationWasEaten = false;

    public void EatMedication(GameObject obj)
    {
        if (GameManager.instance.toEatMedication)
        {
            if (medicationsToEat.Contains(obj))
            {
                // right now only checks if medicine obj in list (probably need to change to use name instead if want to have multiple of the same medicine)
                obj.SetActive(false);
                medicationWasEaten = true;
                medicationsToEat.Remove(obj);
                //debugText.text = "Medication eaten";
            }

            if (!medicationWasEaten)
            {
                //debugText.text = "This is not the medicine to take";
            }
            medicationWasEaten = false;

            if (medicationsToEat.Count == 0)
            {
                GameManager.instance.toEatMedication = false;
                //OnMedicationFinish.Invoke();
            }
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
        if (Input.GetKeyDown(KeyCode.P) && !debugStart) // for debugging to start taichi animations, remember to remove
        {
            debugStart = true;
            NextPose();
        }
    }
}
