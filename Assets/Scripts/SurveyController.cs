using System;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurveyController : MonoBehaviour
{
    private enum SurveyQnType { mcq, rating }

    [Serializable]
    private class SurveyQn
    {        
        public string question;
        public SurveyQnType surveyQnType;

        [Header("MCQ")]
        public string[] choices;

        [Header("Rating")]
        public string lowRatingCriteria;
        public string highRatingCriteria;
        public int noOfRatings = 5;
    }

    [Serializable]
    private class SurveyAns
    {
        public string timestamp;
        public int age;
        public string gender;
        public string[] answers;
    }

    [SerializeField] private SurveyQn[] surveyQns;
    private SurveyAns surveyAns = new SurveyAns();
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private GameObject mcqGO;
    [SerializeField] private GameObject choice1GO;
    [SerializeField] private GameObject ratingGO;
    [SerializeField] private TextMeshProUGUI lowRatingText;
    [SerializeField] private TextMeshProUGUI highRatingText;
    [SerializeField] private GameObject rating1GO;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject prevButton;
    [SerializeField] private GameObject submitButton;
    [SerializeField] private NumberPadScript numPadScript;
    private TextAsset csvFile;
    private string[] csvInputStrings;

    private int currentQs = 0;

    public void UpdateAge(int newAge)
    {
        surveyAns.age = newAge;
    }

    private void LoadDataFromCSV(string filename)
    {
        try
        {
            string fileText = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(Application.persistentDataPath + "/" + filename));
            string[] fileTextSplit = fileText.Split(new string[] { "\n" }, System.StringSplitOptions.None);
            int tableSize = fileTextSplit.Length;
            csvInputStrings = new string[fileTextSplit.Length];

            for (int i = 0; i < tableSize; i++)
            {
                csvInputStrings[i] = fileTextSplit[i];
            }

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
            string[] parts = csvInputStrings[0].Split(';');

            int smallestNum = 16;
            int biggestNum = 28;

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

            numPadScript.UpdateAgeLimits(smallestNum, biggestNum);
        }
        catch (Exception e)
        {
            Debug.Log("failed to load age from CSV : " + e.ToString());
        }
    }

    private void LoadSurveyQuestions()
    {
        // grab csv from streaming assets
        LoadDataFromCSV("surveyquestions.csv");
        LoadAgeFromCSV();

        surveyQns = new SurveyQn[csvInputStrings.Length - 1];

        //skip the headers in the CSV file        
        // question, question type, choices
        // question, question type, low rating criteria, high rating criteria, no of ratings
        for (int i = 1; i < csvInputStrings.Length; i++)
        {
            string line = csvInputStrings[i].Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(';');
            
            surveyQns[i - 1] = new SurveyQn();
            surveyQns[i - 1].question = parts[0];

            if (System.Enum.TryParse(parts[1].Trim(), true, out SurveyQnType qnType)) 
            {
                surveyQns[i - 1].surveyQnType = qnType;
            }
            else
            {
                Debug.Log("qn type not valid");
                continue;
            }

            switch (surveyQns[i - 1].surveyQnType)
            {
                case SurveyQnType.mcq:

                    // to populate the choices mcqs
                    surveyQns[i - 1].choices = new string[parts.Length - 2];
                    for (int j = 2; j < parts.Length; j++)
                    {
                        surveyQns[i - 1].choices[j - 2] = parts[j];
                    }
                    break;

                case SurveyQnType.rating:
                    
                    surveyQns[i - 1].lowRatingCriteria = parts[2];
                    surveyQns[i - 1].highRatingCriteria = parts[3];
                    
                    if (int.TryParse(parts[4], out int noOfRatingsInt))
                    {
                        surveyQns[i - 1].noOfRatings = noOfRatingsInt;
                    }
                    else
                    {
                        Debug.Log("no of ratings not valid");
                        continue;
                    }
                    break;
            }
        }
    }

    private void PopulateSurveyPage(int qsNumber)
    {
        // change text to show question
        questionText.text = (qsNumber + 1).ToString() + ". " + surveyQns[qsNumber].question;

        // show mcq or true false
        ClearMCQAndRepopulate(qsNumber);

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

    private void ClearMCQAndRepopulate(int qsNumber)
    {
        // destroy all generated mcq from previous questions, to not mess with newly generated mcq. but keep 1st one cause that is the one being duplicated to form the others
        for (int i = 1; i < mcqGO.transform.childCount; i++)
        {
            Destroy(mcqGO.transform.GetChild(i).gameObject);
        }

        // destroy all generated ratings from previous questions, to not mess with newly generated ratings. but keep 1st one cause that is the one being duplicated to form the others
        // skip [0] because it's the low criteria text, skip [1] because it's the first checkbox being used to duplicate. skip final one cause it's the high criteria text
        for (int i = 2; i < ratingGO.transform.childCount - 1; i++)
        {
            Destroy(ratingGO.transform.GetChild(i).gameObject);
        }

        mcqGO.SetActive(false);
        ratingGO.SetActive(false);

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

                        // if this mcq has been selected, make the checkbox black instead of white
                        if (surveyAns.answers[qsNumber] == surveyQns[qsNumber].choices[0])
                            choice1GO.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
                        else
                            choice1GO.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;

                        // to clone 1st mcq choice object and change the text to match subsequent data
                        if (surveyQns[qsNumber].choices.Length > 1)
                        {
                            for (int i = 1; i < surveyQns[qsNumber].choices.Length; i++)
                            {
                                GameObject newChoice = Instantiate(choice1GO, mcqGO.transform);

                                newChoice.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = surveyQns[qsNumber].choices[i];

                                // if this mcq has been selected, make the checkbox black instead of white
                                if (surveyAns.answers[qsNumber] == surveyQns[qsNumber].choices[i])
                                    newChoice.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
                                else
                                    newChoice.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
                            }
                        }
                    }
                }
                break;
            case SurveyQnType.rating:
                ratingGO.SetActive(true);

                lowRatingText.text = surveyQns[qsNumber].lowRatingCriteria;
                highRatingText.text = surveyQns[qsNumber].highRatingCriteria;

                if (surveyQns[qsNumber].noOfRatings > 1)
                {
                    // change 1st rating choice to match the one from data
                    rating1GO.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "1";

                    // if this mcq has been selected, make the checkbox black instead of white
                    if (surveyAns.answers[qsNumber] == "1")
                        rating1GO.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
                    else
                        rating1GO.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;


                    for (int i = 1; i < surveyQns[qsNumber].noOfRatings; i++)
                    {
                        GameObject newChoice = Instantiate(rating1GO, ratingGO.transform);

                        newChoice.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();

                        // if this mcq has been selected, make the checkbox black instead of white
                        if (surveyAns.answers[qsNumber] == (i + 1).ToString())
                            newChoice.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
                        else
                            newChoice.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
                    }
                }

                highRatingText.gameObject.transform.parent.SetAsLastSibling(); // to make the high rating text appear after the checkboxes

                break;
        }
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
        // used for testing purpose. put everything into one line and output to screen
        surveyAns.timestamp = DateTime.Now.ToString();
        switch (MainMenuManager.isGenderMale)
        {
            case true:
                surveyAns.gender = "Male";
                break;
            case false:
                surveyAns.gender = "Female";
                break;
            default:
                surveyAns.gender = "Others";
                break;
        }
        string outputString = surveyAns.timestamp + "," + surveyAns.age + ',' + surveyAns.gender + ',';

        foreach (string level in MainMenuManager.levelsPlayed)
        {
            switch (level)
            {
                case "PastNegativeBathroom":
                    outputString += " Past Negative";
                    break;
                case "PastPositiveBathroom":
                    outputString += " Past Positive";
                    break;
                case "PresentBadBathroom":
                    outputString += " Present Negative";
                    break;
                case "PresentGoodBathroom":
                    outputString += " Present Positive";
                    break;
            }
        }

        foreach (string answer in surveyAns.answers)
        {
            outputString += "," + answer;
        }

        questionText.text = outputString;

        // put everything into one line and append csv
        AppendCSV(outputString);

        LoadThanksForPlaying();
    }

    private void LoadThanksForPlaying()
    {
        SceneManager.LoadScene("ThanksForPlaying");
    }

    private void AppendCSV(string textToWrite)
    {
        try
        {
            string path = Application.persistentDataPath + "/saved_data.csv";

            // check if file exists
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Timestamp,Age,Gender,Scenarios,Results");
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("\n" + textToWrite);
            }
        }
        catch (Exception e)
        {
            Debug.Log("no file found at " + Application.persistentDataPath);
        }
    }

    public void SelectAnswer(TextMeshProUGUI textObj)
    {
        surveyAns.answers[currentQs] = textObj.text;
        PopulateSurveyPage(currentQs);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadSurveyQuestions();

        // declare answers array
        surveyAns.answers = new string[surveyQns.Length];
        
        PopulateSurveyPage(currentQs);
    }

}
