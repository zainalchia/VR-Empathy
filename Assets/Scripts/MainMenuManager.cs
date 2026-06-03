using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenuManager : MonoBehaviour
{
    public static bool isGenderMale; //true = male, false = female
    public static bool videoOrMenu = false; // false = menu, true = video
    public static VideoToPlay video = VideoToPlay.BeforePresentBad;

    [Header("Menus")]
    [SerializeField]
    GameObject scenarioScreen;
    [SerializeField]
    GameObject genderScreen;
    [SerializeField]
    GameObject videoScreen; 
    [SerializeField]
    GameObject proceedButton;
    [SerializeField] 
    GameObject secretMenu;
    [SerializeField]
    GameObject playerMenu;

    [Header("SecretMenuCheckboxes")]
    [SerializeField]
    CheckboxScript CheckboxA;
    [SerializeField]
    CheckboxScript CheckboxB;
    [SerializeField]
    CheckboxScript CheckboxC;
    [SerializeField]
    CheckboxScript CheckboxD;


    [Header("Scenario Panel")]
    [SerializeField]
    GameObject scenarioAPanel;
    [SerializeField]
    GameObject scenarioBPanel,scenarioCPanel,scenarioDPanel;

    [Header("Scenario Checkboxes")]
    [SerializeField]
    GameObject scenarioCheckboxA;
    [SerializeField]
    GameObject scenarioCheckboxB,scenarioCheckboxC,scenarioCheckboxD;

    [Header("Scenario Buttons")]
    [SerializeField]
    Button scenarioButtonA;
    [SerializeField]
    Button scenarioButtonB, scenarioButtonC, scenarioButtonD;

    [Header("Others")]
    [SerializeField]
    VideoClip[] videos;

    [SerializeField]
    Material mainMenuSkybox;




    //dictonaries to keep tabs on the settings selected
    //dictionary for scenarios enabled
    private Dictionary<string, bool> scenariosAvailable = new Dictionary<string, bool>();
    //dictionary for enabled settings
    private Dictionary<string, bool> settingsToggled = new Dictionary<string, bool>();
    //dictonary for selected scenarios
    private Dictionary<string, bool> scenariosSelected = new Dictionary<string, bool>();

    public static bool enableSurvey = true;
    public static string pastLevelSelected = null;
    public static string presentLevelSelected = null;
    public static List<string> levelsPlayed = new List<string>();
    public static int ageInput;

    [SerializeField] Sprite[] snippets;
    [SerializeField] Image[] snippetsBg;
    [SerializeField] NumberPadScript numberPadScript;
    int minRange, maxRange;

    private bool genderHasBeenSelected = false;
    private int intNum;
    private string csvInputString;

    [SerializeField] private TextMeshProUGUI errorText;
    private bool errorMsgIsShowing = false;

    private int pressedBtnA = 0;
    private bool enableSceneRandomizer;

    public enum VideoToPlay
    {
        BeforePresentBad,
        AfterPresentBad
    }

    private void Start()
    {
        RenderSettings.skybox = mainMenuSkybox;
        Debug.Log("Character gender: " + isGenderMale);
        //ShowSnippetOnHover(0);

        //give setting dictionaries their values
        //read from player prefs and initialise
        
        //else initialise with default
        scenariosAvailable.Add("ScenarioA",true);
        scenariosAvailable.Add("ScenarioB",true);
        scenariosAvailable.Add("ScenarioC",true);
        scenariosAvailable.Add("ScenarioD",true);

        settingsToggled.Add("EnableSurvey", true);
        settingsToggled.Add("RandomizeScenario", false);
        settingsToggled.Add("1Past1Present", true);

        scenariosSelected.Add("ScenarioA",false);
        scenariosSelected.Add("ScenarioB",false);
        scenariosSelected.Add("ScenarioC",false);
        scenariosSelected.Add("ScenarioD",false);
    }

    private void Awake()
    {
        if (videoOrMenu) // check if menu or video
        {
            scenarioScreen.SetActive(false);
            videoScreen.SetActive(true);
            PlayVideo();
        }
    }

    public void LoadLevel()
    {
        if(pastLevelSelected != null)
        {
            SceneManager.LoadScene(pastLevelSelected);
        }
        else
        {
            SceneManager.LoadScene(presentLevelSelected);
        }
    }

    public void SelectGender(bool isMale)
    {
        isGenderMale = isMale;
        genderHasBeenSelected = true;
        //genderScreen.SetActive(false);
        //videoScreen.SetActive(true);
        //toVideoScreen();
    }

    public void SelectPastLevel(string levelname)
    {
        if(pastLevelSelected == null)
            pastLevelSelected = levelname;
        else
            pastLevelSelected = null;
    }
    public void SelectPresentLevel(string levelname)
    {
        if (presentLevelSelected == null)
            presentLevelSelected = levelname;
        else
            presentLevelSelected = null;
    }

    public void ToggleOtherScenarioButton(Button imageButton)
    {
        if (settingsToggled["1Past1Present"])
        {
            imageButton.enabled = !imageButton.enabled;
        }
    }

    public void ToggleOtherScenarioCheckbox(Button checkboxButton)
    {
        if (settingsToggled["1Past1Present"])
        {
            checkboxButton.enabled = !checkboxButton.enabled;
        }
    }

    public void SetColorRed(RawImage image)
    {
        image.color = new Color(255, 0, 0);
    }
    public void SetColorGreen(RawImage image)
    {
        image.color = new Color(0, 255, 0);
    }

    public void toScenarioScreen()
    {
        //if (numberPadScript.StringToInt() > biggestNum || numberPadScript.StringToInt() < smallestNum || numberPadScript.StringToInt() == -1)
        //{

        //    if (errorMsgIsShowing)
        //    {
        //        StopAllCoroutines();
        //    }

        //    StartCoroutine(ErrorTextShown("Age is invalid!"));
        //    return;
        //}

        //if (genderHasBeenSelected == false)
        //{

        //    if (errorMsgIsShowing)
        //    {
        //        StopAllCoroutines();
        //    }

        //    StartCoroutine(ErrorTextShown("Gender has not been selected!"));
        //    return;
        //}

        if (!enableSceneRandomizer)
        {
            scenarioScreen.SetActive(true);
            genderScreen.SetActive(false);
        }
        else
        {
            RandomizeScenario();
        }

        //ageInput = numberPadScript.StringToInt();
    }

    public void RandomizeScenario()
    {
        int randomPastScenario = UnityEngine.Random.Range(0, 2);
        int randomPresentScenario = UnityEngine.Random.Range(0, 2);

        if (randomPastScenario == 0)
            pastLevelSelected = "PastNegativeBathroom";
        else
            pastLevelSelected = "PastPositiveBathroom";

        if (randomPresentScenario == 0)
            presentLevelSelected = "PresentBadBathroom";
        else
            presentLevelSelected = "PresentGoodBathroom";

        LoadLevel();
    }

    public void toVideoScreen()
    {
        StartCoroutine(VideoPlaying());
    }

    IEnumerator VideoPlaying()
    {
        PlayVideo();
        //yield return new WaitForSeconds((float)videoScreen.GetComponent<VideoPlayer>().clip.length);
        yield return new WaitForSeconds(2); // to short cut, change it back to the line above after this

        if (!videoOrMenu) {
            proceedButton.SetActive(true);
        }
    }

    IEnumerator ErrorTextShown(string errorMsg)
    {
        errorMsgIsShowing = true;
        errorText.text = errorMsg;

        yield return new WaitForSeconds(3);

        errorText.text = "";
        errorMsgIsShowing = false;
    }

    private void PlayVideo()
    {
        switch (video)
        {
            case VideoToPlay.BeforePresentBad:
                videoScreen.GetComponent<VideoPlayer>().clip = videos[0];
                break;
            case VideoToPlay.AfterPresentBad:
                videoScreen.GetComponent<VideoPlayer>().clip = videos[1];
                break;
        }

        videoScreen.GetComponent<VideoPlayer>().SetTargetAudioSource(0, videoScreen.GetComponent<AudioSource>());
    }

    /// <summary>
    /// Preview gameplay by playing an array of image when hover over image. 
    /// Set min and max range to play the right set of image
    /// </summary>
    /// <param name="num"></which gameplay mode. 0 = Present Negative, 1 = Present Positive, 2 = Past Negative, 3 = Past Positive>
    public void ShowSnippetOnHover(int num)
    {
        switch (num)
        { 
            case 0:
                minRange = 0;
                maxRange = 3;
                Task task = ImageLoop(num, minRange, maxRange);
                break;
        }
    }

    private async Task ImageLoop(int num, int minRange, int maxRange)
    {
        for (int i = minRange; i < maxRange; i++)
        {
            snippetsBg[num].GetComponent <Image>().sprite = snippets[i];
            if (i == maxRange -1)
                    i = minRange-1;
            await Task.Delay(3000);
        }
    }

    private void Update()
    {
        Debug.Log(video);


        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            pressedBtnA += 1;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            if (pressedBtnA >= 5)
            {
                SecretMenu();
            }
            else
            {
                pressedBtnA = 0;
            }
        }

    }

    public void SecretMenu()
    {
        if (playerMenu.activeSelf == true)
        {
            //open secret menu
            playerMenu.SetActive(false);
            secretMenu.SetActive(true);

            //check dictionaries to see which settings are enabled/disabled

            //set checkboxes based on enabled/disabled settings

        }
        else
        {
            playerMenu.SetActive(true);
            secretMenu.SetActive(false);

            //update local param on settings that are enabled disabled
            scenariosAvailable["ScenarioA"] = CheckboxA.isChecked;
            scenariosAvailable["ScenarioB"] = CheckboxB.isChecked;
            scenariosAvailable["ScenarioC"] = CheckboxC.isChecked;
            scenariosAvailable["ScenarioD"] = CheckboxD.isChecked;
            
            //enable/disable scenarios in the scenario menu
            scenarioAPanel.SetActive(scenariosAvailable["ScenarioA"]);
            scenarioBPanel.SetActive(scenariosAvailable["ScenarioB"]);
            scenarioCPanel.SetActive(scenariosAvailable["ScenarioC"]);
            scenarioDPanel.SetActive(scenariosAvailable["ScenarioD"]);

            //save settings to playerprefs
            //including settingsToggled Dictionary
            //reset values?
        }
    }

    public void ToggleSurvey(RawImage checkboxColor)
    {
        enableSurvey = !enableSurvey;
        if (enableSurvey) checkboxColor.color = new Color(0, 255, 0);
        else checkboxColor.color = new Color(255, 255, 255);
    }
    public void ToggleSceneRandomizer(RawImage checkboxColor)
    {
        enableSceneRandomizer = !enableSceneRandomizer;
        if (enableSceneRandomizer) checkboxColor.color = new Color(0, 255, 0);
        else checkboxColor.color = new Color(255, 255, 255);
    }

    public void Toggle1Past1Present(RawImage checkboxColor)
    {
        //toggle 1past1present checkbox
        if(settingsToggled["1Past1Present"])
        {
            //uncheck button
            checkboxColor.color = new Color(255, 255, 255);
            settingsToggled["1Past1Present"] = false;
        } else
        {
            //check button
            checkboxColor.color = new Color(0, 255, 0);
            settingsToggled["1Past1Present"] = true;
        }
    }

    public void checkScenarioButtonA()
    {
        checkScenarioButton(scenarioCheckboxA, "ScenarioA", scenarioCheckboxB, "ScenarioB", scenarioButtonB);
    }

    void checkScenarioButton(GameObject checkbox, string scenarioName, GameObject otherCheckbox, string otherScenarioName, Button otherScenarioButton)
    {
        CheckboxScript checkboxScript = checkbox.GetComponent<CheckboxScript>();
        checkboxScript.ChangeColor();
        scenariosSelected[scenarioName] = checkboxScript.isChecked;

        if (settingsToggled["1Past1Present"])
        {
            //disable or enable the other scenario button
            CheckboxScript otherCheckboxScript = otherCheckbox.GetComponent<CheckboxScript>();
            Button otherCheckboxButton = otherCheckbox.GetComponent<Button>();

            otherCheckboxScript.ChangeColorDisabledEnabled();
            otherCheckboxButton.enabled = !otherCheckboxButton.enabled;
            otherScenarioButton.enabled = !otherScenarioButton.enabled;

            otherCheckboxScript.isChecked = false;
            scenariosSelected[otherScenarioName] = false;
        }
    }


    public void checkScenarioButtonB()
    {
        checkScenarioButton(scenarioCheckboxB, "ScenarioB", scenarioCheckboxA, "ScenarioA", scenarioButtonA);
    }

    void checkScenarioButtonC()
    {
        
    }

    void checkScenarioButtonD()
    {
        
    }

    void enableScenarioButtonA()
    {
        
    }

    void enableScenarioButtonB()
    {
        
    }

    void enableScenarioButtonC()
    {
        
    }

    void enableScenarioButtonD()
    {
        
    }
}
