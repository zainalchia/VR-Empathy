using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenuManager : MonoBehaviour
{
    public static bool isGenderMale = false; //true = male, false = female
    public static bool videoOrMenu = false; // false = menu, true = video
    public static VideoToPlay video = VideoToPlay.BeforePresentBad;
    [SerializeField]
    GameObject scenarioScreen, genderScreen, videoScreen, proceedButton;
    [SerializeField]
    VideoClip[] videos;

    [SerializeField]
    Material mainMenuSkybox;

    string levelSelected;

    [SerializeField] Sprite[] snippets;
    [SerializeField] Image[] snippetsBg;
    int minRange, maxRange;

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
        SceneManager.LoadScene(levelSelected);
    }

    public void SelectGender(bool isMale)
    {
        isGenderMale = isMale;
        genderScreen.SetActive(false);
        videoScreen.SetActive(true);
        toVideoScreen();
    }

    public void SelectLevel(string levelname)
    {
        levelSelected = levelname;
    }

    public void toGenderScreen()
    {
        scenarioScreen.SetActive(false);

        // to temporarily disable gender select and force select female for demo
        //genderScreen.SetActive(true);
        SelectGender(false);
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

    private void Update()
    {
        Debug.Log(video);
    }
}
