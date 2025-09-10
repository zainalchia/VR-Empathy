using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WhiteFade : MonoBehaviour
{
    Color TempFadeColor;
    bool DoFadeIn,DoFadeOut;
    // Start is called before the first frame update
    void Start()
    {
        TempFadeColor = Color.white;
        TempFadeColor.a = 0;
        DoFadeIn = DoFadeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoFadeOut)
        {
            TempFadeColor.a = Mathf.Lerp(TempFadeColor.a, 1, 1f * Time.deltaTime);
            if (TempFadeColor.a >= 1)
                DoFadeOut = false;  
        }
        if (DoFadeIn)
        {
            TempFadeColor.a = Mathf.Lerp(TempFadeColor.a, 0, 1f * Time.deltaTime);
            if (TempFadeColor.a <= 0)
                DoFadeIn = false;
        }
            Debug.Log(TempFadeColor.a);
            this.GetComponent<Image>().color = TempFadeColor;
    }
    public void FadeOut()
    {
        DoFadeOut = true;
        DoFadeIn = false;
    }
    public void FadeIn()
    {
        DoFadeIn = true;
        DoFadeOut= false;
    }
}
