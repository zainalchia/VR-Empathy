using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class PlayerCamera : MonoBehaviour
{
    #region Singleton
    public static PlayerCamera instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }
    #endregion
    [SerializeField] GameObject CenterEyeAnchor;
    public void RecenterPlayer()
    {
        CenterEyeAnchor.transform.localPosition = new Vector3(0,CenterEyeAnchor.transform.localPosition.y,0);
        Debug.Log("Recenter Called");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
