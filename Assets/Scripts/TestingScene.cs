using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestingScene : MonoBehaviour
{
    [SerializeField] TextMeshPro sceneText;
    bool buttonPressed = false;
    // use for testing features

    SceneToPlay sceneToPlay = SceneToPlay.SCENE1;
    enum SceneToPlay
    {
        SCENE1,
        SCENE2,
        SCENE3
    }

    void Scene1()
    {
        sceneText.text = "Put on glasses";
        GameManager.instance.toPutGlassesOn = true;
    }

    void Scene2()
    {
        sceneText.text = "Eat medication";
        GameManager.instance.toEatMedication = true;
    }

    void Scene3()
    {
        sceneText.text = "Take off glasses";
        GameManager.instance.toTakeGlassesOff = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene1();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneToPlay == SceneToPlay.SCENE1 && OVRInput.GetDown(OVRInput.Button.Three) && !buttonPressed)
        {
            buttonPressed = true;
            Scene2();
            sceneToPlay = SceneToPlay.SCENE2;
        }
        if (sceneToPlay == SceneToPlay.SCENE2 && OVRInput.GetDown(OVRInput.Button.Three) && !buttonPressed)
        {
            buttonPressed = true;
            Scene3();
            sceneToPlay = SceneToPlay.SCENE3;
        }

        if (OVRInput.GetUp(OVRInput.Button.Three) && buttonPressed)
        {
            buttonPressed = false;
        }
    }
}
