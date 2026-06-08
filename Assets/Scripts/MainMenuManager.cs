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
    [SerializeField]
    GameObject startScreen;

    [Header("SecretMenuCheckboxes")]
    [SerializeField]
    CheckboxScript CheckboxA;
    [SerializeField]
    CheckboxScript CheckboxB;
    [SerializeField]
    CheckboxScript CheckboxC;
    [SerializeField]
    CheckboxScript CheckboxD;
    [SerializeField]
    RawImage surveyCheckbox,randomiseCheckbox,pastPresentCheckbox;


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

    [Header("First Scene Name in Scenario")]
    [SerializeField]
    string FirstScenarioAName;
    [SerializeField]
    string FirstScenarioBName;
    [SerializeField]
    string FirstScenarioCName;
    [SerializeField]
    string FirstScenarioDName;

    [Header("Last Scene Name in Scenario")]
    [SerializeField]
    string LastScenarioAName;
    [SerializeField]
    string LastScenarioBName;
    [SerializeField]
    string LastScenarioCName;
    [SerializeField]
    string LastScenarioDName;

    public static Queue<string> scenariosQueued = new Queue<string>();

    [Header("Others")]
    [SerializeField]
    TMP_Text debugText;
    [SerializeField]
    VideoClip[] videos;

    [SerializeField]
    Material mainMenuSkybox;

    private bool atStartScreen = false;


    //dictonaries to keep tabs on the settings selected
    //dictionary for scenarios enabled
    public static Dictionary<string, bool> scenariosAvailable = new Dictionary<string, bool>();
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
    private bool enableSceneRandomizer = false;

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
        
        //initialise with default
        scenariosAvailable.Add("ScenarioA",true);
        scenariosAvailable.Add("ScenarioB",true);
        scenariosAvailable.Add("ScenarioC",true);
        scenariosAvailable.Add("ScenarioD",true);

        settingsToggled.Add("1Past1Present", true);

        //retrieve settings from playerprefs and give parameters their values
        if(PlayerPrefs.GetString("ScenarioA", "NoValue") == "False")
        {
            scenariosAvailable["ScenarioA"] = false;
        }
        if(PlayerPrefs.GetString("ScenarioB", "NoValue") == "False")
        {
            scenariosAvailable["ScenarioB"] = false;
        }
        if(PlayerPrefs.GetString("ScenarioC", "NoValue") == "False")
        {
            scenariosAvailable["ScenarioC"] = false;
        }
        if(PlayerPrefs.GetString("ScenarioD", "NoValue") == "False")
        {
            scenariosAvailable["ScenarioD"] = false;
        }

        if(PlayerPrefs.GetString("1Past1Present", "NoValue") == "False")
        {
            settingsToggled["1Past1Present"] = false;
        }
        if(PlayerPrefs.GetString("Randomise", "NoValue") == "True")
        {
            enableSceneRandomizer = true;
        }
        if(PlayerPrefs.GetString("SurveyEnabled", "NoValue") == "False")
        {
            enableSurvey = false;
        }

        //printDebug(scenariosAvailable["ScenarioA"].ToString());

/*
        bool result;

        if (bool.TryParse(PlayerPrefs.GetString("1Past1Present"), out result))
        {
            settingsToggled["1Past1Present"] = result;
        }

        if (bool.TryParse(PlayerPrefs.GetString("Randomise"), out result))
        {
            enableSceneRandomizer = result;
        }

        if (bool.TryParse(PlayerPrefs.GetString("Randomise"), out result))
        {
            enableSurvey = result;
        }


        //with retrived data, update UI
        if(settingsToggled["1Past1Present"])
            pastPresentCheckbox.color = new Color(0,255,0);
        else
            pastPresentCheckbox.color = new Color(255,255,255);

        if(enableSceneRandomizer)
            randomiseCheckbox.color = new Color(0,255,0);
        else
            randomiseCheckbox.color = new Color(255,255,255);

        if(enableSurvey)
            surveyCheckbox.color = new Color(0,255,0);
        else
            surveyCheckbox.color = new Color(255,255,255);
*/
        

        UpdateScenarioMenuScreen();

        //initialise scenariosSelected dictionary
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
        string LevelName = "";
        //remove the next scenario in the queue and get their scene name. 
        switch (scenariosQueued.Dequeue())
        {
            case "ScenarioA":
                LevelName = FirstScenarioAName;
                break;
            case "ScenarioB":
                LevelName = FirstScenarioBName;
                break;
            case "ScenarioC":
                LevelName = FirstScenarioCName;
                break;
            case "ScenarioD":
                LevelName = FirstScenarioDName;
                break;
        }
        SceneManager.LoadScene(LevelName);
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
            //if randomising scenario, skip scenario selection and go straight to start screen.
            queueScenarios();
            GoToStartScreen();
            //printDebug();
        }

        //ageInput = numberPadScript.StringToInt();
    }

/*
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
    }*/

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

        //stop you from triggering secret menu at the start screen

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            pressedBtnA += 1;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            if (pressedBtnA >= 5 && !atStartScreen)
            {
                SecretMenu();
            }
            else
            {
                pressedBtnA = 0;
            }
        }

    }

    [ContextMenu("SecretMenu")] 
    public void SecretMenu()
    {
        if (playerMenu.activeSelf == true)
        {
            //open secret menu
            playerMenu.SetActive(false);
            startScreen.SetActive(false);
            secretMenu.SetActive(true);

            // check dictionaries to see which settings are enabled/disabled
            // set checkboxes based on enabled/disabled settings
            StartCoroutine(UpdateSettingsUI());

            /*
            //unsure why but the if comparison below doesnt trigger
            printDebug($"{scenariosAvailable["ScenarioA"]} , {CheckboxA.isChecked}");
            if (scenariosAvailable["ScenarioA"] != CheckboxA.isChecked)
            {
                printDebug("bool check works ");
            } else if (CheckboxA == null)
            {
                printDebug("Checkbox A is null");

            }*/

            
            //printDebug($"{scenariosAvailable["ScenarioA"]} , {CheckboxA.isChecked}, checkboxes executed");


            //scenarioCheckboxA.GetComponent<CheckboxScript>().ChangeColor();

        }
        else
        {
            playerMenu.SetActive(true);
            secretMenu.SetActive(false);
            genderScreen.SetActive(true);
            scenarioScreen.SetActive(false);


            //update local param on settings that are enabled disabled
            scenariosAvailable["ScenarioA"] = CheckboxA.isChecked;
            scenariosAvailable["ScenarioB"] = CheckboxB.isChecked;
            scenariosAvailable["ScenarioC"] = CheckboxC.isChecked;
            scenariosAvailable["ScenarioD"] = CheckboxD.isChecked;
            
            //enable/disable scenarios in the scenario menu
            UpdateScenarioMenuScreen();

            //save settings to playerprefs
            foreach (var scenarios in scenariosAvailable)
            {
                PlayerPrefs.SetString(scenarios.Key,scenarios.Value.ToString());
            }
            //including settingsToggled Dictionary
            PlayerPrefs.SetString("1Past1Present", settingsToggled["1Past1Present"].ToString());
            PlayerPrefs.SetString("Randomise", enableSceneRandomizer.ToString());
            PlayerPrefs.SetString("SurveyEnabled", enableSurvey.ToString());

            //reset values
            resetButton(scenarioCheckboxA, scenarioButtonA, "ScenarioA");
            resetButton(scenarioCheckboxB, scenarioButtonB, "ScenarioB");
            resetButton(scenarioCheckboxC, scenarioButtonC, "ScenarioC");
            resetButton(scenarioCheckboxD, scenarioButtonD, "ScenarioD");

            PlayerPrefs.Save();
        }
    }

    private void UpdateScenarioMenuScreen()
    {
        scenarioAPanel.SetActive(scenariosAvailable["ScenarioA"]);
        scenarioBPanel.SetActive(scenariosAvailable["ScenarioB"]);
        scenarioCPanel.SetActive(scenariosAvailable["ScenarioC"]);
        scenarioDPanel.SetActive(scenariosAvailable["ScenarioD"]);
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

    public void checkScenarioButtonC()
    {
        checkScenarioButton(scenarioCheckboxC, "ScenarioC", scenarioCheckboxD, "ScenarioD", scenarioButtonD);
    }

    public void checkScenarioButtonD()
    {
        checkScenarioButton(scenarioCheckboxD, "ScenarioD", scenarioCheckboxC, "ScenarioC", scenarioButtonC);
    }

    void resetButton(GameObject checkBox, Button scenarioButton, string scenarioName)
    {
        CheckboxScript checkboxScript = checkBox.GetComponent<CheckboxScript>();
        checkboxScript.isChecked = false;
        checkboxScript.isDisabled = false;
        checkboxScript.image.color = new Color(255, 255, 255);

        checkBox.GetComponent<Button>().enabled = true;

        scenarioButton.enabled = true;

        scenariosSelected[scenarioName] = false;
    }

    public void printDebug(string log)
    {
        //check which scenarios are selected
        //debugText.text = $"Scenario A: {scenariosSelected["ScenarioA"]}, Scenario B: {scenariosSelected["ScenarioB"]}, Scenario C: {scenariosSelected["ScenarioC"]}, Scenario D: {scenariosSelected["ScenarioD"]}, ";

        /*
        //check scenarios queued up
        debugText.text = "";
        foreach(var scenario in scenariosQueued)
        {
            debugText.text += scenario;
        }*/

        
        //debugText.text = $"Player Prefs value:{PlayerPrefs.GetString("ScenarioA","NoValue")}, local data value: {scenariosAvailable["ScenarioA"].ToString()}" ;
        debugText.text = log;
    }

    public void queueScenarios ()
    {   
        if(enableSceneRandomizer)
        {
            //parameters randomizer and 1past1present

            //scenarios for randomizer.
            //could randomise from 1 past 1 preset
            //could randomise from all past
            //could randomise from all present
            //no matter when randomising, it will always be 1 past and 1 present or 1 past or 1 present
            string randomPastScenario;
            string randomPresentScenario;
    
            int pastScenarioNumbers = 0;
            int presentScenarioNumbers = 0;

            int randomPastScenarioIndex;
            int randomPresentScenarioIndex;

            List<string> validPastScenarios = new List<string>();
            List<string> validPresentScenarios = new List<string>();

            //randomised pulls from scenarios available and skips the scenario selection screen.
            foreach(var scenario in scenariosAvailable)
            {
                switch (scenario.Key)
                {
                    case "ScenarioA":
                    case "ScenarioB":
                        if (scenario.Value)
                        {
                            validPastScenarios.Add(scenario.Key);
                        }
                        break;
                    case "ScenarioC":
                    case "ScenarioD":
                        if (scenario.Value)
                        {
                            validPresentScenarios.Add(scenario.Key);
                        }
                        break;
                }
            }

            //pick random past scenario
            pastScenarioNumbers = validPastScenarios.Count;

            if(pastScenarioNumbers > 0)
            {
                randomPastScenarioIndex = UnityEngine.Random.Range(0,pastScenarioNumbers);
                //add them to queue
                scenariosQueued.Enqueue(validPastScenarios[randomPastScenarioIndex]);
            }

            //pick random present scenario
            presentScenarioNumbers = validPresentScenarios.Count;
            if(presentScenarioNumbers > 0)
            {
                randomPresentScenarioIndex = UnityEngine.Random.Range(0,presentScenarioNumbers);
                scenariosQueued.Enqueue(validPresentScenarios[randomPresentScenarioIndex]);
            }


        } else
        {
            //handle the non-randomised queuing
            foreach(var scenario in scenariosSelected)
            {
                if (scenario.Value)
                {
                    scenariosQueued.Enqueue(scenario.Key);
                }
            }
        }
    }

    public void GoToStartScreen()
    {

        if(scenariosQueued.Count == 0)
        {
            debugText.text = "No Scenarios Selected";
            return;
        }

        //check which scenarios are selected
        printDebug($"Scenario A: {scenariosSelected["ScenarioA"]}, Scenario B: {scenariosSelected["ScenarioB"]}, Scenario C: {scenariosSelected["ScenarioC"]}, Scenario D: {scenariosSelected["ScenarioD"]}, ");

        
        atStartScreen = true;
        startScreen.SetActive(true);
        playerMenu.SetActive(false);
    }

    IEnumerator UpdateSettingsUI()
    {

        // 2. Pauses execution until the very next frame
        //let the menu be enabled first
        yield return null;
        Debug.Log("One additional frame passed. Done!");
        if (scenariosAvailable["ScenarioA"] != CheckboxA.isChecked)
        {
            CheckboxA.ChangeColor();
        }
        if (scenariosAvailable["ScenarioB"] != CheckboxB.isChecked)
        {
            CheckboxB.ChangeColor();
        }
        if (scenariosAvailable["ScenarioC"] != CheckboxC.isChecked)
        {
            CheckboxC.ChangeColor();
        }
        if (scenariosAvailable["ScenarioD"] != CheckboxD.isChecked)
        {
            CheckboxD.ChangeColor();
        }

        if (enableSceneRandomizer)
        {
            randomiseCheckbox.color = new Color(0,255,0);
        } else
        {
            randomiseCheckbox.color = new Color(255,255,255);
        }
        if (enableSurvey)
        {
            surveyCheckbox.color = new Color(0,255,0);
        } else
        {
            surveyCheckbox.color = new Color(255,255,255);
        }
        if (settingsToggled["1Past1Present"])
        {
            pastPresentCheckbox.color = new Color(0,255,0);
        } else
        {
            pastPresentCheckbox.color = new Color(255,255,255);
        }
    }
}
