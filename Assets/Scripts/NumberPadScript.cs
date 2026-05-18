using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberPadScript : MonoBehaviour
{
    public string num;
    string newNum;

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
}
