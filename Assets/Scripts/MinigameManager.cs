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

    #region TaiChi Minigame (Scene ???)
    [Header("TaiChi Minigame")]
    [SerializeField] GameObject taichiInstructor;
    [SerializeField] int numOfPoses;
    public UnityEvent OnPosesFinish;

    int currentPose = 0;

    public void TaiChiMinigameEnabled(bool trueOrFalse)
    {
        GameManager.instance.toDoTaiChi = trueOrFalse;
    }

    public void NextPose()
    {
        if (GameManager.instance.toDoTaiChi)
        {
            if (currentPose < numOfPoses)
            {
                taichiInstructor.GetComponent<Animator>().SetInteger("Pose", currentPose);
                currentPose += 1;
            }
            else
            {
                GameManager.instance.toDoTaiChi = false;
                OnPosesFinish.Invoke();
            }
        }
    }
    #endregion

    #region Medication Minigame (Scene 3)
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
        
    }
}
