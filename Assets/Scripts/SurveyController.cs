using System;
using System.IO;
using UnityEngine;
using TMPro;

public class SurveyController : MonoBehaviour
{
    private enum SurveyQnType { mcq, trueFalse }

    [Serializable]
    private class SurveyQn
    {
        public string question;
        public SurveyQnType surveyQnType;
        public string[] choices;
    }
    [SerializeField] private SurveyQn[] surveyQns;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private GameObject mcqGO;
    [SerializeField] private GameObject trueFalseGO;
    [SerializeField] private GameObject choice1GO;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject prevButton;
    [SerializeField] private GameObject submitButton;
    private int currentQs = 0;

    private void GrabDataFromCSV()
    {
        // todo?
    }

    private void PopulateSurveyPage(int qsNumber)
    {
        // change text to show question
        questionText.text = (qsNumber + 1).ToString() + ". " + surveyQns[qsNumber].question;

        // show mcq or true false
        mcqGO.SetActive(false);
        trueFalseGO.SetActive(false);

        switch (surveyQns[qsNumber].surveyQnType)
        {
            case SurveyQnType.mcq:
                mcqGO.SetActive(true);

                // change 1st mcq choice text to match the one from data
                if (choice1GO.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>())
                {
                    if (surveyQns[qsNumber].choices.Length > 0)
                    {
                        choice1GO.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = surveyQns[qsNumber].choices[0];

                        // to clone 1st mcq choice object and change the text to match subsequent data
                        if (surveyQns[qsNumber].choices.Length > 1)
                        {
                            for (int i = 1; i < surveyQns[qsNumber].choices.Length; i++)
                            {
                                GameObject newChoice = Instantiate(choice1GO, mcqGO.transform);

                                newChoice.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = surveyQns[qsNumber].choices[i];
                            }
                        }
                    }
                }
                break;

            case SurveyQnType.trueFalse:
                trueFalseGO.SetActive(true);
                break;
        }

        prevButton.SetActive(false);              
        nextButton.SetActive(false); 
        submitButton.SetActive(false); 

        // if prev qs exists, show "prev" button
        if (qsNumber > 0 && surveyQns[qsNumber - 1] != null)        
            prevButton.SetActive(true);              

        // if next qs exists, show "next" button, else show "submit" button
        if (qsNumber < surveyQns.Length - 1 && surveyQns[qsNumber + 1] != null)        
            nextButton.SetActive(true); 
        else
            submitButton.SetActive(true); 
    }

    public void PressNext()
    {
        currentQs++;
        PopulateSurveyPage(currentQs);
    }

    public void PressPrev()
    {
        currentQs--;
        PopulateSurveyPage(currentQs);
    }

    public void PressSubmit()
    {
        
    }

    private void AppendCSV()
    {
        try
        {
            string path = Application.persistentDataPath + "/saved_data.csv";

            // check if file exists
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Timestamp,Position\n");
                Debug.Log("yoohoo " + path);
            }

            // StreamWriter append set to true
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("test");
                Debug.Log(path);
            }

            Debug.Log("blegh2");
            /*
            string fileText = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(Application.persistentDataPath + filename));
            string[] fileTextSplit = fileText.Split(new string[] { "\n" }, System.StringSplitOptions.None);
            int tableSize = fileTextSplit.Length;

            for (int i = 0; i < tableSize; i++)
            {
                //narration[i] = fileTextSplit[i];
            } */
        }
        catch (Exception e)
        {
            Debug.Log("no file found at " + Application.persistentDataPath);
        }
    }

    public void SelectLevel(string levelname)
    {
        //levelSelected = levelname;
    }

    public void toGenderScreen()
    {
        //scenarioScreen.SetActive(false);
        //genderScreen.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        //AppendCSV();
        PopulateSurveyPage(currentQs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
