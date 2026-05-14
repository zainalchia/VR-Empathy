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
    [SerializeField]
    GameObject scenarioScreen, genderScreen, videoScreen, proceedButton;
    [SerializeField]
    VideoClip[] videos;

    [SerializeField]
    Material mainMenuSkybox;

    public static string pastLevelSelected = null;
    public static string presentLevelSelected = null;
    public static int ageInput;

    [SerializeField] Sprite[] snippets;
    [SerializeField] Image[] snippetsBg;
    [SerializeField] NumberPadScript numberPadScript;
    int minRange, maxRange;

    [SerializeField] private int smallestNum;
    [SerializeField] private int biggestNum;
    private bool genderHasBeenSelected = false;
    private int intNum;
    private string csvInputString;

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

        LoadAgeFromCSV();
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
        if (pastLevelSelected == null)
            presentLevelSelected = levelname;
        else
            presentLevelSelected = null;
    }

    public void ToggleOtherScenario(Button button)
    {
        button.enabled = !button.enabled;
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
        if (numberPadScript.StringToInt() > biggestNum || numberPadScript.StringToInt() < smallestNum) return;

        if (genderHasBeenSelected == false) return;

        scenarioScreen.SetActive(true);
        genderScreen.SetActive(false);

        ageInput = numberPadScript.StringToInt();
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

    private void LoadDataFromCSV(string filename)
    {
        try
        {
            string fileText = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(Application.persistentDataPath + "/" + filename));
            string[] fileTextSplit = fileText.Split(new string[] { "\n" }, System.StringSplitOptions.None);
            int tableSize = fileTextSplit.Length;

            csvInputString = fileTextSplit[0];

        }
        catch (Exception e)
        {
            Debug.Log("no file found at " + Application.persistentDataPath);
        }
    }

    private void LoadAgeFromCSV()
    {
        try
        {
            // grab csv from streaming assets
            LoadDataFromCSV("surveyquestions.csv");

            string[] parts = csvInputString.Split(',');

            if (int.TryParse(parts[0], out int lowerLimit))
            {
                smallestNum = lowerLimit;
            }
            else
            {
                Debug.Log("lower limit not valid");                
            }

            if (int.TryParse(parts[1], out int upperLimit))
            {
                biggestNum = upperLimit;
            }
            else
            {
                Debug.Log("upper limit not valid");                
            }
        }
        catch (Exception e)
        {
            Debug.Log("failed to load age from CSV : " + e.ToString());
        }
        
    }

    private void Update()
    {
        Debug.Log(video);
    }
}
