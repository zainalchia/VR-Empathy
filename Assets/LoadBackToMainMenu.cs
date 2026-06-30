using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBackToMainMenu : MonoBehaviour
{
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            ReloadBackToMainMenu();
        }
    }

    public void ReloadBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
