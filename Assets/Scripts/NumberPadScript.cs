using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberPadScript : MonoBehaviour
{
    private string num;
    string newNum;
    private bool errorMsgIsShowing;
    [SerializeField] private TextMeshProUGUI errorText;

    [SerializeField] private int biggestNum;
    [SerializeField] private int smallestNum;
    [SerializeField] private GameObject quizScreen;
    [SerializeField] private GameObject ageScreen;

    public void NumberAdd(int number)
    {
        if (num.Length > 3) return;

        num += number.ToString();
    }

    public void NumberSubtract()
    {
        newNum = "";
        for (int i = 0; i < num.Length - 1; i++) {
            newNum += num[i];
        }
        num = newNum;
    }

    public void UpdateNumberPadScreen(GameObject numShown)
    {
        numShown.GetComponent<TextMeshProUGUI>().text = num;
    }

    public int StringToInt()
    {
        int intNum = -1;

        if(num != "")
            intNum = Convert.ToInt32(num);

        return intNum;
    }

    public void CheckAgeRange()
    {
        if (StringToInt() > biggestNum || StringToInt() < smallestNum || StringToInt() == -1)
        {

            if (errorMsgIsShowing)
            {
                StopAllCoroutines();
            }

            StartCoroutine(ErrorTextShown("Age is invalid!"));
            return;
        }
        else
        {
            quizScreen.SetActive(true);
            ageScreen.SetActive(false);
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
}
