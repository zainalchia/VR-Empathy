using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction;

public class GameManager : MonoBehaviour
{
    #region Singleton Stuff
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }
    #endregion

    // OVR PLAYER
    public GameObject ovrCamRig;
    public GameObject middleEyeAnchor;
    public GrabInteractor[] grabInteractors;

    // IMPORTANT SCENE GAMEOBJECTS
    public GameObject glasses;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
