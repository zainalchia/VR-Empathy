using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction;
using UnityEngine.Events;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton Stuff
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

    }
    #endregion

    public ScenarioID scenarioID = ScenarioID.PresentGood;
    public SceneID sceneID = SceneID.Bathroom;

    public TextMeshPro testText;
    public GameObject postProcessing;

    // OVR PLAYER
    [Header("OVR PLAYER")]
    public GameObject ovrCamRig;
    public GameObject centerEyeAnchor;
    public GrabInteractor[] grabInteractors; // if can left controller should be index 0, right controller should be index 1
    [SerializeField]
    GameObject MaleModel, FemaleModel;
    public GameObject leftHand;
    public GameObject rightHand;
    [HideInInspector]
    public GameObject characterModel;

    // ALERT TEXT
    [Header("ALERT TEXT")]
    public GameObject alertText;

    // UI FADE IN-OUT
    [Header("FADE IN-OUT PANEL")]
    public GameObject fadePanel;
    public GameObject whiteFadePanel;

    [Header("Goodbye Text Panel")]
    public GameObject goodbyeText;
    public GameObject goodbyeText2;
    private bool canRestartGame = false;

    // PUTTING ON & TAKING OFF GLASSES
    [Header("GLASSES")]
    public GameObject glasses;
    public bool toPutGlassesOn = false;
    public bool toTakeGlassesOff = false;
    public UnityEvent OnGlassesTakeOff;

    // PUTTING ON & TAKING OFF DENTURES
    [Header("DENTURES")]
    public GameObject dentures;
    public bool toTakeDenturesOff = false;
    public UnityEvent OnDenturesTakeOff;

    [Header("MEDICINE")]
    public GameObject medicine;
    public GameObject pill;
    public bool toConsumeMedicine = false;
    public UnityEvent OnMedicineConsumed;
    public UnityEvent OnMedicineGrabbed;

    [Header("Hand Targets for Pill")]
    public Transform leftPalm;
    public Transform rightPalm;

    [Header("PHOTO FRAME")]
    public GameObject photoFrame;
    public bool toViewPhotoFrame = false;
    public UnityEvent OnPhotoFrameViewed;

    [Header("Any Look at Objectives")]
    public bool toLookAtObjective = false;

    [Header("MOBILE PHONE")]
    public bool toPickUpPhone = false;
    public bool canAnswerPhone = false;

    [Header("TAICHI")]
    public TaiChiInstructor[] taiChiAnimations;
    public bool toDoTaiChi = false;

    // FURNITURE SPASMING (Bedroom Scene of Present-Bad)
    [Header("FURNITURE SPASMING")]
    public bool toStartSpasming = false;

    // Plaster container
    [Header("Plaster")]
    public bool toUsePlaster = false;
    public GameObject plasterContainer;
    public GameObject plaster;

    [Header("Hand")]
    public Renderer leftHandRenderer;       
    public GameObject bloodEffect;        
    public Material plasteredHandMaterial;
    public bool handHealed = false;

    public void DebugLog(string text)
    {
        if (DebugTextTest.Instance != null)
            DebugTextTest.Instance.AddToConsole("[GM] " + text);
        else
            Debug.LogWarning("DebugTextTest not found. Falling back to Debug.Log.");
    }

    #region Alert Text Functions
    public void ShowAlert(string textToShow)
    {
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow);
    }
    public void ShowAlert(string textToShow, float length)
    {
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow, length);
    }
    public void ShowAlert(string textToShow, Color color)
    {
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow, color);
    }
    public void ShowAlert(string textToShow, float length, Color color)
    {
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow, length, color);
    }

    public void ShowAlertWithDelay(string textToShow, float length, float delay)
    {
        StartCoroutine(ShowAlertWithDelay_Coroutine(textToShow, length, delay));
    }
    public IEnumerator ShowAlertWithDelay_Coroutine(string textToShow, float length, float delay)
    {
        yield return new WaitForSeconds(delay);
        alertText.SetActive(true);
        AlertTextController.instance.ShowAlert(textToShow, length);
    }
    public void HideAlert()
    {
        if (AlertTextController.instance)
        {
            if (AlertTextController.instance.gameObject.activeInHierarchy)
                AlertTextController.instance.SetInactive();
        }
    }
    #endregion

    #region Player's Position
    public bool IsPlayerWithinPosition(float minXInclusive, float minZInclusive, float maxXInclusive, float maxZInclusive)
    {
        if ((centerEyeAnchor.transform.position.x >= minXInclusive && centerEyeAnchor.transform.position.x <= maxZInclusive) 
            && (centerEyeAnchor.transform.position.z >= minZInclusive && centerEyeAnchor.transform.position.z <= maxZInclusive))
            return true;
        else
            return false;
    }
    #endregion

    #region Othello Stuff

    private Vector3[] directions = new Vector3[] // directions to raycast from for each piece
    {
         Vector3.forward,              // North
         new Vector3(1, 0, 1),         // Northeast
         Vector3.right,                // East
         new Vector3(1, 0, -1),        // Southeast
         Vector3.back,                 // South
         new Vector3(-1, 0, -1),       // Southwest
         Vector3.left,                 // West
         new Vector3(-1, 0, 1)         // Northwest
    };

    public List<GameObject> FindPiecesToFlip(GameObject pieceToCheck)
    {
        List<GameObject> piecesToFlip = new List<GameObject>();

        List<GameObject> possiblePiecesToFlip = new List<GameObject>();

        // Start with one cell distance
        float currentDistance = 0.1f; // 0.05f is the length and height of one square on the othello board

        for(int i = 0; i < directions.Length; i++)
        { 
            // how this method works is that i am going to change the position of the raycast to check each square individually
            GameObject currentPieceToCheck = pieceToCheck;

            possiblePiecesToFlip.Clear();

            while (true)
            {
                RaycastHit hit;

                if (Physics.Raycast(currentPieceToCheck.transform.position, directions[i],out hit,currentDistance))
                {
                    if(Mathf.Abs(hit.transform.rotation.eulerAngles.z - pieceToCheck.transform.rotation.eulerAngles.z) > 10) // means the piece colors are different
                    {
                        possiblePiecesToFlip.Add(hit.transform.gameObject);
                        currentPieceToCheck = hit.transform.gameObject; // raycast from next piece
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    possiblePiecesToFlip.Clear();

                    break;
                }
            }

            if (possiblePiecesToFlip != null)
            {
                if (possiblePiecesToFlip.Count > 0)
                {
                    foreach (var piece in possiblePiecesToFlip)
                    {
                        piecesToFlip.Add(piece);
                    }
                }
            }
        }

        return piecesToFlip;
    }

    public IEnumerator AnimateFlippingPieces(List<GameObject> piecesToFlip)
    {
        float durationPerPiece = 0.5f; // Time for each individual piece to flip

        // Flip each piece one at a time
        if (piecesToFlip != null)
        {
            if (piecesToFlip.Count > 0)
            {
                foreach (GameObject piece in piecesToFlip)
                {
                    // Store initial and target rotations
                    Quaternion startRotation = piece.transform.rotation;

                    Vector3 currentEuler = piece.transform.rotation.eulerAngles;

                    float targetZ = 0;

                    switch (currentEuler.z)
                    {
                        case >= 90:
                            targetZ = 0f;
                            break;

                        case < 90:
                            targetZ = 180f;
                            break;
                    }

                    Quaternion targetRotation = Quaternion.Euler(currentEuler.x, currentEuler.y, targetZ);

                    // Animate this single piece
                    float timer = 0f;
                    while (timer < durationPerPiece)
                    {
                        float t = timer / durationPerPiece; // Normalized time (0 to 1)

                        // Update rotation for this piece
                        piece.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

                        timer += Time.deltaTime;
                        yield return null; // Wait for next frame
                    }

                    // Ensure the piece ends at exactly its target rotation
                    piece.transform.rotation = targetRotation;

                    // Optional small pause between pieces
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }

        // Small delay after all animations complete
        yield return new WaitForSeconds(0.2f);
    }

    #endregion

    #region Restart Game stuff (at end game)
    public void SetCanRestart()
    {
        canRestartGame = true;
    }
    public bool CheckIfCanRestart()
    {
        return canRestartGame;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        canRestartGame = false;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (MaleModel != null && FemaleModel != null)
        {
            if (MainMenuManager.isGenderMale)
            {
                characterModel = MaleModel;
                FemaleModel.SetActive(false);
            }
            else
            {
                characterModel = FemaleModel;
                MaleModel.SetActive(false);
            }
        }
        StartCoroutine(StartRotateTowards());
    }


    private IEnumerator StartRotateTowards()
    {
        while (ovrCamRig == null || centerEyeAnchor == null)
            yield return null;

        Vector3 flat;
        do
        {
            yield return null; 
            flat = Vector3.ProjectOnPlane(centerEyeAnchor.transform.forward, Vector3.up).normalized;
        }
        while (flat.sqrMagnitude < 0.0001f);

        float angle;
        if(SceneManager.GetActiveScene().name == "PastNegativeHome" || SceneManager.GetActiveScene().name == "PastPositiveHome")
        {
            angle = Vector3.SignedAngle(flat, Vector3.back, Vector3.up);
        }
        else if (SceneManager.GetActiveScene().name == "PresentGoodLivingRoom" || SceneManager.GetActiveScene().name == "PresentBadLivingRoom")
        {
            angle = Vector3.SignedAngle(flat, Vector3.left, Vector3.up);
        }
        else
        {
            angle = Vector3.SignedAngle(flat, Vector3.forward, Vector3.up);
        }
        ovrCamRig.transform.Rotate(Vector3.up, angle);
    }

    public void LoadNextScenario()
    {
        if (MainMenuManager.presentLevelSelected != null)
        {
            SceneManager.LoadScene(MainMenuManager.presentLevelSelected);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
