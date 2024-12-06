using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static bool isGenderMale = true; //true = male, false = female
    [SerializeField]
    GameObject scenarioScreen, genderScreen;
    string levelSelected;

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
}
