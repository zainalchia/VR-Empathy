using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugTextTest : MonoBehaviour
{
    private TMP_Text debugText;
    [SerializeField] private GameObject[] gameObjectPosition;

    // Start is called before the first frame update
    void Start()
    {
        debugText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjectPosition != null)
        {
            for (int i = 0; i < gameObjectPosition.Length; i++)
            {
                if (i == 0)
                    debugText.text = gameObjectPosition[i].transform.position.ToString();
                else
                    debugText.text += ", " + gameObjectPosition[i].transform.position.ToString();
            }            
        }
    }
}
