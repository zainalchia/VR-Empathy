using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlertTextController : MonoBehaviour
{
    #region  Singleton stuff
    public static AlertTextController instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion

    bool alertTextActive = false;
    float alertTextTimer = 0;
    [SerializeField] float alertTextTime = 1;
    [SerializeField] Animator anim;
    [SerializeField] TextMeshProUGUI textMesh;
    Color initialColor = Color.white;

    bool alertAppended = false;

    public void ShowAlert(string textToShow)
    {
        alertAppended = false;
        SetInactive();
        gameObject.SetActive(true);
        textMesh.text = textToShow;
        textMesh.color = initialColor;
    }
    public void ShowAlert(string textToShow, float length)
    {        
        ShowAlert(textToShow);
        alertTextTime = length;
        alertTextActive = true;
        alertTextTimer = 0;
    }
    public void ShowAlert(string textToShow, Color color)
    {
        ShowAlert(textToShow);
        textMesh.color = color;
    }
    public void ShowAlert(string textToShow, float length, Color color)
    {        
        ShowAlert(textToShow, length);
        textMesh.color = color;
    }

    public void HideAlert()
    {
        if (gameObject.activeInHierarchy)        
            anim.SetTrigger("disappear");        
    }

    public void SetInactive()
    {
        alertTextActive = false;
        alertTextTimer = 0;
        gameObject.SetActive(false);

        alertAppended = false;
    }

    public void AppendAlert(string additionalText)
    {
        if (!alertAppended)
        {
            textMesh.text += "\n\n" + additionalText;
            alertAppended = true;
        }
    }

    public bool GetAlertTextActive()
    {
        return alertTextActive;
    }
    public bool GetAlertAppended()
    {
        return alertAppended;
    }

    // Start is called before the first frame update
    void Start()
    {
        //initialColor = textMesh.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (alertTextActive)
        {            
            alertTextTimer += Time.deltaTime;
            if (alertTextTimer > alertTextTime)
                HideAlert();
        }
    }
}
