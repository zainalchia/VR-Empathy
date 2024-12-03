using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static bool isGenderMale = false; //true = male, false = female
    [SerializeField]
    Image genderImage;
    [SerializeField]
    TextMeshProUGUI genderText;

    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public void ToggleGender()
    {
        if (isGenderMale)
        {
            isGenderMale = false;
            genderImage.color = new Color32(255, 20, 147, 100);
            genderText.text = "Female";
        }
        else
        {
            isGenderMale = true;
            genderImage.color = Color.blue;
            genderText.text = "Male";
        }
    }
}
