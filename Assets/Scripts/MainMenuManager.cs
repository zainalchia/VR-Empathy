using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static bool isGenderMale = false; //true = male, false = female
    [SerializeField]
    GameObject scenarioScreen, genderScreen;
    string levelSelected;

    [SerializeField] Sprite[] snippets;
    [SerializeField] Image[] snippetsBg;
    int minRange, maxRange;

    private void Start()
    {
        //ShowSnippetOnHover(0);
    }
    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public void SelectGender(bool isMale)
    {
        isGenderMale = isMale;
        LoadLevel(levelSelected);
    }

    public void SelectLevel(string levelname)
    {
        levelSelected = levelname;
    }

    public void toGenderScreen()
    {
        scenarioScreen.SetActive(false);
        genderScreen.SetActive(true);
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
}
